using UnityEngine;

namespace ShootEmUp
{
    public class CharacterDeathObserver : MonoBehaviour
    {
        [SerializeField] private GameManager _gameManager;
        [SerializeField] private HitPointsComponent _hitPointsComponent;

        private void OnEnable()
        {
            _hitPointsComponent.HpEmpty += this.OnCharacterDeath;
        }

        private void OnDisable()
        {
            _hitPointsComponent.HpEmpty -= this.OnCharacterDeath;
        }

        private void OnCharacterDeath(GameObject _character) => _gameManager.FinishGame();
    }
}