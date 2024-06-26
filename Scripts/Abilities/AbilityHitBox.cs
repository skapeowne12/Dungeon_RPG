using Dungeon_RPG.Scripts.Abilities;
using Dungeon_RPG.Scripts.Interfaces;
using Godot;
using System;

public partial class AbilityHitBox : Area3D, IHitbox
{
    public bool CanStun()
    {
        return true;
    }


    public float GetDamage()
    {
        return GetOwner<Ability>().damage;
    }
}
