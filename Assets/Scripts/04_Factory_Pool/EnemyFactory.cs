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

    public override IProduct GetProduct(Vector3 position, Quaternion rotation)
    {
        var instance = Object.Instantiate(_enemyPrefab);
        //var instance = (IProduct)_pool.Release();
        instance.Initialize(position);
        return instance;
    }
    
    public IProduct GetProduct(Vector3 position)
    {
        return GetProduct(position, _enemyPrefab.transform.rotation);
    }
}