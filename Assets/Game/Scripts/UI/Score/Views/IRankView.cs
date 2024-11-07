using UnityEngine;

namespace Game.Scripts.UI.Score.Views
{
    public interface IRankView
    {
        public void OnShow(Sprite rank);

        public void ChangeRank(Sprite rank);
    }
}