using UnityEngine;

[RequireComponent(typeof(CommandTracker))]
public class MoveControl : MonoBehaviour
{
    private CommandTracker _commandTracker;
    private void Awake()
    {
        _commandTracker = GetComponent<CommandTracker>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            _commandTracker.Move(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            _commandTracker.Move(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            _commandTracker.Move(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            _commandTracker.Move(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            _commandTracker.Undo();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            _commandTracker.ChangeColor(Color.red);
        }
    }
}
