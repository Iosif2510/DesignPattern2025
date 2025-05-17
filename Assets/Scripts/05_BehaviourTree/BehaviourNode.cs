using System.Collections.Generic;
using UnityEngine;

namespace BehaviourTree
{
    [System.Serializable]
    public abstract class BehaviourNode
    {
        public enum NodeState
        {
            Running,
            Success,
            Failure
        }
    
        public BehaviourNode Parent { get; protected set; }

        protected internal void SetParent(BehaviourNode parent)
        {
            Parent = parent;
        }

        public abstract NodeState Run();
    }

}