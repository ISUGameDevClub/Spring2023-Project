using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    

    [SerializeField] float speed;
    public GameObject point;
    Rigidbody2D rb;
    Vector2 pos;
    [SerializeField] float bufferDistance;
    
    /*
     * Hey its cody! 
     * I know you know what to do from here
     * 
     * Michael finished his script for grabbing the closest thing, now just make the position it moves to the closest thing according to the attack script
     * 
     * I believe!
     * 
     * If you have any questions just let me know :D
     * 
     */
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        
        pos = (point.transform.position) - (Vector3)(rb.position);
        float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
        if (Vector2.Distance(point.transform.position, rb.position) > bufferDistance)
        {
            rb.MovePosition(rb.position + pos.normalized * speed * Time.deltaTime);
        }



    }
}
