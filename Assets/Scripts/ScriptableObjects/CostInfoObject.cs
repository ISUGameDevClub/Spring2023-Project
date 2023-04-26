using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="costInfoObject",menuName ="ScriptableObjects/Currency/CostInfoObject")]
public class CostInfoObject : ScriptableObject
{
    public int currencyCost = 0;
    public int seedCost = 0;
}
