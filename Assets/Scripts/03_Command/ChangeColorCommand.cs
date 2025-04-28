using UnityEngine;

public class ChangeColorCommand : ICommand
{
    private Renderer targetRenderer;
    private Color previousColor;
    private Color newColor;
    
    public ChangeColorCommand(Renderer targetRenderer, Color newColor)
    {
        this.targetRenderer = targetRenderer;
        this.newColor = newColor;
        this.previousColor = targetRenderer.material.color;
    }
    
    public void Execute()
    {
        targetRenderer.material.color = newColor;
    }

    public void Undo()
    {
        targetRenderer.material.color = previousColor;
    }
}