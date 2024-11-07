using Atomic.Contexts;
using Atomic.Entities;
using Game.Scripts.GameContext.EntityPool;
using Game.Scripts.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Scripts.GameContext.BulletSystem.Installers
{
    public class BulletSystemInstaller : SceneEntityInstallerBase
    {
        [SerializeField] private int _damageOnHit;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private SceneEntity _bulletPrefab;
        [SerializeField] private Transform _poolContainer;
        [SerializeField] private Transform _worldContainer;
        [SerializeField] private int _initialNumbOfBulletsInPool;
        
        [SerializeField] private float _moveSpeed;
        private readonly bool _hasInertness = false;

        public override void Install(IEntity entity)
        {
            SceneEntity playerEntity = GameContext.Instance.GetPlayer();

            entity.AddShootPoint(_shootPoint);
            entity.AddOnShot(playerEntity.GetOnShot());
            entity.AddAttackDamage(_damageOnHit);
            
            entity.AddPrefab(_bulletPrefab);
            entity.AddPoolContainer(_poolContainer);
            entity.AddWorldContainer(_worldContainer);
            entity.AddInitalCount(_initialNumbOfBulletsInPool);

            entity.AddMoveSpeed(_moveSpeed);
            entity.AddHasInertness(_hasInertness);

            entity.AddBehaviour(new SceneEntityPool());
            entity.AddBehaviour(new BulletsSystem());
            
            EntityInstalledLogger.Instance.Log(entity);
        }
    }
}