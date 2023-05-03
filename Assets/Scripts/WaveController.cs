using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveController : MonoBehaviour
{
    public static WaveController instance;

    public int WaveNumber { get; private set; } = 0;
    private bool enemiesSpawned = false;
    private phaseType currentPhaseType;
    public Transform enemyHolder;
    private bool shouldSkipSetup = false;

    //Tracker variables for Gian's WaveTracker.
    private int enemiesSpawnedInGroup;
    private float currentSetupTimeElapsed;

    // Temporary measure for GameShowcaseDemo
    [SerializeField]
    private string winScene;

    public enum phaseType
    {
        SETUP,
        ACTIVE,
    }

    public bool isSetupPhase()
    {
        return currentPhaseType == phaseType.SETUP;
    }

    public bool isActivePhase()
    {
        return currentPhaseType == phaseType.ACTIVE;
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

    [Header("Spawnpoints")]
    [SerializeField]
    private Transform northSpawn;
    [SerializeField]
    private Transform northEastSpawn, eastSpawn, southEastSpawn, southSpawn, southWestSpawn, westSpawn, northWestSpawn;

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
        enemiesSpawnedInGroup = 0;
        currentSetupTimeElapsed = 0;
        yield return StartCoroutine(CompleteSetupPhase(WaveNumber));
        yield return StartCoroutine(BeginActivePhase(WaveNumber));
        WaveNumber++;
        Debug.Log("WaveNumber: " + WaveNumber);
    }

    private IEnumerator CompleteSetupPhase(int setupIndex)
    {
        currentPhaseType = phaseType.SETUP;
        float setupDuration = setupTimes[setupIndex];
        
        const float skipCheckInterval = 0.5f;
        const float errorMargin = 0.1f;
        
        // This probably isn't necessary, but if for whatever reason you had a short setup time or a long skip check interval.
        // The point of the loop below is to allow the player to skip the setup phase, rather than wait its full duration.
        if(setupDuration > skipCheckInterval)
        {
            float timeElapsed = 0f;
            float timeToCheck = setupDuration - errorMargin;
            while (timeElapsed < timeToCheck)
            {
                if (shouldSkipSetup) break;
                yield return new WaitForSeconds(skipCheckInterval);
                timeElapsed += skipCheckInterval;
                currentSetupTimeElapsed = timeElapsed;
            }
        }
        shouldSkipSetup = false;
        yield return null;
    }

    public void skipSetupPhase()
    {
        shouldSkipSetup = true;
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
                enemiesSpawnedInGroup++;
            }
        }
        enemiesSpawned = true;
    }
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
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
        // This could potentially/should be changed in the future, I'm checking if all enemies are dead by counting the children of an enemyHolder transform.
        // This method could cause issues with the dog enemy. If the dog enemy is the last one to die, then theoretically, it could start the next wave before spawning
        // the dogs.
        if (enemyHolder.childCount == 0 && enemiesSpawned && WaveNumber < waves.Length)
        {
            enemiesSpawned = false;
            StartCoroutine(beginNextWave());
        }
        else if (WaveNumber == waves.Length && enemyHolder.childCount == 0)
        {
            // In this case, the last wave has finished. // Temporary measure for the GameShowcaseDemo.
            FindObjectOfType<TransitionController>().FadeToLevel(winScene);
        }
    }

    //Helper methods Gian added to help with wave tracking.
    public int GetWaveAmt()
    {
        return waves[WaveNumber].spawnGroups[0].enemiesToSpawn.Length;
    }
    public int GetEnemiesSpawned()
    {
        return enemiesSpawnedInGroup;
    }
    public float GetSetupTime()
    {
        return setupTimes[WaveNumber];
    }
    public float GetSetupTimeElapsed()
    {
        return currentSetupTimeElapsed;
    }
}
