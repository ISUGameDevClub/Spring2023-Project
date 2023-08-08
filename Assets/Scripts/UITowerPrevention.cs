using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITowerPrevention : MonoBehaviour
{
    public void UIEnter()
    {
        BuildManager.instance.SetCondition(1);

        Debug.Log("On build-free UI");
    }

    public void UIExit()
    {
        BuildManager.instance.SetCondition(0);

        Debug.Log("Off build-free UI");
    }
}
