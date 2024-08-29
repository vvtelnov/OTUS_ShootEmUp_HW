using System;
using GameSystem.GameContext;
using UnityEngine;

namespace Input
{
    public sealed class InputHandler : IUpdateElement, IUpdateInPauseElement,
        IGameFinishElement
    {
        public event Action OnSpacePressed;
        public event Action OnLeftArrowPressed;
        public event Action OnRightArrowPressed;
        public event Action OnEscapePressed;

        void IUpdateElement.UpdateElement(float _)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                OnSpacePressed?.Invoke();

            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
                OnLeftArrowPressed?.Invoke();

            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
                OnRightArrowPressed?.Invoke();
            
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
                OnEscapePressed?.Invoke();
        }

        void IUpdateInPauseElement.UpdateInPause(float _)
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Escape))
                OnEscapePressed?.Invoke();
        }
        
        void IGameFinishElement.Finish()
        {
            IGameElement.Unregister(this);
        }
    }
}