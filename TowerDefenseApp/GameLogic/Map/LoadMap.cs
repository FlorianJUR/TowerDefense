using System.Collections.Generic;
using System.IO;
using TowerDefenseApp.Models;
using System.Text.Json;

namespace TowerDefenseApp.GameLogic.Maps;

public class LoadMap
{
    public GameMap Load(string filepath)
    {
        string jsonfile = File.ReadAllText(filepath);
        // jsonfile into a C# object using MapData type
        MapData? filedata = JsonSerializer.Deserialize<MapData>(jsonfile);

        if (filedata == null)
        {
            throw new System.Exception("Map impossible to read (null exception) at: " + filepath);
        }

        GameMap tileslist = new GameMap();

        for (int row = 0; row < filedata.rows.Count; row++)
        {
            string line = filedata.rows[row];
            for (int column = 0; column<line.Length; column++)
            {
                // explicite cast: char -> TileType
                tileslist.tiles.Add(new Tile(row, column, (TileType)line[column]));
            }
        }
        return tileslist;
    }
}

// MapData for reading .json
public class MapData
{
    public List<string> rows { get; set; } = new List<string>();
}