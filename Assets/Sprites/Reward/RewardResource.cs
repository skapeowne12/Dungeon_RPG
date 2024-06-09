namespace Dungeon_RPG.Assets.Sprites.Reward
{
    using Dungeon_RPG.Scripts.Resources;

    using Godot;
    [GlobalClass]
    public partial class RewardResource : Resource
    {
        [Export]public Texture2D spriteTexture {get; private set;}
        [Export]public string Description {get; private set;}

        [Export]public Stat TargetStat {get; private set;}

        [Export(PropertyHint.Range,"1,100,1")]public float Amount {get; private set;}

    }
}