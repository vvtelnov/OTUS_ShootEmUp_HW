using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Behaviours.Attack;
using Game.Scripts.Behaviours.General;
using Game.Scripts.Behaviours.Health;
using Game.Scripts.Behaviours.Movement;
using Game.Scripts.Behaviours.Rotation;
using Game.Scripts.Utils;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Scripts.GameContext.EnemySystem.Installers
{
    public class ZombieInstaller : SceneEntityInstallerBase
    {
        [Title("Movement")]
        [SerializeField] private float _moveSpeed;
        [SerializeField] private bool _hasInertness = true;
        [SerializeField] private float _acceleration;
        [SerializeField] private float _deceleration;
        [SerializeField] private float _followRadius;

        [Title("Attack")]
        [SerializeField] private int _attackDamage;
        [SerializeField] private float _attackRadius;
        [SerializeField] private float _attackRate;
        

        [Title("Health")]
        [SerializeField] private int _maxHitPoints;
        [SerializeField] private int _hitPoints;
        private readonly bool _isDead = false;
            

        public override void Install(IEntity entity)
        {
            SceneEntity zombieSystem = GameContext.Instance.GetZombieSystem();

            entity.AddEnemyTag();
            
            // Events
            entity.AddOnAttacked(new BaseEvent<int>());
            entity.AddOnDeath(new BaseEvent<IEntity>());
            entity.AddOnDamageIsTaken(new BaseEvent());
            
            // Transforms
            entity.AddTransform(this.transform);
            entity.AddTargetTransform(zombieSystem.GetTargetTransform());
            
            // Movement
            entity.AddMoveSpeed(_moveSpeed);
            entity.AddHasInertness(_hasInertness);
            entity.AddAcceleration(_acceleration);
            entity.AddDeceleration(_deceleration);
            entity.AddFollowRadius(_followRadius);
            
            // Attack
            entity.AddAttackDamage(_attackDamage);
            entity.AddAttackRate(_attackRate);
            entity.AddAttackRadius(_attackRadius);
            
            // Health
            entity.AddMaxHitPoints(_maxHitPoints);
            entity.AddHitPoints(_hitPoints);
            entity.AddIsDead(_isDead);

            //Conditions
            InstallCanMoveConditions(entity);
            InstallCanRotateConditions(entity);
            InstallCanTakeDamageConditions(entity);
            InstallCanAttackConditions(entity);
            
            InstallBehaviours(entity);
            
            EntityInstalledLogger.Instance.Log(entity);
        }
        
        private void InstallBehaviours(IEntity entity)
        {
            entity.AddBehaviour(new FollowUpBehaviour());
            entity.AddBehaviour(new MovementBehavior());
            entity.AddBehaviour(new LookAtBehaviour());
            entity.AddBehaviour(new AttackBehaviour());
            entity.AddBehaviour(new TakeDamageBehaviour());
            entity.AddBehaviour(new DeathBehaviour());
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
        
        private void InstallCanAttackConditions(IEntity entity)
        {
            ActionByTimerBehaviour actionByTimerBehaviour = new();
            BaseEvent onAttack = new BaseEvent();
            entity.GetOnAttacked().Subscribe((dmg) => onAttack.Invoke());
            
            actionByTimerBehaviour.Init(true, entity.GetAttackRate().Value, onAttack);
            entity.AddBehaviour(actionByTimerBehaviour);
            
            AndExpression canAttack = new();

            canAttack.Append(() => !entity.GetIsDead().Value);
            canAttack.Append(() => actionByTimerBehaviour.CanPerformAction.Value);

            entity.AddCanAttack(canAttack);
        }
    }
}