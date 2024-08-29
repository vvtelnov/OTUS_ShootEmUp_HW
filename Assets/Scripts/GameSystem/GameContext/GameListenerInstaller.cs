namespace GameSystem.GameContext
{
    public interface IGameListenerInstaller
    {
        internal void InstallContext(IGameElement element);
        internal void UninstallContext(IGameElement element);
    }

    public class GameListenerInstaller : IGameListenerInstaller
    {
        private IListenerInstallable _installable;
        private IListenerUninstallable _uninstallable;

        public void Construct(IListenerInstallable installable, IListenerUninstallable uninstallable)
        {
            _installable = installable;
            _uninstallable = uninstallable;
        }
        
        // MonoBehaviors are registered in DI.DependencyInjector
        // Instances are registered in GameListenerRegister
        void IGameListenerInstaller.InstallContext(IGameElement element)
        {
            _installable.InstallGameElements(element);
            
            if (element is IUpdateElement updateElement)
                _installable.InstallUpdateElements(updateElement);
            
            if (element is IUpdateInPauseElement updateInPauseElement)
                _installable.InstallUpdateInPauseElements(updateInPauseElement);
                        
            if (element is IFixedUpdateElement fixedUpdateElement)
                _installable.InstallFixedUpdateElements(fixedUpdateElement);
            
            if (element is ILateUpdateElement lateUpdateElement)
                _installable.InstallLateUpdateElements(lateUpdateElement);
        }

        void IGameListenerInstaller.UninstallContext(IGameElement element)
        {
            _uninstallable.UninstallGameElements(element);
            
            if (element is IUpdateElement updateElement)
                _uninstallable.UninstallUpdateElements(updateElement);
            
            if (element is IUpdateInPauseElement updateInPauseElement)
                _uninstallable.UninstallUpdateInPauseElements(updateInPauseElement);
                        
            if (element is IFixedUpdateElement fixedUpdateElement)
                _uninstallable.UninstallFixedUpdateElements(fixedUpdateElement);
            
            if (element is ILateUpdateElement lateUpdateElement)
                _uninstallable.UninstallLateUpdateElements(lateUpdateElement);
        }
    }
}