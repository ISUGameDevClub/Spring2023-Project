using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimsHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetToWave()
    {
        FindObjectOfType<WaveController>().WaveNumber = 5;
        FindObjectOfType<TransitionController>().ResetCurrentScene();
    }
}
