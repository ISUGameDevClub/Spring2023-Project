using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    // Main Menu functions
    public void PlayGame()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        FindObjectOfType<TransitionController>().FadeToLevel("GameShowcaseDemo1");
    }

    public void ExitGame()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }

    //Options Menu functions

}
