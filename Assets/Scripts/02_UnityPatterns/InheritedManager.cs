using UnityEngine;

public class InheritedManager : GenericSingleton<InheritedManager>
{
    [SerializeField] private float someData;
    
    public float SomeData => someData;
}
