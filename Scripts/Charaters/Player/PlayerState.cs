using System;
using Dungeon_RPG.Scripts;
using Dungeon_RPG.Scripts.Charaters;
using Dungeon_RPG.Scripts.General;
using Godot;
public abstract partial class PlayerState : CharacterState
    {
    public override void _Ready()
    {
        base._Ready();
        characterNode.GetStatResource(Dungeon_RPG.Scripts.Resources.Stat.Health).OnZero += HandelZeroHealth;
    }




    protected void CheckForAttackInput()
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_ATTACK))
        {
            characterNode.StateMachineNode.SwitchStates<PlayerAttackState>();
        }
    } 
    private void HandelZeroHealth()
    {
        characterNode.StateMachineNode.SwitchStates<PlayerDeathState>();
    }
    }
