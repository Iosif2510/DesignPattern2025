using UnityEngine;

public class AttackLogic : MonoBehaviour
{
    [SerializeField] private HealthData healthData;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack(healthData, 10);
        }
    }
    
    public void Attack(HealthData target, int damage)
    {
        if (target == null) return;
        target.GetDamage(damage);
    }
}
