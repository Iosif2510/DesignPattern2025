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
        Attack
    }
    
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private Transform target;

    [SerializeField] private ZombieState state = ZombieState.Idle;
    
    [SerializeField] private float startTrackDistance = 5.0f;
    [SerializeField] private float attackDistance = 1.5f;
    [SerializeField] private float attackCooldown = 1.0f;

    private float _attackTimer = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.isStopped = true;
    }

    // Update is called once per frame
    private void Update()
    {
        //Debug.Log(_navMeshAgent.remainingDistance);
        switch (state)
        {
            case ZombieState.Idle:
                if (Vector3.Distance(transform.position, target.position) <= startTrackDistance)
                {
                    state = ZombieState.Track;
                    
                    return;
                }
                Idle();
                break;
            case ZombieState.Track:
                if (Vector3.Distance(transform.position, target.position) > startTrackDistance)
                {
                    state = ZombieState.Idle;
                    return;
                }
                if (Vector3.Distance(transform.position, target.position) < attackDistance)
                {
                    state = ZombieState.Attack;
                    return;
                }
                Track();
                break;
            case ZombieState.Attack:
                if (Vector3.Distance(transform.position, target.position) > attackDistance)
                {
                    state = ZombieState.Track;
                    return;
                }
                Attack();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    private void Idle()
    {
        _navMeshAgent.isStopped = true;
    }

    private void Track()
    {
        _attackTimer = 0f;
        _navMeshAgent.isStopped = false;
        _navMeshAgent.SetDestination(target.position);
    }
    
    private void Attack()
    {
        _navMeshAgent.isStopped = true;
        
        _attackTimer += Time.deltaTime;
        if (_attackTimer < attackCooldown) return;
        _attackTimer -= attackCooldown;
        Debug.Log("Attack!");

    }
}
