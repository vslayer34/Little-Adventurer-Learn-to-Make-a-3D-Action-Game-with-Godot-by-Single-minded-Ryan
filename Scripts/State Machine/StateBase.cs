using System;
using Godot;

namespace LittleAdventurer.Scripts.State_Machine;
public partial class StateBase : Node
{
    protected Character _character;

    protected StateMachine _stateMachine;



    // Member Methods------------------------------------------------------------------------------

    public override void _Ready()
    {
        _stateMachine = GetParent() as StateMachine;
    }

    public virtual void EnterState()
    {
        GD.Print($"{Name} entering state");
    }

    protected virtual void ExitState()
    {
        GD.Print($"{Name} exting state");
    }

    protected virtual void UpdateState(float delta)
    {

    }

    protected virtual void DisplayInfo()
    {
        GD.Print($"{Name} / {_character}");
    }
}