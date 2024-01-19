using Godot;
using System;

namespace Deniard;
public partial class ManaBar : TextureProgressBar
{
	
	[Export] private Player player;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Player>("/root/World/Player");
		
		// this.ShowPercentage = false;
		this.Position = new Vector2(10, 40);
		this.Size = new Vector2(5 * player.GetMaxMana(), 20);
		this.Scale = new Vector2(3, 3);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

		this.Value = player.GetCurrMana() * 100 / player.GetMaxMana();

	}
}
