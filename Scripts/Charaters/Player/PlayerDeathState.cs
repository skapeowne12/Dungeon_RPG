using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class PlayerDeathState : PlayerState
{
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_DEATH);
        characterNode.AnimPlayerNode.AnimationFinished += HandleAnamationFinished;
    }

    private void HandleAnamationFinished(StringName animName)
    {
        GameEvents.RaiseEndGame();
        characterNode.QueueFree();
    }

}
