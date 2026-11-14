namespace TowerDefenseApp.Models;

// tile caracteristics
public class Tile
{
    public int Row;
    public int Column;
    public TileType Type;

    public Tile(int row, int column, TileType type)
    {
        Row = row;
        Column = column;
        Type = type;
    }
}