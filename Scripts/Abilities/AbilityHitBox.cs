using Dungeon_RPG.Scripts.Abilities;
using Dungeon_RPG.Scripts.Interfaces;
using Godot;
using System;

public partial class BombHitBox : Area3D, IHitbox
{
    public float GetDamage()
    {
        return GetOwner<Ability>().damage;
    }
}
