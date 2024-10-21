using Godot;
using System;
using System.Collections.Generic;
using static Deniard.Tilemap.TileType;

namespace Deniard.Tilemap;
public partial class DualGridTilemap : TileMapLayer {

	[Export] TileMapLayer displayTilemap;
	[Export] public Vector2I grassPlaceholderAtlasCoord;
	[Export] public Vector2I dirtPlaceholderAtlasCoord;
	readonly Vector2I[] NEIGHBOURS = new Vector2I[] { new(0, 0), new(1, 0), new(0, 1), new(1, 1) };

	// 0 1
	// 2 3
	readonly Dictionary<Tuple<TileType, TileType, TileType, TileType>, Vector2I> neighboursToAtlasCoord = new() {
		{new (Grass, Grass, Grass, Grass), new Vector2I(2, 1)}, // All corners
        {new (Dirt, Dirt, Dirt, Grass), new Vector2I(1, 3)}, // Outer bottom-right corner
        {new (Dirt, Dirt, Grass, Dirt), new Vector2I(0, 0)}, // Outer bottom-left corner
        {new (Dirt, Grass, Dirt, Dirt), new Vector2I(0, 2)}, // Outer top-right corner
        {new (Grass, Dirt, Dirt, Dirt), new Vector2I(3, 3)}, // Outer top-left corner
        {new (Dirt, Grass, Dirt, Grass), new Vector2I(1, 0)}, // Right edge
        {new (Grass, Dirt, Grass, Dirt), new Vector2I(3, 2)}, // Left edge
        {new (Dirt, Dirt, Grass, Grass), new Vector2I(3, 0)}, // Bottom edge
        {new (Grass, Grass, Dirt, Dirt), new Vector2I(1, 2)}, // Top edge
        {new (Dirt, Grass, Grass, Grass), new Vector2I(1, 1)}, // Inner bottom-right corner
        {new (Grass, Dirt, Grass, Grass), new Vector2I(2, 0)}, // Inner bottom-left corner
        {new (Grass, Grass, Dirt, Grass), new Vector2I(2, 2)}, // Inner top-right corner
        {new (Grass, Grass, Grass, Dirt), new Vector2I(3, 1)}, // Inner top-left corner
        {new (Dirt, Grass, Grass, Dirt), new Vector2I(2, 3)}, // Bottom-left top-right corners
        {new (Grass, Dirt, Dirt, Grass), new Vector2I(0, 1)}, // Top-left down-right corners
		{new (Dirt, Dirt, Dirt, Dirt), new Vector2I(0, 3)}, // No corners	
	};

	public override void _Ready() {
		// refresh display tiles
		foreach(Vector2I coord in GetUsedCells()) {
			SetDisplayTile(coord);
		}
	}

	private void SetDisplayTile(Vector2I pos) {
		// loop through 4 display neighbours
		GD.Print($"Editing tile at {pos}");
		for (int i = 0; i < NEIGHBOURS.Length; i++) {
			Vector2I newPos = pos + NEIGHBOURS[i];
			displayTilemap.SetCell(newPos, 1, CalculateDisplayTile(newPos));
		}
	}

	private Vector2I CalculateDisplayTile(Vector2I coords) {
		// get 4 world tile neighbours
		TileType botRight = GetWorldTile(coords - NEIGHBOURS[0]);
		TileType botLeft = GetWorldTile(coords - NEIGHBOURS[1]);
		TileType topRight = GetWorldTile(coords - NEIGHBOURS[2]);
		TileType topLeft = GetWorldTile(coords - NEIGHBOURS[3]);

		return neighboursToAtlasCoord[new(topLeft, topRight, botLeft, botRight)];
	}

	TileType GetWorldTile(Vector2I coords) {
		Vector2I atlasCoords = GetCellAtlasCoords(coords);
		if(atlasCoords == grassPlaceholderAtlasCoord)
			return Grass;
		else
			return Dirt;
	}
}


public enum TileType {
	None,
	Grass,
	Dirt,
}