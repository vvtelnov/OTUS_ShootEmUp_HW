using Atomic.Contexts;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.GameContext
{
    public class GameContextInstaller : SceneContextInstallerBase
    {
        [SerializeField] private SceneEntity _player;
        [SerializeField] private SceneEntity _bulletSystem;
        [SerializeField] private SceneEntity _zombieSystem;
        
        public override void Install(IContext context)
        {
            context.AddPlayer(_player);
            context.AddBulletSystem(_bulletSystem);
            context.AddZombieSystem(_zombieSystem);
        }
    }
}