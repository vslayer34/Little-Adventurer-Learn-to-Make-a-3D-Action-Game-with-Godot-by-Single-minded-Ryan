using Godot;
using LittleAdventurer.Scripts.State_Machine.Player;
using System;

public partial class AttackState_Player : State_Player
{
	protected override void EnterState()
    {
		if (_stateMachine.CurrentState == this)
		{
			base.EnterState();
		}
    }


    protected override void UpdateState(float delta)
    {
		if (_stateMachine.CurrentState == this)
		{
			base.UpdateState(delta);
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
