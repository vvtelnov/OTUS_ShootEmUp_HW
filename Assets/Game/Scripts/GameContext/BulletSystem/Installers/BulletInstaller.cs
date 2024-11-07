using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Behaviours;
using Game.Scripts.Behaviours.Movement;
using Game.Scripts.Utils;
using UnityEngine;

namespace Game.Scripts.GameContext.BulletSystem.Installers
{
    public class BulletInstaller : SceneEntityInstallerBase
    {
        [SerializeField] private float _timerDuration;
        [SerializeField] private BulletMonoCollisionHandler _collisionHandler;
        private bool _isDead = false;
        
        public override void Install(IEntity entity)
        {
            var bulletSystem = GameContext.Instance.GetBulletSystem();

            entity.AddOnRemoveBullet(new BaseEvent<IEntity>());
            entity.AddMoveSpeed(bulletSystem.GetMoveSpeed());
            entity.AddShootPoint(bulletSystem.GetShootPoint());
            entity.AddHasInertness(false);
            entity.AddTransform(transform);
            entity.AddTimer(new Timer(_timerDuration));
            entity.AddAttackDamage(bulletSystem.GetAttackDamage());

            InstallBehaviours(entity);
            InstallMonoBehaviours(entity);
            InstallCanMoveConditions(entity);

            EntityInstalledLogger.Instance.Log(entity);
        }
        
        private void InstallBehaviours(IEntity entity)
        {
            entity.AddBehaviour(new MovementBehavior());
            entity.AddBehaviour(new Bullet());
        }

        private void InstallMonoBehaviours(IEntity entity)
        {
            _collisionHandler.Init(
                entity.GetOnRemoveBullet(),
                entity,
                entity.HasPlayerTag(),
                entity.GetAttackDamage()
                );
        }


        private void InstallCanMoveConditions(IEntity entity)
        {
            AndExpression canMove = new();
            
            //Логики "смерти пули у нас нет". Но тут реактивно она не обновляется
            canMove.Append(() => !_isDead);
            entity.AddCanMove(canMove);
        }
    }
}
