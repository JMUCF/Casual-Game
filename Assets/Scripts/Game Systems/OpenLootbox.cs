using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLootbox : MonoBehaviour
{
    private float randomNum;
    public int common, uncommon, rare, legendary;
    private PlayerData playerData;

    Dictionary<string, float> dropRates = new Dictionary<string, float>()
    {
        {"Common", 55},
        {"Uncommon", 30},
        {"Rare", 12},
        {"Legendary", 3}
    };

    void Start()
    {
        playerData = SaveSystem.LoadStats();

        for (int i = 0; i < 100; i++)
        {
            GetRandomLoot();
        }
        PrintAmounts();
    }

    void GetRandomLoot()
    {
        randomNum = Random.Range(0, 100);

        if (randomNum < dropRates["Common"])
            common++;
        else if (randomNum < dropRates["Uncommon"] + dropRates["Common"])
            uncommon++;
        else if (randomNum < dropRates["Rare"] + dropRates["Uncommon"] + dropRates["Common"])
            rare++;
        else
            legendary++;
    }

    void PrintAmounts()
    {
        Debug.Log("Common: " + common);
        Debug.Log("Uncommon: " + uncommon);
        Debug.Log("Rare: " + rare);
        Debug.Log("Legendary: " + legendary);
    }
}
