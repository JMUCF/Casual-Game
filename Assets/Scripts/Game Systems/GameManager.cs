using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EnemyHitBox;

public class GameManager : MonoBehaviour
{
    public GameObject LosePanel;
    private void OnEnable()
    {
        EnemyHitBox.onPlayerLose += LoseState;
    }
    private void OnDisable()
    {
        EnemyHitBox.onPlayerLose -= LoseState;
    }

    public void LoseState()
    {
        //Invoke("ChangeScene", 1);
        EnableLosePanel();

    }
   /*private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/

    private void EnableLosePanel()
    {
        LosePanel.SetActive(true);
    }
}
