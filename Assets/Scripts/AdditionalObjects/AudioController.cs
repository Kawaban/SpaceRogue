using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class AudioController : MonoBehaviour
{
    public static AudioController Instance { get; private set; }

    [SerializeField] private  AudioCollection audioCollection;
    [SerializeField] private AudioMixer audioMixer;

    private static Dictionary<string, Sound> soundsDictionary = new Dictionary<string, Sound>(); 

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
            foreach (Sound sound in audioCollection.sounds)
            {
                sound.AudioSource = gameObject.AddComponent<AudioSource>();
                Debug.Log(audioMixer.FindMatchingGroups("")[0]);
                sound.AudioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("")[0];
                sound.AudioSource.clip = sound.audio;
                sound.AudioSource.pitch = sound.pitch;
                sound.AudioSource.volume = sound.volume;
                sound.AudioSource.loop = sound.loop;
                soundsDictionary.Add(sound.name, sound);
            }
        }


        
    }

    

    public void Play(string name)
    {
        if(isExisting(name) && !isPlayed(name))
            soundsDictionary[name].AudioSource.Play();
        
    }

    public void Play(Sound sound)
    {
        if (isExisting(sound.name))
        {
            soundsDictionary[sound.name].AudioSource.Play();
        }
        else
        {
            sound.AudioSource = gameObject.AddComponent<AudioSource>();
            sound.AudioSource.outputAudioMixerGroup = audioMixer.FindMatchingGroups("")[0];
            sound.AudioSource.clip = sound.audio;
            sound.AudioSource.pitch = sound.pitch;
            sound.AudioSource.volume = sound.volume;
            sound.AudioSource.loop = sound.loop;
            soundsDictionary.Add(sound.name, sound);
            sound.AudioSource.Play();
        }
    }

    public void Off(string name)
    {
        if(isPlayed(name))
           soundsDictionary[name].AudioSource.Stop();
    }

    private Boolean isPlayed(string name)
    {
        if (isExisting(name))
        {
            return soundsDictionary[name].AudioSource.isPlaying;
        }
        return false;
    }

    private Boolean isExisting(string name)
    {
        return soundsDictionary.ContainsKey(name);
    }

    
    
}
