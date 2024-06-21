using System;
using System.Collections;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyMoveAgent : MonoBehaviour
    {
        public event Action OnDestinationReached;
        public bool IsReached
        {
            get { return this.isReached; }
        }

        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private Vector2 _destination;
        [SerializeField] private float _destinationAccuracyValue = 0.25f;

        private bool isReached;
        private Coroutine MoveCoroutine;


        public void SetDestination(Vector2 endPoint)
        {
            this._destination = endPoint;
            this.isReached = false;

            MoveToDestination();
        }

        public void MoveToDestination()
        {
            if (MoveCoroutine != null)
                return;

            MoveCoroutine = StartCoroutine(MoveRotine());
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

            isReached = true;
            OnDestinationReached?.Invoke();

            MoveCoroutine = null;
            yield break;
        }
    }
}