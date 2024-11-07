using System;
using Atomic.Elements;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Behaviours.General
{
    public class ActionByTimerBehaviour : IEntityFixedUpdate , IEntityDispose
    {
        public readonly ReactiveVariable<bool> CanPerformAction = new();
        private readonly Cycle _cycle = new();
        private IEvent _onActionCompleted;

        public void Init(bool initState, float duration, IEvent onActionCompleted)
        {
            CanPerformAction.Value = initState;
            _onActionCompleted = onActionCompleted;
            
            _cycle.SetDuration(duration);
            _cycle.Start();
            
            _cycle.OnCycle += AllowAction;
            _onActionCompleted.OnEvent += RestartCycle;
        }

        void IEntityFixedUpdate.OnFixedUpdate(IEntity entity, float deltaTime)
        {
            _cycle.Tick(deltaTime);
        }

        void IEntityDispose.Dispose(IEntity entity)
        {
            _cycle.OnCycle -= AllowAction;
            _onActionCompleted.OnEvent -= RestartCycle;
            _cycle.Stop();
        }

        private void RestartCycle()
        {
            CanPerformAction.Value = false;
            _cycle.Stop();
            _cycle.Start();
        }

        private void AllowAction()
        {
            CanPerformAction.Value = true;
            _cycle.Stop();
        }
    }
}