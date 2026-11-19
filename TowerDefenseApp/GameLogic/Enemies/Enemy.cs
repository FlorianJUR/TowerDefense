using System.Collections.Generic;
using TowerDefenseApp.Models;

namespace TowerDefenseApp.GameLogic.Enemies;

public class Enemy
{
    // in tile position
    public double X;
    public double Y;
    public double Speed = 2;

    public bool ReachedBase = false;
    private List<Tile> path;
    private int targetIndex = 1;   // numéro de la case visée

    // constructor: get on the spawn tile
    public Enemy(List<Tile> path)
    {
        this.path = path;
        X = path[0].Column;
        Y = path[0].Row;
    }

    public void Update(double deltaTime)
    {
        if (ReachedBase) return;

        Tile target = path[targetIndex];
        double step = Speed * deltaTime;

        // actual move
        if (X < target.Column) X = X + step; 
        else if (X > target.Column) X = X - step;
        else if (Y < target.Row) Y = Y + step;
        else if (Y > target.Row) Y = Y - step;

        if (X >= target.Column - step && X <= target.Column + step
            && Y >= target.Row - step && Y <= target.Row + step)
        {
            X = target.Column;
            Y = target.Row;
            targetIndex++;

            if (targetIndex >= path.Count)
            {
                ReachedBase = true;
            }
        }
    }
}