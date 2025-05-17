using System;
using UnityEngine;
using UnityEngine.AI;

public class ZombieAction : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    [SerializeField] private float startTrackDistance = 5.0f;
    [SerializeField] private float attackDistance = 1.5f;
    [SerializeField] private float attackCooldown = 1.0f;

    [SerializeField] private bool isAlive = true;
    
    public NavMeshAgent NavMeshAgent { get; private set; }
    
    public float StartTrackDistance => startTrackDistance;
    public float AttackDistance => attackDistance;
    public float AttackCooldown => attackCooldown;
    public bool IsAlive => isAlive;
    
    public float TargetDistance => Vector3.Distance(transform.position, target.position);

    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
    }

    public void StartTrack()
    {
        NavMeshAgent.isStopped = false;
        NavMeshAgent.SetDestination(target.position);
    }

    public void StopTrack()
    {
        NavMeshAgent.isStopped = true;
    }
    
    public void Attack()
    {
        Debug.Log("Attack!");
    }

    public void Die()
    {
        Debug.Log("Died!");
    }
}
