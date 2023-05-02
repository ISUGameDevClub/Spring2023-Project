using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    private CurrencyManager currencyManager;
    public Animator towerBarAnims;
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

        //UI For State Controller
        // attack state = 0
        // build state = 1
        // sell state = 2
        //stateText.text = "Current State - " + stateController.getStateString();
        if (stateController.getState() == 0)
        {
            towerBarAnims.SetBool("sellbar", false);
            towerBarAnims.SetBool("attackbar", true);
        }
        if (stateController.getState() == 1)
        {
            towerBarAnims.SetBool("attackbar", false);
            towerBarAnims.SetBool("buildbar", true);
        }
        if (stateController.getState() == 2)
        {
            towerBarAnims.SetBool("buildbar", false);
            towerBarAnims.SetBool("sellbar", true);
        }
    }

}
