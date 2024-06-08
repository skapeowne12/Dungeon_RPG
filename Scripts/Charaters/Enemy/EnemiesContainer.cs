using Dungeon_RPG.Scripts.General;
using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

public partial class EnemiesContainer : Node3D
{
    public override void _Ready()
    {
       int totalEnmies = GetChildCount();

       GameEvents.RaiseNewEnemyCount(totalEnmies);

       ChildExitingTree += HandleChidlExithingTree;

    }

    private void HandleChidlExithingTree(Node node)
    {
        int totalEnmies = GetChildCount() - 1;

       GameEvents.RaiseNewEnemyCount(totalEnmies);

       if (totalEnmies == 0)
       {
            GameEvents.RaiseOnVictory();
       }
    }

}
