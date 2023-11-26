using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Sound 
{
    public AudioClip audio;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    private AudioSource audioSource;
    public string name;

    public Boolean loop;
    public AudioSource AudioSource { get => audioSource; set => audioSource = value; }
}
