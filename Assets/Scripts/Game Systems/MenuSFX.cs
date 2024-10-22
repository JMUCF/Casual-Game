using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;

    public AudioClip enter, exit;

    public void ExitSound()
    {
        audioSource.clip = exit;
        audioSource.Play();
    }
    public void EnterSound()
    {
        audioSource.clip = enter;
        audioSource.Play();
    }
}
