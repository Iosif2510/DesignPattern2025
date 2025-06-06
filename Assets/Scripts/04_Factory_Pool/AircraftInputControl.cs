using UnityEngine;
using UnityEngine.Serialization;

public class AircraftInputControl : MonoBehaviour
{
    [FormerlySerializedAs("aircraftBehaviour")] [SerializeField] private AircraftMovement aircraftMovement;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W)) aircraftMovement.Move(Vector2.up);
        if (Input.GetKey(KeyCode.S)) aircraftMovement.Move(Vector2.down);
    }
}
