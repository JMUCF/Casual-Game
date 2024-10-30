using System.Collections.Generic;
using UnityEngine;

public class SkinInitializer : MonoBehaviour
{
    public jsonSave jsonSaveScript;
    public SkinData[] skinDataAssets;

    private void Start()
    {
        InitializeSkins();
    }

    private void InitializeSkins()
    {
        jsonSaveScript.skins = new List<Skin>();

        foreach (var skinData in skinDataAssets)
        {
            Skin skin = gameObject.AddComponent<Skin>();
            skin.skinName = skinData.skinName;
            skin.rarity = skinData.rarity;
            skin.id = skinData.id;
            skin.unlocked = skinData.unlocked;
            skin.materials = skinData.materials;
            skin.selected = false;

            jsonSaveScript.skins.Add(skin);
        }

        Debug.Log("Skins initialized using SkinData assets.");
    }
}
