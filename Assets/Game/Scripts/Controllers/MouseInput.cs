using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.Behaviours;
using Game.Scripts.Behaviours.Rotation;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class MouseInput: IEntityInit, IEntityUpdate
    {
        private BaseEvent _onShootRequested;

        private RotationBehaviour _rotationBehaviour;
        private Camera _camera;
        private Transform _transform;
        
        private readonly string _shootButton = "Fire1";

        
        void IEntityInit.Init(IEntity entity)
        {
            _onShootRequested = entity.GetOnShootRequested();
            _rotationBehaviour = entity.GetBehaviour<RotationBehaviour>();
            _camera = Camera.main;
            _transform = entity.GetShootPoint(); 
        }

        void IEntityUpdate.OnUpdate(IEntity entity, float deltaTime)
        {
            Vector2 positionOnScreen = _camera.WorldToViewportPoint(_transform.position);
            Vector2 mouseOnScreen = _camera.ScreenToViewportPoint(Input.mousePosition);
            float angle = AngleBetweenTwoPoints(positionOnScreen, mouseOnScreen);

            SetRotateDirection(new Vector3(0f, angle, 0f));

            if (Input.GetButtonDown(_shootButton))
            {
                HandleShoot();
            }
        }
        
        private float AngleBetweenTwoPoints(Vector2 a, Vector2 b) 
        {
            return Mathf.Atan2(a.x - b.x, a.y - b.y) * Mathf.Rad2Deg + 180f;
        }

        private void SetRotateDirection(Vector3 vector3)
        {
            _rotationBehaviour.SetRotation(vector3);
        }

        private void HandleShoot()
        {
            _onShootRequested.Invoke();
        }
    }
}