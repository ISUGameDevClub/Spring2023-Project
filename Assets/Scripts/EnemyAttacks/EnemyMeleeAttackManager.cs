using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyMeleeAttackManager : MonoBehaviour
{
    public float enemyAttackSpeed;
    [SerializeField] GameObject projectilePrefab;
    public int attackDamage;
    private bool attackCoroutineRunning = false;
    // Update is called once per frame
    void Update()
    {
        // This function will fire a Prefab at the direction of a target within its collider.
        // The target will depend on who is closer and what priority.
        // Towers will be targeted first even though the player is closer.
        // It will only attack the player if there is not towers in its collider.
        // Targeting system will use the Tower and Player Tags.
        // Attack target every n seconds.
        if (!attackCoroutineRunning && this.GetComponentInChildren<EnemyAttackRangeCollider>().collidersInside.Count > 0)
        {
            StartCoroutine("AttackEntity");
        }
    }

    private IEnumerator AttackEntity()
    {
        attackCoroutineRunning = true;
        //sorts all of the objects in the array in order by distance.
        var target = this.GetComponentInChildren<EnemyAttackRangeCollider>().collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
        if (target.Any(item => item.tag == "Tower"))
        {
            // Gets the first object with the tag of Tower, no matter what postion it is from the array.
            Vector3 vectorToTarget = target[target.IndexOf(target.Where(x => x.tag == "Tower").FirstOrDefault())].transform.position - transform.position;
            // Gets the angle of the target from the fireing origin.
            float targetAngle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, targetAngle));
            projectile.GetComponent<MeleeAttack>().attackDamage = attackDamage;

        }
        else if (target.Any(item => item.tag == "Player"))
        {
            // Gets the first object with the tag of Player, no matter what postion it is from the array.
            Vector3 vectorToTarget = target[target.IndexOf(target.Where(x => x.tag == "Player").FirstOrDefault())].transform.position - transform.position;
            // Gets the angle of the target from the fireing origin.
            float targetAngle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, targetAngle));
            projectile.GetComponent<MeleeAttack>().attackDamage = attackDamage;
        }
        else if (target.Any(item => item.tag == "Core"))
        {
            // Gets the first object with the tag of Core, no matter what postion it is from the array.
            Vector3 vectorToTarget = target[target.IndexOf(target.Where(x => x.tag == "Core").FirstOrDefault())].transform.position - transform.position;
            // Gets the angle of the target from the fireing origin.
            float targetAngle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, targetAngle));
            projectile.GetComponent<MeleeAttack>().attackDamage = attackDamage;
        }
        yield return new WaitForSeconds(enemyAttackSpeed);
        attackCoroutineRunning = false;
    }
}
