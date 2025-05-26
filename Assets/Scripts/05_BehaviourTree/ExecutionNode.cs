using System;
using UnityEngine.Events;

namespace BehaviourTree
{
    public class ExecutionNode<TData> : BehaviourNode
    {
        private readonly TData _data;
        private readonly UnityAction<TData> _onExecute;

        private readonly UnityAction onExecute;
        
        public ExecutionNode(TData data, UnityAction<TData> onExecute) : base()
        {
            _data = data;
            _onExecute = onExecute;
        }

        public override NodeState Run()
        {
            _onExecute?.Invoke(_data);
            return NodeState.Success;
        }
    }
}