using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBounds : MonoBehaviour
    {
        [SerializeField]
        private Transform leftBorder;

        [SerializeField]
        private Transform rightBorder;

        [SerializeField]
        private Transform downBorder;

        [SerializeField]
        private Transform topBorder;


        // Information expert - поэтому оставляем метод InBounds;
        // Хотя, как я понял, нарушается SRP.
        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;

            // Здесь решил оставить без изменений по KISS, Хотя нарушается OCP
            // Потому что если еще добавятся границы, то придется дописывать класс.
            return positionX > this.leftBorder.position.x
                   && positionX < this.rightBorder.position.x
                   && positionY > this.downBorder.position.y
                   && positionY < this.topBorder.position.y;
        }
    }
}