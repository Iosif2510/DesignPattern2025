using System;

namespace BehaviourTree
{
    public class IfNode<TData> : DecoratorNode
    {
        private readonly TData _data;
        private readonly Func<TData, bool> _evaluate;
        
        public IfNode(BehaviourNode parent, BehaviourNode onTrue, TData data, Func<TData, bool> evaluate) : base(onTrue)
        {
            _evaluate = evaluate;
            _data = data;
        }

        public override NodeState Run()
        {
            return _evaluate(_data) ? Child.Run() : NodeState.Failure;
        }
    }
}