﻿

public class ZombieTrackState : IState
{
    private ZombieStateMachine _machine;
    private ZombieAction _zombie;

    public ZombieTrackState(ZombieStateMachine machine)
    {
        _machine = machine;
        _zombie = machine.Action;
    }
    
    public void Enter()
    {
        
    }

    public void Execute()
    {
        
        if (_zombie.TargetDistance > _zombie.StartTrackDistance)
        {
            _machine.TransitionTo(_machine.IdleState);
        }
        else if (_zombie.TargetDistance <= _zombie.AttackDistance)
        {
            _machine.TransitionTo(_machine.AttackState);
        }
        _zombie.StartTrack();
    }

    public void Exit()
    {
        _zombie.StopTrack();
    }
}