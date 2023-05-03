using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Main Menu functions
    public void SceneChange(string newScene)
    {
        Debug.Log("changing scene to " + newScene);
        FindObjectOfType<TransitionController>().FadeToLevel(newScene);
    }

    public void ExitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    public void ChangeSong(string newSong)
    {
        FindObjectOfType<AudioManager>().Play(newSong);
    }

    //Options Menu functions

}
