using Godot;
using LittleAdventurer.Scripts.Helper;
using LittleAdventurer.Scripts.State_Machine.Player;
using System;

public partial class SlideState_Player : State_Player
{
	private const float SLIDE_SPEED = 650.0f;
	private const float SLIDE_DURATION = 0.3f;
	private float _slideTimer;

    protected override void EnterState()
    {
		if (_stateMachine.CurrentState == this)
		{
			base.EnterState();
			_slideTimer = SLIDE_DURATION;
			Player.AnimPlayer.Play(AnimationConsts.Player.ROLL);
		}
    }


    protected override void UpdateState(float delta)
    {
		if (_stateMachine.CurrentState == this)
		{
			base.UpdateState(delta);

			_slideTimer -= delta;

			if (_slideTimer <= 0)
			{
				_stateMachine.SwitchStates<IdleState_Player>();
			}
		}
    }


    protected override void ExitState()
    {
		if (_stateMachine.CurrentState == this)
        {
			base.ExitState();
		}
    }
}
