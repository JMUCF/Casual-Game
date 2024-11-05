using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour 
{
    public static SFXPlayer current;
    private AudioSource audioSource;

    private void Start()
    {
        AudioRandom.Instance.PlayGameMusic();
        current = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
