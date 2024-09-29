using Godot;
using System;

public partial class GameManager : Node3D
{
	[ExportGroup("Required Nodes")]
	[Export]
	public NavigationRegion3D NavigationRegion { get; private set; }



    // Game Loop Methods---------------------------------------------------------------------------

    public override void _Ready()
    {
        NavigationRegion.BakeFinished += NavigationRegion_BakeFinished;
		NavigationRegion.NavigationMeshChanged += NavigationRegion_NavigationMeshChanged;
    }

    private void NavigationRegion_NavigationMeshChanged()
    {
        GD.Print("Ready: Navigation Mesh Changed");
    }

    private void NavigationRegion_BakeFinished()
    {
        GD.Print("Ready: Bake Finished");
    }
}
