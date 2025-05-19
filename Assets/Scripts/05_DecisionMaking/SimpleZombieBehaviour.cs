using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SimpleZombieBehaviour : MonoBehaviour
{
    public enum ZombieState
    {
        Idle,
        Track,
        Attack,
        Dead
    }
    

    [SerializeField] private ZombieState state = ZombieState.Idle;

    private ZombieAction _action;

    private float _attackTimer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        _action = GetComponent<ZombieAction>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (state != ZombieState.Dead && !_action.IsAlive)
        {
            state = ZombieState.Dead;
        }
        switch (state)
        {
            case ZombieState.Idle:
                if (_action.TargetDistance <= _action.StartTrackDistance)
                {
                    _attackTimer = 0f;
                    state = ZombieState.Track;
                    return;
                }
                Idle();
                break;
            case ZombieState.Track:
                if (_action.TargetDistance > _action.StartTrackDistance)
                {
                    state = ZombieState.Idle;
                    _action.StopTrack();
                    return;
                }
                if (_action.TargetDistance <= _action.AttackDistance)
                {
                    state = ZombieState.Attack;
                    _action.StopTrack();
                    return;
                }
                Track();
                break;
            case ZombieState.Attack:
                if (_action.TargetDistance > _action.AttackDistance)
                {
                    _attackTimer = 0f;
                    state = ZombieState.Track;
                    return;
                }
                Attack();
                break;
            case ZombieState.Dead:
                _action.StopTrack();
                _action.Die();
                return;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private void Idle()
    {
        _action.StopTrack();
    }

    private void Track()
    {
        
        _action.StartTrack();
    }
    
    private void Attack()
    {
        _action.StopTrack();
        
        _attackTimer += Time.deltaTime;
        if (_attackTimer < _action.AttackCooldown) return;
        _attackTimer -= _action.AttackCooldown;
        _action.Attack();

    }
}
