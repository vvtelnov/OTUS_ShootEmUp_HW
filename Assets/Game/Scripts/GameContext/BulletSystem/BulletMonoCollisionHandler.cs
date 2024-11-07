using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Behaviours.Health;
using UnityEngine;

namespace Game.Scripts.GameContext.BulletSystem
{
    public class BulletMonoCollisionHandler : MonoBehaviour
    {
        private BaseEvent<IEntity> _onRemoveBullet;

        private IEntity _entity;
        private bool _isThisPlayer;
        private int _damageOnHit;


        public void Init(
            BaseEvent<IEntity> onRemoveBullet, 
            IEntity entity, 
            bool isThisPlayer, 
            int damageOnHit
            )
        {
            _onRemoveBullet = onRemoveBullet;
            _entity = entity;
            _isThisPlayer = isThisPlayer;
            _damageOnHit = damageOnHit;
        }

        public void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.TryGetComponent<SceneEntity>(out var entityComponent))
                return;
            
            if (entityComponent.HasEnemyTag() == _isThisPlayer)
                return;
            
            entityComponent.GetBehaviour<TakeDamageBehaviour>().Invoke(_damageOnHit);

            _onRemoveBullet.Invoke(_entity);
        }
    }
}