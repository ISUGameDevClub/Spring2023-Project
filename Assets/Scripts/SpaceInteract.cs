using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SpaceInteract : MonoBehaviour
{
    public Color hoverColor;

    private GameObject turret;

    private Renderer render;
    private Color startColor;

    StateController currentState;

    public int condition;
    // condition 0 = can build
    // condition 1 = cannot build

    private void Awake()
    {
        currentState = GameObject.Find("GameManager").GetComponent<StateController>();
    }

    private void Start()
    {
        if (GetComponent<Renderer>()) { render = GetComponent<Renderer>(); }
        else if (GetComponentInChildren<Renderer>()) { render = GetComponentInChildren<Renderer>(); }
        else if (GetComponentInParent<Renderer>()) { render = GetComponentInParent<Renderer>(); }

        startColor = render.material.color;

        condition = 0;
    }

    private void OnMouseDown()
    {
        if (currentState != null && currentState.state == 1)
        {
            Debug.Log("Can't build there!");
            return;
        }
        
        //Sell a turret
        if (currentState.state == 2 & GetComponent<TowerHealth>()!=null && !FindObjectOfType<UniversalUpgradeSys>().shopActive)
        {
            BuildManager.instance.SetCondition(0);
            // if you destroy the object before getting the refund amount, wierd stuff happens?
            int refundAmount = gameObject.GetComponent<BuildCost>().getCurrencyRefundAmount();
            Destroy(gameObject);
            CurrencyManager.instance.AddCurrency(refundAmount);
        }
    }

    void OnMouseEnter()
    {
        BuildManager.instance.SetCondition(1);

        Debug.Log("On Tower");
    }

    void OnMouseExit ()
    {
        BuildManager.instance.SetCondition(0);

        Debug.Log("Not on Tower");
    }
}
