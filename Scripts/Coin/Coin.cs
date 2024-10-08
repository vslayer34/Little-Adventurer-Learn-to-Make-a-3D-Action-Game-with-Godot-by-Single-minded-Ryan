using Godot;
using LittleAdventurer.Scripts.Helper;
using LittleAdventurer.Scripts.Player;
using LittleAdventurer.Scripts.Resources;
using System;

public partial class Coin : Node3D
{
	[Signal]
	public delegate void OnCoinCollectedEventHandler(int value);

	#region Child Nodes
	[ExportGroup("Child Nodes")]
	[Export]
	public Node3D CoinMesh { get; private set; }

	[Export]
	public GpuParticles3D PickUpVFX { get; private set; }

	[Export]
	public Area3D CoinCollider { get; private set; }

	[Export]
	public AnimationPlayer AnimePlayer { get; private set; }

	[ExportGroup("")]
	#endregion

	
	
	[ExportCategory("Required Nodes")]
	[Export]
	public GameResources SharedResources { get; private set; }
	[ExportCategory("")]

	private const float ROTAION_SPEED = 1.0f;
	private float coinValue = 1.0f;



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        CoinCollider.BodyEntered += Coin_BodyEntered;
		OnCoinCollected += SharedResources.IncrementCoins;
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
			PickUpVFX.Emitting = true;
			AnimePlayer.Play(AnimationConsts.Coin.COLLECTED);

			// add the coin and subscribe itself from the coin before destroying itself
			EmitSignal(SignalName.OnCoinCollected, coinValue);
			OnCoinCollected -= SharedResources.IncrementCoins;
			GD.Print(SharedResources.CoinsCollected);

			PickUpVFX.Finished += () =>
			{
				QueueFree();
			};
		}
	}
}
