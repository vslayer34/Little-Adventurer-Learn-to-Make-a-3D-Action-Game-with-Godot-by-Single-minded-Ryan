using System;
using Godot;

namespace LittleAdventurer.Scripts.State_Machine;
public partial class StateBase : Node3D
{
    private Character _character;

    private StateMachine _stateMachine;



    // Member Methods------------------------------------------------------------------------------

    private void EnterState()
    {
        GD.Print($"{Name} entering state");
    }

    private void ExitState()
    {
        GD.Print($"{Name} exting state");
    }

    private void UpdateState(float delta)
    {

    }

    private void DisplayInfo()
    {
        GD.Print($"{Name} / {_character}");
    }
}