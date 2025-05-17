using System;
using UnityEngine;

public class ZombieStateMachine : StateMachine
{
    public ZombieAction Action { get; private set; }
    
    public ZombieIdleState IdleState { get; private set; }
    public ZombieTrackState TrackState { get; private set; }
    public ZombieAttackState AttackState { get; private set; }
    public ZombieDeadState DeadState { get; private set; }

    private void Awake()
    {
        Action = GetComponent<ZombieAction>();
    }

    private void Start()
    {
        IdleState = new ZombieIdleState(this);
        TrackState = new ZombieTrackState(this);
        AttackState = new ZombieAttackState(this);
        DeadState = new ZombieDeadState(this);
        
        Initialize(IdleState);
    }

    protected override void Update()
    {
        if (!Action.IsAlive) TransitionTo(DeadState);
        base.Update();
    }
}
