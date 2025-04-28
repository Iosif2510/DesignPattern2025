using UnityEngine;

public class SimpleSingleton : MonoBehaviour
{
    [SerializeField] private int someField;
    
    private static SimpleSingleton instance;
    public static SimpleSingleton Instance => instance;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else Destroy(gameObject);
    }
    
    public void DoSomething()
    {
        Debug.Log("Singleton instance is doing something!");
    }

    public void DoSomethingWithField()
    {
        Debug.Log($"Singleton instance's field value: {someField}");
    }
}
