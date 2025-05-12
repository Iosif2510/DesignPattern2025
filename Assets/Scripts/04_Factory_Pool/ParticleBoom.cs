using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBoom : MonoBehaviour, IProduct, IPooled
{
    [SerializeField] private string particleName;
    public string ProductName => particleName;
    public ObjectPool Pool { get; private set; }

    [SerializeField] private float lifeTime = 2f;
    private WaitForSeconds _waitForSeconds;
    
    public void Initialize(Vector2 position)
    {
        _waitForSeconds = new WaitForSeconds(lifeTime);
        transform.position = position;
    }
    
    public void Initialize(ObjectPool pool)
    {
        Pool = pool;
        gameObject.SetActive(false);
    }

    public void Activate(Vector3 position, Quaternion rotation)
    {
        gameObject.SetActive(true);
        GetComponent<ParticleSystem>().Play();
        StartCoroutine(DestroyAtTime());
    }

    public void Return()
    {
        gameObject.SetActive(false);
        GetComponent<ParticleSystem>().Stop();
        Pool.Return(this);
    }

    private IEnumerator DestroyAtTime()
    {
        yield return _waitForSeconds;
        Return();
    }
}
