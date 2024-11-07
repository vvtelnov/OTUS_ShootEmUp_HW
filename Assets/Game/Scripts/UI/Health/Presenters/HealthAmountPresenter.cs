using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.UI.Context;

namespace Game.Scripts.UI.Health.Presenters
{
    public class HealthPresenter : IHealthPresenter, 
        IEntityInit
    {
        public ReactiveVariable<int> HitPoints { get; private set; }
        public ReactiveVariable<int> MaxHitPoints { get; private set; }

        void IEntityInit.Init(IEntity entity)
        {
            HitPoints = entity.GetHitPoints();
            MaxHitPoints = entity.GetMaxHitPoints();

            UIContext.Instance.GetHitPointsView().OnShow(this);
        }
    }
}