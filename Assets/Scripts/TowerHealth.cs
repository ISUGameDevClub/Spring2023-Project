using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealth : MonoBehaviour
{

    [SerializeField] 
    int currentHealth;
    public int totalHealth;

    public void loseHealth(int damage)
    {
        currentHealth = currentHealth - damage;
        if (currentHealth <= 0)
        {
            GameObject.Find("SoundController").GetComponent<Sound>().SpawnSound("TowerDestroy");
            Destroy(gameObject);
        }
    }

    public void gainHealth(int heal)
    {
        currentHealth += heal;
    }

    public void levelUpHealth(int inhealth)
    {
        totalHealth += inhealth;
        currentHealth += inhealth;
    }

    public void setHealth(int newHealth)
    {
        currentHealth += newHealth - totalHealth;
        totalHealth = newHealth;
    }

    public float GetHealthPercent()
    {
        if(currentHealth == 0 && totalHealth == 0)
        {
            return 0;
        }
        return (float)currentHealth / (float)totalHealth;
    }
}
