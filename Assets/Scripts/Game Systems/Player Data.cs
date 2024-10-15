using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int starsOwned;
    //public gameobject[] skinsOwned;
    public PlayerData(GameManager gameManager)
    {
        starsOwned += gameManager.pointsEarned;
    }
}
