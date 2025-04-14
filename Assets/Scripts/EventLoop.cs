using System;
using UnityEngine;

public class EventLoop : MonoBehaviour
{
    private bool playLoop = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        //FloatingPointError();
    }

    // Update is called once per frame
    private void Update()
    {
        Debug.Log($"Update: {Time.deltaTime}, {Time.fixedDeltaTime}");
    }

    private void LateUpdate()
    {
        Debug.Log($"Late Update: {Time.deltaTime}, {Time.fixedDeltaTime}");
    }

    private void FixedUpdate()
    {
        Debug.Log($"Fixed Update: {Time.deltaTime}, {Time.fixedDeltaTime}");
    }

    private void WhileLoop()
    {
        while (true)
        {
            Debug.Log("Looping...");
            if (playLoop) break;
        }
    }

    private void FloatingPointError()
    {
        var a = 0f;
        for (int i = 0; i < 100000; i++)
        {
            a += 0.01f;
        }

        var b = 0f;
        for (int i = 0; i < 100; i++)
        {
            b += 10f;
        }
        
        Debug.Log($"a: {a}, b: {b}");
    }
}
