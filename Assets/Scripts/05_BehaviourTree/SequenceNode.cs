namespace BehaviourTree
{
    public class SequenceNode : CompositeNode
    {
        public SequenceNode(BehaviourNode parent) : base()
        {
        }

        public override NodeState Run()
        {
            foreach (var child in Children)
            {
                var state = child.Run();
                if (state is NodeState.Failure or NodeState.Running) return state;
            }

            return NodeState.Success;
        }
    }
}