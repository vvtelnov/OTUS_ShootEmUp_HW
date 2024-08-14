using Components;
using GameSystem;
using GameSystem.GameManager;
using UnityEngine;

namespace Character
{
    public class DeathObserver : MonoBehaviour,
        IGameInitElement, IGameFinishElement
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private HitPointsComponent _hitPointsComponent;

        private void Start()
        {
            // TODO: Change to a constructor method.
            // Я понимаю, что не следуют исплользовать Awake в задании, но решил такую реализацию сделать установки зависимостей
            IGameElement.Register(this);
        }
        
        void IGameInitElement.Init()
        {
            _hitPointsComponent.HpEmpty += OnCharacterDeath;
        }

        void IGameFinishElement.Finish()
        {
            _hitPointsComponent.HpEmpty -= OnCharacterDeath;
            
            IGameElement.Unregister(this);
            Destroy(gameObject);
        }

        private void OnCharacterDeath(GameObject character) => _gameManager.FinishGame();
    }
} 