using UnityEngine;

public class EnemyStraight : AircraftBrain
{
    [SerializeField] private float speed;
    

    private void Awake()
    {
        _movement = GetComponent<AircraftMovement>();
        _movement.SetSpeed(speed);
    }

    private void Update()
    {
        _movement.Move(Vector2.left);
    }
}
