using System;
using System.Collections;
using Components;
using UnityEngine;

namespace Enemy.Agents
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public event Action OnDestinationReached;

        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private Vector2 _destination;
        [SerializeField] private float _destinationAccuracyValue = 0.25f;

        private Coroutine _moveCoroutine;
        
        public void SetDestination(Vector2 endPoint)
        {
            _destination = endPoint;

            MoveToDestination();
        }

        private void MoveToDestination()
        {
            if (_moveCoroutine != null)
                return;

            _moveCoroutine = StartCoroutine(MoveRotine());
        }

        private IEnumerator MoveRotine()
        {
            float routeMagnitude = (_destination - (Vector2)transform.position).magnitude;

            while (routeMagnitude > _destinationAccuracyValue)
            {
                _moveComponent.MoveToPoint(_destination);

                routeMagnitude = (_destination - (Vector2)transform.position).magnitude;

                yield return new WaitForFixedUpdate();
            }

            OnDestinationReached?.Invoke();

            _moveCoroutine = null;
        }
    }
}