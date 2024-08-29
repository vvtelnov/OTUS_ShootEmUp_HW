using System;
using Bullets;
using Character;
using Components;
using GameSystem.DependencySystem.DI;
using GameSystem.GameContext;
using UnityEngine;
using Utils;
using DeathObserver = Character.DeathObserver;

namespace Nodes
{
    [InjectionNeeded]
    public class CharacterNode : IGameReadyElement, IGameFinishElement
    {
        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private Character.Character _character;
        
        [Inject(DependencyResolvePrinciple.FROM_GAME_OBJECT, "Character")]
        private GameObject _charGameObject;
        
        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private Controller _controller;
        
        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private DeathObserver _deathObserver;
        
        [Inject(DependencyResolvePrinciple.FROM_CONFIG, "PlayerBullet")]
        private ScriptableObject _playerBulletConfig;

        [Inject(DependencyResolvePrinciple.CREATE_NEW_INSTANCE)]
        private AttackComponent _attackComponent;
        
        private readonly MoveComponent _moveComponent = new MoveComponent();
        private MonoHitPointsComponent _hitPointsComponent;

        private int _characterHp = 5;
        
        void IGameReadyElement.Ready()
        {
            ConstructNode();
        }

        void IGameFinishElement.Finish()
        {
            CleanupNode();
        }

        private void ConstructNode()
        {
            Rigidbody2D rb = _charGameObject.GetComponent<Rigidbody2D>();
            Transform firePoint = ChildGameObjectGetter.GetChildTransform(_charGameObject, "FirePoint");
            _hitPointsComponent = _charGameObject.GetComponent<MonoHitPointsComponent>();
            
            if (_playerBulletConfig is not BulletConfig config)
                throw new Exception("Wrong config is passed to CharacterNode");
            
            if (firePoint is null)
                throw new Exception("There is no FirePoint GameObject on CharacterNode");
            
            _hitPointsComponent.SetHitPoints(_characterHp);
            
            _moveComponent.Construct(rb);
            _attackComponent.Construct(config, firePoint);
            _deathObserver.Construct(_hitPointsComponent);
            _character.Construct(_moveComponent, _attackComponent);
            _controller.Construct(_character);
        }
        
        private void CleanupNode()
        {
            IGameElement.Unregister(this);
        }
    }
}