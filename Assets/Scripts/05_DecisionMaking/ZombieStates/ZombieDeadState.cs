

public class ZombieDeadState : IState
{
    private ZombieStateMachine _machine;
    private ZombieAction _zombie;

    public ZombieDeadState(ZombieStateMachine machine)
    {
        _machine = machine;
        _zombie = machine.Action;
    }
    
    public void Enter()
    {
        _zombie.Die();
    }

    public void Execute()
    {
        
    }

    public void Exit()
    {
        
    }
}