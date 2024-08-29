using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using GameSystem.DependencySystem.DI;

namespace GameSystem.DependencySystem.ServiceLocator
{
    public class Logger : IServiceLocator
    {
        private bool _isLoggingRequired;
        
        private IServiceLocator _serviceLocator;
        private IMonoBehaviorLocator _monoBehaviorLocator;
        private IInstanceLocator _instanceLocator;
        private IGameObjectLocator _gameObjectLocator;
        private IPrefabLocator _prefabLocator;
        private IConfigLocator _configLocator;

        private Utils.Logger _allServiceLogger;
        private Utils.Logger _newInstanceLogger;
        private readonly string _allServiceLoggerPath;
        private int _currentLogGroupNumber = 0;
        private bool _isNewInstanceLoggerHeaderWrote;
        
        
        public Logger()
        {
#if UNITY_EDITOR
            string[] paths = new[]
            {
                Environment.CurrentDirectory,
                "Assets",
                "Scripts",
                "GameSystem",
                "Logs",
            };

            string path = Path.Combine(paths);
            string allServiceLoggerFileName = "ServiceLocatorContentLogs";
            string newInstanceLoggerFileName = "ServiceLocatorNewInstanceCreatedLogs";

            _allServiceLoggerPath = Path.Combine(path, string.Concat(allServiceLoggerFileName, ".txt"));
            
            CreateLoggers(path, allServiceLoggerFileName, newInstanceLoggerFileName);
#endif
        }

        public void Construct(bool isLoggingRequired,
            IServiceLocator serviceLocator,
            IMonoBehaviorLocator monoBehaviorLocator,
            IInstanceLocator instanceLocator,
            IGameObjectLocator gameObjectLocator,
            IPrefabLocator prefabLocator,
            IConfigLocator configLocator)
        {
            _isLoggingRequired = isLoggingRequired;
            
            _serviceLocator = serviceLocator;
            _monoBehaviorLocator =  monoBehaviorLocator;
            _instanceLocator = instanceLocator; 
            _gameObjectLocator = gameObjectLocator; 
            _prefabLocator = prefabLocator;
            _configLocator = configLocator;
        }
        
        object IServiceLocator.GetService(Type type, DependencyResolvePrinciple resolvePrinciple, string gameObjectName, object injectionObj)
        {
            object service = _serviceLocator.GetService(type, resolvePrinciple, gameObjectName);

#if UNITY_EDITOR
            if (_isLoggingRequired)
            {
                string injectionObjStr = injectionObj is null 
                    ? "Is not specified" 
                    : injectionObj.ToString();
                
                if (resolvePrinciple == DependencyResolvePrinciple.CREATE_NEW_INSTANCE)
                    LogNewInstanceLocator(type, service, injectionObjStr);
                else
                    LogAllLocators(type, resolvePrinciple, injectionObjStr);
            }
#endif

            return service;
        }
        
        private void CreateLoggers(string path, string allServiceLoggerFileName, string newInstanceLoggerFileName)
        {
            _allServiceLogger = new(path, allServiceLoggerFileName);
            _newInstanceLogger = new(path, newInstanceLoggerFileName);
        }

        private void LogNewInstanceLocator(Type type, object service, string injectionObj)
        {
            if (!_isNewInstanceLoggerHeaderWrote)
            {
                _newInstanceLogger.WriteHeader("Type", "New instance", "Who asked for service");
                _isNewInstanceLoggerHeaderWrote = true;
            }
            
            string splitedType = type.ToString().Split('.')[^1];
            _newInstanceLogger.AppendStringsToFile(splitedType, service.ToString(), injectionObj.ToString());
        }

        private void LogAllLocators(Type serviceType, DependencyResolvePrinciple resolveMethod, string injectionObj)
        {
            using var writer = new StreamWriter(File.Open(_allServiceLoggerPath, FileMode.Append));
            {
                writer.WriteLine(new string('_', 121));
                writer.WriteLine($"\n\nLog group number: {_currentLogGroupNumber}");
                writer.WriteLine($"Service that asked for injection: {injectionObj}");
                writer.WriteLine($"Asked Service type: {serviceType}");
                writer.WriteLine($"Resolve method: {resolveMethod}\n");
            }
            writer.Dispose();
            
            LogPassedLocator(FormatInstanceLocator(_monoBehaviorLocator.GetLocatorCopy()),
                "MonoBehavior Locator",
                "Type",
                "MonoBehaviour");
            
            LogPassedLocator(FormatInstanceLocator(_instanceLocator.GetLocatorCopy()),
                "Instances Locator",
                "Type",
                "Instance");
            
            LogPassedLocator(_gameObjectLocator.GetLocatorCopy(),
                "GameObjects ACTIVE Locator",
                "Name",
                "GameObject");
            
            LogPassedLocator(_gameObjectLocator.GetInactiveLocatorCopy(),
                "GameObjects INACTIVE Locator",
                "Name",
                "GameObject");
            
            LogPassedLocator(_prefabLocator.GetLocatorCopy(),
                "Prefabs Locator",
                "Name",
                "GameObject");
            
            LogPassedLocator(_configLocator.GetLocatorCopy(),
                "Configs Locator",
                "Name",
                "ScriptableObject");
            
            _currentLogGroupNumber++;
        }

        private void LogPassedLocator(IDictionary serviceLocator, string locatorName, string firstHeader, string secondHeader)
        {
            int locatorLength = serviceLocator.Count;
            int i = 0;
            
            string[] keys = new string[locatorLength];
            string[] values = new string[locatorLength];
            
            foreach (var iKey in serviceLocator.Keys)
            {
                keys[i] = iKey.ToString();
                values[i] = serviceLocator[iKey].ToString();
                i++;
            }
            
            using var writer = new StreamWriter(File.Open(_allServiceLoggerPath, FileMode.Append));
            {
                writer.WriteLine($">> {locatorName}");
                writer.Dispose();
            }
            
            _allServiceLogger.WriteHeader(firstHeader, secondHeader);
            _allServiceLogger.AppendStringsToFile(keys, values);
        }

        private IDictionary FormatInstanceLocator(IDictionary locator)
        {
            IDictionary newLocator = new Dictionary<string, object>();

            foreach (var iKey in locator.Keys)
            {
                string[] splitedKey = iKey.ToString().Split('.');
                string newKey = splitedKey[^1];

                newLocator[newKey] = locator[iKey];
            }

            return newLocator;
        }
    }
}