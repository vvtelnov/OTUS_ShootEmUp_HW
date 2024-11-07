using Atomic.Contexts;
using Atomic.Entities;
using Game.Scripts.UI.Context;

namespace Game.Scripts.UI.GameOver.Presenters
{
    public class GameOverPresenter : IGameOverPresenter,
        IEntityInit, IEntityDispose
    {
        void IEntityInit.Init(IEntity entity)
        {
            entity.GetOnDeath().Subscribe(ShowGameOverPopup);
        }

        void IEntityDispose.Dispose(IEntity entity)
        {
            entity.GetOnDeath().Unsubscribe(ShowGameOverPopup);
        }

        private void ShowGameOverPopup(IEntity _)
        {
            UIContext.Instance.GetGameOverView().OnShow(this);
        }
    }
}