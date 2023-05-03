using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradesIconHelper : MonoBehaviour
{
    public GameObject plusIcon;
    public GameObject xIcon;

    private UniversalUpgradeSys upgradeSys;
    private CurrencyManager currencyManager;
    private int towerIndex;


    // Start is called before the first frame update
    void Start()
    {
        upgradeSys = FindObjectOfType<UniversalUpgradeSys>();
        currencyManager = FindObjectOfType<CurrencyManager>();
        towerIndex = GetComponentInChildren<UpdateUpgradeCosts>().towerIndex;
    }

    // Update is called once per frame
    void Update()
    {
        if (currencyManager.CanPlayerAfford(upgradeSys.GetCurrentCost(towerIndex)))
        {
            plusIcon.SetActive(true);
            xIcon.SetActive(false);
        }
        else if(!currencyManager.CanPlayerAfford(upgradeSys.GetCurrentCost(towerIndex)))
        {
            plusIcon.SetActive(false);
            xIcon.SetActive(true);
        }

        if (!upgradeSys.CanUpgradeFurther(towerIndex))
        {
            this.gameObject.SetActive(false);
        }
    }
}
