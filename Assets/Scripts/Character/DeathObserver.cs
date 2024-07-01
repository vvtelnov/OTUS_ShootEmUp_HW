using Components;
using UnityEngine;

namespace Character
{
    public class DeathObserver : MonoBehaviour
    {
        [SerializeField] private GameManager.GameManager _gameManager;
        [SerializeField] private HitPointsComponent _hitPointsComponent;

        private void OnEnable()
        {
            _hitPointsComponent.HpEmpty += OnCharacterDeath;
        }

        private void OnDisable()
        {
            _hitPointsComponent.HpEmpty -= OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject character) => _gameManager.FinishGame();
    }
}