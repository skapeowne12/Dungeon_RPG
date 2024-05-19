using Dungeon_RPG.Scripts.Charaters;
using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class Player : Character
{
    public override void _Input(InputEvent @event)
    {
           direction = Input.GetVector
        (
            GameConstants.INPUT_MOVE_LEFT,
            GameConstants.INPUT_MOVE_RIGHT,
            GameConstants.INPUT_MOVE_FORWARD,
            GameConstants.INPUT_Move_BACKWARD
        );

    }
}
