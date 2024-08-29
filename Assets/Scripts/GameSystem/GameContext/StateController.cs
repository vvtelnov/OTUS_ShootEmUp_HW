using GameSystem.DependencySystem.DI;
using Input;

namespace GameSystem.GameContext
{
    [InjectionNeeded]
    public class StateController : IGameReadyElement, IGameFinishElement
    {
        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private InputHandler _input;
        
        private GameStateContext _gameContext;

        [Inject]
        public void Construct(GameStateContext gameContext)
        {
            _gameContext = gameContext;
        }

        void IGameReadyElement.Ready()
        {
            _input.OnEscapePressed += TogglePause;
        }

        void IGameFinishElement.Finish()
        {
            _input.OnEscapePressed -= TogglePause;
            
            IGameElement.Unregister(this);
        }

        private void TogglePause()
        {
            if (!CanTogglePause())
                return;

            if (_gameContext.CurrState is State.PLAY)
                _gameContext.PauseGame();
            else
                _gameContext.UnpauseGame();
            
        }

        private bool CanTogglePause()
        {
            return _gameContext.CurrState is 
                State.PLAY or 
                State.PAUSE;
        }
    }
}