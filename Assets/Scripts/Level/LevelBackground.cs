using System;
using GameSystem;
using UnityEngine;

namespace Level
{
    public sealed class LevelBackground : MonoBehaviour,
        IGameInitElement, IFixedUpdateElement,
        IGameFinishElement
    {
        private float _startPositionY;

        private float _endPositionY;

        private float _movingSpeedY;

        private float _positionX;

        private float _positionZ;

        private Transform _myTransform;

        [SerializeField]
        private InitParams initParams;
        
        private void Awake()
        {
            // TODO: Change to a constructor method.
            // Я понимаю, что не следуют исплользовать Awake в задании, но решил такую реализацию сделать установки зависимостей
            IGameElement.Register(this);
        }

        void IGameInitElement.Init()
        {
            _startPositionY = initParams.StartPositionY;
            _endPositionY = initParams.EndPositionY;
            _movingSpeedY = initParams.MovingSpeedY;
            _myTransform = transform;
            var position = _myTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        void IFixedUpdateElement.FixedUpdateElement(float fixedDeltaTime)
        {
            if (_myTransform.position.y <= _endPositionY)
            {
                _myTransform.position = new Vector3(
                    _positionX,
                    _startPositionY,
                    _positionZ
                );
            }

            _myTransform.position -= new Vector3(
                _positionX,
                _movingSpeedY * fixedDeltaTime,
                _positionZ
            );
        }
        
        void IGameFinishElement.Finish()
        {
            IGameElement.Unregister(this);

            Destroy(gameObject);
        }

        [Serializable]
        public sealed class InitParams
        {
            [SerializeField]
            public float StartPositionY;

            [SerializeField]
            public float EndPositionY;

            [SerializeField]
            public float MovingSpeedY;
        }
    }
}