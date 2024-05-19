using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class IdleState : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        if(base.characterNode.direction != Vector2.Zero)
        {
            base.characterNode.StateMachineNode.SwitchStates<MoveState>();
        }
        else
        {
            base.characterNode.Velocity = Vector3.Zero;
            base.characterNode.MoveAndSlide();
        }

    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            base.characterNode.StateMachineNode.SwitchStates<DashState>();
        }
    }
    protected override void EnterState()
    {
        base.EnterState();
        base.characterNode.AnimPlayerNode.Play(GameConstants.ANIM_IDLE);
    }
}
