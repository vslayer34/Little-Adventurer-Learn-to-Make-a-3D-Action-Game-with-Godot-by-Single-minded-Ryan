using Godot;
using System;

public partial class PlayerCharacter : CharacterBody3D
{
	[ExportGroup("Required Nodes")]
	[Export]
	public Node3D Visual { get; private set; }


	public const float SPEED = 5.0f;
	public const float JUMP_VELOCITY = 4.5f;

	private Vector2 _lookDirection;

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

			// Visual.Rotation = new Vector3(Visual.Rotation.X, _lookDirection.Angle(), Visual.Rotation.Z);
			// Visual.RotateY()
			Visual.RotateObjectLocal(Vector3.Up, RotationDegrees.X);
			
			var a = new Quaternion(Transform.Basis);
			var b = new Quaternion(Visual.Transform.Basis);

			var c = a.Slerp(b,0.5f);

			// Visual.Transform = new Transform3D(c);
		}

		Velocity = velocity;
		MoveAndSlide();
	}
}
