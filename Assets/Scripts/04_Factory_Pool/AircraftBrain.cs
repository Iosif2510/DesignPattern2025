using UnityEngine;

public class AircraftBrain : MonoBehaviour, IProduct
{
    [SerializeField] private string aircraftName;
    public string ProductName => aircraftName;
}