using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject BulletPrefab;

    GameObject soundCont; 
    [SerializeField] float bulletForce;
    [SerializeField] float bulletCooldown;
    private bool canFire;
    // Start is called before the first frame update
    void Start()
    {
        soundCont = GameObject.Find("SoundController");
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
        soundCont.GetComponent<Sound>().SpawnSound("PitchforkThrow");
    }
    IEnumerator fireWait()
    {
        yield return new WaitForSeconds(bulletCooldown);
        canFire = true;
    }
}


