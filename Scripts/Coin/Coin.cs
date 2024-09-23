using Godot;
using LittleAdventurer.Scripts.Player;
using System;

public partial class Coin : Node3D
{
	[ExportGroup("Child Nodes")]
	[Export]
	public Node3D CoinMesh { get; private set; }

	[Export]
	public Area3D CoinCollider { get; private set; }

	[ExportGroup("")]

	private const float ROTAION_SPEED = 1.0f;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        CoinCollider.BodyEntered += Coin_BodyEntered;
    }

    public override void _Process(double delta)
    {
        CoinMesh.RotateY(ROTAION_SPEED * (float)delta);
    }

	// Signal Methods------------------------------------------------------------------------------

	private void Coin_BodyEntered(Node3D body)
	{
		if (body is PlayerCharacter player)
		{
			QueueFree();
		}
	}
}
