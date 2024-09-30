using System;
using System.Collections.Generic;
using Godot;
using LittleAdventurer.Scripts.State_Machine.Player;

namespace LittleAdventurer.Scripts.State_Machine;

public partial class StateMachine : Node3D
{
    [Signal]
    public delegate void OnEnterStateEventHandler(StateBase state);

    [Signal]
    public delegate void OnExitStateEventHandler(StateBase state);

    [ExportCategory("Required Nodes")]
    [Export]
    public StateBase[] States { get; private set; }

    private StateBase _initialState;
    private StateBase _currentState;

    private Node _newState = new Node();



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        foreach (var state in States)
        {
            if (state is IdleState_Player idleState)
            {
                _initialState = idleState;
                state.ParentCharacter = GetParent() as Character;
            }
        }

        _currentState = _initialState;
        EmitSignal(SignalName.OnEnterState, _currentState);
    }

    // Member Methods------------------------------------------------------------------------------

    private void SwitchStates<T>() where T : StateBase
    {
        _newState = null;

        foreach (var state in States)
        {
            if (state is T)
            {
                _newState = state;
                break;
            }
        }

        if (_newState != null)
        {
            EmitSignal(SignalName.OnExitState, _currentState);
            _currentState = _newState as StateBase;
            EmitSignal(SignalName.OnEnterState, _currentState);
        }
    }
}