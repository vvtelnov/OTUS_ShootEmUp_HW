using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Score.Presenters
{
    public class Ranks : MonoBehaviour
    {
        [SerializeField] private List<Sprite> _rankImages;

        public int CalculateRankIndex(int score)
        {
            switch (score)
            {
                case >= 20:
                    return 3;
                case >= 14:
                    return 2;
                case >= 6:
                    return 1;
                case >= 0:
                    return 0;
                default:
                    throw new Exception("Cannot calculate rack index based on score");
            }
        }

        public Sprite GetRankImage(int index)
        {
            return _rankImages[index];
        }
    }
}