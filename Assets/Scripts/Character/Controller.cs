using GameSystem;
using Input;
using UnityEngine;

namespace Character
{
    public sealed class Controller : MonoBehaviour, 
        IGameInitElement, IGameFinishElement
    {
        [SerializeField] private Character _character;
        [SerializeField] private InputHandler _inputHandler;

        private readonly float _leftHorizontalDirection = -1;
        private readonly float _rightHorizontalDirection = 1;
        
        private void Awake()
        {
            // TODO: Change to a constructor method.
            // Я понимаю, что не следуют исплользовать Awake в задании, но решил такую реализацию сделать установки зависимостей
            IGameElement.Register(this);
        }

        void IGameInitElement.Init()
        {
            _inputHandler.OnSpacePressed += SpaceKeyHandler;
            _inputHandler.OnLeftArrowPressed += LeftArrowKeyHandler;
            _inputHandler.OnRightArrowPressed += RightArrowKeyHandler;
        }

        void IGameFinishElement.Finish()
        {
            IGameElement.Unregister(this);

            _inputHandler.OnSpacePressed -= SpaceKeyHandler;
            _inputHandler.OnLeftArrowPressed -= LeftArrowKeyHandler;
            _inputHandler.OnRightArrowPressed -= RightArrowKeyHandler;
            
            Destroy(gameObject);
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