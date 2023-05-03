using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public Animator tutorialAnims;
    private int currentStage;
    public GameObject[] enemiesInScene;

    // Start is called before the first frame update
    void Start()
    {
        currentStage = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentStage == 1)
        {
            if(Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                tutorialAnims.SetTrigger("tutorial2");
                currentStage++;
            }
        }
        else if (currentStage == 2)
        {
            if (FindObjectOfType<StateController>().getState() == 1 || FindObjectOfType<StateController>().getState() == 2)
            {
                tutorialAnims.SetTrigger("tutorial3");
                currentStage++;
            }
        }
        else if (currentStage == 3)
        {
            if (FindObjectOfType<UniversalUpgradeSys>().shopActive)
            {
                tutorialAnims.SetTrigger("tutorial4");
                currentStage++;
            }
        }
        else if (currentStage == 4)
        {
            if(AllElementsEmpty())
            {
                tutorialAnims.SetTrigger("tutorial5");
                currentStage++;
            }
        }
    }

    private bool AllElementsEmpty()
    {
        foreach (GameObject obj in enemiesInScene)
        {
            if (obj != null)
            {
                return false;
            }
        }
        return true;
    }

    public void EndTutorial(string nextScene)
    {
        FindObjectOfType<TransitionController>().FadeToLevel(nextScene);
    }
}
