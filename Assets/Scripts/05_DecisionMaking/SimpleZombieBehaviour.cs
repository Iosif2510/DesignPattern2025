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
        //Debug.Log(_navMeshAgent.remainingDistance);
        switch (state)
        {
            case ZombieState.Idle:
                if (_action.TargetDistance <= _action.StartTrackDistance)
                {
                    state = ZombieState.Track;
                    return;
                }
                Idle();
                break;
            case ZombieState.Track:
                if (_action.TargetDistance > _action.StartTrackDistance)
                {
                    state = ZombieState.Idle;
                    return;
                }
                if (_action.TargetDistance <= _action.AttackDistance)
                {
                    state = ZombieState.Attack;
                    return;
                }
                Track();
                break;
            case ZombieState.Attack:
                if (_action.TargetDistance > _action.AttackDistance)
                {
                    state = ZombieState.Track;
                    return;
                }
                Attack();
                break;
            case ZombieState.Dead:
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
        _attackTimer = 0f;
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
