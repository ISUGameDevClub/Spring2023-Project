using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateController : MonoBehaviour
{
    // build state = 1
    // sell state = 2
    // attack state = 0

    public int state;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Space))
       {
            state++;
            state %= 3;
            //Debug.Log(state);
       }
    }

    public int getState()
    {
        return state;
    }

    public string getStateString()
    {
        switch (state)
        {
            case 0:
                return "Attack";
            case 1:
                return "Build";
            case 2:
                return "Sell";
            default:
                return "Unknown";
        }
    }
}
