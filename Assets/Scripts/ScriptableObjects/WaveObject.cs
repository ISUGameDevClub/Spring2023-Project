using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "waveObject", menuName = "ScriptableObjects/Waves/WaveObject")]
public class WaveObject : ScriptableObject
{
    public SpawnGroupObject[] spawnGroups;
    
}
