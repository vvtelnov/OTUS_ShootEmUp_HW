using Atomic.Elements;

namespace Game.Scripts.UI.Score.Presenters
{
    public interface IScorePresenter
    {
        public ReactiveVariable<int> Score { get; }
        public ReactiveVariable<uint> Rank { get; }
    }
}