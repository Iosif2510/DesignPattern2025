using UnityEngine;

public class AircraftMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private static (Vector2 min, Vector2 max) screenRestirctions = (new Vector2(-8.5f, -4.5f), new Vector2(8.5f, 4.5f));
    
    public void Move(Vector2 direction)
    {
        var nextPosition = new Vector2(
            Mathf.Clamp(transform.position.x + direction.x * speed * Time.deltaTime, screenRestirctions.min.x,
                screenRestirctions.max.x),
            Mathf.Clamp(transform.position.y + direction.y * speed * Time.deltaTime, screenRestirctions.min.y,
                screenRestirctions.max.y)
        );
        transform.position = nextPosition;
    }
    
    public void SetSpeed(float speed) => this.speed = speed;    
}
