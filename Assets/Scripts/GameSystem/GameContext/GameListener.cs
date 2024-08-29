using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace GameSystem.GameContext
{
    public class GameListener : IGameListener, IUnityUpdates,
        IListenerInstallable, IListenerUninstallable
    {
        private List<IGameElement> _gameElements = new();
        private List<IUpdateElement> _updateElements = new();
        private List<IUpdateInPauseElement> _updateInPauseElements = new();
        private List<IFixedUpdateElement> _fixedUpdateElements = new();
        private List<ILateUpdateElement> _lateUpdateElements = new();

        void IGameListener.ReadyGame()
        {
            int index = 0;
            while (true)
            {
                int counter = _gameElements.Count;

                if (!(index < counter))
                    break;

                var element = _gameElements[index];
                
                if (element is IGameReadyElement initElement)
                {
                    initElement.Ready();
                }

                index++;
            }
        }
        
        void IGameListener.StartGame()
        {
            int index = 0;
            while (true)
            {
                int counter = _gameElements.Count;

                if (!(index < counter))
                    break;

                var element = _gameElements[index];
                
                if (element is IGameStartElement initElement)
                {
                    initElement.OnStart();
                }

                index++;
            }
        }
        
        void IGameListener.PauseGame()
        {
            // PrintToConsole.Debug_PrintAllGameElements(_gameElements, _updateElements, _updateInPauseElements, _fixedUpdateElements, _lateUpdateElements);
            
            foreach (var element in _gameElements)
            {
                if (element is IGamePauseElement pauseElement)
                {
                    if (element is Behaviour { isActiveAndEnabled: true })
                        pauseElement.Pause();
                }
            }
        }
        
        void IGameListener.ResumeGame()
        {
            foreach (var element in _gameElements)
            {
                if (element is IGameResumeElement resumeElement)
                {
                    if (element is Behaviour { isActiveAndEnabled: true })
                        resumeElement.Resume();
                }
            }
        }
        
        void IGameListener.FinishGame()
        {
            IGameElement[] copyGameElements = _gameElements.ToArray();

            foreach (var element in copyGameElements)
            {
                if (element is IGameFinishElement finishElement)
                {
                    finishElement.Finish();
                }
            }
        }
        
        void IUnityUpdates.Update(float deltaTime)
        {
            for (int i = 0, count = _updateElements.Count; i < count; i++)
            {
                var element = _updateElements[i];
                
                if (element is Behaviour { isActiveAndEnabled: false })
                    continue;
                
                element.UpdateElement(deltaTime);
            }
        }

        void IUnityUpdates.UpdateInPause(float deltaTime)
        {
            for (int i = 0, count = _updateInPauseElements.Count; i < count; i++)
            {
                var element = _updateInPauseElements[i];
                    
                if (element is Behaviour { isActiveAndEnabled: false })
                    continue;
                
                element.UpdateInPause(deltaTime);
            }
        }
        
        void IUnityUpdates.FixedUpdate(float fixedDeltaTime) 
        {
            for (int i = 0, count = _fixedUpdateElements.Count; i < count; i++)
            {
                var element = _fixedUpdateElements[i];
                
                if (element is Behaviour { isActiveAndEnabled: false })
                    continue;
                
                element.FixedUpdateElement(fixedDeltaTime);
            }
        }

        void IUnityUpdates.LateUpdate(float deltaTime) 
        {
            for (int i = 0, count = _lateUpdateElements.Count; i < count; i++)
            {
                var element = _lateUpdateElements[i];
                
                if (element is Behaviour { isActiveAndEnabled: false })
                    continue;
                
                element.LateUpdateElement(deltaTime);
            }
        }
        
        
        void IListenerInstallable.InstallGameElements(IGameElement element)
        {
            _gameElements.Add(element);
        }

        void IListenerInstallable.InstallUpdateElements(IUpdateElement element)
        {
            _updateElements.Add(element);
        }        
        
        void IListenerInstallable.InstallUpdateInPauseElements(IUpdateInPauseElement element)
        {
            _updateInPauseElements.Add(element);
        }

        void IListenerInstallable.InstallFixedUpdateElements(IFixedUpdateElement element)
        {
             _fixedUpdateElements.Add(element);
        }

        void IListenerInstallable.InstallLateUpdateElements(ILateUpdateElement element)
        {
            _lateUpdateElements.Add(element);
        }
        
        void IListenerUninstallable.UninstallGameElements(IGameElement element)
        {
            _gameElements.Remove(element);
        }

        void IListenerUninstallable.UninstallUpdateElements(IUpdateElement element)
        {
            _updateElements.Remove(element);
        }        
        
        void IListenerUninstallable.UninstallUpdateInPauseElements(IUpdateInPauseElement element)
        {
            _updateInPauseElements.Remove(element);
        }

        void IListenerUninstallable.UninstallFixedUpdateElements(IFixedUpdateElement element)
        {
            _fixedUpdateElements.Remove(element);
        }

        void IListenerUninstallable.UninstallLateUpdateElements(ILateUpdateElement element)
        {
            _lateUpdateElements.Remove(element);
        }
    }
}