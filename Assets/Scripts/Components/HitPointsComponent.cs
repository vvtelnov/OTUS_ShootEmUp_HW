using System;
using UnityEngine;

namespace Components
{
    public sealed class HitPointsComponent
    {
        public event Action<GameObject> HpEmpty;

        private GameObject _thisGameObject;
        private int _hitPoints;

        public void Construct(GameObject thisGameObject ,int hp)
        {
            _thisGameObject = thisGameObject;
            _hitPoints = hp;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;
            if (_hitPoints <= 0)
            {
                HpEmpty?.Invoke(_thisGameObject);
            }
        }
    }
}