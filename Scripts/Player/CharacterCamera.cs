using Godot;
using System;

namespace Deniard;

public partial class CharacterCamera : Camera2D
{
	[Export] CharacterBody2D target;
	[Export] string rootNodeStr = "root/";
	[Export] Vector2 camera_zoom = new(2.5f, 2.5f);

	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		
		if(target == null) {
			try {
				target = GetNode<CharacterBody2D>($"{rootNodeStr}Player");
			} 
			catch(Exception e) {
				GD.PrintErr($"Error loading target node: {e}.");
				throw;
			}
		}

		this.Zoom = camera_zoom;
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
		// smooth camera
		Vector2 dist_to_target = target.Position - this.Position;
		if(dist_to_target.Length() > 5) {
			this.Position += dist_to_target.Normalized() * dist_to_target.Length()*0.1f;
		}
		

	}
}
