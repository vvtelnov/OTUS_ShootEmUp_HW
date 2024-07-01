using System;
using UnityEngine;

namespace Components
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> HpEmpty;

        [SerializeField] private int _hitPoints;

        public void SetHitPoints(int hp)
        {
            _hitPoints = hp;
        }

        public void TakeDamage(int damage)
        {
            _hitPoints -= damage;
            if (_hitPoints <= 0)
            {
                HpEmpty?.Invoke(gameObject);
            }
        }
    }
}