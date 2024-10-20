using Godot;
using System;

namespace Deniard.Component;

public partial class HealthComponent : Node {

    [Export] int max_health = 0;
    private int curr_health = 0;

    public int MaxHealth { get=>max_health; set=>max_health=value; }
    public int CurrHealth { get=>curr_health; set=>curr_health=value; }

    public override void _Ready() {
        curr_health = max_health;
    }

    public override void _Process(double delta) {
        
        if(curr_health == 0) {
            EmitSignal("User Died!");
        }
    }

}
