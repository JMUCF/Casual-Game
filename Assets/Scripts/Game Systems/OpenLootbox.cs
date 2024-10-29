using System.Collections.Generic;
using UnityEngine;

public class OpenLootbox : MonoBehaviour
{
    public jsonSave save;

    public void OpenLootBox()
    {
        List<Skin> availableSkins = GetAvailableSkins();

        if (availableSkins.Count > 0)
        {
            int randomSkinIndex = Random.Range(0, availableSkins.Count);
            Skin unlockedSkin = availableSkins[randomSkinIndex];
            unlockedSkin.unlocked = true;
            Debug.Log("Unlocked Skin: " + unlockedSkin.skinName);
        }
        else
        {
            Debug.Log("No skins available to unlock.");
        }

        save.SaveSkins();
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
