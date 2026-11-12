namespace TowerDefenseApp.Models;

// each member is linked to a character (easier map construction in TowerDefenseApp\Database\Maps\Map1.json)
public enum TileType
{
    Base = 'X',
    Buildable = 'B',
    Path = '.',
    Spawn = 'S'
}
