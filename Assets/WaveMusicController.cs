using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMusicController : MonoBehaviour
{
    private void OnEnable()
    {
        //Debug.Log("WaveMusic OnEnable");
        WaveController.instance.onNewSetupStart += playNextSetupSong;
        WaveController.instance.onNewAttackStart += playNextAttackSong;
    }

    private void OnDisable()
    {
        //Debug.Log("WaveMusic OnDisable");
        WaveController.instance.onNewSetupStart -= playNextSetupSong;
        WaveController.instance.onNewAttackStart -= playNextAttackSong;
    }

    // Start is called before the first frame update
    void Start()
    {
        if(AudioManager.instance is null)
        {
            Debug.LogWarning("AudioManager not found in the scene");
        }
    }

    public void playNextSetupSong(object sender, EventArgs e)
    {
        switch (WaveController.instance.WaveNumber)
        {
            case 0:
                AudioManager.instance?.Play("Setup1");
                break;
            case 1:
                AudioManager.instance?.Play("Setup2");
                break;
            case 2:
                AudioManager.instance?.Play("Setup3");
                break;
            case 3:
                AudioManager.instance?.Play("Setup3");
                break;
        }
    }

    public void playNextAttackSong(object sender, EventArgs e)
    {
        switch (WaveController.instance.WaveNumber)
        {
            case 0:
                AudioManager.instance?.Play("Attack1");
                break;
            case 1:
                AudioManager.instance?.Play("Attack2");
                break;
            case 2:
                AudioManager.instance?.Play("Attack3");
                break;
            case 3:
                AudioManager.instance?.Play("FinalAttack");
                break;
        }
    }

}
