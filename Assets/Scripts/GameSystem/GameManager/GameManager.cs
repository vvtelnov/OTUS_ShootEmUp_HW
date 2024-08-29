using GameSystem.DependencySystem.DI;
using GameSystem.GameContext;

namespace GameSystem.GameManager
{
    [InjectionNeeded]
    public sealed class GameManager
    {
        private GameStateContext _gameContext;

        [Inject]
        public void Constructor(GameStateContext gameContext)
        {
            _gameContext = gameContext;
        }

        public void FinishGame()
        {
            Utils.PrintToConsole.PrintGameOver();
            
            _gameContext.FinishGame();
        }
    }
}