using System;
using UnityEngine;

namespace Components
{
    public class MonoHitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> HpEmpty;

        private int _hitPoints;

        public void SetHitPoints(int hp)
        {
            _hitPoints = hp;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;
            if (_hitPoints <= 0)
            {
                HpEmpty?.Invoke(transform.gameObject);
            }
        }
    }
}