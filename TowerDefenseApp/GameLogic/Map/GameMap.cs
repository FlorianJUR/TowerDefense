using System.Collections.Generic;
using TowerDefenseApp.Models;

namespace TowerDefenseApp.GameLogic.Maps;

// recieve tileslist from TowerDefenseApp\GameLogic\Map\LoadMap.cs
public class GameMap
{
    public List<Tile> tiles = new List<Tile>();
}