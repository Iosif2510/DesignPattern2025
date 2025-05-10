using UnityEngine;

public interface IProduct
{
    public string ProductName { get; }
    public void Initialize(Vector2 position);
}
