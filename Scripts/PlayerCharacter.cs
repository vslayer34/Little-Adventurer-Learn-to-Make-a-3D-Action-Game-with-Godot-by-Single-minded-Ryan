using Godot;
using System;

public partial class PlayerCharacter : CharacterBody3D
{
	public const float SPEED = 5.0f;
	public const float JUMP_VELOCITY = 4.5f;

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

		Velocity = velocity;
		MoveAndSlide();
	}
}
