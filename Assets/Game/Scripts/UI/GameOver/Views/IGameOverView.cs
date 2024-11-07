using Game.Scripts.UI.GameOver.Presenters;

namespace Game.Scripts.UI.GameOver.Views
{
    public interface IGameOverView
    {
        public void OnShow(IGameOverPresenter presenter);
    }
}