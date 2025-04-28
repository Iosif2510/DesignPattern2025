using System.Collections.Generic;
using UnityEngine;

public class CommandTracker : MonoBehaviour
{
    private Stack<ICommand> commands = new();
    
    public void Move(Vector2 direction)
    {
        var command = new MoveCommand(transform, direction);
        command.Execute();
        commands.Push(command);
    }

    public void ChangeColor(Color color)
    {
        var command = new ChangeColorCommand(GetComponent<Renderer>(), color);
        command.Execute();
        commands.Push(command);
    }
    
    public void Undo()
    {
        if (commands.Count <= 0) return;
        var command = commands.Pop();
        command.Undo();
    }
}
