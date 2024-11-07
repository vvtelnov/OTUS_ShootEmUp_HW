using Atomic.Elements;
using Atomic.Entities;

namespace Game.Scripts.Behaviours.Shoot
{
    public class AmmoMagazineBehaviour : IEntityInit, 
        IEntityFixedUpdate,
        IEntityDispose
    {
        private IEvent _onShot;
        // private BaseEvent _onIncrementAmmoCycleCompl
        
        private IEntity _entity;
        private ReactiveVariable<uint> _ammo;
        private float _reloadTime;
        private float _ammoRestoreTime;
        private readonly Timer _reloadTimer = new();
        private readonly Cycle _incrementAmmoCycle = new();
        private bool _isMagazineEmpty;
        
        void IEntityInit.Init(IEntity entity)
        {
            _onShot = entity.GetOnShot();
            _entity = entity;
            _ammo = entity.GetAmmo();
            _reloadTime = entity.GetReloadTime();
            _ammoRestoreTime = entity.GetAmmoRestoreTime();
            
            _reloadTimer.SetDuration(_reloadTime);
            _incrementAmmoCycle.SetDuration(_ammoRestoreTime);

            _onShot.Subscribe(DecrementAmmo);
            _reloadTimer.OnEnded += ReloadMagazine;
            _incrementAmmoCycle.OnCycle += IncrementAmmo;
        }

        void IEntityFixedUpdate.OnFixedUpdate(IEntity entity, float deltaTime)
        {
            if (_isMagazineEmpty)
            {
                _incrementAmmoCycle.Stop();
                _reloadTimer.Start();
                _reloadTimer.Tick(deltaTime);
                
                return;
            }
            
            _incrementAmmoCycle.Tick(deltaTime);
        }

        void IEntityDispose.Dispose(IEntity entity)
        {
            _onShot.Unsubscribe(DecrementAmmo);
        }

        private void IncrementAmmo()
        {
            if (!_entity.GetCanAddAmmoToMagazine().Invoke())
                return;
            
            _ammo.Value++;
        }
        
        private void DecrementAmmo()
        {
            _incrementAmmoCycle.Start();
            _ammo.Value--;
        }

        private void ReloadMagazine()
        {
            _incrementAmmoCycle.Start();
            IncrementAmmo();
        }
    }
}