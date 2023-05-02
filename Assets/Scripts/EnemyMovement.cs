using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Animator enemyAnims;

    [SerializeField] float speed;
    [SerializeField] GameObject towerDetectObject;
    private Rigidbody2D rb;
    Vector2 pos;
    [SerializeField] float bufferDistance;
    private GameObject playerCore;

    //Player Anti Follow
    private Vector2 centerMaxRange;
    [SerializeField] float maxPlayerFollowRange = 4;
    [SerializeField] float playerIgnoreCooldown = 2;
    private bool playerAgro = false;
    private bool ignorePlayer = false;

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
        enemyAnims = GetComponent<Animator>();

        rb = GetComponent<Rigidbody2D>();
        playerCore = GameObject.Find("core");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject NearestObject = towerDetectObject.GetComponent<EnemyDetector>().GetCloseTower();
        bool nearCore = towerDetectObject.GetComponent<EnemyDetector>().IsNearCore();
        if (NearestObject != null)
        {
            if (NearestObject.GetComponent<PlayerHealth>() && !playerAgro && !ignorePlayer && !nearCore)
            {
                // Run once to get the center position of player for the max range.
                playerAgro = true;
                centerMaxRange = NearestObject.transform.position;
            } else if (playerAgro && Vector2.Distance(transform.position, centerMaxRange) >= maxPlayerFollowRange)
            {
                // Run when player gets out of range and ignores them for N amount of seconds.
                ignorePlayer = true;
                playerAgro = false;
                StartCoroutine("PlayerAgroCooldown");
            }
            if ((NearestObject.GetComponent<PlayerHealth>() && ignorePlayer) || nearCore)
            {
                // default to the core if ignorePlayer is enabled
                pos = (playerCore.transform.position) - (Vector3)(rb.position);
                float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                if (Vector2.Distance(playerCore.transform.position, rb.position) > bufferDistance)
                {
                    rb.MovePosition(rb.position + pos.normalized * speed * Time.deltaTime);
                    enemyAnims.SetBool("moving", true);
                }
            } else
            {
                if (!NearestObject.GetComponent<PlayerHealth>())
                {
                    // Set the agro if targeting changes.
                    playerAgro = false;
                }
                pos = (NearestObject.transform.position) - (Vector3)(rb.position);
                float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - 90f;
                rb.rotation = angle;
                if (Vector2.Distance(NearestObject.transform.position, rb.position) > bufferDistance)
                {
                    rb.MovePosition(rb.position + pos.normalized * speed * Time.deltaTime);
                    enemyAnims.SetBool("moving", true);
                }
            }

            //Flip sprite TOWARDS what its facing.
            if(rb.position.x - NearestObject.transform.position.x < 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else if(rb.position.x - NearestObject.transform.position.x > 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
        } else
        {
            pos = (playerCore.transform.position) - (Vector3)(rb.position);
            float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = angle;
            if (Vector2.Distance(playerCore.transform.position, rb.position) > bufferDistance)
            {
                rb.MovePosition(rb.position + pos.normalized * speed * Time.deltaTime);
                enemyAnims.SetBool("moving", true);
            }

            //Flip sprite TOWARDS the player. 
            if (rb.position.x - playerCore.transform.position.x < 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
            else if (rb.position.x - playerCore.transform.position.x > 0)
            {
                GetComponentInChildren<SpriteRenderer>().flipX = true;
            }
        }
    }
    private IEnumerator PlayerAgroCooldown()
    {
        yield return new WaitForSeconds(playerIgnoreCooldown);
        ignorePlayer = false;
    }
}
