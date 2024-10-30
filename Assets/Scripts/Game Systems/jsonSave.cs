using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class jsonSave : MonoBehaviour
{
    public SkinData[] skinDataAssets;
    public List<Skin> skins = new List<Skin>();

    void Start()
    {
        InitializeSkinsFromData();
        Invoke("LoadSkins", .15f);
    }

    private void InitializeSkinsFromData()
    {
        skins.Clear();

        foreach (var data in skinDataAssets)
        {
            Skin skin = new Skin
            {
                skinName = data.skinName,
                rarity = data.rarity,
                id = data.id,
                unlocked = data.unlocked,
                materials = data.materials,
                selected = false
            };
            skins.Add(skin);
        }
    }

    public void SaveSkins()
    {
        Debug.Log("Saving skins");

        List<SaveSkin> saveData = new List<SaveSkin>();
        foreach (Skin skin in skins)
        {
            saveData.Add(new SaveSkin
            {
                skinName = skin.skinName,
                rarity = skin.rarity,
                id = skin.id,
                unlocked = skin.unlocked,
                selected = skin.selected
            });
        }

        SaveLoadSkinsWrapper wrapper = new SaveLoadSkinsWrapper { skins = saveData };
        string json = JsonUtility.ToJson(wrapper, true);

        string path = Application.persistentDataPath + "/SavedSkins.json";
        File.WriteAllText(path, json);
        Debug.Log("File saved at: " + path);
    }

    public void LoadSkins()
    {
        Debug.Log("Loading skins");
        string path = Application.persistentDataPath + "/SavedSkins.json";

        if (!File.Exists(path))
        {
            Debug.LogWarning("Save file not found.");
            return;
        }

        string json = File.ReadAllText(path);
        SaveLoadSkinsWrapper wrapper = JsonUtility.FromJson<SaveLoadSkinsWrapper>(json);

        foreach (SaveSkin data in wrapper.skins)
        {
            foreach (Skin skin in skins)
            {
                if (skin.id == data.id)
                {
                    skin.unlocked = data.unlocked;
                    skin.selected = data.selected;
                    Debug.Log("Loaded skin: " + data.skinName);
                }
            }
        }
    }

    public void TestingSave()
    {
        foreach (var skin in skins)
        {
            Debug.Log("Skin: " + skin.skinName + " | Unlocked: " + skin.unlocked);
        }
    }
}

[System.Serializable]
public class SaveSkin
{
    public string skinName;
    public int rarity;
    public int id;
    public bool unlocked;
    public bool selected;
}

[System.Serializable]
public class SaveLoadSkinsWrapper
{
    public List<SaveSkin> skins;
}
