using UnityEngine;

public class LazySingletonCaller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log($"Data: {UniversalLazySingleton.Instance.someData}");
    }
}
