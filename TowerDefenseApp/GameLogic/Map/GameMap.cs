using System.Collections.Generic;
using TowerDefenseApp.Models;

namespace TowerDefenseApp.GameLogic.Maps;

// recieve tileslist from TowerDefenseApp\GameLogic\Map\LoadMap.cs
public class GameMap
{
    public List<Tile> tiles = new List<Tile>();


    // search for the tile in the passed in coordonates (can't be row=-1)
    // ? quick fix decaled as nullable
    public Tile? GetTile(int row, int column)
    {
        foreach (Tile tile in tiles)
        {
            if (tile.Row == row && tile.Column == column)
            {
                return tile;
            }
        }
        return null;
    }

    // retunrs a track or a base that is not null or already used
    private bool IsNextTile(Tile tile, List<Tile> path)
    {
        if (tile == null) return false;
        if (path.Contains(tile)) return false;
        return tile.Type == TileType.Track || tile.Type == TileType.Base;
    }
}