using Components;
using GameSystem.DependencySystem.DI;
using GameSystem.GameContext;
using GameSystem.GameManager;
using UnityEngine;

namespace Character
{
    [InjectionNeeded]
    public class DeathObserver : IGameStartElement, IGameFinishElement
    {
        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private GameManager _gameManager;
        
        private MonoHitPointsComponent _hitPointsComponent;

        public void Construct(MonoHitPointsComponent hpComponent)
        {
            _hitPointsComponent = hpComponent;
        }
        
        void IGameStartElement.OnStart()
        {
            _hitPointsComponent.HpEmpty += OnCharacterDeath;
        }

        void IGameFinishElement.Finish()
        {
            _hitPointsComponent.HpEmpty -= OnCharacterDeath;
            
            IGameElement.Unregister(this);
        }

        private void OnCharacterDeath(GameObject character)
        {
            _gameManager.FinishGame();
        }
    }
} 