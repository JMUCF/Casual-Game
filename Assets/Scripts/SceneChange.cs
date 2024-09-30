using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{

    [Header("Game Settings")]
    public static string propType;
    public static int spawnAmount, enemyViewRadius, enemyViewAngle, enemySpeed;

    [Header("LoadScreen")]
    public GameObject loadingScreen;
    public Image LoadingBarFill;

    //Switches scene to Difficulty Scene
    public void PlayButton()
    {
        StartCoroutine(LoadSceneAsync(1));
    }

    //Switches Scene to Game with Easy Difficulty and required Assets
    public void SuburbsButton()
    {
        SetTypes("Suburbs", 10, 4, 45, 2);
        StartCoroutine(LoadSceneAsync(2));
    }

    //Switches Scene to Game with Medium Difficulty and required Assets
    public void PlayCity()
    {
        SetTypes("City", 25, 6, 60,4);
        StartCoroutine(LoadSceneAsync(2));
    }

    //Switches Scene to Game with Hard Difficulty and required Assets
    public void PlayArmy()
    {
        SetTypes("Army", 50, 8, 90,5);
        StartCoroutine(LoadSceneAsync(2));
    }

    //Returns to Start Menu
    public void HomeButton()
    {
        StartCoroutine(LoadSceneAsync(0));
    }

    //Restarts the Level
    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    IEnumerator LoadSceneAsync(int sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(progressValue);
            LoadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }

    private void SetTypes(string type, int propCount,int viewRad, int viewAgl,int speed)
    {
        propType = type;
        spawnAmount = propCount;
        enemyViewRadius = viewRad;
        enemyViewAngle = viewAgl;
        enemySpeed = speed;
    }
}
