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

    private void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            AudioRandom.Instance.PlayMenuMusic();
        }
    }
    public void PlayButton()
    {   
        StartCoroutine(LoadSceneAsync(1));
    }

    public void MenuButton()
    {
        StartCoroutine(LoadSceneAsync(0));
    }

    public void ShopButton()
    {
        StartCoroutine(LoadSceneAsync(3));
        SetTypes("Suburbs", 10, 4, 45, 2);
    }

    public void SuburbsButton()
    {
        SetTypes("Suburbs", 20, 4, 45, 2);
        StartCoroutine(LoadSceneAsync(2));
    }

    public void PlayCity()
    {
        SetTypes("City", 20, 6, 60,3);
        StartCoroutine(LoadSceneAsync(2));
    }
    public void PlayArmy()
    {
        SetTypes("Army", 20, 8, 90,4);
        StartCoroutine(LoadSceneAsync(2));
    }
    public void Exit()
    {
        Application.Quit();
    }
    IEnumerator LoadSceneAsync(int sceneID)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);

        loadingScreen.SetActive(true);

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
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

    private Vector3 buttonSize;
    private GameObject lastButton;
    public void LeanButton(GameObject button)
    {
        MenuSFX.SFXInstance.EnterSound();
        lastButton = button;
        buttonSize = button.transform.localScale;
        LeanTween.scale(button, buttonSize*1.5f, 0.2f).setOnComplete(resetButton);
    }
    public void resetButton()
    {
        lastButton.transform.localScale = buttonSize;
    }
}
