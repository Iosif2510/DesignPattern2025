using UnityEngine;

public class AircraftBrain : MonoBehaviour, IProduct
{
    [SerializeField] private string aircraftName;
    public string ProductName => aircraftName;
    protected AircraftMovement _movement;
    
    public void Initialize(Vector2 position)
    {
        transform.position = position;
    }
}