using Deniard;
using Godot;
using System;
using System.Collections.Generic;

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
		
		var space_state = GetWorld2D().DirectSpaceState;
		var query = PhysicsRayQueryParameters2D.Create(this.Position, player.Position);
		Godot.Collections.Dictionary result = space_state.IntersectRay(query);
		// GD.Print(result["collider_id"], player.GetInstanceId()); //DEBUG
		
		// check for LOS and distance
		if(dist_to_player.Length() < 100 && (ulong)(result["collider_id"]) == player.GetInstanceId()) {
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
