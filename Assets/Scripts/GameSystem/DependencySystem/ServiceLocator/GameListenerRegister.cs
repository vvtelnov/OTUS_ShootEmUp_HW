using GameSystem.GameContext;

namespace GameSystem.DependencySystem.ServiceLocator
{
    public class GameListenerRegister : IGameFinishElement
    {
        private IGameListenerInstaller _listenerInstaller;
        
        public void Construct(IGameListenerInstaller listenerInstaller)
        {
            _listenerInstaller = listenerInstaller;
            
            INewInstanceLocator.InstanceIsCreated += TryToRegisterListener;

            RegisterListener(this);
        }
        
        private void TryToRegisterListener(object instance)
        {
            if (instance is IGameElement listener)
                RegisterListener(listener);
        }

        private void RegisterListener(IGameElement listener)
        {
            _listenerInstaller.InstallContext(listener);
        }

        public void Finish()
        {
            INewInstanceLocator.InstanceIsCreated -= TryToRegisterListener;
        }
    }
}