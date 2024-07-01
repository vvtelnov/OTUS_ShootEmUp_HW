using System;
using UnityEngine;

namespace Input
{
    public sealed class InputHandler : MonoBehaviour
    {
        public event Action OnSpacePressed;
        public event Action OnLeftArrowPressed;
        public event Action OnRightArrowPressed;

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                OnSpacePressed?.Invoke();

            if (UnityEngine.Input.GetKey(KeyCode.LeftArrow))
                OnLeftArrowPressed?.Invoke();

            if (UnityEngine.Input.GetKey(KeyCode.RightArrow))
                OnRightArrowPressed?.Invoke();
        }
    }
}