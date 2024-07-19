using Input;
using UnityEngine;

namespace GameSystem
{
    public class StateController : MonoBehaviour, 
        IGameInitElement, IGameFinishElement
    {
        [SerializeField] private InputHandler _input;
        [SerializeField] private GameContext _gameContext;

        private void Awake()
        {
            // TODO: Change to a constructor method.
            // Я понимаю, что не следуют исплользовать Awake в задании, но решил такую реализацию сделать установки зависимостей
            IGameElement.Register(this);
        }


        void IGameInitElement.Init()
        {
            _input.OnEscapePressed += TogglePause;
        }

        void IGameFinishElement.Finish()
        {
            _input.OnEscapePressed -= TogglePause;
            
            IGameElement.Unregister(this);
            
            Destroy(this);
        }

        private void TogglePause()
        {
            if (!CanTogglePause())
                return;

            if (_gameContext.CurrState is State.PLAY)
                _gameContext.PauseGame();
            else
                _gameContext.ResumeGame();
            
        }

        private bool CanTogglePause()
        {
            return _gameContext.CurrState is 
                State.PLAY or 
                State.PAUSE;
        }
    }
}