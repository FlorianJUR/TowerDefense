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

    private GameMap map;

    public GameEngine(GameMap map)
    {
        this.map = map;
        path = map.GetPath();
        Enemy = new Enemy(path);
    }

    // call update every tick
    public void Update(double deltaTime)
    {
        time = time + deltaTime;

        Enemy.Update(deltaTime);
        
        if (Enemy.EnemyDead)
        {
            Enemy = new Enemy(path);
        }
        else if (Enemy.ReachedBase)
        {
            gamebase.TakeDamage(1);
            Enemy = new Enemy(path);
        }

        foreach (Tower tower in Towers)
        {
            tower.Update(deltaTime, Enemy);
        }
    }

    public bool CanBuild(int row, int column)
    {
        Tile tile = map.GetTile(row, column);
        if (tile.Type != TileType.Buildable)
        {
            return false;
        }
        foreach (Tower tower in Towers)
        {
            if (tower.Row == row && tower.Column == column)
            {
                return false;
            }
        }
        return true;
    }
    public Tower BuildTower(int row, int column)
    {
        Tower newTower = new Tower(row, column);
        Towers.Add(newTower);
        return newTower;
    }
}