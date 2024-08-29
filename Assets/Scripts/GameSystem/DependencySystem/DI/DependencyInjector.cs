using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GameSystem.DependencySystem.ServiceLocator;
using GameSystem.GameContext;
using UnityEngine;

namespace GameSystem.DependencySystem.DI
{
    public interface IDependencyInjector
    {
        internal void InjectInSingleService(object service);
        internal void InjectRecursivelyInGameObject(GameObject sceneObject);
        internal void InjectInGameObject(GameObject gameObject);
        internal void InjectRecursively(object component);
    }
    
    // init
    public class DependencyInjector : IDependencyInjector
    {
        private IServiceLocator _serviceLocator;
        private IGameListenerInstaller _listenerInstaller;
        
        private readonly List<object> _alreadyInjected = new List<object>();

        internal void Construct(IServiceLocator serviceLocator, IGameListenerInstaller listenerInstaller)
        {
            _serviceLocator = serviceLocator;
            _listenerInstaller = listenerInstaller;
        }

        void IDependencyInjector.InjectInSingleService(object service)
        {
            if (!IsInjectionNeeded(service))
            {
                throw new Exception($"Service ({service}) passed does not need Injection. Maybe you forgot [InjectionNeeded] attribute?");
            } 
                
            var type = service.GetType();
            
            InjectThroughFields(type, service);
            InjectThroughConstructMethod(type, service);
        }

        void IDependencyInjector.InjectRecursivelyInGameObject(GameObject sceneObject)
        {
            ((IDependencyInjector)this).InjectInGameObject(sceneObject);

            foreach (Transform child in sceneObject.transform)
            {
                ((IDependencyInjector)this).InjectRecursivelyInGameObject(child.gameObject);
            }
        }

        void IDependencyInjector.InjectInGameObject(GameObject sceneObject)
        {
            MonoBehaviour[] components = sceneObject.GetComponents<MonoBehaviour>();
            
            foreach (var component in components)
            {
                if (component is IGameElement gameElement)
                    _listenerInstaller.InstallContext(gameElement);

                ((IDependencyInjector)this).InjectRecursively(component);
            }
        }

        void IDependencyInjector.InjectRecursively(object component)
        {
            _alreadyInjected.Add(component);
            
            if (!IsInjectionNeeded(component))
            {
                return;
            } 
                
            var type = component.GetType();
            
            var fieldsDependencies = InjectThroughFields(type, component);
            var constructDependencies = InjectThroughConstructMethod(type, component);
            var allDependency = constructDependencies.Union(fieldsDependencies)
                .ToList();
            
            foreach (var dependency in allDependency)
            {
                if (_alreadyInjected.Contains(dependency))
                    continue;
                
                ((IDependencyInjector)this).InjectRecursively(dependency);
            }
        }
        
        private bool IsInjectionNeeded(object obj)
        {
            return obj.GetType().IsDefined(typeof(InjectionNeeded));
        } 

        private object[] InjectThroughConstructMethod(Type type, object component)
        {
            var methodsInfo = GetAllMethodsInfo(type);
                
            ParameterInfo[] parametersInfo = new ParameterInfo[] { };
            DependencyResolvePrinciple resolvePrinciple = DependencyResolvePrinciple.DO_NOT_INJECT;
            string gameObjectName = null;
            
            MethodInfo constructMethod = GetConstructMethodInfo(methodsInfo, 
                ref parametersInfo, 
                ref resolvePrinciple,
                ref gameObjectName);

            object[] parameters = new object[parametersInfo.Length];
            
            if (constructMethod is null)
            {
                return parameters;
            }

            for (var i = 0; i < parametersInfo.Length; i++)
            {
                var paramInfo = parametersInfo[i];

                parameters[i] = GetService(paramInfo.ParameterType, resolvePrinciple, gameObjectName, component);
            }

            constructMethod.Invoke(component, parameters);

            return parameters;
        }

        private MethodInfo[] GetAllMethodsInfo(Type type)
        {
            return type.GetMethods(BindingFlags.Public |
                                   BindingFlags.NonPublic | 
                                   BindingFlags.Instance |
                                   BindingFlags.FlattenHierarchy |
                                   BindingFlags.Static);
        }

        private MethodInfo GetConstructMethodInfo(MethodInfo[] methodsInfo, 
            ref ParameterInfo[] parametersInfo,
            ref DependencyResolvePrinciple resolvePrinciple,
            ref string gameObjectName
            )
        {
            foreach (var methodInfo in methodsInfo)
            {
                var attrs = Attribute.GetCustomAttributes(methodInfo);

                foreach (var attr in attrs)
                {
                    if (attr is not InjectAttribute attribute) continue;
                    
                    parametersInfo = methodInfo.GetParameters();
                    resolvePrinciple = attribute.ResolvePrinciple;
                    gameObjectName = attribute.ObjectName;
                    return methodInfo;
                }
            }
            
            return null;
        }
                
        private List<object> InjectThroughFields(Type type, object component)
        {
            List <object> injectFieldValues = new();
            
            var fieldsInfo = GetAllFieldsInfo(type);

            foreach (var fieldInfo in fieldsInfo)
            {
                if (!fieldInfo.IsDefined(typeof(InjectAttribute)))
                {
                    continue;
                }
                
                var attrs = Attribute.GetCustomAttributes(fieldInfo);

                foreach (var attr in attrs)
                {
                    if (attr is not InjectAttribute attribute) continue;
                
                    DependencyResolvePrinciple resolvePrinciple = attribute.ResolvePrinciple;
                    string gameObjectName = attribute.ObjectName;
                    
                    var fieldValue = GetService(fieldInfo.FieldType, resolvePrinciple, gameObjectName, component);
                    
                    injectFieldValues.Add(fieldValue);
                
                    fieldInfo.SetValue(component, fieldValue);
                }
            }

            return injectFieldValues;
        }

        private FieldInfo[] GetAllFieldsInfo(Type type)
        {
            return type.GetFields(BindingFlags.Public |
                                  BindingFlags.NonPublic | 
                                  BindingFlags.Instance |
                                  BindingFlags.FlattenHierarchy |
                                  BindingFlags.Static);
        }

        private object GetService(Type type,
            DependencyResolvePrinciple resolvePrinciple, string gameObjectName, object injectionTarget)
        {
            return _serviceLocator.GetService(type, resolvePrinciple, gameObjectName, injectionTarget);
        }
    }
}