using Godot;
using System;

namespace LittleAdventurer.Scripts.Resources;

public partial class GameResources : Resource
{
    [Export]
    public float CoinsCollected { get; private set; }



    // Member Methods------------------------------------------------------------------------------

    public void IncrementCoins(float amount) => CoinsCollected += amount;
}