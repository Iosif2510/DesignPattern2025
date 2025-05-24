using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    private List<GameObject> hearts = new(5);

    private void Start()
    {
        foreach (Transform child in transform)
        {
            hearts.Add(child.gameObject);
        }
        
    }

    public void ShowHealth(int health)
    {
        var heartCount = health switch
        {
            <= 0 => 0,
            <= 20 => 1,
            <= 40 => 2,
            <= 60 => 3,
            <= 80 => 4,
            _ => 5
        };
        for (var i = 0; i < 5; i++)
        {
            hearts[i].SetActive(i < heartCount);
        }
    }
}
