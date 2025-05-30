using UnityEngine;

public class UniversalLazySingleton : MonoBehaviour
{
    private static UniversalLazySingleton instance;
    public static UniversalLazySingleton Instance
    {
        get
        {
            if (instance == null)
            {
                SetupInstance();
            }
            return instance;
        }
    }
    
    public int someData = 3;
    
    private static void SetupInstance()
    {
        if (instance != null) return;
        instance = FindAnyObjectByType<UniversalLazySingleton>();
        if (instance == null)
        {
            var managerObject = GameObject.Find("UniversalLazySingleton");
            if (managerObject == null)
            {
                managerObject = new GameObject
                {
                    name = "UniversalLazySingleton"
                };
            }
            instance = managerObject.AddComponent<UniversalLazySingleton>();
        }
        DontDestroyOnLoad(instance.gameObject);
        instance.Initialize();
    }

    private void Initialize()
    {
        
    }
    
    private void Awake()
    {
        if (Instance == this) return;
        if (Instance.gameObject != gameObject) Destroy(gameObject);
        else Destroy(this);
    }

}
