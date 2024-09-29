using System;
using Godot;

namespace LittleAdventurer.Scripts;

public abstract partial class Character : CharacterBody3D
{
    [ExportGroup("Child Nodes")]
	[Export]
	public Node3D Mesh { get; protected set; }

	[Export]
	public AnimationPlayer AnimPlayer { get; protected set; }
}
