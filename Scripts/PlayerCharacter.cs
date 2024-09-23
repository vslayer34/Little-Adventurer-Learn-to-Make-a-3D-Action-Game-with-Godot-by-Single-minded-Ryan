using Godot;
using System;
using System.Threading.Tasks;

public partial class PlayerCharacter : CharacterBody3D
{
	[ExportGroup("Required Nodes")]
	[Export]
	public Node3D Visual { get; private set; }


	public const float SPEED = 5.0f;
	public const float JUMP_VELOCITY = 4.5f;

	private Vector2 _lookDirection;

	private bool _isMoving;

	public override void _PhysicsProcess(double delta)
	{
		Vector3 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
			velocity.Y -= 1.0f;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 inputDir = Input.GetVector(
			InputMapConsts.UserDefined.MOVE_LEFT, 
			InputMapConsts.UserDefined.MOVE_RIGHT, 
			InputMapConsts.UserDefined.MOVE_UP, 
			InputMapConsts.UserDefined.MOVE_DOWN
			);
		
		Vector3 direction = (Transform.Basis * new Vector3(inputDir.X, 0, inputDir.Y)).Normalized();
		
		if (direction != Vector3.Zero)
		{
			velocity.X = direction.X * SPEED;
			velocity.Z = direction.Z * SPEED;
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, SPEED);
			velocity.Z = Mathf.MoveToward(Velocity.Z, 0, SPEED);
		}

		if (velocity.Length() > 0.2f)
		{
			_lookDirection.X = velocity.Z;
			_lookDirection.Y = velocity.X;

			_isMoving = true;
			
			RotateCharacterAsync((float)delta);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private async void RotateCharacterAsync(float delta)
	{
		if (!_isMoving)
		{
			return;
		}

		float turnTimer = 0.0f;
		const float TURN_TIME = 0.15f;


		Transform3D currentTransform = Visual.Transform;
		Transform3D modifyableTransforn = currentTransform;

		modifyableTransforn.Basis = Basis.FromEuler(new Vector3(0.0f, _lookDirection.Angle(), 0.0f));
		Transform3D targetTransform = modifyableTransforn;
		

		while (turnTimer < TURN_TIME)
		{
			turnTimer += delta;

			await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);

			// Visual.Rotation = currentRotation.Lerp(targetRotation, turnTimer/TURN_TIME);

			Visual.Transform = currentTransform.InterpolateWith(targetTransform, turnTimer / TURN_TIME);
		}

		// Visual.Rotation = targetRotation;
		Visual.Transform = targetTransform;

		_isMoving = true;
	}
}
