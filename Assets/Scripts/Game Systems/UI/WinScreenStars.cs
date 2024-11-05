using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreenStars : MonoBehaviour
{
    float starsEarned;
    public GameObject star1, star2, star3;
    void Start()
    {
        GameManager gm = FindAnyObjectByType<GameManager>();
        starsEarned = gm.starsEarned;
        Debug.Log(starsEarned);
        CheckStars();
    }
    private void CheckStars()
    {
        switch (starsEarned)
        {
            case 0:
                star1.SetActive(true);
                LeanTween.scale(star1, new Vector3(1, 1, 1), 1);
                break;

            case 1:
                star1.SetActive(true);
                LeanTween.scale(star1, new Vector3(1, 1, 1), 1);
                break;

            case 2:
                star1.SetActive(true);
                LeanTween.scale(star1, new Vector3(1, 1, 1), 1);
                star2.SetActive(true);
                LeanTween.scale(star2, new Vector3(1, 1, 1), 1);
                break;
            case 3:
                star1.SetActive(true);
                LeanTween.scale(star1, new Vector3(1, 1, 1), 1);
                star2.SetActive(true);
                LeanTween.scale(star2, new Vector3(1, 1, 1), 1);
                star3.SetActive(true);
                LeanTween.scale(star3, new Vector3(1, 1, 1), 1);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
