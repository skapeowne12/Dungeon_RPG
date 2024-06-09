using Dungeon_RPG.Scripts.UI;
using Godot;
using System;

public partial class UIContainer : Container
{
    [Export]public ContainerType Container {get; private set;}

    [Export]public Button ButtonNode {get;private set;}
    [Export]public TextureRect TextureNode {get; private set;}
    [Export]public Label Lablenode {get;private set;}
}
