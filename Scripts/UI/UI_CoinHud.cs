using Godot;
using System;


namespace LittleAdventurer.Scripts.UI;
/// <summary>
/// Reference to the UI elements in the HUB
/// </summary>
public partial class UI_CoinHud : HBoxContainer
{
	[ExportGroup("Child Nodes")]
	[Export]
	/// <summary>
	/// The label property of the coin hub
	/// </summary>
	public Label CoinLabel { get; private set; }
}