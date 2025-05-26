using System;
using System.Collections.Generic;
using BehaviourTree;
using UnityEngine;
using UnityEngine.Events;

public class DelegateEvent : MonoBehaviour
{
    public delegate void SomeDelegate(int a, int b);
    public delegate bool CompareDelegate(float c, float d);
    
    private SomeDelegate someDelegate;
    private CompareDelegate compareDelegate;
    
    private Action<int, int> someAction;
    private Func<int, int, int> someFunc;
    
    private Action<int, bool, float, char, string, int, int, int, int> someActionWithParams;
    
    private UnityAction<int, int> someUnityAction;
    public UnityEvent<int, int> someUnityEvent;

    public int offset = 3;
    
    private void Start() {
        someDelegate += (a, b) => Debug.Log(a > b);
        someDelegate += SomeMethod;
        someDelegate?.Invoke(3, 4);
        someDelegate -= SomeMethod;
        someDelegate?.Invoke(5, 4);

        var execution = new ExecutionNode<DelegateEvent>(this, (d) =>
        {
            Debug.Log(d.offset);
        });

    }
    
    public void SomeMethod(int a, int b)
    {
        Debug.Log(a < b);
    }

    public void Do()
    {
        Debug.Log("Do");
    }
    
    public void DoSecond(string message)
    {
        Debug.Log(message);
    }

    
}
