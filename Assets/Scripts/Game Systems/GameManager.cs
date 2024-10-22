using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pointsEarned;  
    private int nextScene;

    #region Event Listeners
    private void OnEnable()
    {
        EnemyHitBox.onPlayerLose += LoseState;
        PlayerInteract.onPLayerWin += WinState;
    }

    private void OnDisable()
    {
        EnemyHitBox.onPlayerLose -= LoseState;
        PlayerInteract.onPLayerWin -= WinState;
    }
    #endregion
    #region Save Systems
    public void SavePlayerStats()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayerStats()
    {
        PlayerData data = SaveSystem.LoadStats();
        pointsEarned = data.totalPoints;
    }
    #endregion
    private void Start()
    {
        AudioRandom.Instance.PlayGameMusic();
        LoadPlayerStats();
    }
    public void WinState()
    {
        PlayerInteract.onPLayerWin -= WinState;
        EnemyHitBox.onPlayerLose -= LoseState;
        nextScene = 2;
        pointsEarned++;
        SavePlayerStats();
        Invoke("ChangeScene", 1);
    }

    public void LoseState()
    {
        EnemyHitBox.onPlayerLose -= LoseState;
        Invoke("ChangeScene", 1);
        nextScene = 0;
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
