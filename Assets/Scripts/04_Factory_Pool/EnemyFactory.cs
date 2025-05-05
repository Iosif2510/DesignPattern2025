using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : Factory
{
    private readonly AircraftBrain _enemyPrefab;

    public EnemyFactory(AircraftBrain prefab)
    {
        _enemyPrefab = prefab;
    }

    public override IProduct GetProduct(Vector3 position, Quaternion rotation)
    {
        return Object.Instantiate(_enemyPrefab, position, rotation);
    }
    
    public IProduct GetProduct(Vector3 position)
    {
        return GetProduct(position, _enemyPrefab.transform.rotation);
    }
}