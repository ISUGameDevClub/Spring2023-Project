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
        //this needs to be a reset to the last completed wave!!!
        FindObjectOfType<TransitionController>().ResetCurrentScene();
    }

    //public void HaltPlayerActions()
    //{
    //    //FindObjectOfType<PlayerMovement>().canWalk = false;
    //    //FindObjectOfType<Shooting>().canShoot = false;
    //}
}
