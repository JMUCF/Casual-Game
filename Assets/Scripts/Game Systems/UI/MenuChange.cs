using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChange : MonoBehaviour
{
    public GameObject mainMenu, howToPlay, credits;
    private GameObject currentMenu;

    private void Start()
    {
        
        mainMenu.transform.LeanMoveLocalY(10, 5f).setLoopPingPong();
    }
    public void BackButton()
    {
        mainMenu.SetActive(true);
        currentMenu.SetActive(false);
    }
    public void HelpMenu()
    {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
        currentMenu = howToPlay;
    }
    public void CreditsMenu()
    {
        mainMenu.SetActive(false);
        credits.SetActive(true);
        currentMenu = credits;
    }
}
