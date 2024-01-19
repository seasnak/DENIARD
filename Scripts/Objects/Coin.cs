using Godot;
using System;

namespace Deniard;
public partial class Coin : Area2D
{
	//Attributes
	int value = 5;

	// Children Nodes
	private AnimatedSprite2D sprite;
	private CollisionShape2D collider;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
		sprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		collider = GetNode<CollisionShape2D>("CollisionShape2D");

		sprite.Play("default");
		sprite.SpeedScale = 2f;

		BodyEntered += OnBodyEntered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnBodyEntered(Node body) {
		if(body == null ||  body is not Player) { return; }

		((Player)body).AddMoney(this.value);
		QueueFree();
	}
}
