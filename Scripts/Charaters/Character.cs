namespace Dungeon_RPG.Scripts.Charaters
{
    using System;
    using Dungeon_RPG.Scripts.Resources;
    using System.Linq;

    using Godot;
    public abstract partial class Character : CharacterBody3D
    {
    [Export]private StatResource[] stats;
    [ExportGroup("Required Nodes")]
    [Export] public AnimationPlayer AnimPlayerNode {get; private set;}
    [Export] public Sprite3D Spri3DNode {get; private set;}
    [Export] public StateMachine StateMachineNode {get; private set;}
    [Export] public Area3D HurtBoxNode {get; private set;}
    [Export] public Area3D HitBoxNode {get; private set;}
    [Export] public CollisionShape3D HitBoxShapeNode {get; private set;}
    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode {get; private set;}
    [Export] public NavigationAgent3D AgentNode {get;private set;}
    [Export] public Area3D ChaseAreaNode {get; private set;}
    [Export] public Area3D AttackAreaNode {get; private set;}


    public Vector2 direction = new();
        public override void _Ready()
        {
            HurtBoxNode.AreaEntered += HandleHrutBoxEnterd;
        }

        private void HandleHrutBoxEnterd(Area3D area)
        {
            StatResource health = GetStatResource(Stat.Health);
            Character player = area.GetOwner<Character>();
            health.StatValue -= player.GetStatResource(Stat.Strength).StatValue;
            GD.Print(health.StatValue);
        }

        public StatResource GetStatResource(Stat stat)
        {
           return stats.Where((element) => element.StatType == stat).FirstOrDefault();
        }

        public void flip()
        {
            bool isNotMovingHorizontally = Velocity.X == 0;

            if(isNotMovingHorizontally){return;}

            bool isMovingLeft = Velocity.X < 0;
            Spri3DNode.FlipH = isMovingLeft;

        }
        public void ToggleHitBox(bool flag)
        {
            HitBoxShapeNode.Disabled = flag;
        }
    }
}