using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSliderUI : MonoBehaviour
{
    private BaseHealthScript baseHealth;
    public Slider healthSlider;

    private void Start()
    {
        baseHealth = GameObject.Find("core").GetComponent<BaseHealthScript>();

        healthSlider.maxValue = baseHealth.getMaxHealth();
        healthSlider.value = baseHealth.getCurrentHealth();
    }

    private void Update()
    {
        healthSlider.value = baseHealth.getCurrentHealth();
    }
}
