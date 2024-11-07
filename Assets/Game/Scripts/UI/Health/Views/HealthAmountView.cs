using Atomic.Elements;
using Game.Scripts.UI.Health.Presenters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Health.Views
{
    public class HealthAmountView : MonoBehaviour, IHealthAmountView
    {
        [SerializeField] private Image _fillingImage;
        [SerializeField] private TextMeshProUGUI _textField;
        
        private ReactiveVariable<int> _hitPoints;
        private ReactiveVariable<int> _maxHitPoints;
        private int _previousHitPointsValue;

        void IHealthAmountView.OnShow(IHealthPresenter healthPresenter)
        {
            _hitPoints = healthPresenter.HitPoints;
            _maxHitPoints = healthPresenter.MaxHitPoints;
            _previousHitPointsValue = _hitPoints.Value;
            
            _hitPoints.Subscribe(HandleHitPointsChanged);
        }

        private void HandleHitPointsChanged(int value)
        {
            // if (_previousHitPointsValue > value)
            //     Decrease(value);
            // else
            //     Increase(value);

            UpdateFilling();
            
            //TODO: Так можно делать, где-то на курсе говорили, что во  вьюшку должна строка приходить
            _textField.text = value.ToString();

            _previousHitPointsValue = value;
        }

        private void Decrease(int value)
        {
            throw new System.NotImplementedException();
        }

        private void Increase(int value)
        {
            throw new System.NotImplementedException();
        }

        private void UpdateFilling()
        {
            float fillAmount = (float)_hitPoints.Value / _maxHitPoints.Value;

            _fillingImage.fillAmount = Mathf.Clamp01(fillAmount);
        }
    }
}