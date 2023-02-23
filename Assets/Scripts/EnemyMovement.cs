using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    

    public float speed;
    public GameObject point;
    Rigidbody2D rb;
    Vector2 pos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, point.transform.position, speed * Time.deltaTime); 
        pos = new Vector2(point.transform.position.x + rb.position.x, point.transform.position.y + rb.position.y);

        rb.MovePosition(rb.position + pos.normalized * speed * Time.deltaTime);
    }
}