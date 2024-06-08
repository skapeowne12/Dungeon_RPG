using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class Camera : Camera3D
{
    [Export]public Node target;
    [Export]private Vector3 postionFromTarget;
    public override void _Ready()
    {
        GameEvents.OnStartGame += HandleStartGame;
        GameEvents.OnEndGame += HandleEndGame;
    }

    private void HandleEndGame()
    {
        // Reparent to Main Scene node
        Reparent(GetTree().CurrentScene);
    }


    private void HandleStartGame()
    {
        Reparent(target);
        Position = postionFromTarget;
    }

}
