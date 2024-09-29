using Godot;
using LittleAdventurer.Scripts;
using LittleAdventurer.Scripts.Helper;
using LittleAdventurer.Scripts.Resources;
using System;

public partial class Enemy : Character
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
	private Vector2 _lookDirection;



    // Game Loop Methods---------------------------------------------------------------------------

    public override async void _PhysicsProcess(double delta)
    {
		await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
		
		Agent.TargetPosition = SharedResources.Player.GlobalPosition;
		
		_direction = Agent.GetNextPathPosition() - GlobalPosition;
		_direction = _direction.Normalized();

		if (Agent.DistanceToTarget() < STOP_DISTANCE)
		{
			AnimPlayer.Play(AnimationConsts.Enemy.IDLE);
			return;
		}

		Velocity = Velocity.Lerp(SPEED * _direction, (float)delta);
		AnimPlayer.Play(AnimationConsts.Enemy.WALK);

		// Transform3D targetTransform = EnemyMesh.Transform;
		// targetTransform.Basis = Basis.FromEuler(new Vector3(0.0f, _direction.Y, 0.0f));

		// EnemyMesh.Transform = targetTransform;

		// EnemyMesh.LookAt(_direction);

		if (Velocity.Length() > 0.2f)
		{
			_lookDirection = new Vector2(Velocity.Z, Velocity.X);
			Mesh.Rotation = new Vector3(Mesh.Rotation.X, _lookDirection.Angle(), Mesh.Rotation.Z);
		}

		MoveAndSlide();
    }

	// Member Methods------------------------------------------------------------------------------
}
