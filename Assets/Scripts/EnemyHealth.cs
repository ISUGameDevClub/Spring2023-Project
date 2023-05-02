using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject guardEnemyDogPrefab;
    [SerializeField] int health;

    public void loseHealth(int damage)
    {
        health = health - damage;
        if (health <= 0)
        {
            EnemyDropScript dropScript = this.GetComponent<EnemyDropScript>();
            if (dropScript != null) dropScript.dropItems();

            if (gameObject.name.Length >= 4 && gameObject.name.Substring(0, 5).Equals("Guard"))
            {
                Instantiate(guardEnemyDogPrefab, transform.position, transform.rotation, null);
            }
            Destroy(gameObject);
        }
    }

    public void gainHealth(int heal)
    {
        health = health + heal;
    }
}
