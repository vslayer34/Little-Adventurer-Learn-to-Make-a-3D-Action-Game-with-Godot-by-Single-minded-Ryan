using Godot;
using LittleAdventurer.Scripts.Helper;
using LittleAdventurer.Scripts.State_Machine.Player;
using System;

public partial class AttackState_Player : State_Player
{
    protected override void EnterState()
    {
		if (_stateMachine.CurrentState == this)
		{
			base.EnterState();
			Player.AnimPlayer.Play(AnimationConsts.Player.ATTACK_01);
			Player.AnimPlayer.AnimationFinished += SwitchToIdle;
		}
    }


    protected override void UpdateState(float delta)
    {
		if (_stateMachine.CurrentState == this)
		{
			base.UpdateState(delta);
			if (Player.AnimPlayer.IsPlaying() == false)
			{
				// _stateMachine.SwitchStates<IdleState_Player>();
			}
		}
    }


    protected override void ExitState()
    {
		if (_stateMachine.CurrentState == this)
        {
			base.ExitState();
			Player.AnimPlayer.AnimationFinished -= SwitchToIdle;
		}
    }


	private void SwitchToIdle(StringName name) => _stateMachine.SwitchStates<IdleState_Player>();
}
