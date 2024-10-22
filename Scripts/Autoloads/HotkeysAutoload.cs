using Godot;
using System;

public partial class HotkeysAutoload : Node
{	
	public override void _Ready() {

	}

	public override void _Process(double delta) {

		if(Input.IsKeyPressed(Key.Escape)) { GetTree().Quit(); }
	}
}
