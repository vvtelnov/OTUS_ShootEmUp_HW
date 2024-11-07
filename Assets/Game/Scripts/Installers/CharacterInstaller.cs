using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Behaviours.General;
using Game.Scripts.Behaviours.Health;
using Game.Scripts.Behaviours.Movement;
using Game.Scripts.Behaviours.Rotation;
using Game.Scripts.Behaviours.Shoot;
using Game.Scripts.Controllers;
using Game.Scripts.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.Installers
{
    public class CharacterInstaller : SceneEntityInstallerBase
    {
        [Title("Health")]
        [SerializeField] private int _maxHitPoints = 10;
        private readonly bool _isDead = false;
        private AndExpression _canTakeDamage;

        [Title("Movement")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _deceleration;
        [SerializeField] private bool _hasInertness = true;
        // [SerializeField] private float _rotationSpeed;
        // [SerializeField] private Vector3 _moveDirection;
        // [SerializeField] private Vector3 _rotateDirection;

        [Title("Shoot")]
        [SerializeField] private uint _maxAmmo;
        [SerializeField] private Transform _shootPoint;
        [SerializeField] private float _fireRate;
        [SerializeField] private float _reloadTime;
        [SerializeField] private float _ammoRestoreTime;
        private AndExpression _canShoot;
        
        
        public override void Install(IEntity entity)
        {
            entity.AddPlayerTag();
            
            // Events
            entity.AddOnDamageIsTaken(new BaseEvent());
            entity.AddOnDeath(new BaseEvent<IEntity>());
            entity.AddOnShootRequested(new BaseEvent());
            entity.AddOnShot(new BaseEvent());
            
            // Health
            entity.AddMaxHitPoints(_maxHitPoints);
            entity.AddHitPoints(_maxHitPoints);
            entity.AddIsDead(_isDead);
            InstallCanTakeDamageConditions(entity);

            
            // Movement
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddAcceleration(_acceleration);
            entity.AddDeceleration(_deceleration);
            entity.AddHasInertness(_hasInertness);
            InstallCanMoveConditions(entity);
            entity.AddMoveDirection(Vector3.zero);

            // Rotation
            // entity.AddRotationSpeed(_rotationSpeed);
            // entity.AddRotateDirection(_rotateDirection);
            InstallCanRotateConditions(entity);
            
            // Shoot
            entity.AddMaxAmmo(_maxAmmo);
            entity.AddAmmo(_maxAmmo);
            entity.AddFireRate(_fireRate);
            entity.AddReloadTime(_reloadTime);
            entity.AddAmmoRestoreTime(_ammoRestoreTime);
            InstallCanShootConditions(entity);
            InstallCanAddAmmoToMagazine(entity);

            // Transforms
            entity.AddTransform(this.transform);
            entity.AddShootPoint(_shootPoint);
            
            //Score
            entity.AddScore(0);
            entity.AddStartScore(0);

            InstallBehaviours(entity);

            EntityInstalledLogger.Instance.Log(entity);
        }

        private void InstallBehaviours(IEntity entity)
        {
            // Behaviours
            entity.AddBehaviour(new MovementBehavior());
            entity.AddBehaviour(new RotationBehaviour());
            entity.AddBehaviour(new ShootBehaviour());
            entity.AddBehaviour(new AmmoMagazineBehaviour());
            entity.AddBehaviour(new TakeDamageBehaviour());
            entity.AddBehaviour(new DeathBehaviour());

            // Controllers
            entity.AddBehaviour(new KeyboardInput());
            entity.AddBehaviour(new MouseInput());
        }


        private void InstallCanMoveConditions(IEntity entity)
        {
            AndExpression canMove = new();
            
            canMove.Append(() => !entity.GetIsDead().Value);
            entity.AddCanMove(canMove);
        }
        
        private void InstallCanRotateConditions(IEntity entity)
        {
            AndExpression canRotate = new();

            canRotate.Append(() => !entity.GetIsDead().Value);
            entity.AddCanRotate(canRotate);
        }
        
        private void InstallCanTakeDamageConditions(IEntity entity)
        {
            AndExpression canTakeDamage = new();

            canTakeDamage.Append(() => !entity.GetIsDead().Value);
            entity.AddCanTakeDamage(canTakeDamage);
        }
        
        private void InstallCanShootConditions(IEntity entity)
        {
            AndExpression canShoot = new();
            ActionByTimerBehaviour actionByTimerBehaviour = new();
            actionByTimerBehaviour.Init(true, entity.GetFireRate().Value, entity.GetOnShot());
            entity.AddBehaviour(actionByTimerBehaviour);

            canShoot.Append(() => !entity.GetIsDead().Value);
            canShoot.Append(() => entity.GetAmmo().Value > 0);
            canShoot.Append(() => actionByTimerBehaviour.CanPerformAction.Value);
            
            entity.AddCanShoot(canShoot);
        }
        
        private void InstallCanAddAmmoToMagazine(IEntity entity)
        {
            AndExpression canAddAmmoToMagazine = new();

            canAddAmmoToMagazine.Append(() => !entity.GetIsDead().Value);
            canAddAmmoToMagazine.Append(() => entity.GetAmmo().Value < entity.GetMaxAmmo().Value);
            
            entity.AddCanAddAmmoToMagazine(canAddAmmoToMagazine);
        }
    }
}