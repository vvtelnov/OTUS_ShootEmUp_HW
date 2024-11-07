using Atomic.Contexts;
using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.UI.Context;

namespace Game.Scripts.UI.Score.Presenters
{
    public class ScorePresenter : IScorePresenter, IEntityInit
    {
        public ReactiveVariable<int> Score { get; private set; }
        public ReactiveVariable<uint> Rank { get; private set; }

        void IEntityInit.Init(IEntity entity)
        {
            Score = entity.GetScore();

            UIContext.Instance.GetScoreView().OnShow(this);
        }
    }
}