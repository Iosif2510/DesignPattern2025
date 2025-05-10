using UnityEngine;

public class EnemySpin : AircraftBrain
{
    [SerializeField] private float speed;
    [SerializeField] private float rotateSpeed;
    
    private void Awake()
    {
        _movement = GetComponent<AircraftMovement>();
        _movement.SetSpeed(speed);
    }

    private void Update()
    {
        _movement.Move(Vector2.left);
        transform.Rotate(Vector3.forward, rotateSpeed * Time.deltaTime);
    }
    
}
