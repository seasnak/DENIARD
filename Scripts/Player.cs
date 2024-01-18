using Godot;
using System;

namespace Deniard;
public partial class Player : CharacterBody2D
{

	//Stats
	private int curr_health = 10;
	private int max_health = 10;
	
	private int curr_mana = 10;
	private int max_mana = 10;

	private int movespeed = 50;
	
	private int dashspeed = 50;
	private float dash_dur = 0.2f;
	
	//Conditional Checks
	private bool is_dashing = false;
	private bool is_attacking = false;

	//Child Nodes (Attributes)
	private AnimatedSprite2D sprite;
	
	//Main Functions
	public override void _Ready() 
	{

		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		
	}

	public override void _Process(double delta) 
	{

		HandleInput();
		HandleAttack();

		MoveAndSlide();
	}

	//Handlers
	private Vector2 HandleInput() 
	{
		//Handles basic player movement and animations

		Vector2 input = Input.GetVector("left", "right", "up", "down");
		Velocity = input.Normalized() * movespeed;

		if(input.X != 0) {
			sprite.FlipH = input.X > 0;
		}

		//Animation Handler
		if(input.X != 0) {
			sprite.Play("walking");
		}
		else {
			sprite.Play("idle");
		}

		if(Input.IsActionPressed("attack")) {
			is_attacking = true;
		}

		return Velocity;
	}

	private void HandleAttack() 
	{
		//Handles the player's attacks
		if(is_attacking) {
			// Do Something
		}

	}


	//Interactions
	public void Damage(int damage)
	{
		curr_health -= damage;
	}

	public void Heal(int healing)
	{
		curr_health += healing;
	}

	//Getters and Setters
	public int GetCurrHealth() { return curr_health; }
	public void SetCurrHealth(int val) { curr_health = val; }
	public int GetCurrMana() { return curr_mana; }
	public void SetCurrMana(int val) { curr_mana = val; }

}
