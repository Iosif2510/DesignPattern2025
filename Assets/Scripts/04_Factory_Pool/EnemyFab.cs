using System.Collections.Generic;
using UnityEngine;

public class EnemyFab : MonoBehaviour
{
    [SerializeField] private List<AircraftBrain> enemies;
    [SerializeField] private string enemyToCreateWithClick;
    private Dictionary<string, EnemyFactory> factories;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
        factories = new Dictionary<string, EnemyFactory>(enemies.Count);
        foreach (var enemy in enemies)
        {
            var factory = new EnemyFactory(enemy);
            factories.Add(enemy.ProductName, factory);
        }
    }
    
    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateEnemyWithClick();
        }
    }

    public void CreateEnemy(string aircraftName, Vector3 position)
    {
        if (!factories.TryGetValue(aircraftName, out var factory)) return;
        factory.GetProduct(position);
    }
    
    public void CreateEnemyWithClick()
    {
        var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        CreateEnemy(enemyToCreateWithClick, mousePos);
    }
} 