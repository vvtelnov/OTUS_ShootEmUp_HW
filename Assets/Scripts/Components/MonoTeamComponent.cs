using UnityEngine;

namespace Components
{
    // Монобех, что бы пули могли понимать с кем коллизия: с врагом или персонажем 
    public sealed class MonoTeamComponent : MonoBehaviour
    {
        public bool IsPlayer
        {
            get { return isPlayer; }
        }

        [SerializeField]
        private bool isPlayer;
    }
}