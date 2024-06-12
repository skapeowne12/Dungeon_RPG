using Dungeon_RPG.Scripts.Interfaces;
using Godot;
using System;

public partial class BombHitBox : Area3D, IHitbox
{
    public float GetDamage()
    {
        return GetOwner<Bomb>().damage;
    }
}
