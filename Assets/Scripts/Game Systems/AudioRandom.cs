using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioRandom : MonoBehaviour
{
    public static AudioRandom Instance;

    public AudioClip[] MenuClips;
    public AudioClip[] GameClips;
    public AudioSource source;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }
    public void PlayMenuMusic()
    {
        source.clip = MenuClips[Random.Range(0,MenuClips.Length)];
        source.Play();
    }
    public void PlayGameMusic()
    {
        source.clip = GameClips[Random.Range(0, GameClips.Length)];
        source.Play();
    }
}
