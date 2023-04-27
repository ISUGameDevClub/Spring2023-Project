using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    public int playerCurrentCurrency;
    [SerializeField] int startingCurrency = 500;
    public static CurrencyManager instance;
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
            // Not sure why, but this seems to run when the GameShowcaseDemoScene Reloads
            // Assuming part of it has to do with how the scene has a built-int Gamemanager on load (this is the case)
            // I had to remove the Debug.Error statement to prevent a gameplay issue.
            Debug.Log("How were there two CurrencyManagers?");
            return;
        }
        instance = this;

    }
    // Start is called before the first frame update
    void Start()
    {
       resetPlayerCurrency();
    }
    public void AddCurrency(int currencyToAdd)
    {
        // Add currency function
        GameObject.Find("SoundController").GetComponent<Sound>().SpawnSound("MoneyGet");
        playerCurrentCurrency += currencyToAdd;
    }
    public bool SubtractCurrency(int currencyToSubtract)
    {
        // Subtract money and return a bool if player can afford.
        if (playerCurrentCurrency - currencyToSubtract < 0)
        {
            Debug.Log("Dont Subtract Currency");
            return false;
        } else
        {
            Debug.Log("Subtract Currency");
            playerCurrentCurrency -= currencyToSubtract;
            return true;
        }
    }
    public bool CanPlayerAfford(int currencyToCheck)
    {
        // Returns a bool if the player can afford 
        if (playerCurrentCurrency < currencyToCheck)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    public int GetPlayerCurrency()
    {
        return playerCurrentCurrency;
    }
    public void SetPlayerCurrency(int setCurrency)
    {
        playerCurrentCurrency = setCurrency;
    }

    public void resetPlayerCurrency(){
        playerCurrentCurrency = startingCurrency;
    }
}
