using Deniard;
using Godot;
using System;
using System.Numerics;

namespace Deniard;
public partial class Glorp : Enemy
{

	private Player player;

    public override void _Ready()
    {
        base._Ready();
		
		player = GetNode<Player>("/root/World/Player");
    }

    public override void _Process(double delta)
    {
        base._Process(delta);

		HandleMovement();
		MoveAndSlide();
    }

	private void HandleMovement() {
		
		Godot.Vector2 dist_to_player = (player.Position - this.Position);
		
		if(dist_to_player.Length() > 30) {
			Velocity = (player.Position - this.Position).Normalized() * movespeed;
			sprite.FlipH = Velocity.X > 0;
		}
		else {
			Velocity = Godot.Vector2.Zero;
		}

		if (Velocity.Length() != 0) {
			sprite.Play("walking");
		}
		else {
			sprite.Play("idle");
		}


	}
    
}
