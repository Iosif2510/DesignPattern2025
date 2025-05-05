using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject pooledPrefab;
    private Queue<IPooled> objectPool;
    [SerializeField] private int poolSize;

    private void Start()
    {
        InitializePool(poolSize);
    }
    
    public void InitializePool(int size)
    {
        var pooled = pooledPrefab.GetComponent<IPooled>();
        if (pooled == null) return;
        objectPool = new Queue<IPooled>(size);
        
        for (int i = 0; i < size; i++)
        {
            IPooled pooledInstance = Instantiate(pooledPrefab).GetComponent<IPooled>();
            pooledInstance.Initialize(this);
            objectPool.Enqueue(pooledInstance);
        }
    }

    public IPooled Release()
    {
        IPooled pooledInstance;
        if (objectPool == null || objectPool.Count == 0)
        {
            pooledInstance = Instantiate(pooledPrefab).GetComponent<IPooled>();
            pooledInstance.Initialize(this);
        }
        else pooledInstance = objectPool.Dequeue();
        
        pooledInstance.Activate(transform.position, pooledPrefab.transform.rotation);
        return pooledInstance;
    }

    public void Return(IPooled pooledInstance)
    {
        objectPool.Enqueue(pooledInstance);
    }
}
