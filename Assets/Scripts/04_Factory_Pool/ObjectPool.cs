using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject pooledPrefab;
    private Stack<IPooled> objectPool;
    [SerializeField] private int poolSize;

    private void Start()
    {
        InitializePool(poolSize);
    }
    
    public void InitializePool(int size)
    {
        var pooled = pooledPrefab.GetComponent<IPooled>();
        if (pooled == null) return;
        objectPool = new Stack<IPooled>(size);
        
        for (int i = 0; i < size; i++)
        {
            IPooled pooledInstance = Instantiate(pooledPrefab).GetComponent<IPooled>();
            pooledInstance.Initialize(this);
            objectPool.Push(pooledInstance);
        }
    }

    public IPooled Release(Vector3 position)
    {
        IPooled pooledInstance;
        if (objectPool == null || objectPool.Count == 0)
        {
            pooledInstance = Instantiate(pooledPrefab).GetComponent<IPooled>();
            pooledInstance.Initialize(this);
        }
        else pooledInstance = objectPool.Pop();
        
        pooledInstance.Activate(position, pooledPrefab.transform.rotation);
        return pooledInstance;
    }
    
    public IPooled Release() => Release(transform.position);

    public void Return(IPooled pooledInstance)
    {
        objectPool.Push(pooledInstance);
    }
}
