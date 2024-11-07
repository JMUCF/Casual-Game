using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    //Stars
    public int pointsEarned;
    public int starsEarned;


    //Star Conditions
    [SerializeField]
    private bool playerSeen = false;

    //SceneStuff
    private static int ScenesCompleted = 0;


    //UIStuff
    public GameObject winScreen;
    public GameObject loseScreen;

    //Enemy
    public GameObject Enemy;

    #region Event Listeners
    private void OnEnable()
    {
        EnemyHitBox.onPlayerLose += LoseState;

        PlayerInteract.earlyWin += WinState;
        PlayerInteract.earlyWin += EarnAStar;

        PlayerInteract.lateWin += WinState;

        EnemyBrain.wasSeen += wasSeen;
    }

    private void OnDisable()
    {
        EnemyHitBox.onPlayerLose -= LoseState;

        PlayerInteract.earlyWin -= WinState;

        PlayerInteract.lateWin -= WinState;
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
        Enemy.SetActive(true);
        winScreen.SetActive(false);
        loseScreen.SetActive(false);
        LoadPlayerStats();
    }
    public void WinState()
    {
        Enemy.SetActive(false);
        EarnAStar();
        ScenesCompleted++;
        if (!playerSeen) 
        { 
            EarnAStar(); 
        }
        pointsEarned += starsEarned;
        SavePlayerStats();
        winScreen.SetActive(true);
        LeanTween.moveLocalY(winScreen, 0, 1);
    }

    private void EarnAStar()
    {
        starsEarned++;
    }
    private void wasSeen()
    {
        Debug.Log("I WAS SEEN");
        playerSeen = true;
    }


    public void LoseState()
    {
        EnemyHitBox.onPlayerLose -= LoseState;
        loseScreen.SetActive(true);
        LeanTween.moveLocalY(loseScreen, 0, 1);
    }

    //WIN/LOSE UI functions

    public void ReturnToHome()
    {
        ScenesCompleted = 0;
        MenuSFX.SFXInstance.EnterSound();
        SceneManager.LoadScene(0);
    }
    public void RestartGame()
    {
        MenuSFX.SFXInstance.EnterSound();
        SceneManager.LoadScene(2);
    }
    public void Contiune()
    {
        MenuSFX.SFXInstance.EnterSound();
        if (ScenesCompleted == 3)
        {
            ScenesCompleted = 0;
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(2);
        }

    }
}
