using Dungeon_RPG.Scripts.Charaters.Enemy;
using Dungeon_RPG.Scripts.General;
using Godot;
using System;
using System.Linq;

public partial class EnemyAttackState : EnemyState
{
    private Vector3 targetPosition;
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_ATTACK);
        Node3D target = characterNode.AttackAreaNode.GetOverlappingBodies().First();
        targetPosition = target.GlobalPosition;
        characterNode.AnimPlayerNode.AnimationFinished += HandleAnimationFinish;
    }
    protected override void ExitState()
    {
        characterNode.AnimPlayerNode.AnimationFinished -= HandleAnimationFinish;
    }

    private void HandleAnimationFinish(StringName animName)
    {
        characterNode.ToggleHitBox(true);

        Node3D target = characterNode.AttackAreaNode
            .GetOverlappingBodies()
            .FirstOrDefault();
        if (target == null)
        {
            Node3D chaseTarget = characterNode.ChaseAreaNode
                .GetOverlappingBodies()
                .FirstOrDefault();
            if (chaseTarget == null)
            {
                characterNode.StateMachineNode.SwitchStates<EnemyReturnState>();
            }

            characterNode.StateMachineNode.SwitchStates<EnemyChaseState>();
            return;
        }
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_ATTACK);
        targetPosition = target.GlobalPosition;
        Vector3 direction = characterNode.GlobalPosition
            .DirectionTo(targetPosition);
        characterNode.Spri3DNode.FlipH = direction.X < 0;
    }


    private void PreformHit()
    {
        characterNode.ToggleHitBox(false);
        characterNode.HitBoxNode.GlobalPosition = targetPosition;
    }
    
}
