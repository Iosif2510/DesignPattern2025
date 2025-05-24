using UnityEngine;

public class UpdateHealth : MonoBehaviour
{
    [SerializeField] private HealthData healthData;
    [SerializeField] private HealthUI healthUI;

    private void Awake()
    {
        healthData.onHealthChanged += ShowHealth;
    }

    private void ShowHealth(int health)
    {
        healthUI.ShowHealth(health);
    }
}
