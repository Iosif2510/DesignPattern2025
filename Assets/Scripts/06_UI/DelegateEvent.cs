using System;
using UnityEngine;
using UnityEngine.Events;

public class DelegateEvent : MonoBehaviour
{
    public delegate void SomeDelegate(int a, int b);
    
    private SomeDelegate someDelegate;
    private Action<int, int> someAction;
    private Func<int, int, bool> someFunc;
    
    private UnityAction<int, int, int, int> someUnityAction;
    public UnityEvent<int, int> someUnityEvent;
    
    private void Start() {
        someDelegate += (a, b) => Debug.Log(a > b);
        someDelegate += SomeMethod;
        someDelegate?.Invoke(3, 4);
        someDelegate -= SomeMethod;
        someDelegate?.Invoke(5, 4);

        someUnityEvent = new UnityEvent<int, int>();
        someUnityEvent.AddListener((a, b) => Debug.Log(a == b));
        someUnityEvent.AddListener((a, b) => Debug.Log(a != b));
        someUnityEvent.Invoke(5, 5);
    }
    
    private void SomeMethod(int a, int b)
    {
        Debug.Log(a < b);
    }
}
