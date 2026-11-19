using System.Collections.Generic;
using TowerDefenseApp.Models;

namespace TowerDefenseApp.GameLogic.Maps;

// recieve tileslist from TowerDefenseApp\GameLogic\Map\LoadMap.cs
public class GameMap
{
    public List<Tile> tiles = new List<Tile>();


    // search for the tile in the passed in coordonates (can't be row=-1)
    public Tile GetTile(int row, int column)
    {
        foreach (Tile tile in tiles)
        {
            if (tile.Row == row && tile.Column == column)
            {
                return tile;
            }
        }
        return null; //yellow = can be null but it works
    }

    // retunrs a track or a base that is not null or already used
    private bool IsNextTile(Tile tile, List<Tile> path)
    {
        if (tile == null) return false;
        if (path.Contains(tile)) return false;
        return tile.Type == TileType.Track || tile.Type == TileType.Base;
    }

    public List<Tile> GetPath()
    {
        List<Tile> path = new List<Tile>();

        //find the spawn tile
        foreach (Tile tile in tiles)
        {
            if (tile.Type == TileType.Spawn)
            {
                path.Add(tile);
            }
        }

        // move
        while (path[path.Count - 1].Type != TileType.Base)  // go further in the paht list until we arrive at the Base 
        {
            Tile last = path[path.Count - 1];

            // get the 4 surounding tiles
            Tile up = GetTile(last.Row - 1, last.Column);
            Tile down = GetTile(last.Row + 1, last.Column);
            Tile left = GetTile(last.Row, last.Column - 1);
            Tile right = GetTile(last.Row, last.Column + 1);

            // add to the path the first type track tile
            if (IsNextTile(up, path)) path.Add(up);
            else if (IsNextTile(down, path)) path.Add(down);
            else if (IsNextTile(left, path)) path.Add(left);
            else if (IsNextTile(right, path)) path.Add(right);
        }

        return path;
    }
}