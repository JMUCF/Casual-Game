using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int totalPoints;
    public int skinCount = 10;
    public bool[] skinsUnlocked;

    public PlayerData(GameManager gameManager)
    {
        totalPoints += gameManager.pointsEarned;

        skinsUnlocked = new bool[10];
    }

    public void InitializeSkins(int skinCount)
    {
        if (skinsUnlocked == null || skinsUnlocked.Length != skinCount)
        {
            skinsUnlocked = new bool[skinCount];
        }
    }
}
