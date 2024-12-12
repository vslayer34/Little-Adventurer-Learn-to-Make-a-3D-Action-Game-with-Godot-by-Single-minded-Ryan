using Godot;
using LittleAdventurer.Scripts.Helper;
using LittleAdventurer.Scripts.State_Machine.Player;
using System;

public partial class AttackState_Player : State_Player
{
	[Export]
	public SwordVFXAnimator BladeVFXAnimator { get; private set; }

	[Export]
	public CollisionShape3D HitBoxCollider { get; private set; }



	// Member Methods------------------------------------------------------------------------------
    protected override void EnterState()
    {
		if (_stateMachine.CurrentState == this)
		{
			base.EnterState();
			Player.AnimPlayer.Play(AnimationConsts.Player.ATTACK_01);
			Player.AnimPlayer.AnimationFinished += SwitchToIdle;

			HitBoxCollider.Disabled = false;
			
			BladeVFXAnimator.BladeVFX1.Visible = true;
			BladeVFXAnimator.Stop();
			BladeVFXAnimator.Play(AnimationConsts.SwordVFX.AttackVFX);
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

			BladeVFXAnimator.BladeVFX1.Visible = false;
			HitBoxCollider.Disabled = true;
		}
    }

	public void DisableHitCollider(bool state)
	{
		HitBoxCollider.Disabled = state;
		GD.Print($"Hit box collider is disabled: {state}");
	}


	private void SwitchToIdle(StringName name) => _stateMachine.SwitchStates<IdleState_Player>();
}
