using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] int health;

    public void loseHealth(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            EnemyDropScript dropScript = this.GetComponent<EnemyDropScript>();
            if (dropScript != null) dropScript.dropItems();
            Destroy(gameObject);
        }
    }

    public void gainHealth(int heal)
    {
        health = health + heal;
    }
}
