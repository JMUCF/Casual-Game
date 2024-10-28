using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreChange : MonoBehaviour
{
    private int score;
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        LoadPlayerStats();
        scoreText.SetText(score.ToString());
    }
    public void LoadPlayerStats()
    {
        PlayerData data = SaveSystem.LoadStats();
        score = data.totalPoints;
    }
}
