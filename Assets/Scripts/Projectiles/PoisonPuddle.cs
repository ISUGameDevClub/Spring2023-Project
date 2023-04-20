using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonPuddle : MonoBehaviour
{
    [SerializeField] float puddleDuration;
    [SerializeField] int damgePerTick;
    // How many times per second.
    [SerializeField] int tickRate;
    private List<Collider2D> collidersInside = new List<Collider2D>();
    private float timePass;
    private float tickTimePass;
    private float tickTime;
    // Start is called before the first frame update
    void Start()
    {
        tickTime = 1 / (float) tickRate;
    }

    // Update is called once per frame
    void Update()
    {
        timePass += Time.deltaTime;
        tickTimePass += Time.deltaTime;
        if (tickTimePass >= tickTime)
        {
            tickTimePass = 0;
            foreach(Collider2D obj in collidersInside)
            {
                obj.gameObject.GetComponent<EnemyHealth>().loseHealth(damgePerTick);
            }
        }
        if (timePass >= puddleDuration)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Checks if collider already exist inside of the array.
        // NOTE: Bullet bug may affect this if statment. 
        if (other.gameObject.GetComponent<EnemyHealth>() && !collidersInside.Contains(other))
        {
            collidersInside.Add(other);
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.9186232f, 0.5509434f, 1, 1);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (collidersInside.Contains(other))
        {
            other.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
        collidersInside.Remove(other);
    }
}
