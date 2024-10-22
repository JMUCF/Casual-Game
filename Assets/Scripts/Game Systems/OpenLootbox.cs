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
        common = 0;
        uncommon = 0;
        rare = 0;
        legendary = 0;

        // Load player data
        playerData = SaveSystem.LoadStats();

        // Check if playerData is null and initialize it if needed
        if (playerData == null)
        {
            Debug.Log("No saved data found. Initializing new player data.");
            playerData = new PlayerData(FindObjectOfType<GameManager>());
        }

        // Ensure skinsUnlocked array is initialized correctly
        playerData.InitializeSkins(10); // Adjust skinCount if necessary

        for (int i = 0; i < 100; i++)
        {
            GetRandomLoot();
        }
        PrintAmounts();
    }

    void GetRandomLoot()
    {
        randomNum = Random.Range(0, 100);
        int skinToUnlock = -1;

        // Determine rarity of the lootbox drop
        if (randomNum < dropRates["Common"])
            common++;
        else if (randomNum < dropRates["Uncommon"] + dropRates["Common"])
            uncommon++;
        else if (randomNum < dropRates["Rare"] + dropRates["Uncommon"] + dropRates["Common"])
            rare++;
        else
            legendary++;

        // Try to unlock a new skin based on the drop rarity
        skinToUnlock = GetNewSkinToUnlock();
        if (skinToUnlock != -1)
        {
            playerData.skinsUnlocked[skinToUnlock] = true;
            Debug.Log("Unlocked skin: " + skinToUnlock);

            // Save the updated player data
            SaveSystem.SavePlayer(FindObjectOfType<GameManager>());
        }
        else
        {
            Debug.Log("All skins unlocked for this rarity.");
        }
    }

    int GetNewSkinToUnlock()
    {
        if (playerData == null || playerData.skinsUnlocked == null)
        {
            Debug.LogError("Player data or skinsUnlocked array is null.");
            return -1;
        }

        for (int i = 0; i < playerData.skinsUnlocked.Length; i++)
        {
            if (!playerData.skinsUnlocked[i])
            {
                return i; // Return the first unlocked skin index
            }
        }
        return -1; // No skin available to unlock
    }

    void PrintAmounts()
    {
        Debug.Log("Common: " + common);
        Debug.Log("Uncommon: " + uncommon);
        Debug.Log("Rare: " + rare);
        Debug.Log("Legendary: " + legendary);
    }
}
