using Dungeon_RPG.Scripts.Abilities;
using Godot;
using System;

public partial class lightning : Ability
{
    public override void _Ready()
    {
        playerNode.AnimationFinished += (animName) => QueueFree();
    }

}
