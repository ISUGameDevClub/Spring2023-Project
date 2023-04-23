using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerUI : MonoBehaviour
{
    public bool buildMode;
    public int towerSelector;
    public GameObject towerBar;
    public GameObject[] outlineLocations;
    public GameObject highlight;
    public float scrollSum;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if build mode is active, instantiate the tower bar animation and pull it up
        if (buildMode == true || Input.GetKeyDown(KeyCode.Alpha1))
        {
            towerBar.gameObject.SetActive(true);
        }
        else
        {
            towerBar.gameObject.SetActive(false);
        }

        //if towerSelector is equal to any of the towers corresponding numbers, switch the highlighted/selected tower
        if (towerSelector>=0 && towerSelector<=5) 
        { 
            highlight.transform.position = outlineLocations[towerSelector].transform.position;
        }
        else
        {
            if (scrollSum > 5)
            {
                scrollSum = 0;
            }

            if (scrollSum < 0)
            {
                scrollSum = 5;
            }
        }
        scrollSum = towerSelector;
        scrollSum -= Input.mouseScrollDelta.y;
        towerSelector = (int)Mathf.Round(scrollSum);

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            towerSelector = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            towerSelector = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            towerSelector = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            towerSelector = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            towerSelector = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            towerSelector = 5;
        }
    }
}
