using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    [SerializeField] private ObjectPool bulletPool;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            bulletPool.Release();
        }
    }
}
