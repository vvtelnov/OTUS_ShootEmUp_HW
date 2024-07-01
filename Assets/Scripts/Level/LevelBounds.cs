using UnityEngine;

namespace Level
{
    public sealed class LevelBounds : MonoBehaviour
    {
        [SerializeField]
        private Transform _leftBorder;

        [SerializeField]
        private Transform _rightBorder;

        [SerializeField]
        private Transform _downBorder;

        [SerializeField]
        private Transform _topBorder;


        //TODO: remove comments
        // Information expert - поэтому оставляем метод InBounds;
        // Хотя, как я понял, нарушается SRP.
        public bool InBounds(Vector3 position)
        {
            var positionX = position.x;
            var positionY = position.y;

            //TODO: remove comments
            // Здесь решил оставить без изменений по KISS, Хотя нарушается OCP
            // Потому что если еще добавятся границы, то придется дописывать класс.
            return positionX > _leftBorder.position.x
                   && positionX < _rightBorder.position.x
                   && positionY > _downBorder.position.y
                   && positionY < _topBorder.position.y;
        }
    }
}