using Game.Scripts.UI.GameOver.Presenters;
using UnityEngine;

namespace Game.Scripts.UI.GameOver.Views
{
    public class GameOverView : MonoBehaviour, IGameOverView
    {
        [SerializeField] private GameObject _popup;
        
        public void OnShow(IGameOverPresenter presenter)
        {
            _popup.SetActive(true);
        }
    }
}