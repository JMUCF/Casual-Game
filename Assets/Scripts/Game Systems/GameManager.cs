using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static EnemyHitBox;

public class GameManager : MonoBehaviour
{
    int nextScene;
    private void OnEnable()
    {
        EnemyHitBox.onPlayerLose += LoseState;
        PlayerInteract.onPLayerWin += WinState;
    }
<<<<<<< Updated upstream

=======
    private void OnDisable()
    {
        EnemyHitBox.onPlayerLose -= LoseState;
        PlayerInteract.onPLayerWin -= WinState;
    }
    public void WinState()
    {
        Invoke("ChangeScene", 1);
        nextScene = 1;
    }
>>>>>>> Stashed changes
    public void LoseState()
    {
        Invoke("ChangeScene", 1);
        nextScene = 0;
    }
    private void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }
}
