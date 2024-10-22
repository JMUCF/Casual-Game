using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SetMenuScore : MonoBehaviour
{
    public TMP_Text pointsText;

    void Start()
    {
        UpdatePointsText();
    }

    public void UpdatePointsText()
    {
        PlayerData data = SaveSystem.LoadStats();
        if (data != null)
        {
            pointsText.text = "" + data.totalPoints.ToString();
        }
    }
}
