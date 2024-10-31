using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSFX : MonoBehaviour
{
    [SerializeField]
    private AudioSource audioSource;
    public static MenuSFX SFXInstance;

    public AudioClip enter, exit;

    private void Awake()
    {
        if (SFXInstance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            SFXInstance = this;
            DontDestroyOnLoad(this);
        }
    }
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
