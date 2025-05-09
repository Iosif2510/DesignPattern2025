using UnityEngine;

public class SingletonCaller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        // if (SimpleSingleton.Instance == null) 
        // {
        //     // Unity 객체 수명 주기에 대한 묵시적 검사; Scene 전환으로 인한 파괴도 확인
        //     Debug.LogError("SimpleSingleton instance is null!");
        //     return;
        // }
        SimpleSingleton.Instance.DoSomething();
        // SimpleSingleton.Instance?.DoSomething();
        // if (SimpleSingleton.Instance != null)
        // {
        //     SimpleSingleton.Instance?.DoSomethingWithField();
        // }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SimpleSingleton.Instance.DoSomethingWithField();
            //SimpleSingleton.Instance?.DoSomethingWithField();
        }
    }
}
