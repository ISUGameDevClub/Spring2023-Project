using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TowerInfoUI : MonoBehaviour
{
    public GameObject UIElement;
    private bool isHovering;
    private TowerUI towerUI;

    public TextMeshProUGUI towerName;
    public string[] towerNames;
    public TextMeshProUGUI towerInfo;
    public string[] towerInfos;

    public void Start()
    {
        towerUI = GetComponent<TowerUI>();
    }

    private void Update()
    {
        if (isHovering && !UIElement.activeSelf)
        {
            UIElement.SetActive(true);
        }
        else if (!isHovering && UIElement.activeSelf)
        {
            UIElement.SetActive(false);
        }

        switch(towerUI.towerSelector)
        {
            case 0:
                towerName.text = towerNames[0];
                towerInfo.text = towerInfos[0];
                break;
            case 1:
                towerName.text = towerNames[1];
                towerInfo.text = towerInfos[1];
                break;
            case 2:
                towerName.text = towerNames[2];
                towerInfo.text = towerInfos[2];
                break;
            case 3:
                towerName.text = towerNames[3];
                towerInfo.text = towerInfos[3];
                break;
            case 4:
                towerName.text = towerNames[4];
                towerInfo.text = towerInfos[4];
                break;
            case 5:
                towerName.text = towerNames[5];
                towerInfo.text = towerInfos[5];
                break;
            default:
                towerName.text = "ERROR";
                towerInfo.text = "ERROR";
                break;
        }
    }

    public void OnPointerEnter()
    {
        isHovering = true;
    }

    public void OnPointerExit()
    {
        isHovering = false;
    }
}
