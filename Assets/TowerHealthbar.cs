using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHealthbar : MonoBehaviour
{
    private Vector3 localScale;
    private TowerHealth towerHealth;

    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        towerHealth = GetComponentInParent<TowerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        localScale.x = towerHealth.GetHealthPercent();
        transform.localScale = localScale;
    }
}
