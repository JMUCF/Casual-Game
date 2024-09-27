using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
