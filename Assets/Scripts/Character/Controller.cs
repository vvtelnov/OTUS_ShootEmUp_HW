using GameSystem.DependencySystem.DI;
using GameSystem.GameContext;
using Input;

namespace Character
{
    [InjectionNeeded]
    public sealed class Controller : IGameStartElement, IGameFinishElement
    {
        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private InputHandler _inputHandler;
        private Character _character;

        private readonly float _leftHorizontalDirection = -1;
        private readonly float _rightHorizontalDirection = 1;
        
        public void Construct(Character character)
        {
            _character = character;
        }

        void IGameStartElement.OnStart()
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