using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    StateController currentState;

    CurrencyManager purchase;

    Sound towerPlaceSound;

    // Contains information about what tower the player intends to build
    TowerUI towerUI;

    int currentCondition;

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
        //Debug.Log("Currency Manager present");
        towerPlaceSound = GameObject.Find("SoundController").GetComponent<Sound>();
        towerUI = GameObject.Find("TowerBar").GetComponent<TowerUI>();
    }

    /* Noting this out since I'm not sure if it's required
     * private GameObject TurretToBuild;

    public GameObject GetTurretToBuild ()
    {
        return TurretToBuild;
    }*/

    public void SetCondition (int condition)
    {
        currentCondition = condition;
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && currentState != null && currentState.state == 1 && currentCondition == 0)
        {
            GameObject towerToBuild = towerUI.getHoveredTower();
            // Right now, the build manager is only used to build towers that cost currency, but maybe it will be extended to build plants that cost seeds as well.
            // If that's the case, we will have to consider the seed cost of the tower. I also don't think there is a seed pool yet.
            int currencyPrice = towerToBuild.GetComponent<BuildCost>().getCurrencyCost();
            if (purchase.CanPlayerAfford(currencyPrice))
            {
                towerPlaceSound.SpawnSound("TowerPlace1");
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Instantiate(towerToBuild, pos, Quaternion.identity);
                purchase.SubtractCurrency(currencyPrice);
            }
        }
    }
}
