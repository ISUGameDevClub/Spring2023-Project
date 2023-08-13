using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenuScript : MonoBehaviour
{
    public static bool IsGamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject pauseButton;

    GameObject gm;

    void Awake()
    {
        gm = GameObject.Find("GameManager");
    }

    void Update()
    {
        //Change P to Esc for release
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // GameObject.Find("SoundController").GetComponent<Sound>().SpawnSound("MenuSelect");
            if (IsGamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        // Note: If you change the volume multiplier (.2f), make sure to change all 3 uses of it here,
        //     and update the max value of VolumeSlider in the PauseMenu and MainMenu
        // Restore unpaused volume (divide by multiplier)
        AudioListener.volume = AudioListener.volume / .2f;
        IsGamePaused = false;
        pauseButton.SetActive(true);
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        // Apply volume pause multiplier
        AudioListener.volume = AudioListener.volume * .2f;
        IsGamePaused = true;
        //GameObject.Find("PauseButton").SetActive(false);
        pauseButton.SetActive(false);
    }

    public void QuitToMainMenu ()
    {
        Time.timeScale = 1f;
        // Restore unpaused volume (divide by multiplier)
        AudioListener.volume = AudioListener.volume / .2f;
        SceneManager.LoadScene(0);
    }
}
