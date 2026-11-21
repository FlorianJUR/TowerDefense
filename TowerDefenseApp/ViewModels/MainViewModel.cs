using System.Collections.Generic;
using System;
using System.IO;
using TowerDefenseApp.GameLogic.Maps;
using TowerDefenseApp.Models;
using TowerDefenseApp.GameLogic.Engine;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using TowerDefenseApp.GameLogic.Towers;

namespace TowerDefenseApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public List<TileViewModel> tilesview { get; set; } = new List<TileViewModel>();
    public List<TowerViewModel> towersview { get; set; } = new List<TowerViewModel>();

    public GameEngine engine;
    public DispatcherTimer timer = new DispatcherTimer();

    [ObservableProperty]
    private string timeText = "Temps : 0.0 s";

    [ObservableProperty]
    private string healthText = "Base : 10 PV";

    [ObservableProperty]
    private double enemyX;
    
    [ObservableProperty]
    private double enemyY;

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
        TimeText = "Temps : " + engine.time.ToString("F1") + " s, Enemy health:" + engine.Enemy.Health + " PV";
        HealthText = "Base : " + engine.gamebase.Health + " PV";

        int enemySize = 20;
        EnemyX = engine.Enemy.X * TileViewModel.size + (TileViewModel.size - enemySize) / 2;
        EnemyY = engine.Enemy.Y * TileViewModel.size + (TileViewModel.size - enemySize) / 2;
    }
}
