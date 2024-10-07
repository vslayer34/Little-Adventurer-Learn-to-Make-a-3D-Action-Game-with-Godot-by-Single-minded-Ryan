using System;
using Godot;
using LittleAdventurer.Scripts.Helper;

namespace LittleAdventurer.Scripts.State_Machine.Player;
public partial class IdleState_Player : State_Player
{
    protected override void EnterState(StateBase state)
    {
        if (state == this)
        {
            base.EnterState(state);
            Player.AnimPlayer.Play(AnimationConsts.Player.IDLE);
        }
    }

    protected override void UpdateState(float delta)
    {
        if (Player.MoveDirection != Vector3.Zero)
        {
            _stateMachine.SwitchStates<RunState_Player>();
            GD.Print("Switched to run");
        }
    }
}