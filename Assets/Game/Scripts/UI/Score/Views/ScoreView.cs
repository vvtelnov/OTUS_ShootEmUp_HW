using Atomic.Elements;
using Game.Scripts.UI.Score.Presenters;
using TMPro;
using UnityEngine;

namespace Game.Scripts.UI.Score.Views
{
    public class ScoreView : MonoBehaviour, IScoreView
    {
        [SerializeField] private TextMeshProUGUI _textField;
        
        private ReactiveVariable<int> _score;
        private ReactiveVariable<uint> _maxAmmo;
        private int _previousValue;

        void IScoreView.OnShow(IScorePresenter scorePresenter)
        {
            _score = scorePresenter.Score;
            _score.Subscribe(HandleScoreChanged);
        }


        private void HandleScoreChanged(int value)
        {
            // if (_previousValue > value)
            //     Decrease(value);
            // else
            //     Increase(value);

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
    }
}