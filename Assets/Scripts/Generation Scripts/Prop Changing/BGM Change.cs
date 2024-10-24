using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class BGMChange : SceneTypeCheck
{
    [SerializeField]
    private AudioSource audioSource;
    public AudioClip suburb,city,army;
    void Start()
    {
        Check();
    }
    protected override void CreateSuburbs()
    {
        audioSource.clip = suburb;
        audioSource.Play();
    }
    protected override void CreateCity()
    {
        audioSource.clip = city;
        audioSource.Play();
    }
    protected override void CreateArmy()
    {
        audioSource.clip = army;
        audioSource.Play();
    }
}
