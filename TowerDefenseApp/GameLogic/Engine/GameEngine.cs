namespace TowerDefenseApp.GameLogic.Engine;

public class GameEngine
{
    public double time = 0;

    // call update every tick
    public void Update(double deltaTime)
    {
        time = time + deltaTime;
    }
}