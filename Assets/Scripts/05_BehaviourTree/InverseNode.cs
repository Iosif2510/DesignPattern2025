namespace BehaviourTree
{
    public class InverseNode : DecoratorNode
    {
        public InverseNode(BehaviourNode parent, BehaviourNode child) : base(child)
        {
        }

        public override NodeState Run()
        {
            var state = Child.Run();
            return state switch
            {
                NodeState.Success => NodeState.Failure,
                NodeState.Failure => NodeState.Success,
                _ => state
            };
        }
    }
}