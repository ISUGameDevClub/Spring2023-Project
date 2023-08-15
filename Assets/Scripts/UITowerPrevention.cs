using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITowerPrevention : MonoBehaviour
{
    // Indicates whether the mouse is hovering over any build-free UI in the scene.
    public static bool MouseOnUI { get; private set; }

    // Indicates whether the mouse is hovering over UI having this script instance, or having a parent with this instance of the script attached.
    [HideInInspector]
    public bool mouseOnThis;

    // A variable for managing all instances of this script. The 'static' keyword ensures that this single variable is shared between all script instances.
    private static UITowerPrevention[] scriptCopies;

    private void Awake()
    {
        if(scriptCopies == null) scriptCopies = GameObject.FindObjectsOfType<UITowerPrevention>();
    }

    // To be called when the mouse first enters a UI object containing this script instance.
    // This function is currently called with the help of an EventTrigger component.
    public void UIEnter()
    {
        mouseOnThis = true;

        // Condition that disallows the building of towers.
        BuildManager.instance.SetCondition(1);

        MouseOnUI = true;

        //Debug.Log("On build-free UI");
    }

    // To be called when the mouse exits a UI object containing this script instance.
    // This function is currently called with the help of an EventTrigger component.
    public void UIExit()
    {
        mouseOnThis = false;

        if (isMouseOffUI())
        {
            // Condition that allows the building of towers.
            BuildManager.instance.SetCondition(0);

            MouseOnUI = false;
            //Debug.Log("Off build-free UI");
        }    
    }

    private static bool isMouseOffUI()
    {
        foreach(UITowerPrevention s in scriptCopies)
        {
            if (s.mouseOnThis) return false;
        }

        return true;
    }


}
