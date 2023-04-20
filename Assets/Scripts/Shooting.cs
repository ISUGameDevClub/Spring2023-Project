using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;

    [SerializeField] float bulletForce;
    [SerializeField] float bulletCooldown;
    private bool canFire;
    // Start is called before the first frame update
    void Start()
    {
        canFire = true;
    }

    // Update is called once per frame
    void Update()
    {
            if (Input.GetButton("Fire1") && canFire)
            {
                Shoot();
                canFire = false;
                StartCoroutine(fireWait());
            }
    }
    void Attack()
    {

    }
    void Shoot()
    {
        GameObject bullet = Instantiate(BulletPrefab, FirePoint.position, FirePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(FirePoint.up * bulletForce, ForceMode2D.Impulse);
        //if (GetComponent<Sound>()) { 
        GameObject.Find("SoundController").GetComponent<Sound>().SpawnSound("Shoot");
        /*}
        else
        {
            Debug.Log("There is no Sound!");
        }*/
    }
    IEnumerator fireWait()
    {
        yield return new WaitForSeconds(bulletCooldown);
        canFire = true;
    }
}


