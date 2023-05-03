using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUpgradeCosts : MonoBehaviour
{
    private TextMeshProUGUI costText;
    private UniversalUpgradeSys upgradeSys;
    public int towerIndex;


    // Start is called before the first frame update
    void Start()
    {
        costText = GetComponent<TextMeshProUGUI>();
        upgradeSys = FindObjectOfType<UniversalUpgradeSys>();
    }

    // Update is called once per frame
    void Update()
    {
        costText.text = "$" + upgradeSys.GetCurrentCost(towerIndex);
    }
}
