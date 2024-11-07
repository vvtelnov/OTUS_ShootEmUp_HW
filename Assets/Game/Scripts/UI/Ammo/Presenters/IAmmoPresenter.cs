using Atomic.Elements;

namespace Game.Scripts.UI.Ammo.Presenters
{
    public interface IAmmoPresenter
    {
        public ReactiveVariable<uint> Ammo { get; }
        public ReactiveVariable<uint> MaxAmmo { get; }
    }
}