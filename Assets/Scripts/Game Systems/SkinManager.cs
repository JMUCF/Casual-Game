using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinManager : MonoBehaviour
{
    public GameObject[] skins;

    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SaveSystem.LoadStats();
        if (data != null)
        {
            data.InitializeSkins(10);
            for (int i = 0; i < data.skinsUnlocked.Length; i++)
            {
                Debug.Log(data.skinsUnlocked[0]);
            }
        }
    }
}
