using System.Collections.Generic;
using UnityEngine;

public class OpenLootbox : MonoBehaviour
{
    public jsonSave save;
    public GameManager manager;

    public void OpenLootBox()
    {
        List<Skin> availableSkins = GetAvailableSkins();

        if (availableSkins.Count > 0 && CheckPoints())
        {
            manager.pointsEarned -= 3;
            int randomSkinIndex = Random.Range(0, availableSkins.Count);
            Skin unlockedSkin = availableSkins[randomSkinIndex];
            unlockedSkin.unlocked = true;
            Debug.Log("Unlocked Skin: " + unlockedSkin.skinName);
            manager.SavePlayerStats();
        }
        else
        {
            Debug.Log("No skins available to unlock.");
        }
        save.SaveSkins();
    }

    private bool CheckPoints()
    {
        PlayerData data = SaveSystem.LoadStats();
        if (data.totalPoints >= 3)
            return true;
        return false;
    }

    private List<Skin> GetAvailableSkins()
    {
        List<Skin> filteredSkins = new List<Skin>();
        foreach (var skin in save.skins)
        {
            if (!skin.unlocked)
            {
                filteredSkins.Add(skin);
            }
        }
        return filteredSkins;
    }
}
