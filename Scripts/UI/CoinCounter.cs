using Godot;
using System;
using System.ComponentModel.DataAnnotations;

namespace Deniard;
public partial class CoinCounter : Label
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		this.Position = new  Vector2(0, 0);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
