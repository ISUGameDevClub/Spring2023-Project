using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float attackRange = 1f;
    private float movementTime;
    private float timeStop;
    // Start is called before the first frame update
    void Start()
    {
        movementTime = attackRange / speed;
        timeStop = Time.time + movementTime;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(1,0) * speed * Time.deltaTime);
        if (Time.time >= timeStop)
        {
            Destroy(this.gameObject);
        }
    }
}