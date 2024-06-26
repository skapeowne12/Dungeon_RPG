using Dungeon_RPG.Scripts.Charaters.Enemy;
using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class StunState : EnemyState
{

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_STUN);
        characterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinished;
    }
    protected override void ExitState()
    {
        characterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinished;
    }

    private void HandleAnimationFinished(StringName animName)
    {
        if(characterNode.AttackAreaNode.HasOverlappingBodies())
        {
            characterNode.StateMachineNode.SwitchStates<EnemyAttackState>();
        }
        else if (characterNode.ChaseAreaNode.HasOverlappingBodies())
        {
            characterNode.StateMachineNode.SwitchStates<EnemyChaseState>();    
        }
        else
        {
            characterNode.StateMachineNode.SwitchStates<EnemyIdleState>();
        }
    }
}
