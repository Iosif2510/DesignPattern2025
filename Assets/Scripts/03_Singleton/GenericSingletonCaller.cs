using UnityEngine;

public class GenericSingletonCaller : MonoBehaviour
{
    private void Start()
    {
        Debug.Log($"{InheritedManager.Instance.SomeData}, {InheritedSingleton.Instance.someData2}");
    }
}