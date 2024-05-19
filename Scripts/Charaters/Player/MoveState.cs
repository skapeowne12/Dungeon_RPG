using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class MoveState : PlayerState
{
    [Export(PropertyHint.Range,"0,10,.1")]
    private float velocityMultiplyer = 5;
        public override void _PhysicsProcess(double delta)
    {
        if(characterNode.direction == Vector2.Zero)
        {
            characterNode.StateMachineNode.SwitchStates<IdleState>();
            return;
        }
        characterNode.Velocity = new(characterNode.direction.X,0,characterNode.direction.Y);
        characterNode.Velocity *= velocityMultiplyer;
        characterNode.MoveAndSlide();
        characterNode.flip();

    }
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            characterNode.StateMachineNode.SwitchStates<DashState>();
        }
    }
    protected override void EnterState()
    {
        base.EnterState();
        characterNode.AnimPlayerNode.Play(GameConstants.ANIM_MOVE);
    }
}
