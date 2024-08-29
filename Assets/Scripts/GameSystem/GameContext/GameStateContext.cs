using GameSystem.DependencySystem.DI;
using UnityEngine;
using Utils;

namespace GameSystem.GameContext
{
    public enum State
    {
        OFF = 0,
        INIT = 1,
        READY = 2,
        PLAY = 3,
        PAUSE = 4,
        FINISH = 5,
    }

    [InjectionNeeded]
    public class GameStateContext : MonoBehaviour
    {
        public State CurrState { get; internal set; } = State.OFF;
        
        [SerializeField] private bool _isLoggingRequired = false;
        
        private readonly GameSystemConstructor _gameSystemConstructor = new GameSystemConstructor();
        
        private IGameListener _gameListener;
        private IUnityUpdates _updatesListener;
        
        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        public void Construct(GameListener gameListener)
        {
            _gameListener = gameListener;
            _updatesListener = gameListener;
        }
        
        public void InitializeGame()
        {
            if (CurrState != State.OFF)
            {
                PrintStateSwitchErr(State.INIT);
                return;
            }
            
            _gameSystemConstructor.Construct(_isLoggingRequired);
            _gameSystemConstructor.InitializeGame();
            
            CurrState = State.INIT;
            PrintCurrState();
        }
        
        public void ReadyGame()
        {
            if (CurrState != State.INIT)
            {
                PrintStateSwitchErr(State.READY);
                return;
            }
            
            _gameListener.ReadyGame();
            
            CurrState = State.READY;
            PrintCurrState();
        }

        public void StartGame()
        {
            if (CurrState != State.READY)
            {
                PrintStateSwitchErr(State.PLAY);
                return;
            }
            
            _gameListener.StartGame();
            
            CurrState = State.PLAY;
            PrintCurrState();
        }
        
        public void PauseGame()
        {
            if (CurrState != State.PLAY)
            {
                PrintStateSwitchErr(State.PAUSE);
                return;
            }
            
            _gameListener.PauseGame();
            
            CurrState = State.PAUSE;
            PrintCurrState();
        }

        public void UnpauseGame()
        {
            if (CurrState != State.PAUSE)
            {
                PrintStateSwitchErr(State.PLAY);
                return;
            }
            
            _gameListener.ResumeGame();
            
            CurrState = State.PLAY;
            PrintCurrState();
        }
        
        public void FinishGame()
        {
            if (!CanFinishGame())
            {
                PrintStateSwitchErr(State.FINISH);
                return;
            }
            
            _gameListener.FinishGame();

            CurrState = State.FINISH;
            PrintCurrState();
        }

        private void Update()
        {
            switch (CurrState)
            {
                case State.PLAY:
                    _updatesListener.Update(Time.deltaTime);
                    break;
                case State.PAUSE:
                    _updatesListener.UpdateInPause(Time.deltaTime);
                    break;
            }
        }

        private void FixedUpdate()
        {
            if (CurrState != State.PLAY) 
                return;

            _updatesListener.FixedUpdate(Time.fixedDeltaTime);
        }

        private void LateUpdate()
        {
            if (CurrState != State.PLAY) 
                return;
            
            _updatesListener.LateUpdate(Time.deltaTime);
        }

        private bool CanFinishGame()
        {
            return CurrState is 
                State.READY or 
                State.PLAY or 
                State.PAUSE;
        }

        private void PrintCurrState()
        {
            PrintToConsole.PrintWhite($"Current state is {CurrState}");
        }

        private void PrintStateSwitchErr(State nextState)
        {
            string msgError = $"You cannot switch to {nextState}." +
                              $"\nYou current state is {CurrState}";
            
            PrintToConsole.PrintAsError(msgError);
        }
    }
}