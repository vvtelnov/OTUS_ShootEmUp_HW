using Atomic.Elements;
using Game.Scripts.UI.Ammo.Presenters;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Ammo.Views
{
    public class AmmoAmountView : MonoBehaviour, IAmmoAmountView
    {
        [SerializeField] private GameObject _magazineImage;
        [SerializeField] private GameObject _reloadImage;
        [SerializeField] private TextMeshProUGUI _textField;
        
        private ReactiveVariable<uint> _ammo;
        private ReactiveVariable<uint> _maxAmmo;
        private uint _previousValue;

        void IAmmoAmountView.OnShow(IAmmoPresenter ammoPresenter)
        {
            _ammo = ammoPresenter.Ammo;
            _maxAmmo = ammoPresenter.MaxAmmo;
            _previousValue = _ammo.Value;
            
            _ammo.Subscribe(HandleAmmoChanged);
        }

        private void HandleAmmoChanged(uint value)
        {
            // if (_previousValue > value)
            //     Decrease(value);
            // else
            //     Increase(value);

            if (value <= 0)
                ToggleToReloadImage();
            else if (_previousValue <= 0)
                ToggleToMagazineImage();

            //TODO: Так можно делать? где-то на курсе говорили, что во  вьюшку должна строка приходить
            _textField.text = value.ToString();

            _previousValue = value;
        }

        private void Decrease(int value)
        {
            throw new System.NotImplementedException();
        }

        private void Increase(int value)
        {
            throw new System.NotImplementedException();
        }
        
        private void ToggleToReloadImage()
        {
            _magazineImage.SetActive(false);
            _reloadImage.SetActive(true);
        }
        
        private void ToggleToMagazineImage()
        {
            _magazineImage.SetActive(true);
            _reloadImage.SetActive(false);
        }
    }
}