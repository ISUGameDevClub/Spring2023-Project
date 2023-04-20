using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChainProjectiles : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float attackRange = 1f;
    [SerializeField] int chains = 1;
    public GameObject lockTarget;
    public int attackDamage;
    public List<GameObject> fireChain = new List<GameObject>();
    [SerializeField] GameObject detectObject;
    private int currentBounce = 0;
    [SerializeField] bool dontChainToSameEnemys;

    // Update is called once per frame
    private void Update()
    {
        // Checks to make sure a target is selected
        if (lockTarget)
        {
            //Move To the enemy and will flow them even through they changed direction.
            transform.position = Vector2.MoveTowards(transform.position, lockTarget.transform.position, speed * Time.deltaTime);
            //Will always turn the bullet to face the enemy.
            Vector3 vectorToTarget = lockTarget.transform.position - transform.position;
            float targetAngle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, targetAngle);
        } else
        {
            // If the target was destoryed, then delete bullet.
            // You can change it to find a new target if the enemy dies before it reaches it target.
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>())
        {
            // Set the bullet to the center of the hit object to make it the firing origin.
            transform.position = collision.transform.position;
            // This If statment checks to make sure that the target is the one that loses health and not other objects in the line of fire.
            // Can be removed if the desired function is to also hit enemys in the path.
            if (collision.gameObject == lockTarget)
            {
                collision.GetComponent<EnemyHealth>().loseHealth(attackDamage);
                fireChain.Add(collision.gameObject);
            }
            //Checks for other enemys in range to fire at.
            if (dontChainToSameEnemys)
            {
                var newTarget = detectObject.GetComponent<TowerChainDetect>().FindClosestWhileExludeArray(fireChain);
                //If no other enemys are near by or the max chain is reach, destory.
                if (newTarget == null || currentBounce >= chains)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    currentBounce++;
                    // add object to array for the function to stop same targeting.
                    fireChain.Add(newTarget);
                    lockTarget = newTarget;
                }
            }
            else
            {
                var newTarget = detectObject.GetComponent<TowerChainDetect>().FindClosestWhileExlude(collision.gameObject);
                //If no other enemys are near by or the max chain is reach, destory.
                if (newTarget == null || currentBounce >= chains)
                {
                    Destroy(this.gameObject);
                }
                else
                {
                    currentBounce++;
                    // add object to array for the function to stop same targeting.
                    fireChain.Add(newTarget);
                    lockTarget = newTarget;
                }
            }
        }
    }
}
