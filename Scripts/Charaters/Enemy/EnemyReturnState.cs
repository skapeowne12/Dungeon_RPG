using Dungeon_RPG.Scripts.Charaters.Enemy;
using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class EnemyReturnState : EnemyState
{
    public override void _Ready()
    {
        base._Ready();
        destination = GetPointGlobalPosition(0);

    }
    protected override void EnterState()
    {
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);
        characterNode.AgentNode.TargetPosition = destination;
        characterNode.ChaseAreaNode.BodyEntered += HandleChaseAreaBodyEntered;
    }
    protected override void ExitState()
    {
        characterNode.ChaseAreaNode.BodyEntered -= HandleChaseAreaBodyEntered;
    }
    public override void _PhysicsProcess(double delta)
    {
        if(characterNode.AgentNode.IsNavigationFinished())
        {
            characterNode.StateMachineNode.SwitchStates<EnemyPatrolState>();
            return;
        }
        Move();

    }
}
