namespace Dungeon_RPG.Scripts.Charaters
{
    using System;
    using Dungeon_RPG.Scripts.Resources;
    using System.Linq;

    using Godot;
    using Dungeon_RPG.Scripts.Interfaces;


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
    [Export] public Timer HitShaderTimer {get; private set;}
    
    [ExportGroup("AI Nodes")]
    [Export] public Path3D PathNode {get; private set;}
    [Export] public NavigationAgent3D AgentNode {get;private set;}
    [Export] public Area3D ChaseAreaNode {get; private set;}
    [Export] public Area3D AttackAreaNode {get; private set;}
    

    private ShaderMaterial shader;


    public Vector2 direction = new();
        public override void _Ready()
        {
            shader = (ShaderMaterial)Spri3DNode.MaterialOverlay;
            HurtBoxNode.AreaEntered += HandleHrutBoxEnterd;
            Spri3DNode.TextureChanged += HandleTextureChanged;
            HitShaderTimer.Timeout += HandleHitShaderTimer;
        }

        private void HandleHitShaderTimer()
        {
            shader.SetShaderParameter(
                "active",false
            );
        }


        private void HandleHrutBoxEnterd(Area3D area)
        {
            if (area is not IHitbox hitbox)
            {
                return;
            }
            StatResource health = GetStatResource(Stat.Health);
            float damage = hitbox.GetDamage();
            health.StatValue -= damage;
            shader.SetShaderParameter(
                "active",true
            );
            HitShaderTimer.Start();
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
        private void HandleTextureChanged()
        {
            shader.SetShaderParameter(
                "tex", Spri3DNode.Texture
            );
        }

    }
}