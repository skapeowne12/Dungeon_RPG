using Dungeon_RPG.Scripts.Charaters.Enemy;
using Dungeon_RPG.Scripts.General;
using Godot;
using System;
using System.Linq;

public partial class EnemyChaseState : EnemyState
{
    [Export]public Timer MovmentUpdateTimer {get;private set;}
    private CharacterBody3D target;
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);
        target = characterNode.ChaseAreaNode.GetOverlappingBodies().First() as CharacterBody3D;
        MovmentUpdateTimer.Timeout += HandelMovementUpdateTimer;
        characterNode.AttackAreaNode.BodyEntered += HanldeAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited += HandleChaseAreaBodyExited;
    }




    protected override void ExitState()
    {
        MovmentUpdateTimer.Timeout -= HandelMovementUpdateTimer;
        characterNode.AttackAreaNode.BodyEntered -= HanldeAttackAreaBodyEntered;
        characterNode.ChaseAreaNode.BodyExited -= HandleChaseAreaBodyExited;
    }

    private void HandelMovementUpdateTimer()
    {
        destination = target.GlobalPosition;
        characterNode.AgentNode.TargetPosition = destination;
    }


    public override void _PhysicsProcess(double delta)
    {
        Move();
    }
    private void HandleChaseAreaBodyExited(Node3D body)
    {
        characterNode.StateMachineNode.SwitchStates<EnemyReturnState>();
    }
}
