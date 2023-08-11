using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyDetector : MonoBehaviour
{
    private List<Collider2D> collidersInside = new List<Collider2D>();
    private bool coreLockOn = false;
    private GameObject coreObject;
    // Update is called once per frame
    // Creates the array of objects inside of the collider.
    private void Start()
    {
        coreObject = GameObject.Find("core");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if collider already exist inside of the array.
        if ((other.CompareTag("Tower") || other.CompareTag("Player") || other.CompareTag("Core")) && !collidersInside.Contains(other))
        {
            collidersInside.Add(other);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        collidersInside.Remove(other);
    }
    public GameObject GetCloseTower()
    {
        //sorts all of the objects in the array in order by distance.
        var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
        if (target.Any(item => item.GetComponent<TowerHealth>()))
        {
            GameObject vectorToTarget = target[target.IndexOf(target.Where(x => x.GetComponent<TowerHealth>()).FirstOrDefault())].gameObject;
            return vectorToTarget;
        } else if (target.Any(item => item.GetComponent<PlayerHealth>()))
        {
            GameObject vectorToTarget = target[target.IndexOf(target.Where(x => x.GetComponent<PlayerHealth>()).FirstOrDefault())].gameObject;
            return vectorToTarget;
        }
        return null;
    }
    public bool IsNearCore()
    {
        var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
        if (coreLockOn)
        {
            return true;
        }
        if ((target.Any(item => item.name == "core") && !(target.Any(item => item.GetComponent<TowerHealth>())) && !(target.Any(item => item.GetComponent<PlayerHealth>()))) || Vector2.Distance(transform.position, coreObject.transform.position) <= 0.3f)
        {
            coreLockOn = true;
            return true;
        } else
        {
            return false;
        }
    }
}
