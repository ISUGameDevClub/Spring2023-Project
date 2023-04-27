using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionController : MonoBehaviour
{

    public Animator animator;
    public string nextLevel;

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
        {
            FadeToNextLevel();
        }
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(nextLevel);
    }

    public void FadeToLevel(string levelToLoad)
    {
        nextLevel = levelToLoad;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(nextLevel);
    }

    public void ResetCurrentScene()
    {
        FadeToLevel(SceneManager.GetActiveScene().name);
    }
}
