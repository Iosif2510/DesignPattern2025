using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class RequireOther : MonoBehaviour
{
    private Rigidbody rigidbody;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
}
