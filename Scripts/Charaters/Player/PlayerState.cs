using Dungeon_RPG.Scripts;
using Dungeon_RPG.Scripts.Charaters;
using Dungeon_RPG.Scripts.General;
using Godot;
public abstract partial class PlayerState : CharacterState
    {
        protected void CheckForAttackInput()
        {
            if (Input.IsActionJustPressed(GameConstants.INPUT_ATTACK))
            {
                characterNode.StateMachineNode.SwitchStates<PlayerAttackState>();
            }

        }
    }
