using System.Collections;
using GameSystem.DependencySystem.StaticServices;
using UnityEngine;
using Utils;

namespace GameSystem.GameContext
{
    public class GameLauncher : MonoBehaviour
    {
        [SerializeField] private bool _autoRun = true;
        
        private GameStateContext _gameStateContext;
        
        private Coroutine _startGameCoroutine;

        private void Start()
        {
            InstallGameContext();
            
            if (!_autoRun)
                return;

            LaunchGameWithTimer();
        }
        
        public void LaunchGameWithTimer()
        {
            if (_gameStateContext.CurrState == State.OFF)
                _gameStateContext.InitializeGame();
            
            if (_gameStateContext.CurrState == State.INIT)
                _gameStateContext.ReadyGame();
            
            if (_gameStateContext.CurrState == State.READY)
                StartGameWithTimer();
        }
        
        private void InstallGameContext()
        {
            _gameStateContext = (GameStateContext) ServiceFinder.Instance
                .FindObjectOnScene(typeof(GameStateContext));
        }

        private void StartGameWithTimer()
        {
            if (_startGameCoroutine is not null)
            {
                PrintToConsole.PrintAsError("Game Count Coroutine is already in progress");
                return;
            }
                
            _startGameCoroutine = StartCoroutine(GameStartCounter());
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

            _gameStateContext.StartGame();

            _startGameCoroutine = null;
        }
    }
}