using System;
using System.Collections;
using UnityEngine;

namespace Components
{
    // Монобех ради transform.position и корутины
    public class MonoMoveComponent : MonoBehaviour
    {
        public event Action OnDestinationReached;
        
        private Coroutine _moveCoroutine;
        private float _speed = 0.8f;
        private float _destinationAccuracyValue = 0.25f;
        private float _coroutineWaitTime = 0.02f;

        public void SetMoveSpeed(float speed)
        {
            _speed = speed;
        }

        public void SetDestinationAccuracyValue(float destinationAccuracyValue)
        {
            _destinationAccuracyValue = destinationAccuracyValue;
        }

        public void SetCoroutineWaitTime(float time)
        {
            _coroutineWaitTime = time;
        }
        
        public void MoveToPointInstantly(Vector2 destination)
        {
            transform.position = Vector2.MoveTowards(transform.position, destination, _speed);
        }
        
        public void MoveToPointWithCoroutine(Vector2 endPoint)
        {
            if (_moveCoroutine != null)
                return;

            _moveCoroutine = StartCoroutine(MoveRoutine(endPoint));
        }

        private IEnumerator MoveRoutine(Vector2 endPoint)
        {
            float routeMagnitude = (endPoint - (Vector2)transform.position).magnitude;

            while (routeMagnitude > _destinationAccuracyValue)
            {
                MoveToPointInstantly(endPoint);

                routeMagnitude = (endPoint - (Vector2)transform.position).magnitude;

                yield return new WaitForSeconds(_coroutineWaitTime);
            }

            OnDestinationReached?.Invoke();

            _moveCoroutine = null;
        }
    }
}