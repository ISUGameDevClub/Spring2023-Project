using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveInfo
{
    public GameObject spawnPoint;
    public int enemyAmount;
    public Transform enemyPrefab;
    public float timeBetweenSpawn;
}
