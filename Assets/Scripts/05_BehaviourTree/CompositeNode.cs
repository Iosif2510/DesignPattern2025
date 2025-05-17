using System.Collections.Generic;

namespace BehaviourTree
{
    public abstract class CompositeNode : BehaviourNode
    {
        protected readonly List<BehaviourNode> Children = new();
        
        public void AddChild(BehaviourNode child)
        {
            Children.Add(child);
            child.SetParent(this);
        }

        public void ClearChildren()
        {
            Children.Clear();
        }
    }
}