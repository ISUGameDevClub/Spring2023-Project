using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealthScript : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;

    [SerializeField]
    private int health;

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
}
