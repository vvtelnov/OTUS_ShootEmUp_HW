using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.UI.Context;

namespace Game.Scripts.UI.Ammo.Presenters
{
    public class AmmoPresenter : IAmmoPresenter, IEntityInit
    {
        public ReactiveVariable<uint> Ammo { get; private set; }
        public ReactiveVariable<uint> MaxAmmo { get; private set; }

        void IEntityInit.Init(IEntity entity)
        {
            Ammo = entity.GetAmmo();
            MaxAmmo = entity.GetMaxAmmo();

            UIContext.Instance.GetAmmoView().OnShow(this);
        }
    }
}