using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLootbox : MonoBehaviour
{
    private float randomNum;
    public int common, uncommon, rare, legendary;

    Dictionary<string, float> dropRates = new Dictionary<string, float>() // % drop chances, make sure the add up to 100
    {
        {"Common", 55}, 
        {"Uncommon", 30},
        {"Rare", 12},
        {"Legendary", 3}
    };
    
    void Start()
    {
        common = 0;
        uncommon = 0;
        rare = 0;
        legendary = 0;

        for(int i = 0; i < 100; i++)
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
        else if (randomNum < dropRates["Common"] + dropRates["Uncommon"])
            uncommon++;
        else if (randomNum < dropRates["Common"] + dropRates["Uncommon"] + dropRates["Rare"])
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
