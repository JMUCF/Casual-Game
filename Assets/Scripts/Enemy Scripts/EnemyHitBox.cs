using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{

    public delegate void OnPlayerLose();
    public static event OnPlayerLose onPlayerLose;
    public AudioClip looseSound;
    bool hasFound = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !hasFound)
        {
            hasFound = true;
            SFXPlayer.current.PlaySound(looseSound);
            onPlayerLose?.Invoke();
        }
    }
}
