using UnityEngine.Audio;
using UnityEngine;
using System;

[System.Serializable]
public class AudioManagerSound
{
    public string name;

    public AudioClip clip;
    [Range(0f, 1f)]
    public float volume;
    [Range(.1f, 3f)]
    public float pitch;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

    public AudioManagerSound(string name, AudioClip clip, float volume, float pitch, bool loop, AudioSource source)
    {
        this.name = name;
        this.clip = clip;
        this.volume = volume;
        this.pitch = pitch;
        this.loop = loop;
        this.source = source;
        InitializeSource();
    }
    private void InitializeSource()
    {
        source.clip = clip;
        source.volume = volume;
        source.pitch = pitch;
        source.loop = loop;
    }
}
