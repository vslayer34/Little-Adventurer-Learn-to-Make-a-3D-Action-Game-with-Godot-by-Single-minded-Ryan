using Godot;
using LittleAdventurer.Scripts.Resources;
using LittleAdventurer.Scripts.UI;
using System;


namespace LittleAdventurer.Scripts.Managers;
public partial class UIManager : Control
{
	[ExportCategory("Required Nodes")]
	[Export]
	public GameResources SharedResources { get; private set; }


	[ExportGroup("Child Nodes")]
	[Export]
	public UI_CoinHud CoinHud { get; private set; }



    // Game Loop Methods---------------------------------------------------------------------------
    public override void _Ready()
    {
        SharedResources.CoinAdded += CoinAdded_UpdateCoinHub;
    }

    public override void _ExitTree()
    {
        SharedResources.CoinAdded -= CoinAdded_UpdateCoinHub;
    }
    // Member Methods------------------------------------------------------------------------------

    /// <summary>
    /// Update the hud with the amount of collected coins
    /// </summary>
    /// <param name="amount"></param>
	private void CoinAdded_UpdateCoinHub(int amount)
	{
		CoinHud.CoinLabel.Text = amount.ToString();
	}
}
