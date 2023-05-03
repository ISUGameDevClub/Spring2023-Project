using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerProjectile : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float attackRange = 1f;
    private float movementTime;
    private float timeStop;
    public int attackDamage;
    // Start is called before the first frame update
    void Start()
    {
        movementTime = attackRange / speed;
        timeStop = Time.time + movementTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1, 0) * speed * Time.deltaTime);

        // Rotate the projectile to face its movement direction
        Vector2 direction = new Vector2(1, 0);
        transform.LookAt(transform.position + new Vector3(direction.x, direction.y, 0));

        if (Time.time >= timeStop)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>())
        {
            collision.GetComponent<EnemyHealth>().loseHealth(attackDamage);
            Destroy(this.gameObject);
        }
    }
}
