using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{

    [Header("Game Settings")]
    public static string propType;
    public static int spawnAmount, enemyViewRadius, enemyViewAngle;

    [Header("LoadScreen")]
    public GameObject loadingScreen;
    public Image LoadingBarFill;

    public void PlayButton()
    {
        SetTypes("Suburbs", 10, 4, 45);
        StartCoroutine(LoadSceneAsync(1));
    }
    public void PlayCity()
    {
        SetTypes("City", 25, 6, 60);
        StartCoroutine(LoadSceneAsync(1));
    }
    public void PlayArmy()
    {
        SetTypes("Army", 50, 8, 90);
        StartCoroutine(LoadSceneAsync(1));
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

    private void SetTypes(string type, int propCount,int viewRad, int viewAgl)
    {
        propType = type;
        spawnAmount = propCount;
        enemyViewRadius = viewRad;
        enemyViewAngle = viewAgl;
    }
}
