using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public GameObject guardEnemyDogPrefab;
    [SerializeField] int health;
    private bool dying;

    public void loseHealth(int damage)
    {
        if (dying) return;
        health = health - damage;
        if (health <= 0)
        {
            dying = true;
            EnemyDropScript dropScript = this.GetComponent<EnemyDropScript>();
            if (dropScript != null) dropScript.dropItems();

            if (gameObject.name.Length >= 4 && gameObject.name.Substring(0, 5).Equals("Guard"))
            {
                Instantiate(guardEnemyDogPrefab, transform.position, transform.rotation, WaveController.instance.enemyHolder);
            }
            GetComponent<Rigidbody2D>().simulated = false;
            GetComponent<EnemyMeleeAttackManager>().enabled = false;
            GetComponent<EnemyMovement>().enabled = false;
            GetComponentInParent<Animator>().SetTrigger("death");
        }
    }

    public void gainHealth(int heal)
    {
        health = health + heal;
    }

    //Animator Method
    public void DestroyObject()
    {
        Destroy(gameObject);
    }
}
