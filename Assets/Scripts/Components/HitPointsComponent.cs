using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class HitPointsComponent : MonoBehaviour
    {
        public event Action<GameObject> HpEmpty;

        [SerializeField] private int _hitPoints;

        public void SetHitPoints(int hp)
        {
            _hitPoints = hp;
        }

        public bool IsHitPointsExists()
        {
            return this._hitPoints > 0;
        }

        public void TakeDamage(int damage)
        {
            this._hitPoints -= damage;
            print("HP: " + this._hitPoints);
            if (this._hitPoints <= 0)
            {
                print("HP depleted");
                this.HpEmpty?.Invoke(this.gameObject);
            }
        }
    }
}