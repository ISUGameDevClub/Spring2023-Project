using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackRangeCollider : MonoBehaviour
{
    public List<Collider2D> collidersInside = new List<Collider2D>();
    // Creates the array of objects inside of the collider.
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
}
