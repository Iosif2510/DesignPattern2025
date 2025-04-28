using System;
using UnityEngine;

public abstract class GenericSingleton<T> : MonoBehaviour where T : GenericSingleton<T>
{
    private static T instance;
    public static T Instance
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
    
    private static void SetupInstance()
    {
        if (instance != null) return;
        instance = FindAnyObjectByType<T>();
        if (instance == null)
        {
            var managerObject = GameObject.Find("@Managers");
            if (managerObject == null)
            {
                managerObject = new GameObject
                {
                    name = "@Managers"
                };
            }
            instance = managerObject.AddComponent<T>();
            DontDestroyOnLoad(managerObject);
        }
        else DontDestroyOnLoad(instance.gameObject);

        instance.Init();
    }

    protected abstract void Init();
    
    private void Awake()
    {
        if (Instance == this) return;
        if (Instance.gameObject != gameObject) Destroy(gameObject);
        else Destroy(this);
    }
}
