using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.UI.Context;
using Game.Scripts.UI.Score.Views;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Score.Presenters
{
    public class RankPresenter : IRankPresenter, IEntityInit
    {
        private IRankView _rankView;
        private ReactiveVariable<int> _score;
        private Ranks _ranks;
        private int _currentRank;
        private Image _currentRankImage;
        
        void IEntityInit.Init(IEntity entity)
        {
            _score = entity.GetScore();
            int initScore = entity.GetStartScore();
            
            _score.Subscribe(CalculateRank);
            
            _rankView = UIContext.Instance.GetRankView();
            _ranks = UIContext.Instance.GetRanks();

            _currentRank =  _ranks.CalculateRankIndex(initScore);
            Sprite rankImage = _ranks.GetRankImage(_currentRank);

            _rankView.OnShow(rankImage);
        }

        private void CalculateRank(int score)
        {
            int newRank = _ranks.CalculateRankIndex(score);

            if (newRank == _currentRank)
                return;

            _currentRank = newRank;
            _rankView.ChangeRank(
                _ranks.GetRankImage(_currentRank)
                );
        }
    }
}