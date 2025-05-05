using UnityEngine;

public interface IPooled
{
    public ObjectPool Pool { get; }
    
    public void Initialize(ObjectPool pool);
    public void Activate(Vector3 position, Quaternion rotation);
    public void Return();
}
