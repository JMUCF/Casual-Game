using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EnemyHitBox;

public class GameManager : MonoBehaviour
{

    private void OnEnable()
    {
        EnemyHitBox.onPlayerLose += LoseState;
    }

    public void LoseState()
    {
        Invoke("ChangeScene", 1);
       
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
