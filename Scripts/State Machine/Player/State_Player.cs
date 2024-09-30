using System;
using LittleAdventurer.Scripts.Player;

namespace LittleAdventurer.Scripts.State_Machine.Player;

public partial class State_Player : StateBase
{
    // Getters and Setters-------------------------------------------------------------------------

    public PlayerCharacter Player { get => _character as PlayerCharacter; }
}
