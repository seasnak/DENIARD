using Godot;
using System;

namespace Deniard;
public partial class HealthBar : TextureProgressBar
{
	
	[Export] private Player player;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Player>("/root/World/Player");
		
		// this.ShowPercentage = false;
		this.Position = new Vector2(30, 30);
		this.Size = new Vector2(500, 20);
		this.Scale = new Vector2(5, 5);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		this.Value = (player.GetCurrHealth() *100) / player.GetMaxHealth();

	}
}
