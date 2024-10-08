using System;
using Godot;
using LittleAdventurer.Scripts.Helper;

namespace LittleAdventurer.Scripts.State_Machine.Player;
public partial class RunState_Player : State_Player
{
    protected override void EnterState()
    {
        if (_stateMachine.CurrentState != this)
        {
            return;
        }

        base.EnterState();
        Player.AnimPlayer.Play(AnimationConsts.Player.RUN);
        Player.VFXReference.FootStepsVFX.Emitting = true;
    }

    protected override void UpdateState(float delta)
    {
        if (Player.MoveDirection == Vector3.Zero)
        {
            _stateMachine.SwitchStates<IdleState_Player>();
            GD.Print("Switched to idle");
        }
    }

    protected override void ExitState()
    {
        if (_stateMachine.CurrentState != this)
        {
            return;
        }
        
        base.ExitState();
        Player.VFXReference.FootStepsVFX.Emitting = false;
    }
}