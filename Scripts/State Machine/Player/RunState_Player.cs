using System;
using Godot;
using LittleAdventurer.Scripts.Helper;

namespace LittleAdventurer.Scripts.State_Machine.Player;
public partial class RunState_Player : State_Player
{
    protected override void EnterState(StateBase state)
    {
        if (state == this)
        {
            base.EnterState(state);
            Player.AnimPlayer.Play(AnimationConsts.Player.RUN);
        }
    }

    protected override void UpdateState(float delta)
    {
        if (Player.MoveDirection == Vector3.Zero)
        {
            _stateMachine.SwitchStates<IdleState_Player>();
            GD.Print("Switched to idle");
        }
    }
}