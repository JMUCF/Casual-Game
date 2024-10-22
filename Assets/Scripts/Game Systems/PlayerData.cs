using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int totalPoints;
    //public gameobject[] skinsOwned;
    public PlayerData(GameManager gameManager)
    {
        totalPoints += gameManager.pointsEarned;
    }
}
