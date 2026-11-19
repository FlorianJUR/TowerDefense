namespace TowerDefenseApp.GameLogic.Base;

public class GameBase
{

    public int Health = 100;
    public bool IsDestroyed = false;

    public void TakeDamage(int damage)
    {
        Health = Health - damage;

        if (Health <= 0)
        {
            IsDestroyed = true; // later : end the game
        }
    }
}