using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : Factory
{
    private readonly AircraftBrain _enemyPrefab;
    private readonly ObjectPool _pool;

    public EnemyFactory(AircraftBrain prefab, ObjectPool pool = null)
    {
        _enemyPrefab = prefab;
        //_pool = pool;
    }

    public override IProduct GetProduct(Vector3 position)
    {
        var instance = Object.Instantiate(_enemyPrefab);
        //var instance = (IProduct)_pool.Release();
        instance.Initialize(position);
        return instance;
    }
}