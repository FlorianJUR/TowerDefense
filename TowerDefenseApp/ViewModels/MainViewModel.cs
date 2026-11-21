using System.Collections.Generic;
using System;
using System.IO;
using TowerDefenseApp.GameLogic.Maps;
using TowerDefenseApp.Models;
using TowerDefenseApp.GameLogic.Engine;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using TowerDefenseApp.GameLogic.Towers;
using System.Collections.ObjectModel;



namespace TowerDefenseApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public List<TileViewModel> tilesview { get; set; } = new List<TileViewModel>();

    // add to list form the screen
    public ObservableCollection<TowerViewModel> towersview { get; set; } = new ObservableCollection<TowerViewModel>();

    public GameEngine engine;
    public DispatcherTimer timer = new DispatcherTimer();

    private int selectedRow;
    private int selectedColumn;

    [ObservableProperty] private bool isTileSelected = false;
    [ObservableProperty] private double selectedX;
    [ObservableProperty] private double selectedY;
    [ObservableProperty] private string messageText = "Click sur une case verte pour construire une tour";

    [ObservableProperty] private string timeText = "Temps : 0.0 s";
    [ObservableProperty] private string healthText = "Base : 10 PV";

    [ObservableProperty] private double enemyX;
    [ObservableProperty] private double enemyY;

    public MainViewModel()
    {
        // take the Map1.json file copied in the executable folder
        string path = Path.Combine(AppContext.BaseDirectory, "Database", "Maps", "Map1.json");
        
        LoadMap loader = new LoadMap();
        GameMap map = loader.Load(path);
        
        foreach (Tile tile in map.tiles)
        {
            tilesview.Add(new TileViewModel(tile));
        }

        engine = new GameEngine(map);

        foreach (Tower tower in engine.Towers)
        {
            towersview.Add(new TowerViewModel(tower));
        }

        // start the game loop 1s/60fps = 16ms
        timer.Interval = TimeSpan.FromMilliseconds(16);
        timer.Tick += OnTick;
        timer.Start();
    }
    public void OnTick(object? sender, EventArgs e)
    {
        engine.Update(0.016);
        TimeText = "Temps : " + engine.time.ToString("F1") + " s, Ennemi:" + engine.Enemy.Health + " PV";
        HealthText = "Base : " + engine.gamebase.Health + " PV";

        int enemySize = 20;
        EnemyX = engine.Enemy.X * TileViewModel.size + (TileViewModel.size - enemySize) / 2;
        EnemyY = engine.Enemy.Y * TileViewModel.size + (TileViewModel.size - enemySize) / 2;
    }

    public void SelectTile(TileViewModel tile)
    {
    selectedRow = tile.row;
    selectedColumn = tile.column;

    SelectedX = tile.column * TileViewModel.size;
    SelectedY = tile.row * TileViewModel.size;
    IsTileSelected = true;
    MessageText = "Case sélectionnée";
    }
    public void BuildTower()
    {
        if (IsTileSelected == false)
        {
            MessageText = "Veuillez sélectionner une case";
            return;
        }

        if (engine.CanBuild(selectedRow, selectedColumn) == false)
        {
            MessageText = "Terrain inconstructible";
            return;
        }

        AddTower();
    }

    private void AddTower()
    {
        Tower tower = engine.BuildTower(selectedRow, selectedColumn);
        towersview.Add(new TowerViewModel(tower));
        MessageText = "Tour contruite";
    }
}
