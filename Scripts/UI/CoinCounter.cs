using Godot;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel.DataAnnotations;

namespace Deniard;
public partial class CoinCounter : RichTextLabel
{

	TextureRect coin_texture;
	Player player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		coin_texture = GetNode<TextureRect>("TextureRect");	
		
		player = GetNode<Player>("/root/World/Player");

		Vector2 screensize = this.GetViewportRect().Size;
		GD.Print(screensize);
		
		this.ClipContents = false;
		this.AutowrapMode = TextServer.AutowrapMode.Off;
		this.FitContent = true;
		this.Scale = new Vector2(2, 2);

		this.Position = new Vector2(screensize.X - 50, 20);
		coin_texture.Position = new Vector2(-20, 0);
		coin_texture.Scale = new Vector2(0.5f, 0.5f);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		this.Text = $"{player.GetMoney()}";
	}
}
