

public class ZombieIdleState : IState
{
    private ZombieStateMachine _machine;
    private ZombieAction _zombie;

    public ZombieIdleState(ZombieStateMachine machine)
    {
        _machine = machine;
        _zombie = machine.Action;
    }
    
    public void Enter()
    {
        _zombie.StopTrack();
    }

    public void Update()
    {
        if (_zombie.TargetDistance <= _zombie.StartTrackDistance)
        {
            _machine.TransitionTo(_machine.TrackState);
        }
    }

    public void Exit()
    {
        
    }
}