using UnityEngine.Audio;
using System;
using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    float masterListenerVolume;
    public List<AudioManagerSound> readySounds;
    public List<AudioManagerSound> soundBank;

    public string firstSongName;

    public static AudioManager instance;

    public float fadeTime;
    private List<float> fadeTimeRemaining;


    public void SetMasterListenerVolume(float volume)
    {
        masterListenerVolume = volume;
    }

    public float GetMasterListenerVolume()
    {
        return masterListenerVolume;
    }
    void Awake()
    {
        // Make sure new scenes don't have any extra AudioManagers since this one persists
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {

        masterListenerVolume = 1f;
        fadeTimeRemaining = new List<float>();

        // Start by playing first sound, written in editor
        Play(firstSongName);
    }

    // Play song by name
    public void Play(string name)
    {
        // Ignore Play command if same song is already playing
        if (readySounds.Count > 0)
        {
            if (readySounds[0].name.Equals(name))
            {
                Debug.Log("AudioManagerSound: " + name + " is already playing");
                return;
            }
        }
        bool soundFound = false;
        // Locate desired sound and insert it into first index
        foreach (AudioManagerSound s in soundBank)
        {
            if (s.name.Equals(name))
            {
                // Make a new AMS that clones the selected one from the soundBank
                AudioManagerSound newS = new AudioManagerSound (s.name, s.clip, s.volume, s.pitch, s.loop, gameObject.AddComponent<AudioSource>());
                newS.source.volume = 0f; // initial volume to 0
                readySounds.Insert(0, newS); // newest sound gets priority
                readySounds[0].source.Play();
                // fadeTimeRemaining[] should have an entry for each one in readySounds[]
                // Probably would be better to include the fadeTimeRemaining in the sound object itself actually... eh too much work now lol
                fadeTimeRemaining.Insert(0, fadeTime);
                // For other fades (such as the one that just got pushed back, if it exists), set them if they arent already ticking
                if (fadeTimeRemaining.Count > 1) // if there was already a song playing that got pushed back
                {
                    for (int i = 1; i < fadeTimeRemaining.Count; i++)
                    {
                        // If not already on fade timer
                        if (fadeTimeRemaining[i] <= 0)
                        {
                            fadeTimeRemaining[i] = fadeTime;
                        }
                    }
                }
                soundFound = true;
                break;
            }
        } 
        if (!soundFound)
        {
            Debug.LogWarning("AudioManagerSound: " + name + " not found in soundBank");
        }
    }
    public void Pause()
    {
        foreach (AudioManagerSound s in readySounds)
        {
            s.source.Pause();
        }
    }
    public void Stop()
    {
        foreach (AudioManagerSound s in readySounds)
        {
            s.source.Stop();
        }
    }

    private void Update()
    {
        
        //// for testing bgm fade
        //if (Input.GetKeyDown(KeyCode.O)) {
        //    Play("BGM2");
        //}
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    Play("BGM");
        //}


        // handle fades
        if (fadeTimeRemaining.Count > 0) // just protection against list being empty
        {
            for (int i = 0; i < fadeTimeRemaining.Count; i++) // iterate through list
            {
                if (fadeTimeRemaining[i] > 0) // if fade time left on current element
                {
                    if (i == 0) // fade in first element
                    {
                        readySounds[0].source.volume += (readySounds[0].volume / (fadeTime / Time.deltaTime));
                    }
                    else // fade out other elements
                    {
                        readySounds[i].source.volume -= (readySounds[i].volume / (fadeTime / Time.deltaTime));
                    }
                    fadeTimeRemaining[i] -= Time.deltaTime;
                }
                else // if no fade time left
                {
                    if (i == 0) // ensure new clip volume ends up at the proper setting
                    {
                        readySounds[0].source.volume = readySounds[0].volume;
                    }
                    else // if not first element, then ensure volume is gone and remove element
                    {
                        readySounds[i].source.volume = 0f;
                        readySounds.RemoveAt(i);
                        fadeTimeRemaining.RemoveAt(i);
                    }
                }
            }
        }
    }
}
