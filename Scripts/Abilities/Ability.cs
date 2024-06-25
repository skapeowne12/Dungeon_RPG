using Godot;

namespace Dungeon_RPG.Scripts.Abilities
{
    public partial class Ability : Node3D
    {
         [Export]public float damage {get;private set;} = 10;
         [Export]protected AnimationPlayer playerNode;
    }
}