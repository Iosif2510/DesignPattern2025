using UnityEngine;

[RequireComponent(typeof(MoveTracker))]
public class MoveControl : MonoBehaviour
{
    private MoveTracker moveTracker;
    private void Awake()
    {
        moveTracker = GetComponent<MoveTracker>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            moveTracker.Move(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            moveTracker.Move(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            moveTracker.Move(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            moveTracker.Move(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            moveTracker.Undo();
        }
    }
}
