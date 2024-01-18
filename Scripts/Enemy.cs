using Godot;
using System;

namespace Deniard;
public partial class Enemy : CharacterBody2D
{

	protected int max_health = 10;
	protected int curr_health;

	protected int max_mana = 10;
	protected int curr_mana;

	protected int movespeed = 10;

	protected AnimatedSprite2D sprite;

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
