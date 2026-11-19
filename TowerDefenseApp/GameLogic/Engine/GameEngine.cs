using TowerDefenseApp.GameLogic.Enemies;
using TowerDefenseApp.GameLogic.Maps;

namespace TowerDefenseApp.GameLogic.Engine;

public class GameEngine
{
    public double time = 0;

    public Enemy Enemy;
    public GameEngine(GameMap map)
    {
        Enemy = new Enemy(map.GetPath());
    }

    // call update every tick
    public void Update(double deltaTime)
    {
        time = time + deltaTime;
        Enemy.Update(deltaTime);
    }
}