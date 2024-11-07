using Atomic.Elements;

namespace Game.Scripts.UI.Health.Presenters
{
    public interface IHealthPresenter
    {
        public ReactiveVariable<int> HitPoints { get; }
        public ReactiveVariable<int> MaxHitPoints { get; }
    }
}