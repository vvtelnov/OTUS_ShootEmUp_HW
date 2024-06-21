using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class InputHandler : MonoBehaviour
    {
        public event Action OnSpacePressed;
        public event Action OnLeftArrowPressed;
        public event Action OnRightArrowPressed;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                OnSpacePressed?.Invoke();

            if (Input.GetKey(KeyCode.LeftArrow))
                OnLeftArrowPressed?.Invoke();

            if (Input.GetKey(KeyCode.RightArrow))
                OnRightArrowPressed?.Invoke();
        }
    }
}