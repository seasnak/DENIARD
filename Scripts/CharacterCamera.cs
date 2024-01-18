using Godot;
using System;

namespace Deniard;

public partial class CharacterCamera : Camera2D
{
	private CharacterBody2D target;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		try {
			target = GetNode<CharacterBody2D>("/root/World/Player");
		} 
		catch(Exception e) {
			GD.PrintErr($"Error loading target node: {e}.");
			throw;
		}
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// smooth camera
		Vector2 dist_to_target = target.Position - this.Position;
		if(dist_to_target.Length() > 1) {
			this.Position += dist_to_target.Normalized() * dist_to_target.Length()*0.1f;
		}
		

	}
}
