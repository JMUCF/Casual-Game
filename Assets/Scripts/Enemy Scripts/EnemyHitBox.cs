using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHitBox : MonoBehaviour
{

   // public delegate void OnPlayerLose();
    //public static event OnPlayerLose onPlayerLose;

    public UnityEvent playerLost;


    public AudioClip looseSound;
    [SerializeField]
    bool hasFound = false;
    private void OnEnable()
    {
        hasFound = false ;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !hasFound)
        {
            Debug.LogWarning("Found you!");
            hasFound = true;
            FoundPlayer();
        }
    }

    private void FoundPlayer()
    {
       // onPlayerLose?.Invoke();
        playerLost?.Invoke();
        SFXPlayer.current.PlaySound(looseSound);
    }
}
