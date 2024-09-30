using System;
using Godot;

namespace LittleAdventurer.Scripts.State_Machine.Player;
public partial class IdleState_Player : StateBase
{
    protected override void EnterState(StateBase state)
    {
        base.EnterState(state);
        GD.Print("Player entered Idle state");
    }
}
