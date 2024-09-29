using Godot;
using LittleAdventurer.Scripts.Resources;
using System;

public partial class Enemy : CharacterBody3D
{
	[ExportCategory("Required Nodes")]
	[Export]
	public GameResources SharedResources { get; private set; }
	[ExportCategory("")]

	[ExportGroup("Child Nodes")]
	[Export]
	public NavigationAgent3D Agent { get; private set; }
	[ExportGroup("")]

	public const float SPEED = 0.5f;
	private const float STOP_DISTANCE = 2.2f;
	private Vector3 _direction;



    // Game Loop Methods---------------------------------------------------------------------------

    public override async void _PhysicsProcess(double delta)
    {
		await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
		
		Agent.TargetPosition = SharedResources.Player.GlobalPosition;
		
		_direction = Agent.GetNextPathPosition() - GlobalPosition;
		_direction = _direction.Normalized();

		if (Agent.DistanceToTarget() < STOP_DISTANCE)
		{
			return;
		}

		Velocity = Velocity.Lerp(SPEED * _direction, (float)delta);

		MoveAndSlide();
    }

	// Member Methods------------------------------------------------------------------------------
}
