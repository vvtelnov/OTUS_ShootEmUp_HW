using Atomic.Contexts;
using Atomic.Entities;
using Game.Scripts.UI.Ammo.Presenters;
using Game.Scripts.UI.GameOver.Presenters;
using Game.Scripts.UI.Health.Presenters;
using Game.Scripts.UI.Score.Presenters;
using Sirenix.OdinInspector.Editor.TypeSearch;

namespace Game.Scripts.UI
{
    public class UIInstaller : SceneEntityInstallerBase
    {
        public override void Install(IEntity entity)
        {
            SceneEntity player = GameContext.GameContext.Instance.GetPlayer();

            entity.AddHitPoints(player.GetHitPoints());
            entity.AddMaxHitPoints(player.GetMaxHitPoints());
            entity.AddAmmo(player.GetAmmo());
            entity.AddMaxAmmo(player.GetMaxAmmo());
            entity.AddScore(player.GetScore());
            entity.AddStartScore(player.GetStartScore());
            entity.AddOnDeath(player.GetOnDeath());
            
            InstallPresenters(entity);
        }

        private void InstallPresenters(IEntity entity)
        {
            entity.AddBehaviour(new HealthPresenter());
            entity.AddBehaviour(new AmmoPresenter());
            entity.AddBehaviour(new ScorePresenter());
            entity.AddBehaviour(new RankPresenter());
            entity.AddBehaviour(new GameOverPresenter());
        }
    }
}