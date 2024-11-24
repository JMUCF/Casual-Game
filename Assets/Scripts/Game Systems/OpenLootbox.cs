using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class OpenLootbox : MonoBehaviour
{
    public jsonSave save;
    public GameManager manager;
    private Animator animator;
    public TMP_Text unboxText;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        unboxText.gameObject.SetActive(false);
    }

    public void OpenLootBox()
    {
        List<Skin> availableSkins = GetAvailableSkins();

        if (availableSkins.Count > 0 && CheckPoints())
        {
            animator.SetTrigger("PlayLootBoxAnimation");

            manager.pointsEarned -= 3;
            int randomSkinIndex = Random.Range(0, availableSkins.Count);
            Skin unlockedSkin = availableSkins[randomSkinIndex];
            unlockedSkin.unlocked = true;
            DisplayUnlockedSkin(unlockedSkin.skinName);

            manager.SavePlayerStats();
        }
        else
        {
            Debug.Log("No skins available to unlock.");
        }

        save.SaveSkins();
    }

    private void DisplayUnlockedSkin(string skinName)
    {
        unboxText.text = $"Unlocked: {skinName}";
        unboxText.gameObject.SetActive(true);
        Invoke(nameof(HideUnboxText), 5f);
    }

    private void HideUnboxText()
    {
        unboxText.gameObject.SetActive(false);
    }

    private bool CheckPoints()
    {
        PlayerData data = SaveSystem.LoadStats();
        manager.pointsEarned = data.totalPoints;
        return data.totalPoints >= 3;
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
