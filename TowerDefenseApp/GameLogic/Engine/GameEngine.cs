using System.Collections.Generic;
using TowerDefenseApp.GameLogic.Base;
using TowerDefenseApp.GameLogic.Enemies;
using TowerDefenseApp.GameLogic.Maps;
using TowerDefenseApp.Models;
using TowerDefenseApp.GameLogic.Towers;


namespace TowerDefenseApp.GameLogic.Engine;

public class GameEngine
{
    public double time = 0;

    public Enemy Enemy;
    public List<Tower> Towers = new List<Tower>();
    public GameBase gamebase = new GameBase();
    private List<Tile> path;

    public GameEngine(GameMap map)
    {
        path = map.GetPath();
        Enemy = new Enemy(path);
        Towers.Add(new Tower(0,4)); // hard coded tower positon for testing
    }

    // call update every tick
    public void Update(double deltaTime)
    {
        time = time + deltaTime;
        Enemy.Update(deltaTime);
        if (Enemy.ReachedBase)
        {
            gamebase.TakeDamage(1);
        }
    }
}