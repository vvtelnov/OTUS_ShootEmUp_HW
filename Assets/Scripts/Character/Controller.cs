using Input;
using UnityEngine;

namespace Character
{
    public sealed class Controller : MonoBehaviour
    {
        [SerializeField] private Character _character;
        [SerializeField] private InputHandler _inputHandler;

        private readonly float _leftHorizontalDirection = -1;
        private readonly float _rightHorizontalDirection = 1;

        private void OnEnable()
        {
            _inputHandler.OnSpacePressed += SpaceKeyHandler;
            _inputHandler.OnLeftArrowPressed += LeftArrowKeyHandler;
            _inputHandler.OnRightArrowPressed += RightArrowKeyHandler;
        }

        private void OnDisable()
        {
            _inputHandler.OnSpacePressed -= SpaceKeyHandler;
            _inputHandler.OnLeftArrowPressed -= LeftArrowKeyHandler;
            _inputHandler.OnRightArrowPressed -= RightArrowKeyHandler;
        }

        private void LeftArrowKeyHandler()
        {
            _character.Move(_leftHorizontalDirection);
        }

        private void RightArrowKeyHandler()
        {
            _character.Move(_rightHorizontalDirection);
        }

        private void SpaceKeyHandler()
        {
            _character.AttackStraightUp();
        }
    }
}