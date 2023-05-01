using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int health;

    private void Awake(){
        health = maxHealth;
    }

    ////KILL THIS WHEN GAMES SHOWCASE IS OVER
    //private bool resetTriggered = false;
    //public void Update()
    //{
    //    if (health <= 0 && !resetTriggered)
    //    {
    //        resetTriggered = true;
    //        FindObjectOfType<TransitionController>().ResetCurrentScene();
    //    }
    //}

    public void loseHealth(int amount){
        health -= amount;
        if(health < 0) health = 0;
    }

    public void gainHealth(int amount){
        health += amount;
        if(health > maxHealth) health = maxHealth;
    }

    public bool baseDestroyed(){
        return health == 0;
    }

    public int getCurrentHealth()
    {
        return health;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }
}
