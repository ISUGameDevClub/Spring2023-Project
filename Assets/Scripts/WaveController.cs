using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
    public int WaveNumber { get; private set; } = 0;
    private bool enemiesSpawned = false;
    private phaseType currentPhaseType;
    public Transform enemyHolder;

    public enum phaseType
    {
        SETUP,
        ACTIVE,
    }

    public enum spawnLocation { 
        NORTH,
        NORTHEAST,
        EAST,
        SOUTHEAST,
        SOUTH,
        SOUTHWEST,
        WEST,
        NORTHWEST,
    }
    
    public Transform northSpawn,northEastSpawn, eastSpawn, southEastSpawn, southSpawn, southWestSpawn, westSpawn, northWestSpawn;

    private Transform getSpawnTransform(spawnLocation location)
    {
        switch (location)
        {
            case spawnLocation.NORTH:
                return northSpawn;
            case spawnLocation.NORTHEAST:
                return northEastSpawn;
            case spawnLocation.EAST:
                return eastSpawn;
            case spawnLocation.SOUTHEAST:
                return southEastSpawn;
            case spawnLocation.SOUTH:
                return southSpawn;
            case spawnLocation.SOUTHWEST:
                return southWestSpawn;
            case spawnLocation.WEST:
                return westSpawn;
            case spawnLocation.NORTHWEST:
                return northWestSpawn;
            default:
                return northSpawn;
        }
    }

    // List of waves to spawn, these objects contain a group of SpawnGroupObjects, which contain enemy types, spawn locations, and spawn delays.
    [SerializeField]
    private WaveObject[] waves;

    // Currently meant to be the same size as the waves array.
    [SerializeField]
    private float[] setupTimes;
    
    private IEnumerator beginNextWave()
    {
        yield return StartCoroutine(CompleteSetupPhase(WaveNumber));
        yield return StartCoroutine(BeginActivePhase(WaveNumber));
        WaveNumber++;
        Debug.Log("WaveNumber: " + WaveNumber);
    }

    private IEnumerator CompleteSetupPhase(int setupIndex)
    {
        currentPhaseType = phaseType.SETUP;
        yield return new WaitForSeconds(setupTimes[setupIndex]);
    }
    private IEnumerator BeginActivePhase(int waveNumber)
    {
        currentPhaseType = phaseType.ACTIVE;
        // For all spawn groups in a wave
        for(int g = 0; g < waves[waveNumber].spawnGroups.Length; g++)
        {
            SpawnGroupObject currentGroup = waves[waveNumber].spawnGroups[g];
            // For all enemies in a spawn group
            for(int e = 0; e < currentGroup.enemiesToSpawn.Length; e++)
            {
                yield return new WaitForSeconds(currentGroup.spawnDelays[e]);
                Instantiate(currentGroup.enemiesToSpawn[e], getSpawnTransform(currentGroup.spawnLocations[e]).position, Quaternion.identity, enemyHolder);
            }
        }
        enemiesSpawned = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(beginNextWave());
    }

    
    // Update is called once per frame
    void Update()
    {
        // When the last wave has ended, which is when all enemies have died, begin the next wave.
        // This could potentially/should be changed in the future if possible, I'm checking if all enemies are dead by counting the children of an enemyHolder transform
        if(enemyHolder.childCount == 0 && enemiesSpawned && WaveNumber < waves.Length)
        {
            enemiesSpawned = false;
            StartCoroutine(beginNextWave());
        }
    }
}
