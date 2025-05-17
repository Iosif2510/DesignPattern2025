namespace BehaviourTree
{
    public abstract class DecoratorNode : BehaviourNode
    {
        protected readonly BehaviourNode Child;
        
        protected DecoratorNode(BehaviourNode child) : base()
        {
            Child = child;
            child.SetParent(this);
        }
    }
}