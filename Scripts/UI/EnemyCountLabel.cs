using Dungeon_RPG.Scripts.General;
using Godot;
using System;

public partial class EnemyCountLabel : Label
{
    public override void _Ready()
    {
        GameEvents.OnNewEnemyCount += HandleOnNewEnemyCount;
    }

    private void HandleOnNewEnemyCount(int count)
    {
        Text = count.ToString();
    }

}
