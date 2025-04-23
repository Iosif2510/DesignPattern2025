using UnityEngine;

public class MoveCommand : ICommand
{
    private Vector2 direction;
    private Transform movingObject;

    private Vector3 threeDimensionalDirection => new (direction.x, 0, direction.y);

    public MoveCommand(Transform movingObject, Vector2 direction)
    {
        this.movingObject = movingObject;
        this.direction = direction;
    }

    public void Execute()
    {
        movingObject.Translate(threeDimensionalDirection);
    }

    public void Undo()
    {
        movingObject.Translate(-threeDimensionalDirection);
    }
}