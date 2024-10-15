using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int pointsEarned;  
    int nextScene;

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

    public void SavePlayerStats()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayerStats()
    {
        PlayerData data = SaveSystem.LoadStats();
        int point = data.starsOwned;
        Debug.Log(point);
    }
    private void Start()
    {
        LoadPlayerStats();
    }
    public void WinState()
    {
        PlayerInteract.onPLayerWin -= WinState;
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
