using System.Collections.Generic;
using TowerDefenseApp.GameLogic.Base;
using TowerDefenseApp.GameLogic.Enemies;
using TowerDefenseApp.GameLogic.Maps;
using TowerDefenseApp.Models;

namespace TowerDefenseApp.GameLogic.Engine;

public class GameEngine
{
    public double time = 0;

    public Enemy Enemy;
    public GameBase gamebase = new GameBase();
    private List<Tile> path;

    public GameEngine(GameMap map)
    {
        path = map.GetPath();
        Enemy = new Enemy(path);
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