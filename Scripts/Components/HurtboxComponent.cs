using Godot;
using System;

namespace Deniard.Component;
public partial class HurtboxComponent : Area2D {

	public override void _Ready() {
		AreaEntered += OnAreaEntered;
		AreaExited += OnAreaExited;
	}

	public override void _Process(double delta)
	{

	}

	private void OnAreaEntered(Node2D other) {
		
		if(other is HitboxComponent) {
			// GetParent().CurrHealth -= 10;
		}
	}

	private void OnAreaExited(Node2D other) {

	}
}
