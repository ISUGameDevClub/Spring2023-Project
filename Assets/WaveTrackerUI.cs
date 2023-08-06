using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WaveTrackerUI : MonoBehaviour
{
    private WaveController waveController;
    private TextMeshProUGUI textGUI;
    public Image waveFill;
    private Slider waveSlider;

    // Start is called before the first frame update
    void Start()
    {
        waveController = FindObjectOfType<WaveController>();
        textGUI = GetComponentInChildren<TextMeshProUGUI>();
        waveSlider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(waveController.WaveNumber);
        textGUI.text = "Wave: " + (waveController.WaveNumber + 1);

        if(waveController.isSetupPhase())
        {
            waveFill.color = new Color(.1f, .4f, .6f, 1);
            waveSlider.maxValue = waveController.GetSetupTime();
            waveSlider.value = waveController.GetSetupTimeElapsed();
        }
        else if(waveController.isActivePhase())
        {
            //Debug.Log(waveController.GetEnemiesSpawned() + " out of " + waveController.GetWaveAmt());
            waveFill.color = new Color(.4f, 0f, 0f, 1);
            waveSlider.maxValue = waveController.GetWaveAmt();
            waveSlider.value = waveController.GetEnemiesSpawned();
            //Track number of enemyholder, 
        }
    }
}
