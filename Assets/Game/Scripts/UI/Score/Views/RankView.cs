using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Scripts.UI.Score.Views
{
    public class RankView : MonoBehaviour, IRankView
    { 
        [SerializeField] private Image _image;
        
        public void OnShow(Sprite rank)
        {
            _image.sprite = rank;
        }

        public void ChangeRank(Sprite rank)
        {
            _image.sprite = rank;
        }
    }
}