using Godot;
using System;

private int max_health;
private int curr_health;

private int max_mana;
private int curr_mana; 

private AnimatedSprite2D sprite;

public partial class Player : CharacterBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		Velocity = HandleMovement();


		MoveAndSlide();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	private Vector2 HandleMovement() 
	{
		Vector2 velocity = Input.GetVector("move_left", "move_right", "move_up", "move_down");

		print(velocity);

		return velocity;
	}
}
