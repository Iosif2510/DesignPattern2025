using System.Collections.Generic;
using UnityEngine;

public class EnemyFab : MonoBehaviour
{
    [SerializeField] private List<AircraftBrain> enemies;
    [SerializeField] private string enemyToCreateWithClick;
    [SerializeField] private ParticleBoom particlePrefab;
    private Dictionary<string, Factory> factories;
    private ObjectPool particlePool;
    private Camera _mainCamera;

    private void Start()
    {
        _mainCamera = Camera.main;
        factories = new Dictionary<string, Factory>(enemies.Count);
        particlePool = GetComponent<ObjectPool>();
        foreach (var enemy in enemies)
        {
            var factory = new EnemyFactory(enemy);
            factories.Add(enemy.ProductName, factory);
        }
        factories.Add(particlePrefab.ProductName, new ParticleFactory(particlePool));
    }
    
    private void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            CreateWithClick();
        }
    }

    public void CreateProduct(string productName, Vector3 position)
    {
        if (!factories.TryGetValue(productName, out var factory)) return;
        factory.GetProduct(position);
    }
    
    public void CreateWithClick()
    {
        var mousePos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        CreateProduct(enemyToCreateWithClick, mousePos);
    }
} 