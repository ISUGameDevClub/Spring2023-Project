using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{

    [SerializeField] int health;
    public void loseHealth(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            GameObject.Find("SoundController").GetComponent<Sound>().SpawnSound("TowerDestroy");
            Destroy(gameObject);
        }
    }

    public void gainHealth(int heal)
    {
        health = health + heal;
    }

    public void levelUpHealth(int inhealth)
    {
        health = inhealth;
    }
}
