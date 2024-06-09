using Dungeon_RPG.Assets.Sprites.Reward;
using Dungeon_RPG.Scripts.General;
using Dungeon_RPG.Scripts.UI;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
public partial class UIController : Control
{
    private Dictionary<ContainerType,UIContainer> contaniers;
    private bool canPause = false;
    public override void _Ready()
    {
        contaniers = GetChildren().Where((element) => element is UIContainer).Cast<UIContainer>().ToDictionary((elment) => elment.Container);

        contaniers[ContainerType.Start].Visible = true;

        contaniers[ContainerType.Start].ButtonNode.Pressed += HandlStartPuttonPressed;
        contaniers[ContainerType.Pause].ButtonNode.Pressed += HandlePauseButtonPressed;
        contaniers[ContainerType.Reward].ButtonNode.Pressed += HandleRewardButtonPressed;

        GameEvents.OnEndGame += HandleEndGame;
        GameEvents.OnVictory += HandleOnVictory;
        GameEvents.OnReward += HandleReward;
        
    }
    public override void _Input(InputEvent @event)
    {
        if (!canPause)
        {
            return;
        }
        if (!Input.IsActionJustPressed(GameConstants.INPUT_PAUSE))
        {
            return;
        }
        contaniers[ContainerType.Stats].Visible = GetTree().Paused;
        GetTree().Paused = !GetTree().Paused;
        contaniers[ContainerType.Pause].Visible = GetTree().Paused;
        
    }

    private void HandleOnVictory()
    {   
        canPause = false;
        contaniers[ContainerType.Stats].Visible = false;
        contaniers[ContainerType.Vicotry].Visible = true;
        GetTree().Paused = true;
    }


    private void HandleEndGame()
    {
        canPause = false;
        contaniers[ContainerType.Stats].Visible = false;
        contaniers[ContainerType.Defeat].Visible = true;
    }


    private void HandlStartPuttonPressed()
    {
        canPause = true;
        GetTree().Paused = false;
        contaniers[ContainerType.Start].Visible = false;
        contaniers[ContainerType.Stats].Visible = true;
        GameEvents.RaiseStartGame();
        
    }
    private void HandleReward(RewardResource resource)
    {
            canPause = false;
            GetTree().Paused = true;
            contaniers[ContainerType.Stats].Visible = false;
            contaniers[ContainerType.Reward].Visible = true;

            contaniers[ContainerType.Reward].TextureNode.Texture = resource.spriteTexture;
            contaniers[ContainerType.Reward].Lablenode.Text = resource.Description;


    }
    private void HandleRewardButtonPressed()
    {
            canPause = true;
            GetTree().Paused = false;
            contaniers[ContainerType.Stats].Visible = true;
            contaniers[ContainerType.Reward].Visible = false;
    }


    private void HandlePauseButtonPressed()
    {
        GetTree().Paused = false;
        contaniers[ContainerType.Pause].Visible = false;
        contaniers[ContainerType.Stats].Visible = true;
    }
}
