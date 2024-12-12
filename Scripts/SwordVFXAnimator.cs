using Godot;
using System;

public partial class SwordVFXAnimator : AnimationPlayer
{
	[Export]
	public Node3D BladeVFX1 { get; private set; }

	[Export]
	public Node3D BladeVFX2 { get; private set; }

	[Export]
	public Node3D BladeVFX3 { get; private set; }
}
