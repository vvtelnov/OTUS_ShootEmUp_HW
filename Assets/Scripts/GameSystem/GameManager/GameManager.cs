using UnityEngine;

namespace GameSystem.GameManager
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField] private GameContext _gameContext;

        public void FinishGame()
        {
            Utils.PrintToConsole.PrintGameOver();
            
            _gameContext.FinishGame();
        }
    }
}