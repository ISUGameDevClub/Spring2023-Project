using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyCountUI : MonoBehaviour
{
    public TextMeshProUGUI enemiesRemaning;
    public int enemyCount;
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy/Ground").Length;
        enemiesRemaning.SetText("Enemies Remaining: " + enemyCount.ToString());
    }
}
