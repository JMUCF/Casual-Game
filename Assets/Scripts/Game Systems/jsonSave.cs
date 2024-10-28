using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class jsonSave : MonoBehaviour
{
    public Skin[] skins; // Skins that are currently in the game

    void Start()
    {
        // Initialize your skins array with existing skin objects
        skins = new Skin[]
        {
        new Skin { skinName = "Skin1", rarity = 0, id = 0, unlocked = false },
        new Skin { skinName = "Skin2", rarity = 0, id = 1, unlocked = false },
        new Skin { skinName = "Skin3", rarity = 0, id = 2, unlocked = false }
        };
    }

    public void SaveSkins()
    {
        Debug.Log("Saving skins");

        // Convert skins to serializable data
        List<SaveSkin> saveData = new List<SaveSkin>();
        foreach (Skin skin in skins)
        {
            saveData.Add(new SaveSkin
            {
                skinName = skin.skinName,
                rarity = skin.rarity,
                id = skin.id,
                unlocked = skin.unlocked
            });
        }

        // Wrap data in a list wrapper
        SaveLoadSkinsWrapper wrapper = new SaveLoadSkinsWrapper { skins = saveData };
        string json = JsonUtility.ToJson(wrapper, true);

        // Save the data to a file
        string path = Application.persistentDataPath + "/SavedSkins.json";
        File.WriteAllText(path, json);
        Debug.Log("File saved at: " + path);
    }

    public void LoadSkins()
    {
        Debug.Log("in load");
        string path = Application.persistentDataPath + "/SavedSkins.json";

        if (!File.Exists(path))
        {
            Debug.LogWarning("Save file not found.");
            return;
        }

        // Load and deserialize data
        string json = File.ReadAllText(path);
        SaveLoadSkinsWrapper wrapper = JsonUtility.FromJson<SaveLoadSkinsWrapper>(json);

        foreach (SaveSkin data in wrapper.skins)
        {
            foreach (Skin skin in skins)
            {
                if (skin.id == data.id)
                {
                    skins[skin.id].skinName = data.skinName;
                    skins[skin.id].rarity = data.rarity;
                    skins[skin.id].unlocked = data.unlocked;
                    Debug.Log("Loaded skin: " + data.skinName);
                }
            }
        }
    }

    public void TestingSave() //run this to make sure that the skins are in fact loaded 
    {
        Debug.Log(skins[0].skinName);
        Debug.Log(skins[1].skinName);
        Debug.Log(skins[2].skinName);
    }
}

[System.Serializable]
public class SaveSkin
{
    public string skinName;
    public int rarity;
    public int id;
    public bool unlocked;
}

[System.Serializable]
public class SaveLoadSkinsWrapper
{
    public List<SaveSkin> skins;
}
