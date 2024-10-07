using System;
using Godot;

namespace LittleAdventurer.Scripts.State_Machine;
public partial class StateBase : Node
{
    // [Signal]
    // public delegate void OnEnterStateEventHandler(StateBase nextState);

    // [Signal]
    // public delegate void OnExitStateEventHandler(StateBase nextState);


    protected Character _character;

    protected StateMachine _stateMachine;



    // Member Methods------------------------------------------------------------------------------

    public override void _Ready()
    {
        _stateMachine = GetParent() as StateMachine;
        _stateMachine.OnEnterState += EnterState;
        _stateMachine.OnExitState += ExitState;

        SetPhysicsProcess(false);
        SetProcess(false);
    }

    public override void _Process(double delta)
    {
        UpdateState((float) delta);
    }


    public override void _ExitTree()
    {
        _stateMachine.OnEnterState -= EnterState;
        _stateMachine.OnExitState -= ExitState;
    }

    // Member methods------------------------------------------------------------------------------

    protected virtual void EnterState()
    {
        SetPhysicsProcess(true);
        SetProcess(true);

        GD.Print($"{Name} entering state");
    }

    protected virtual void ExitState()
    {
        SetPhysicsProcess(false);
        SetProcess(false);

        GD.Print($"{Name} exting state");
    }

    protected virtual void UpdateState(float delta)
    {

    }

    protected virtual void DisplayInfo()
    {
        GD.Print($"{Name} / {_character}");
    }

    // Getters and Setters-------------------------------------------------------------------------

    public Character ParentCharacter { get => _character; set => _character = value; }
}