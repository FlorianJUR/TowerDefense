using System.Collections.Generic;
using System;
using System.IO;
using TowerDefenseApp.GameLogic.Maps;
using TowerDefenseApp.Models;

namespace TowerDefenseApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    // create a TileViewModel list
    public List<TileViewModel> tilesview { get; set; } = new List<TileViewModel>();

    public MainViewModel()
    {
        // take the Map1.json file copied in the executable folder
        string path = Path.Combine(AppContext.BaseDirectory, "Database", "Maps", "Map1.json");
        
        // create a variable to store the map
        LoadMap loader = new LoadMap();

        // load the map form .json in a tiles list
        GameMap map = loader.Load(path);

        // each tile: (row, column, TileType) added in a diplayable tilesview list
        foreach (Tile tile in map.tiles)
        {
            tilesview.Add(new TileViewModel(tile));
        }
        //a supp
        System.Console.WriteLine("Nombre de cases : " + tilesview.Count);
    }
}
