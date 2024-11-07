using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.GameContext.EntityPool
{
    public sealed class SceneEntityPool : IEntityPool, IEntityInit
    {
        private SceneEntity _prefab;
        private Transform _worldContainer;
        private Transform _poolContainer;

        private readonly Queue<SceneEntity> _queue = new();

        public void Init(IEntity entity)
        {
            _prefab = entity.GetPrefab();
            _poolContainer = entity.GetPoolContainer();
            _worldContainer = entity.GetWorldContainer();

            for (int i = 0; i < entity.GetInitalCount(); i++)
            {
                SceneEntity sceneEntity = SceneEntity.Instantiate(this._prefab, this._poolContainer);
                _queue.Enqueue(sceneEntity);
            }
        }

        public SceneEntity Get()
        {
            if (this._queue.TryDequeue(out SceneEntity entity))
            {
                entity.transform.SetParent(this._worldContainer);
                return entity;
            }

            return SceneEntity.Instantiate(this._prefab, this._worldContainer);
        }

        public void Return(IEntity entity)
        {
            SceneEntity sceneEntity = SceneEntity.Cast(entity);
            sceneEntity.transform.SetParent(this._poolContainer);
            this._queue.Enqueue(sceneEntity);
        }
    }
}