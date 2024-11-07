using Atomic.Contexts;
using Atomic.Entities;
using Game.Scripts.Behaviours.Health;
using Game.Scripts.Effects.Soldier;
using UnityEngine;

namespace Game.Scripts.Effects.Installers
{
    public class CharacterVisualInstaller : SceneEntityInstallerBase
    {
        public override void Install(IEntity entity)
        {
            SceneEntity playerEntity = GameContext.GameContext.Instance.GetPlayer();
            
            entity.AddAnimator(GetComponent<Animator>());
            entity.AddMoveDirection(playerEntity.GetMoveDirection());
            entity.AddOnShot(playerEntity.GetOnShot());
            entity.AddOnDamageIsTaken(playerEntity.GetOnDamageIsTaken());
            entity.AddOnDeath(playerEntity.GetOnDeath());
            

            entity.AddBehaviour(new MoveAnimation());
            entity.AddBehaviour(new ShootAnimation());
            entity.AddBehaviour(new TakeDamageAnimation());
            entity.AddBehaviour(new DeathAnimation());
        }
    }
}