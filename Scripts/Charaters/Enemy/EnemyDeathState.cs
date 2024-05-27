using Dungeon_RPG.Scripts.Charaters.Enemy;
using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class EnemyDeathState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_DEATH);
        characterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        characterNode.QueueFree();
    }

}
