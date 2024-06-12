using Dungeon_RPG.Scripts.Charaters;
using Dungeon_RPG.Scripts.Interfaces;
using Dungeon_RPG.Scripts.Resources;
using Godot;
using System;

public partial class AttackHitbox : Area3D, IHitbox
{
    public float GetDamage()
    {
        return GetOwner<Character>().GetStatResource(Stat.Strength).StatValue;
    }
}
