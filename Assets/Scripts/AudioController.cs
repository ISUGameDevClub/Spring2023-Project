using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    GameObject am;
    Slider volumeSlider;

    public void Awake()
    {
        am = GameObject.Find("AudioManager");
        volumeSlider = GetComponent<Slider>();
        volumeSlider.value = am.GetComponent<AudioManager>().GetMasterListenerVolume();
    }

    public void SetVolume(float newVolume)
    {
        am.GetComponent<AudioManager>().SetMasterListenerVolume(newVolume);
        AudioListener.volume = newVolume;
        //Debug.Log("Volume = " + AudioListener.volume);
    }
}
