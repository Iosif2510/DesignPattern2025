using System;
using UnityEngine;
using UnityEngine.Events;

public class HealthData : MonoBehaviour
{
    [SerializeField] private int maxHealth = 100;
    private int currentHealth;
    
    public int CurrentHealth => currentHealth;

    public event UnityAction<int> onHealthChanged;
    public UnityEvent<int> onHealthChangedEvent = new();

    private void Start()
    {
        currentHealth = maxHealth;
    }

    protected void HealthChanged(int health)
    {
        onHealthChanged?.Invoke(health);
    }

    public void GetDamage(int damage)
    {
        if (damage > currentHealth) currentHealth = 0;
        else currentHealth -= damage;
        onHealthChanged?.Invoke(currentHealth);
        onHealthChangedEvent?.Invoke(currentHealth);
    }
}
