using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinInitializer : MonoBehaviour
{
    public jsonSave jsonSaveScript; // Reference to the jsonSave script

    private void Start()
    {
        InitializeSkins();
    }

    private void InitializeSkins()
    {
        jsonSaveScript.skins = new Skin[3];

        // Create Skin 1
        Skin skin1 = gameObject.AddComponent<Skin>();
        skin1.skinName = "Red Dragon";
        skin1.rarity = 3;
        skin1.id = 1;
        skin1.unlocked = true;
        jsonSaveScript.skins[0] = skin1;

        // Create Skin 2
        Skin skin2 = gameObject.AddComponent<Skin>();
        skin2.skinName = "Golden Phoenix";
        skin2.rarity = 5;
        skin2.id = 2;
        skin2.unlocked = false;
        jsonSaveScript.skins[1] = skin2;

        // Create Skin 3
        Skin skin3 = gameObject.AddComponent<Skin>();
        skin3.skinName = "Silver Wolf";
        skin3.rarity = 2;
        skin3.id = 3;
        skin3.unlocked = false;
        jsonSaveScript.skins[2] = skin3;

        Debug.Log("Skins initialized for testing");
    }
}
