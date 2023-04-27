using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // The player is supposed to share health with the base. See BaseHealthScript.
    //[SerializeField] int health;
    BaseHealthScript baseHealth;

    void Awake(){
        baseHealth = GameObject.Find("core").GetComponent<BaseHealthScript>();
    }

    public void loseHealth(int damage)
    {
        GameObject.Find("SoundController").GetComponent<Sound>().SpawnSound("PlayerDamaged");
        baseHealth.loseHealth(damage);
    }

    public void gainHealth(int heal)
    {
        baseHealth.gainHealth(heal);
    }
}
