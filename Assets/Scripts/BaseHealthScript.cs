using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    private Animator playerAnims;

    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int health;

    private void Awake(){
        health = maxHealth;
    }

    private void Start()
    {
        playerAnims = FindObjectOfType<PlayerMovement>().GetComponentInChildren<Animator>();
    }

    ////KILL THIS WHEN GAMES SHOWCASE IS OVER
    // okay... maybe not.
    private bool resetTriggered = false;
    public void Update()
    {
        if (health <= 0 && !resetTriggered)
        {
            resetTriggered = true;

            //FindObjectOfType<TransitionController>().ResetCurrentScene();
            //instead of this, we'll just play the death animation.
            //the animation has a trigger for a reset.
            playerAnims.SetBool("death", true);
        }
    }

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
