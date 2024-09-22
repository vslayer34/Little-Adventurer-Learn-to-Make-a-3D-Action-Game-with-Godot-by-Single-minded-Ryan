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

	public override async void _PhysicsProcess(double delta)
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

			// float turnTimer = 0.0f;
			// const float TURN_TIME = 0.5f;

			_lookDirection.X = velocity.Z;
			_lookDirection.Y = velocity.X;

			// var currentRotation = Visual.Rotation;
			// var targetRotation = new Vector3(currentRotation.X, _lookDirection.Angle(), currentRotation.Z);

			// Visual.Rotation = new Vector3(Visual.Rotation.X, _lookDirection.Angle(), Visual.Rotation.Z);
			// Visual.Rotation = currentRotation.Slerp(targetRotation, 0.5f);
			// Visual.Rotation = currentRotation.Lerp(targetRotation, 0.5f);

			// Visual.Rotate()
			GD.Print(direction);

			_isMoving = true;

			
			// var newBasis = Visual.Transform;

			// GD.Print($"Visual.Transform:{Visual.Transform.Basis}");
			// GD.Print($"new Basis:{newBasis.Basis}");
			
			// newBasis.Basis = Basis.FromEuler(new Vector3(0.0f, -_lookDirection.Y, 0.0f));

			// GD.Print($"new Basis2:{newBasis.Basis}");
			
			// Visual.Transform = newBasis;

			// GD.Print($"Visual.Transform2:{Visual.Transform.Basis}");
			await RotateCharacterAsync(direction, (float)delta);
		}

		Velocity = velocity;
		MoveAndSlide();
	}

	private async Task RotateCharacterAsync(Vector3 velocity, float delta)
	{
		if (!_isMoving)
		{
			return;
		}

		float turnTimer = 0.0f;
		const float TURN_TIME = 0.2f;

		// _lookDirection.ang

		// _lookDirection.X = velocity.Z;
		// _lookDirection.Y = velocity.X;

		// GD.Print(direction);
		// GD.Print(_lookDirection);

		// var currentRotation = Visual.Rotation;
		// var targetRotation = new Vector3(currentRotation.X, _lookDirection.Angle(), currentRotation.Z);

		var currentRotation = Visual.Transform;
		var modify = currentRotation;
		// modify.Basis = Basis.FromEuler(new Vector3(0.0f, -_lookDirection.Y, 0.0f));
		modify.Basis = Transform.Basis;
		var targetRotation = modify;
		// Visual.Transform = targetRotation;

		var i1 = 1;
		var i2 = 10;

		while (turnTimer < TURN_TIME)
		{
			turnTimer += delta;
			// GD.Print(turnTimer);
			// await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
			GD.Print(_lookDirection.Angle());

			// Visual.Rotation = currentRotation.Lerp(targetRotation, turnTimer/TURN_TIME);

			Visual.Transform = currentRotation.InterpolateWith(targetRotation, turnTimer / TURN_TIME);

			// var newBasis = Visual.Transform;
			// // GD.Print($"Visual.Transform:{Visual.Transform.Basis}");
			// // GD.Print($"new Basis:{newBasis.Basis}");
			// newBasis.Basis = Basis.FromEuler(new Vector3(0.0f, -_lookDirection.Y, 0.0f));
			// // GD.Print($"new Basis2:{newBasis.Basis}");
			// Visual.Transform = newBasis;
			// GD.Print(Mathf.Lerp(i1, i2, turnTimer / TURN_TIME));

			await ToSignal(GetTree(), SceneTree.SignalName.ProcessFrame);
		}

		// Visual.Rotation = targetRotation;
		Visual.Transform = targetRotation;

		_isMoving = true;
	}
}
