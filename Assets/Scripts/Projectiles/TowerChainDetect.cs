using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TowerChainDetect : MonoBehaviour
{
    private List<Collider2D> collidersInside = new List<Collider2D>();
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if collider already exist inside of the array.
        // NOTE: Bullet bug may affect this if statment. 
        if (!other.gameObject.GetComponent<TowerProjectile>() && !collidersInside.Contains(other))
        {
            collidersInside.Add(other);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        collidersInside.Remove(other);
    }
    public GameObject FindClosestEnemy()
    {
        //sorts all of the objects in the array in order by distance.
        var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
        if (target.Any(item => item.GetComponent<EnemyHealth>()))
        {
            GameObject vectorToTarget = target[target.IndexOf(target.Where(x => x.GetComponent<TowerHealth>()).FirstOrDefault())].gameObject;
            return vectorToTarget;
        }
        return null;
    }
    public GameObject FindClosestWhileExlude(GameObject exclude)
    {
        var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
        // checks if the exclude object is inside of the array
        if (target.Any(item => item.gameObject == exclude))
        {
            // Remove the object by finding it position in the array.
            target.Remove(target[target.IndexOf(target.Where(x => x.gameObject == exclude).FirstOrDefault())]);
        }
        if (target.Any(item => item.GetComponent<EnemyHealth>()))
        {
            GameObject vectorToTarget = target[target.IndexOf(target.Where(x => x.GetComponent<EnemyHealth>()).FirstOrDefault())].gameObject;
            return vectorToTarget;
        }
        return null;
    }
    public GameObject FindClosestWhileExludeArray(List <GameObject> exclude)
    {
        var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
        // checks if the exclude object is inside of the array
        foreach(GameObject obj in exclude)
        {
            if (target.Any(item => item.gameObject == obj))
            {
                // Remove the object by finding it position in the array.
                target.Remove(target[target.IndexOf(target.Where(x => x.gameObject == obj).FirstOrDefault())]);
            }
        }
        if (target.Any(item => item.GetComponent<EnemyHealth>()))
        {
            GameObject vectorToTarget = target[target.IndexOf(target.Where(x => x.GetComponent<EnemyHealth>()).FirstOrDefault())].gameObject;
            return vectorToTarget;
        }
        return null;
    }
}
