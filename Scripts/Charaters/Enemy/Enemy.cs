using Dungeon_RPG.Scripts.Charaters;
using Dungeon_RPG.Scripts.Interfaces;
using Dungeon_RPG.Scripts.Resources;
using Godot;
using System;

public partial class Enemy : Character
{
    public override void _Ready()
    {
        base._Ready();
        
        HurtBoxNode.AreaEntered += HandleAreaEntered;
    }

    private void HandleAreaEntered(Area3D area)
    {
        if(area is not IHitbox hitbox)
        {
            return;
        }
        if(hitbox.CanStun() && GetStatResource(Stat.Health).StatValue != 0)
        {
            StateMachineNode.SwitchStates<StunState>();
        }
    }


}
