using GameSystem.DependencySystem.DI;
using GameSystem.GameContext;

namespace Nodes
{
    [InjectionNeeded]
    public class NodesCreator
    {
        [Inject(DependencyResolvePrinciple.FROM_CASHED_INSTANCE)]
        private CharacterNode _characterNode;
        
        [Inject(DependencyResolvePrinciple.CREATE_NEW_INSTANCE)]
        private StateController _stateController;
    }
}