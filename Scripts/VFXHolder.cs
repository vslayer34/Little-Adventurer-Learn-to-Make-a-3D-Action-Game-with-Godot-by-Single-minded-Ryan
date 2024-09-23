using Godot;
using System;


namespace LittleAdventurer.Scripts.Player;
public partial class VFXHolder : Node3D
{
	[Export]
	public GpuParticles3D FootStepsVFX { get; private set; }
}
