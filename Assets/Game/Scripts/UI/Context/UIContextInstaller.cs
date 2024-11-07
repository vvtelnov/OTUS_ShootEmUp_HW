using Atomic.Contexts;
using Game.Scripts.UI.Ammo.Presenters;
using Game.Scripts.UI.Ammo.Views;
using Game.Scripts.UI.GameOver.Views;
using Game.Scripts.UI.Health.Views;
using Game.Scripts.UI.Score.Presenters;
using Game.Scripts.UI.Score.Views;
using UnityEngine;

namespace Game.Scripts.UI.Context
{
    public class UIContextInstaller : SceneContextInstallerBase
    {
        [SerializeField] private HealthAmountView _healthAmountView;
        // [SerializeField] private HealthMaxAmountView _healthMaxAmountView;
        [SerializeField] private AmmoAmountView _ammoView;
        // [SerializeField] private MaxAmmoView _maxAmmoView;
        [SerializeField] private ScoreView _scoreView;
        [SerializeField] private RankView _rankView;
        [SerializeField] private Ranks _ranks;
        [SerializeField] private GameOverView _gameOverView;
        
        public override void Install(IContext context)
        {
            context.AddHitPointsView(_healthAmountView);
            context.AddAmmoView(_ammoView);
            context.AddScoreView(_scoreView);
            context.AddRankView(_rankView);
            context.AddRanks(_ranks);
            context.AddGameOverView(_gameOverView);
        }
    }
}