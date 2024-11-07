using Game.Scripts.UI.Health.Presenters;

namespace Game.Scripts.UI.Health.Views
{
    public interface IHealthAmountView
    {
        public void OnShow(IHealthPresenter healthPresenter);
    }
}