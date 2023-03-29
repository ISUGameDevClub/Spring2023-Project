using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerAttack : MonoBehaviour
{
    public float towerAttackSpeed;
    private List<Collider2D> collidersInside = new List<Collider2D>();
    [SerializeField] GameObject projectilePrefab;
    public int attackDamage;
    private bool attackCoroutineRunning = false;
    [SerializeField] string towerType;
    // Update is called once per frame
    void Update()
    {
        // This function will fire a Prefab at the direction of a target within its collider.
        // The target will depend on who is closer and what priority.
        // Towers will be targeted first even though the player is closer.
        // It will only attack the player if there is not towers in its collider.
        // Targeting system will use the Tower and Player Tags.
        // Attack target every n seconds.
        if (!attackCoroutineRunning && collidersInside.Count > 0)
        {
            StartCoroutine("AttackEntity");
        }
    }
    // Creates the array of objects inside of the collider.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if collider already exist inside of the array.
        if (!other.gameObject.GetComponent<MeleeAttack>() && !other.gameObject.GetComponent<TowerProjectile>() && !collidersInside.Contains(other))
        {
            collidersInside.Add(other);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        collidersInside.Remove(other);
    }

    private IEnumerator AttackEntity()
    {
        attackCoroutineRunning = true;
        //sorts all of the objects in the array in order by distance.
        var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
        
        if (target.Any(item => item.GetComponent<EnemyHealth>()))
        {
            GameObject projectile;
            // Gets the first object with the tag of Tower, no matter what postion it is from the array.
            Vector3 vectorToTarget = target[target.IndexOf(target.Where(x => x.tag == "Enemy/Ground").FirstOrDefault())].transform.position - transform.position;
            // Gets the angle of the target from the fireing origin.
            float targetAngle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            if (towerType == "standard" || towerType == "sniper")
            {
                projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, targetAngle));
                projectile.GetComponent<TowerProjectile>().attackDamage = attackDamage;
            }
            if (towerType == "shotgun")
            {
                projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, targetAngle));
                projectile.GetComponent<TowerProjectile>().attackDamage = attackDamage;
                projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, targetAngle + 45));
                projectile.GetComponent<TowerProjectile>().attackDamage = attackDamage;
                projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, targetAngle - 45));
                projectile.GetComponent<TowerProjectile>().attackDamage = attackDamage;
            }
        }
        yield return new WaitForSeconds(towerAttackSpeed);
        attackCoroutineRunning = false;
    }
}
