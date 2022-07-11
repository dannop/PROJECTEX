using UnityEngine;

public class GameController : MonoBehaviour
{
    public int life = 100;
    public int maxLife = 100;
    public int score = 0;
    
    public int totalWaves = 6;
    public int enemiesPerLevel = 10;

    private int totalEnemies = 0;
    private int currentLevelEnemies = 0; 
    private int pendingUpgrades = 0;

    private void Awake()
    {
        totalEnemies = totalWaves * 30;
    }

    private void Update()
    {   
        if (enemiesPerLevel <= currentLevelEnemies)
        {
            currentLevelEnemies = 0;
            pendingUpgrades += 1;
        }
    }

    public int GetTotalEnemies()
    {
        return totalEnemies;
    }

    public int GetPendingUpgrades()
    {
        return pendingUpgrades;
    }

    public int GetCurrentLevelEnemies()
    {
        return currentLevelEnemies;
    }

    public void setCurrentLevelEnemies(int value)
    {
        currentLevelEnemies = value;
    }

    public void Restart()
    {

    }
}
