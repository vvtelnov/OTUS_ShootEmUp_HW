using System.Collections.Generic;
using Atomic.Entities;
using UnityEngine;

namespace Game.Scripts.Installers
{
    public class GameInstallPipeline : MonoBehaviour
    {
        [SerializeField] private List<SceneEntity> _installPipeline = new();

        public void Start()
        {
            foreach (var sceneEntity in _installPipeline)
            {
                sceneEntity.Install();
            }
        }
    }
}