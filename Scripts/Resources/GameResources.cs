using Godot;
using System;

namespace LittleAdventurer.Scripts.Resources;

public partial class GameResources : Resource
{
    [Signal]
    /// <summary>
    /// Emited when coins are added to the player
    /// </summary>
    /// <param name="coinAmount">The new amount of coins</param>
    public delegate void CoinAddedEventHandler(int coinAmount);

    [Export]
    public int CoinsCollected { get; private set; }



    // Member Methods------------------------------------------------------------------------------

    public void IncrementCoins(int amount)
    {
        CoinsCollected += amount;
        EmitSignal(SignalName.CoinAdded, CoinsCollected);
    }
}