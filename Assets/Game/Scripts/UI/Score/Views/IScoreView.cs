using Game.Scripts.UI.Score.Presenters;

namespace Game.Scripts.UI.Score.Views
{
    public interface IScoreView
    {
        public void OnShow(IScorePresenter ammoPresenter);
    }
}