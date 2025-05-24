using System;
using UnityEngine;

public class StateLogger : MonoBehaviour
{
    [SerializeField] private HealthData healthData;
    int previousHealth = 100;
    
    // private void Update()
    // {
    //     var currentHealth = healthData.CurrentHealth;
    //     if (previousHealth != currentHealth) LogHealth(currentHealth);
    // }

    private void Start()
    {
        healthData.onHealthChanged += LogHealth;
    }

    public void LogHealth(int health)
    {
        Debug.Log($"Current Health: {health}");
    }
}
