using Deniard;
using Godot;
using System;
using System.Collections.Generic;

namespace Deniard;
public partial class Glorp : Enemy
{

	private Player player;
	private Godot.Vector2 target_position; // the location of the target to move to.
	private bool player_visible = false;

	public override void _Ready()
	{
		base._Ready();

		//update local variables
		movespeed = 30;
		
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
		// GD.Print(result); //DEBUG
		
		// check for LOS and distance
		if(dist_to_player.Length() < 100 && (ulong)(result["collider_id"]) == player.GetInstanceId()) {
			Velocity = (player.Position - this.Position).Normalized() * movespeed;
			sprite.FlipH = Velocity.X > 0;
		}
		else if((this.Position - (Vector2)result["position"]).Length() < 100) {
			//Move to position where player was last seen
			if(player_visible) {
				target_position = (Vector2)result["position"]; 
			}
			GD.Print($"{target_position}");
			Velocity = (this.Position - target_position).Normalized() * movespeed; // move towards target
			player_visible = false;
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
