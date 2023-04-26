using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildCost : MonoBehaviour
{
    CostInfoObject costInfo;

    public int getCurrencyCost()
    {
        return costInfo.currencyCost;
    }

    public int getSeedCost()
    {
        return costInfo.seedCost;
    }
}
