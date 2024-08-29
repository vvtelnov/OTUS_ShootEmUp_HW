namespace GameSystem.GameContext
{
    public interface IGameListener
    {
        internal void ReadyGame();
        internal void StartGame();
        internal void PauseGame();
        internal void ResumeGame();
        internal void FinishGame();
    }

    public interface IUnityUpdates
    {
        internal void Update(float deltaTime);
        internal void UpdateInPause(float deltaTime);
        internal void FixedUpdate(float fixedDeltaTime);
        internal void LateUpdate(float deltaTime);
    }

    public interface IListenerInstallable
    {
        internal void InstallGameElements(IGameElement element);

        internal void InstallUpdateElements(IUpdateElement element);

        internal void InstallUpdateInPauseElements(IUpdateInPauseElement element);

        internal void InstallFixedUpdateElements(IFixedUpdateElement element);

        internal void InstallLateUpdateElements(ILateUpdateElement element);
    }
    
    public interface IListenerUninstallable
    {
        internal void UninstallGameElements(IGameElement element);

        internal void UninstallUpdateElements(IUpdateElement element);
        
        internal void UninstallUpdateInPauseElements(IUpdateInPauseElement element);

        internal void UninstallFixedUpdateElements(IFixedUpdateElement element);

        internal void UninstallLateUpdateElements(ILateUpdateElement element);
    }
}