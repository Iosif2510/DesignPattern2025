

using UnityEngine;

public class ZombieAttackState : IState
{
    private ZombieStateMachine _machine;
    private ZombieAction _zombie;

    private float _attackTimer = 0f;

    public ZombieAttackState(ZombieStateMachine machine)
    {
        _machine = machine;
        _zombie = machine.Action;
    }
    
    public void Enter()
    {
        _attackTimer = 0f;
    }

    public void Execute()
    {
        if (_zombie.TargetDistance > _zombie.AttackDistance)
        {
            _machine.TransitionTo(_machine.TrackState);
            return;
        }
        if (_attackTimer >= _zombie.AttackCooldown)
        {
            _zombie.Attack();
            _attackTimer -= _zombie.AttackCooldown;
        }
        _attackTimer += Time.deltaTime;

    }

    public void Exit()
    {
        
    }
}