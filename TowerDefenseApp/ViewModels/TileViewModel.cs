using TowerDefenseApp.Models;

namespace TowerDefenseApp.ViewModels;


public class TileViewModel
{
    public double posX { get; set; }
    public double posY { get; set; }
    public double width { get; set; }
    public double height { get; set; }
    public string color { get; set; }

    public TileViewModel(Tile tile)
    {
        // tile size
        int size = 64; 

        posX = tile.Column * size;
        posY = tile.Row * size;
        width = size;
        height = size;

        color = "Purple"; //default color should not appear
        if (tile.Type == TileType.Track) color = "Brown";       // '.'
        if (tile.Type == TileType.Buildable) color = "Green";   // 'X'
        if (tile.Type == TileType.Spawn) color = "Red";         // 'S'
        if (tile.Type == TileType.Base) color = "Blue";         // 'B'
    }
}