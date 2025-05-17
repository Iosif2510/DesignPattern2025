using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    public class SelectorNode : CompositeNode
    {
        public SelectorNode(BehaviourNode parent) : base()
        {
            
        }

        public override NodeState Run()
        {
            foreach (var child in Children)
            {
                var state = child.Run();
                if (state is NodeState.Success or NodeState.Running) return state;
            }

            return NodeState.Failure;
        }
    }
}
