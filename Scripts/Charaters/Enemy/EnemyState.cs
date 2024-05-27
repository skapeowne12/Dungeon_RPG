

using System;
using Godot;

namespace Dungeon_RPG.Scripts.Charaters.Enemy
{
    public abstract partial class EnemyState: CharacterState
    {
        protected Vector3 destination;

        
    
        protected Vector3 GetPointGlobalPosition(int index)
        {
            Vector3 localPosition = characterNode.PathNode.Curve.GetPointPosition(index);
            Vector3 globalPosition = characterNode.PathNode.GlobalPosition;

            return localPosition + globalPosition;
        }
        protected void Move()
        {
            characterNode.AgentNode.GetNextPathPosition();
            characterNode.Velocity = characterNode.GlobalPosition.DirectionTo(destination);
            characterNode.MoveAndSlide();
            characterNode.flip();
        }
        public override void _Ready()
        {
            base._Ready();

            characterNode.GetStatResource(Resources.Stat.Health).OnZero += HandleZeroHealth;
        }
        protected void HandleChaseAreaBodyEntered(Node3D Body)
        {
            characterNode.StateMachineNode.SwitchStates<EnemyChaseState>();
        }
        protected void HanldeAttackAreaBodyEntered(Node3D Body)
        {
            characterNode.StateMachineNode.SwitchStates<EnemyAttackState>();
        }
        private void HandleZeroHealth()
        {
            characterNode.StateMachineNode.SwitchStates<EnemyDeathState>();
        }
    }
}