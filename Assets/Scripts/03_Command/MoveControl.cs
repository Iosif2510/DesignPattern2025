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
            Debug.Log("W");
            _commandTracker.Move(Vector2.up);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Debug.Log("S");
            _commandTracker.Move(Vector2.down);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            _commandTracker.Move(Vector2.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
            _commandTracker.Move(Vector2.right);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Z");
            _commandTracker.Undo();
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            Debug.Log("Y");
            _commandTracker.Redo();
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
            _commandTracker.ChangeColor(Color.red);
        }
    }
}
