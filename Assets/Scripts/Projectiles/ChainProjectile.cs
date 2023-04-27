using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainProjectile : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] float attackRange = 1f;
    //[SerializeField] int chains = 1;
    [SerializeField] GameObject projectilePrefab;
    public GameObject fireOrigin;
    private int tempChains;
    private float movementTime;
    private float timeStop;
    public int attackDamage;
    private List<Collider2D> collidersInside = new List<Collider2D>();

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
        if (Time.time >= timeStop)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyHealth>()  && collision.gameObject != fireOrigin)
        {
            collision.GetComponent<EnemyHealth>().loseHealth(attackDamage);

            /*
            Destroy(this.gameObject);
            /*if (tempChains <= chains)
            {
                if (!collision.gameObject.GetComponent<MeleeAttack>() && !collision.gameObject.GetComponent<TowerProjectile>() && !collidersInside.Contains(collision))
                {
                    collidersInside.Add(collision);
                }
                GameObject projectile;
                var target = collidersInside.OrderBy(go => (transform.position - go.transform.position).sqrMagnitude).ToList();
                Vector3 vectorToTarget = target[target.IndexOf(target.Where(x => x.tag == "Enemy/Ground").FirstOrDefault())].transform.position - transform.position;
                float targetAngle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
                projectile = Instantiate(projectilePrefab, transform.position, Quaternion.Euler(0, 0, targetAngle));
                projectile.GetComponent<ChainProjectile>().getChains(tempChains);
                projectile.GetComponent<ChainProjectile>().fireOrigin = fireOrigin;
                projectile.GetComponent<ChainProjectile>().attackDamage = attackDamage;
            }*/
        }
    }

    public void getChains(int tempChains)
    {

        tempChains++;
    }
}
