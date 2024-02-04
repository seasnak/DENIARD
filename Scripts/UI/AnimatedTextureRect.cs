using Godot;
using System;

namespace Godot;
public partial class AnimatedTextureRect : TextureRect
{
	[Export] SpriteFrames sprites;
	[Export] string current_anim = "default";
	[Export] int frame_idx = 0;

	private float speed_scale = 1;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
