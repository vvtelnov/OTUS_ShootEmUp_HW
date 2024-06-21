using UnityEngine;

namespace ShootEmUp
{
    internal static class BulletFieldsSetter
    {
        internal static void SetBulletFields
        (
            Bullet bullet,
            Vector2 position,
            Vector2 direction,
            BulletConfig config
        )
        {
            bullet.SetPosition(position);
            bullet.SetColor(config.color);
            bullet.SetPhysicsLayer((int)config.physicsLayer);
            bullet.damage = config.damage;
            bullet.isPlayer = config.isPlayer;
            bullet.SetVelocity(direction * config.speed);
        }
    }
}
