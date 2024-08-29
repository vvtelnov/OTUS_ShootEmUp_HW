using System;
using GameSystem.DependencySystem;
using GameSystem.DependencySystem.DI;
using GameSystem.DependencySystem.ServiceLocator;
using GameSystem.DependencySystem.ServiceLocator.StaticServices;
using GameSystem.GameContext;
using Nodes;
using UnityEngine;
using Logger = GameSystem.DependencySystem.ServiceLocator.Logger;

namespace GameSystem
{
    public class GameSystemConstructor
    {
        private readonly DependencySystem.DependencySystem _dependencySystem = new DependencySystem.DependencySystem();
        private readonly DependencyInjector _dependencyInjector = new DependencyInjector();
        private readonly ObjectLocator _serviceLocator = new ObjectLocator();
        private readonly GameListenerRegister _gameListenerRegister = new GameListenerRegister();
        private readonly Logger _logger = new Logger();
        private readonly GameListenerInstaller _listenerInstaller = new GameListenerInstaller();
        private readonly GameListener _gameListener = new GameListener();

        private readonly GameManager.GameManager _gameManager = new GameManager.GameManager();

        private readonly NodesCreator _nodesCreator = new NodesCreator();

        private bool _isLoggingRequired;
        
        public void Construct(bool isLoggingRequired)
        {
            _isLoggingRequired = isLoggingRequired;
        }
        
        internal void InitializeGame()
        {
            ConstructGameSystem();
            RegisterServices();
            var objects = RegisterGameObjects();
            StartInjection(objects);
            InjectInNodes();
        }

        private void ConstructGameSystem()
        {
            _listenerInstaller.Construct(_gameListener, _gameListener);
            _dependencySystem.Construct(_dependencyInjector, _logger, _serviceLocator, _serviceLocator);
            _dependencyInjector.Construct(_dependencySystem, _listenerInstaller);
            _gameListenerRegister.Construct(_listenerInstaller);
            _logger.Construct(_isLoggingRequired, _serviceLocator, _serviceLocator, _serviceLocator, _serviceLocator, _serviceLocator, _serviceLocator);
        }

        private void RegisterServices()
        {
            _serviceLocator.RegisterInstance(_dependencySystem);
            _serviceLocator.RegisterInstance(_dependencyInjector);
            _serviceLocator.RegisterInstance(_serviceLocator);
            _serviceLocator.RegisterInstance(_gameListenerRegister);
            _serviceLocator.RegisterInstance(_listenerInstaller);
            _serviceLocator.RegisterInstance(_logger);
            _serviceLocator.RegisterInstance(_gameListener);
            _serviceLocator.RegisterInstance(_gameManager);
        }

        private GameObject[] RegisterGameObjects()
        {
            GameObject[] rootObjects = _serviceLocator.GetRootObjects();
            
            RegisterPrefabs();
            RegisterConfigs();
            RegisterInactiveGameObjects();
            RegisterRootObjects(rootObjects);

            return rootObjects;
        }
        
        private void StartInjection(GameObject[] rootObjects)
        {
            ((IDependencySystem)_dependencySystem).InjectDependencyInGameObjects(rootObjects);
        }

        private void InjectInNodes()
        {
            ((IDependencyInjector)_dependencyInjector).InjectRecursively(_nodesCreator);
        }
        
        private void RegisterPrefabs()
        {
            GameObject[] prefabs = PrefabLocator.Instance.GetPrefabs();

            foreach (var prefab in prefabs)
            {
                _serviceLocator.RegisterPrefab(prefab.name, prefab);
            }
        }
        
        private void RegisterConfigs()
        {
            ScriptableObject[] configs = ConfigLocator.Instance.GetConfigs();

            foreach (var config in configs)
            {
                _serviceLocator.RegisterConfig(config.name, config);
            }
        }

        private void RegisterInactiveGameObjects()
        {
            GameObject[] objects = InactiveGameObjectLocator.Instance.GetInactiveGameObjects();
            
            foreach (var obj in objects)
            {
                _serviceLocator.RegisterInactiveGameObject(obj.name, obj);
            }
        }

        private void RegisterRootObjects(GameObject[] rootObjects)
        {
            foreach (var rootObject in rootObjects)
            {
                MonoBehaviour[] rootServices = rootObject.GetComponents<MonoBehaviour>();

                foreach (var rootService in rootServices)
                {
                    Type rootServiceType = rootService.GetType();
                    _serviceLocator.RegisterMonoBehavior(rootServiceType, rootService);
                }
            }
        }
    }
}