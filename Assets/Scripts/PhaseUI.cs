using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PhaseUI : MonoBehaviour
{
    public int enemRemain;
    public TextMeshProUGUI currentPhaseText;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("phase").GetComponent<PhaseShift>().isActivePhase())
            currentPhaseText.SetText("Active"); 
        else
        {
            currentPhaseText.SetText("Setup");
        }
        
    }
}
