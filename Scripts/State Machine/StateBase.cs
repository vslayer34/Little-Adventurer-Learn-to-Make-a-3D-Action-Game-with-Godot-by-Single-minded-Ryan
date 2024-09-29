using System;
using Godot;

namespace LittleAdventurer.Scripts.State_Machine;
public partial class StateBase : Node
{
    protected Character _character;

    protected StateMachine _stateMachine;



    // Member Methods------------------------------------------------------------------------------

    protected void EnterState()
    {
        GD.Print($"{Name} entering state");
    }

    protected void ExitState()
    {
        GD.Print($"{Name} exting state");
    }

    protected void UpdateState(float delta)
    {

    }

    protected void DisplayInfo()
    {
        GD.Print($"{Name} / {_character}");
    }
}