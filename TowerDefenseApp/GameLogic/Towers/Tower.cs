using TowerDefenseApp.GameLogic.Enemies;

namespace TowerDefenseApp.GameLogic.Towers;

public class Tower
{
    public int Row;
    public int Column;

    public int Range = 3;
    public int Damage = 1;
    public int Reload = 1; // s

    private double timer = 0;

    public Tower(int row, int column){
        Row = row;
        Column = column;
    }

    public void Update(double deltaTime, Enemy enemy)
    {
        timer = timer+deltaTime;

        if(timer < Reload) return;
        else if (InRange(enemy))
        {
            enemy.TakeDamage(Damage);
            timer =0;
        }
    }

    // compute the enemy distance and return true if the distance is within the range
    private bool InRange(Enemy enemy)
    {
        double dx = enemy.X - Column;
        double dy = enemy.Y - Row;
        double distance = System.Math.Sqrt(dx * dx + dy * dy); // circle r**2 = x**2 + y**2

        return distance <= Range;
    }
}