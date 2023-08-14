using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaveController : MonoBehaviour
{
    public static WaveController instance;

    public int WaveNumber { get; private set; } = -1;
    public event EventHandler onNewAttackStart;
    public event EventHandler onNewSetupStart;
    private bool enemiesSpawned = false;
    private phaseType currentPhaseType;
    public Transform enemyHolder;
    private bool shouldSkipSetup = false;
    private bool finalWaveSpawned = false;

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
        // Quick fix to avoid index out of bounds error
        if(WaveNumber < waves.Length - 1)
        {
            WaveNumber++;
            yield return StartCoroutine(CompleteSetupPhase(WaveNumber));
            yield return StartCoroutine(BeginActivePhase(WaveNumber));
        }
        else
        {
            finalWaveSpawned = true;
        }
        //Debug.Log("WaveNumber: " + WaveNumber);
    }

    private IEnumerator CompleteSetupPhase(int setupIndex)
    {
        currentPhaseType = phaseType.SETUP;
        //Debug.Log("onNewSetupStart invocation"); ;
        onNewSetupStart?.Invoke(this, EventArgs.Empty);
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
        //Debug.Log("onNewAttackStart invocation");
        onNewAttackStart?.Invoke(this, EventArgs.Empty);
        // For all spawn groups in a wave
        for (int g = 0; g < waves[waveNumber].spawnGroups.Length; g++)
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
        if (enemyHolder.childCount == 0 && enemiesSpawned && !finalWaveSpawned)
        {
            enemiesSpawned = false;
            StartCoroutine(beginNextWave());
        }
        else if (finalWaveSpawned && enemyHolder.childCount == 0)   
        {
            // In this case, the last wave has finished. // Temporary measure for the GameShowcaseDemo.
            FindObjectOfType<TransitionController>().FadeToLevel(winScene);
            FindObjectOfType<AudioManager>()?.Play("VictoryTheme");
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
