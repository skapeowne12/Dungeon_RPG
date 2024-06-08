using Dungeon_RPG.Scripts.Resources;
using Godot;
using System;

public partial class StatLabel : Label
{
    [Export]private StatResource stat;

    public override void _Ready()
    {
        stat.OnUpdate += HandleOnUpdate;
        Text = stat.StatValue.ToString();
    }

    private void HandleOnUpdate()
    {
        Text = stat.StatValue.ToString();
    }

}
