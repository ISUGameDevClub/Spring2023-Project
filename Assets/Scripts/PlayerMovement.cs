using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Player smoothing
    [SerializeField] float speed;
    [SerializeField] AnimationCurve acceleration;
    [SerializeField] float accelerationDuration;
    [SerializeField] AnimationCurve deceleration;
    [SerializeField] float decelerationDuration;
    private Vector2 lastDirection;
    private float timePass = 0;
    private float currentSpeed;
    private float timeSound = 0;
    
    Rigidbody2D rb;
    Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    private void Update()
    {
        // Run when any of the direction keys are pressed
        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            // Store the last direction the player was moving
            lastDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            // Accelerate player
            timePass += Time.deltaTime;
            float linearT = timePass / accelerationDuration;
            float heightT = acceleration.Evaluate(linearT);
            currentSpeed = Mathf.Lerp(0, 4, heightT);
            lastDirection = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if(timeSound <= 0)
            {
                GameObject.Find("SoundController").GetComponent<Sound>().SpawnSound("Footsteps2");
                timeSound = 1f;
            }
            else
            {
                timeSound -= Time.deltaTime;
            }
        }
        else
        {
            // Make sure that time is not over the deceleration duration
            if (timePass > decelerationDuration)
            {
                timePass = decelerationDuration;
            }
            // Make sure that time never goes below 0
            if (timePass <= 0)
            {
                timePass = 0;
            } else
            {
                // Decelerate Player
                timePass -= Time.deltaTime;
                float linearT = timePass / decelerationDuration;
                float heightT = deceleration.Evaluate(linearT);
                currentSpeed = Mathf.Lerp(0, 4, heightT);
                direction = lastDirection;
            }
        }
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + direction.normalized * Time.fixedDeltaTime * currentSpeed * speed);
    }
    public Vector2 GetDirection()
    {
        return direction;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy/Ground")
        {
            Debug.Log("I can hit that");
        } else if(collision.transform.tag == "Enemy/Flying")
        {
            Debug.Log("I can't hit that");
        } else
        {
            Debug.Log("WTF is that");
            Debug.Log(collision.transform.tag);

        }
    }
}
