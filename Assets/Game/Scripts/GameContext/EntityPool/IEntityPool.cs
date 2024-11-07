using Atomic.Entities;

namespace Game.Scripts.GameContext.EntityPool
{
    public interface IEntityPool
    {
        public SceneEntity Get();
        public void Return(IEntity entity);
    }
}