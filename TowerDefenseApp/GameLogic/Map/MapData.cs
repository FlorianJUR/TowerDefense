using System.Collections.Generic;


namespace TowerDefenseApp.GameLogic.Maps;

// recieve json file content for JsonSerializer in TowerDefenseApp\GameLogic\Map\LoadMap.cs
public class MapData
{
    public List<string> rows = new List<string>();
}