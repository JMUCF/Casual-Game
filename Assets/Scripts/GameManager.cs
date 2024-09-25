using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float timeTaken;
    public bool beenSeen;

    public void Start()
    {
        timeTaken = 0f;
    }

    public void Update()
    {
        timeTaken += Time.deltaTime;
    }
    public void LoseState()
    {
        Debug.Log("You were caught after: " + timeTaken);
        //lose logic goes here
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void WinState()
    {
        Debug.Log("You got the trash!");
        Debug.Log("Time taken: " + timeTaken);
        Debug.Log("Were you seen?: " + beenSeen);
        //win logic goes here
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
