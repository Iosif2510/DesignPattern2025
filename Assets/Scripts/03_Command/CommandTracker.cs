using System.Collections.Generic;
using UnityEngine;

public class CommandTracker : MonoBehaviour
{
    private Dictionary<Vector2, MoveCommand> moveCommands = new();
    private Dictionary<Color, ChangeColorCommand> colorCommands = new();
    
    private Stack<ICommand> undoStack = new();
    private Stack<ICommand> redoStack = new();
    
    public void Move(Vector2 direction)
    {
        if (!moveCommands.TryGetValue(direction, out var command))
        {
            command = new MoveCommand(transform, direction);
            moveCommands.Add(direction, command);
        }
        command.Execute();
        undoStack.Push(command);
        redoStack.Clear();
    }

    public void ChangeColor(Color color)
    {
        if (!colorCommands.TryGetValue(color, out var command))
        {
            command = new ChangeColorCommand(GetComponent<Renderer>(), color);
            colorCommands.Add(color, command);
        }
        command.Execute();
        undoStack.Push(command);
        redoStack.Clear();
    }
    
    public void Undo()
    {
        if (undoStack.Count <= 0) return;
        var command = undoStack.Pop();
        command.Undo();
        redoStack.Push(command);
    }

    public void Redo()
    {
        if (redoStack.Count <= 0) return;
        var command = redoStack.Pop();
        command.Execute();
        undoStack.Push(command);
    }
}
