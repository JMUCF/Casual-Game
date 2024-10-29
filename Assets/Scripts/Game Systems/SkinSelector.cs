using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    public jsonSave save;

    public void SelectSkin(int skinId)
    {
        DeselectAllSkins();
        if (skinId < 0 || skinId >= save.skins.Count)
        {
            Debug.LogWarning("Invalid skin ID.");
            return;
        }

        if (!save.skins[skinId].unlocked)
        {
            return;
        }

        save.skins[skinId].selected = true;
        save.SaveSkins();
        Debug.Log("Skin selected: " + save.skins[skinId].skinName);
    }

    private void DeselectAllSkins()
    {
        foreach (Skin skin in save.skins)
        {
            skin.selected = false;
        }
    }
}
