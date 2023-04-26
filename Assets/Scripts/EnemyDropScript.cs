using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropScript : MonoBehaviour
{
    [SerializeField]
    private int currencyDropAmount;
    [SerializeField]
    private int seedDropAmount;

    [SerializeField]
    [Range(0f, 1f)]
    private float currencyDropProbability;
    [SerializeField]
    [Range(0f, 1f)]
    private float seedDropProbability;

    public void dropItems()
    {
        if(currencyDropProbability == 1f || (currencyDropProbability > 0 && evaluateDropSuccess(currencyDropAmount)))
        {
            CurrencyManager.instance.AddCurrency(currencyDropAmount);
        }
       /* if(seedDropProbability == 1f || (seedDropProbability > 0 && evaluateDropSuccess(seedDropProbability)))
        {
            // Give the player/drop the right amount of seeds
        }*/
    }

    private bool evaluateDropSuccess(float probability)
    {
        return (probability < Random.value);
    }
}
