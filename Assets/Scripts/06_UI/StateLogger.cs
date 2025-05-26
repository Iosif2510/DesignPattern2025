using System;
using UnityEngine;

public class StateLogger : MonoBehaviour
{
    [SerializeField] private HealthData healthData;
    int previousHealth = 100;

    private void Start()
    {
        healthData.onHealthChanged += LogHealth;
        //healthData.onHealthChanged(5);
    }

    // private void Update()
    // {
    //     var currentHealth = healthData.CurrentHealth;
    //     if (currentHealth != previousHealth) LogHealth(currentHealth);
    //     previousHealth = currentHealth;
    // }

    private void LogHealth(int health)
    {
        Debug.Log($"Current Health: {health}");
    }
}
