using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    private CurrencyManager currencyManager;
    public TMP_Text moneyText;
    public TMP_Text stateText;

    private StateController stateController;

    private void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        stateController = GameManager.instance.GetComponent<StateController>();
        currencyManager = FindObjectOfType<CurrencyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: $" + currencyManager.GetPlayerCurrency();
        stateText.text = "Current State - " + stateController.getStateString();
    }

}
