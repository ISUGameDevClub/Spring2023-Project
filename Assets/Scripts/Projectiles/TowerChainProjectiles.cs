using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerChainProjectiles : MonoBehaviour
{
    //Gamobject setpiece for bloodsplatter effect.
    public GameObject bloodSplatter;

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
        // The lockTarget condition enforces that the projectile only affects its target.
        // If removed, it could instead affect the first enemy blocking the path between the target.
        if (collision.GetComponent<EnemyHealth>() && collision.gameObject == lockTarget)
        {
            Instantiate(bloodSplatter, collision.transform.position, collision.transform.rotation, null);
            transform.position = collision.transform.position;
            fireChain.Add(collision.gameObject);
            collision.GetComponent<EnemyHealth>().loseHealth(attackDamage);
            
        
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
                    lockTarget = newTarget;
                }
            }
        }
    }
}
