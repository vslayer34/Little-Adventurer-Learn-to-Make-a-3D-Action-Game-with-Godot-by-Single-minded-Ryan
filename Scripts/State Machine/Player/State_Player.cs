using System;
using Godot;
using LittleAdventurer.Scripts.Helper;
using LittleAdventurer.Scripts.Player;

namespace LittleAdventurer.Scripts.State_Machine.Player;

public partial class State_Player : StateBase
{
    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(InputMapConsts.UserDefined.SLIDE))
        {
            _stateMachine.SwitchStates<SlideState_Player>();
        }
    }
    // Getters and Setters-------------------------------------------------------------------------

    public PlayerCharacter Player { get => _character as PlayerCharacter; }
}
