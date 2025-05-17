using UnityEngine;

namespace BehaviourTree
{
    public class TimeCycleNode : DecoratorNode
    {
        private float _interval;
        private float timer;
        
        public TimeCycleNode(BehaviourNode parent, BehaviourNode child, float interval) : base(child)
        {
            _interval = interval;
            timer = 0;
        }

        public override NodeState Run()
        {
            if (timer >= _interval)
            {
                timer -= _interval;
                return Child.Run();
            }
            timer += Time.deltaTime;
            return NodeState.Running;
        }
    }
}