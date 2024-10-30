using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplySkin : MonoBehaviour
{
    public GameObject player;
    public jsonSave save;

    void Start()
    {
        Invoke("ApplySkinToPlayer", .2f);
    }

    public void ApplySkinToPlayer()
    {
        Debug.Log("Attempting to apply skin to player");
        Skin selectedSkin = null;

        foreach (Skin skin in save.skins)
        {
            if (skin.selected && skin.unlocked)
            {
                selectedSkin = skin;
                break;
            }
        }

        if (selectedSkin == null)
        {
            Debug.LogWarning("No selected skin found or none is unlocked.");
            return;
        }

        Debug.Log($"Selected Skin: {selectedSkin.skinName}, ID: {selectedSkin.id}, Unlocked: {selectedSkin.unlocked}");

        Transform ricky1 = player.transform.Find("Ricky 1");
        if (ricky1 == null)
        {
            Debug.LogWarning("Ricky 1 not found on player.");
            return;
        }

        Renderer renderer = ricky1.GetComponent<Renderer>();
        if (renderer == null)
        {
            Debug.LogWarning("Renderer not found on Ricky 1.");
            return;
        }

        Material[] newMaterials = new Material[7];
        for (int i = 0; i < 7; i++)
        {
            newMaterials[i] = new Material(selectedSkin.materials[i]);
        }

        renderer.materials = newMaterials;

        Debug.Log("Applied skin: " + selectedSkin.skinName);
    }
}
