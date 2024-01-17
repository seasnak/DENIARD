using Godot;
using System;

public partial class Enemy : CharacterBody2D
{

	private int max_health;
	private int curr_health;

	private int max_mana;
	private int curr_mana;

	private AnimatedSprite2D sprite;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}
}
