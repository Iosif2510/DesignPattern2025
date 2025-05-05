using UnityEngine;

public class Bullet : MonoBehaviour, IPooled
{
    public ObjectPool Pool { get; private set; }
    [SerializeField] private float speed = 10f;
    [SerializeField] private float screenLimit = 6f;

    private void Update()
    {
        transform.Translate(Vector3.right * (speed * Time.deltaTime), Space.World);
        if (transform.position.x > screenLimit)
        {
            Return();
        }
    }

    public void Initialize(ObjectPool pool)
    {
        Pool = pool;
        gameObject.SetActive(false);
        transform.SetParent(pool.transform);
    }

    public void Activate(Vector3 position, Quaternion rotation)
    {
        transform.SetParent(null);
        transform.SetPositionAndRotation(position, rotation);
        gameObject.SetActive(true);
    }

    public void Return()
    {
        gameObject.SetActive(false);
        transform.SetParent(Pool.transform);
        Pool.Return(this);
    }
}