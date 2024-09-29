using System;
using System.Collections.Generic;
using Godot;
using LittleAdventurer.Scripts.State_Machine.Player;

namespace LittleAdventurer.Scripts.State_Machine;

public partial class StateMachine : Node3D
{
    [ExportCategory("Required Nodes")]
    [Export]
    public StateBase[] States { get; private set; }

    private StateBase _initialState;
    private StateBase _currentState;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        foreach (var state in States)
        {
            if (state is IdleState_Player idleState)
            {
                _initialState = idleState;
                _initialState.EnterState();
                _currentState = _initialState;
            }
        }
    }
}