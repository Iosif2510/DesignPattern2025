using System.Collections.Generic;
using UnityEngine;

public class MoveTracker : MonoBehaviour
{
    private Stack<MoveCommand> commands = new();
    
    public void Move(Vector2 direction)
    {
        var command = new MoveCommand(transform, direction);
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
