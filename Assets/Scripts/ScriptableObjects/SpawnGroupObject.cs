using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "spawnGroup", menuName = "ScriptableObjects/Waves/SpawnGroupObject", order = 1)]
public class SpawnGroupObject : ScriptableObject
{
    public GameObject[] enemiesToSpawn;
    public float[] spawnDelays;
    public WaveController.spawnLocation[] spawnLocations;
}
