using Dungeon_RPG.Scripts.Abilities;
using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class Bomb : Ability
{

    public override void _Ready()
    {
        playerNode.AnimationFinished += HandleExpandAnimationFinished;
    }

    private void HandleExpandAnimationFinished(StringName animName)
    {
        if (animName == GameConstants.ANIM_EXPAND)
        {
            playerNode.Play(GameConstants.ANIM_EXPLOSION);
        }
        else
        {
            QueueFree();
        }
    }

}
