using UnityEngine;

namespace GameSystem
{
    public class GameContextInstaller : MonoBehaviour
    {
        [SerializeField] private GameContext _gameContext;
        
        private void Awake()
        {
            Debug.Log("-----> GameContextInstaller Awaked");
            IGameElement.OnRegister += InstallContext;
            IGameElement.OnUnregister += UninstallContext;
        }

        private void OnDestroy()
        {
            IGameElement.OnRegister -= InstallContext;
            IGameElement.OnUnregister -= UninstallContext;
        }
        
        private void InstallContext(IGameElement element)
        {
            _gameContext.InstallGameElements(element);
            
            if (element is IUpdateElement updateElement)
                _gameContext.InstallUpdateElements(updateElement);
            
            if (element is IUpdateInPauseElement updateInPauseElement)
                _gameContext.InstallUpdateInPauseElements(updateInPauseElement);
                        
            if (element is IFixedUpdateElement fixedUpdateElement)
                _gameContext.InstallFixedUpdateElements(fixedUpdateElement);
            
            if (element is ILateUpdateElement lateUpdateElement)
                _gameContext.InstallLateUpdateElements(lateUpdateElement);
        }

        private void UninstallContext(IGameElement element)
        {
            _gameContext.UninstallGameElements(element);
            
            if (element is IUpdateElement updateElement)
                _gameContext.UninstallUpdateElements(updateElement);
            
            if (element is IUpdateInPauseElement updateInPauseElement)
                _gameContext.UninstallUpdateInPauseElements(updateInPauseElement);
                        
            if (element is IFixedUpdateElement fixedUpdateElement)
                _gameContext.UninstallFixedUpdateElements(fixedUpdateElement);
            
            if (element is ILateUpdateElement lateUpdateElement)
                _gameContext.UninstallLateUpdateElements(lateUpdateElement);
        }
    }
}