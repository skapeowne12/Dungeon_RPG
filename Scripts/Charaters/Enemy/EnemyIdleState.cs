using Dungeon_RPG.Scripts.Charaters.Enemy;
using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class EnemyIdleState : EnemyState
{
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_IDLE);
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }
    protected override void ExitState()
    {
       characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }
    public override void _PhysicsProcess(double delta)
    {
        characterNode.StateMachineNode.SwitchStates<EnemyReturnState>();

    }
}
