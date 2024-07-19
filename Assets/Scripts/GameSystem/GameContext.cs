using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

namespace GameSystem
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
    
    [DisallowMultipleComponent]
    public class GameContext : MonoBehaviour
    {
        public State CurrState { get; internal set; }

        [SerializeField] private bool _autoRun = true;

        private List<IGameElement> _gameElements = new();
        private List<IUpdateElement> _updateElements = new();
        private List<IUpdateInPauseElement> _updateInPauseElements = new();
        private List<IFixedUpdateElement> _fixedUpdateElements = new();
        private List<ILateUpdateElement> _lateUpdateElements = new();

        private Coroutine _startGameCoroutine;

        private void Start()
        {
            CurrState = State.OFF;
            
            if (!_autoRun)
                return;

            InitializeGame();
            ReadyGame();
            StartGameWithTimer();
        }
        
        internal void InstallGameElements(IGameElement element)
        {
            _gameElements.Add(element);
        }

        internal void InstallUpdateElements(IUpdateElement element)
        {
            _updateElements.Add(element);
        }        
        
        internal void InstallUpdateInPauseElements(IUpdateInPauseElement element)
        {
            _updateInPauseElements.Add(element);
        }

        internal void InstallFixedUpdateElements(IFixedUpdateElement element)
        {
             _fixedUpdateElements.Add(element);
        }

        internal void InstallLateUpdateElements(ILateUpdateElement element)
        {
            _lateUpdateElements.Add(element);
        }
        
        internal void UninstallGameElements(IGameElement element)
        {
            _gameElements.Remove(element);
        }

        internal void UninstallUpdateElements(IUpdateElement element)
        {
            _updateElements.Remove(element);
        }        
        
        internal void UninstallUpdateInPauseElements(IUpdateInPauseElement element)
        {
            _updateInPauseElements.Remove(element);
        }

        internal void UninstallFixedUpdateElements(IFixedUpdateElement element)
        {
            _fixedUpdateElements.Remove(element);
        }

        internal void UninstallLateUpdateElements(ILateUpdateElement element)
        {
            _lateUpdateElements.Remove(element);
        }

        [ContextMenu("Initialize game")]
        public void InitializeGame()
        {
            if (CurrState != State.OFF)
            {
                PrintStateSwitchErr(State.OFF);
                return;
            }

            int index = 0;
            while (true)
            {
                int counter = _gameElements.Count;

                if (!(index < counter))
                    break;

                var element = _gameElements[index];
                
                if (element is IGameInitElement initElement)
                {
                    initElement.Init();
                }

                index++;
            }

            CurrState = State.INIT;
            PrintCurrState();
        }
        
        [ContextMenu("Ready game")]
        public void ReadyGame()
        {
            if (CurrState != State.INIT)
            {
                PrintStateSwitchErr(State.INIT);
                return;
            }
            
            int index = 0;
            while (true)
            {
                int counter = _gameElements.Count;

                if (!(index < counter))
                    break;

                var element = _gameElements[index];
                
                if (element is IGameReadyElement initElement)
                {
                    initElement.Ready();
                }

                index++;
            }

            CurrState = State.READY;
            PrintCurrState();
        }
        
        [ContextMenu("Start game")]
        public void StartGame()
        {
            if (CurrState != State.READY)
            {
                PrintStateSwitchErr(State.READY);
                return;
            }

            int index = 0;
            while (true)
            {
                int counter = _gameElements.Count;

                if (!(index < counter))
                    break;

                var element = _gameElements[index];
                
                if (element is IGameStartElement initElement)
                {
                    initElement.OnStart();
                }

                index++;
            }

            CurrState = State.PLAY;
            PrintCurrState();
        }

        internal void StartGameWithTimer()
        {
            if (CurrState != State.READY)
            {
                PrintStateSwitchErr(State.READY);
                return;
            }
            
            if (_startGameCoroutine is not null)
            {
                PrintErr("Game Count Coroutine is already in progress");
                return;
            }
            
            _startGameCoroutine = StartCoroutine(GameStartCounter());
        }
        
        [ContextMenu("Pause game")]
        public void PauseGame()
        {
            if (CurrState != State.PLAY)
            {
                PrintStateSwitchErr(State.PAUSE);
                return;
            }

            foreach (var element in _gameElements)
            {
                if (element is IGamePauseElement pauseElement)
                {
                    if (element is Behaviour { isActiveAndEnabled: true })
                        pauseElement.Pause();
                }
            }

            CurrState = State.PAUSE;
            PrintCurrState();
        }
        
        [ContextMenu("Resume game")]
        public void ResumeGame()
        {
            if (CurrState != State.PAUSE)
            {
                PrintStateSwitchErr(State.PAUSE);
                return;
            }

            foreach (var element in _gameElements)
            {
                if (element is IGameResumeElement resumeElement)
                {
                    if (element is Behaviour { isActiveAndEnabled: true })
                        resumeElement.Resume();
                }
            }

            CurrState = State.PLAY;
            PrintCurrState();
        }
        
        [ContextMenu("Finish game")]
        public void FinishGame()
        {
            if (!CanFinishGame())
            {
                PrintStateSwitchErr(State.FINISH);
                return;
            }
            
            IGameElement[] copyGameElements = _gameElements.ToArray();

            foreach (var element in copyGameElements)
            {
                if (element is IGameFinishElement finishElement)
                {
                    finishElement.Finish();
                }
            }

            CurrState = State.FINISH;
            PrintCurrState();
        }
        
        private void Update()
        {
            if ( (CurrState != State.PLAY) && (CurrState != State.PAUSE) )
                return;

            float deltaTime = Time.deltaTime;

            if (CurrState is State.PLAY)
            {
                for (int i = 0, count = _updateElements.Count; i < count; i++)
                {
                    var element = _updateElements[i];
                    
                    if (element is Behaviour { isActiveAndEnabled: true })
                        element.UpdateElement(deltaTime);
                }
            }
            
            else if (CurrState is State.PAUSE)
            {
                for (int i = 0, count = _updateInPauseElements.Count; i < count; i++)
                {
                    var element = _updateInPauseElements[i];
                    
                    if (element is Behaviour { isActiveAndEnabled: true })
                        element.UpdateInPause(deltaTime);
                }
            }
        }
        
        private void FixedUpdate() 
        {
            if (CurrState != State.PLAY) 
                return;
            
            float fixedDeltaTime = Time.fixedDeltaTime;
            
            for (int i = 0, count = _fixedUpdateElements.Count; i < count; i++)
            {
                var element = _fixedUpdateElements[i];
                
                if (element is Behaviour { isActiveAndEnabled: true })
                    element.FixedUpdateElement(fixedDeltaTime);
            }
        }

        private void LateUpdate() 
        {
            if (CurrState != State.PLAY) 
                return;
            
            float deltaTime = Time.deltaTime;
            
            for (int i = 0, count = _lateUpdateElements.Count; i < count; i++)
            {
                var element = _lateUpdateElements[i];
                
                if (element is Behaviour { isActiveAndEnabled: true })
                    element.LateUpdateElement(deltaTime);
            }
        }

        private IEnumerator GameStartCounter()
        {
            // Взаимодействие с UI ...
            
            PrintToConsole.PrintYellow("3");

            yield return new WaitForSeconds(1);
            PrintToConsole.PrintYellow("2");

            
            yield return new WaitForSeconds(1);
            PrintToConsole.PrintYellow("1");

            
            yield return new WaitForSeconds(1);
            PrintToConsole.PrintGreen("Let's go!");

            StartGame();
            
            _startGameCoroutine = null;
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

        private void PrintErr(string msg)
        {
            PrintToConsole.PrintAsError(msg);
        }
    }
}