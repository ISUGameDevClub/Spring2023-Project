using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * The point of this class is to be an easy way to identify the initial build cost of a given tower.
 * Note that the actual cost info is currently stored in a scriptable object. Any changes to the values
 * of the scriptable object will reflect on any script accessing that same scriptable object.
 * 
 * It may have been a better choice to make a centralized script to store build costs for different tower types, but this
 * was just an easy an quick way to go about it.
 *
 */
public class BuildCost : MonoBehaviour
{
    [SerializeField]
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
