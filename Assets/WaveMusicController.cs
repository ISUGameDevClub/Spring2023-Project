using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMusicController : MonoBehaviour
{
    private WaveController waveController;
    private AudioManager audioManager;

    // Start is called before the first frame update
    void Start()
    {
        waveController = FindObjectOfType<WaveController>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(waveController.WaveNumber == 0)
        {
            if(waveController.isSetupPhase())
            {
                audioManager.Play("Setup1");
            }
            else
            {
                audioManager.Play("Attack1");
            }
        }
        if (waveController.WaveNumber == 1)
        {
            if (waveController.isSetupPhase())
            {
                audioManager.Play("Setup2");
            }
            else
            {
                audioManager.Play("Attack2");
            }
        }
        if (waveController.WaveNumber == 2)
        {
            if (waveController.isSetupPhase())
            {
                audioManager.Play("Setup3");
            }
            else
            {
                audioManager.Play("Attack3");
            }
        }
        if (waveController.WaveNumber == 4)
        {
            if (waveController.isSetupPhase())
            {
                audioManager.Play("Setup3");
            }
            else
            {
                audioManager.Play("FinalAttack");
            }
        }
    }
}
