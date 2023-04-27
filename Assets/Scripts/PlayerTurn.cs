using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurn : MonoBehaviour
{
    public Transform firePoint;
    public SpriteRenderer playerSpriteRenderer;

    Rigidbody2D rb;
    Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void FixedUpdate()
    {
        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        firePoint.rotation = Quaternion.Euler(0f, 0f, angle);

        if (lookDir.x < 0)
        {
            playerSpriteRenderer.flipX = true;
        }
        else
        {
            playerSpriteRenderer.flipX = false;
        }
    }
}
