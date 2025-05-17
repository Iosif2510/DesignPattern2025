using System;
using BehaviourTree;
using UnityEngine;

public class ZombieBehaviourTree : MonoBehaviour
{
    private ZombieAction _action;
    private BehaviourNode _root;

    private void Awake()
    {
        _action = GetComponent<ZombieAction>();
        InitializeTree();
    }

    private void Update()
    {
        _root.Run();
    }

    private void InitializeTree()
    {
        var selector = new SelectorNode(null);
        
        var deadNode = new ExecutionNode<ZombieAction>(_action, (action) =>
        {
            action.Die();
        });
        
        var idleNode = new ExecutionNode<ZombieAction>(_action, (action) =>
        {
            Debug.Log("Idle");
            action.StopTrack();
        });
        var trackNode = new ExecutionNode<ZombieAction>(_action, (action) =>
        {
            Debug.Log("Track");
            action.StartTrack();
        });
        
        var attackNode = new ExecutionNode<ZombieAction>(_action, (action) =>
        {
            Debug.Log("Attack");
            action.StopTrack();
            action.Attack();
        });
        var attackCycle = new TimeCycleNode(selector, attackNode, _action.AttackCooldown);

        selector.AddChild(new IfNode<ZombieAction>(selector, deadNode, 
            _action, (action) => !action.IsAlive));
        selector.AddChild(new IfNode<ZombieAction>(selector, attackCycle,
            _action, (action) => action.TargetDistance <= action.AttackDistance));
        selector.AddChild(new IfNode<ZombieAction>(selector, trackNode,
            _action, (action) => action.TargetDistance <= action.StartTrackDistance));
        selector.AddChild(idleNode);
        
        _root = selector;
    }
}