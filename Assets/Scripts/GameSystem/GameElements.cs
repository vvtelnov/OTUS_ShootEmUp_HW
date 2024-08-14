using System;
using UnityEngine;

namespace GameSystem
{
    public interface IGameElement
    {
        public static event Action<IGameElement> OnRegister;
        public static event Action<IGameElement> OnUnregister;

        public static void Register(IGameElement element)
        {
            OnRegister?.Invoke(element);
        }        
        
        public static void Unregister(IGameElement element)
        {
            OnUnregister?.Invoke(element);
        }
    }

    public interface IGameInitElement : IGameElement
    {
        // TODO: Remove comments.
        // Пусть это будет замена Awake
        void Init();
    }
    
    public interface IGameReadyElement : IGameElement
    {
        // TODO: Remove comments.
        // Пусть это будет замена Start
        void Ready();
    }

    public interface IGameStartElement : IGameElement
    {
        void OnStart();
    }
    
    public interface IGamePauseElement : IGameElement
    {
        void Pause();
    }
    
    public interface IGameResumeElement : IGameElement
    {
        void Resume();
    }
    
    public interface IGameFinishElement : IGameElement
    {
        void Finish();
    }
    
    public interface IUpdateElement : IGameElement
    {
        void UpdateElement(float deltaTime);
    }
    
    public interface IUpdateInPauseElement : IGameElement
    {
        void UpdateInPause(float deltaTime);
    }
    
    public interface IFixedUpdateElement : IGameElement
    {
        void FixedUpdateElement(float fixedDeltaTime);
    }
    
    public interface ILateUpdateElement : IGameElement
    {
        void LateUpdateElement(float deltaTime);
    }
    
    
    
}