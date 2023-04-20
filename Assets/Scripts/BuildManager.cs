using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    StateController currentState;

    CurrencyManager purchase;

    int towerPrice = 50;

    int currentCondition;

    public GameObject tower;


    /*NOTES FROM CODY!
     
    Hey! I just wanted to confirm what we thought about this script from the beginning

    For this script we want this to be able to place towers EVERYWHERE except where turrets are.

    This is actually accomplished pretty easily!

    All we want for this is to look at where the mouse is, estimate the size of the tower, and if another tower is anywhere in that size, then dont allow it!

    We are already kind of doing this, but in the opposite way!

    You are currently tracking IF there is a BUILD POINT and ALLOWING building there.

    All you have to do is swap it around!

    So IF there is a TOWER, then DISALLOW building there!

    Give this a try and let me know if you need any help with this!

    You are doing awesome!
     
     */

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        
        instance = this;

        currentState = GameObject.Find("GameManager").GetComponent<StateController>();

        currentCondition = 0;

        purchase = GameObject.Find("GameManager").GetComponent<CurrencyManager>();
    }

    public GameObject GroundEnemyprefab;
    public GameObject SpinnyEnemyprefab;

    private void Start()
    {
        TurretToBuild = GroundEnemyprefab;
    }

    private GameObject TurretToBuild;

    public GameObject GetTurretToBuild ()
    {
        return TurretToBuild;
    }

    public void SetCondition (int condition)
    {
        currentCondition = condition;
    }
    void Update()
    {   
        if (Input.GetMouseButtonDown(0) && currentState!=null && currentState.state == 1 && currentCondition == 0 && purchase.CanPlayerAfford(towerPrice) == true)
        {
            GameObject.Find("SoundController").GetComponent<Sound>().SpawnSound("TowerPlace1");
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Instantiate(tower, pos, Quaternion.identity);
        }
    }
}
