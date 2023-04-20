using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform enemyPrefab;
    private GameObject enemySpawn;
    public float timeBetweenWaves;
    public float countdown;
    public int waveAmount;
    public int[] northArr;
    public int[] southArr;
    public int[] eastArr;
    public int[] westArr;
    public int[] northEastArr;
    public int[] northWestArr;
    public int[] southEastArr;
    public int[] southWestArr;
    public List<WaveInfo> testList = new List<WaveInfo>();
    private int waveNumber = 1;
    private int index = 0;

    /*TO DO: 
     Array of objects containing enemy type, amount spawn, cool down of spawn*/


    /*NOTES FROM CODY!
     
    For this we want to have the wave controller spawn an enemy spawner
    The enemy spawner should despawn after spawning a certain amount of enemies
    When the wave controller spawns the enemy spawner, it should give a number to the enemy spawn that is the amount it should spawn

    To control this, we want 8 Arrays (One for each Orthagonal and Diagonal Direction (N,NE,E,etc.))
    The array would store the type of enemy we want to spawn
    The array would also have a mirrored array, one that has the same amount of elements, to be used as the amount of those enemy types to spawn
    
    Ask me any questions you have about this. Thanks!
     
     */



    /*Leave enemy spawn prefab set to none on enemy controller object*/

    

    void Update()
    {
        
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        if(waveNumber == waveAmount)
        {
            StopCoroutine(SpawnWave());
            Destroy(this);
        }
    }

    IEnumerator SpawnWave()
    {
        Debug.Log("Spawn Wave");
        Debug.Log("Wave " + waveNumber);

        GameObject.Find("SoundController").GetComponent<Sound>().SpawnSound("WaveIncoming");
        //SpawnEnemy(1, northArr[index]);
        //SpawnEnemy(2, southArr[index]);
        //SpawnEnemy(3, eastArr[index]);
        //SpawnEnemy(4, westArr[index]);
        //SpawnEnemy(5, northEastArr[index]);
        //SpawnEnemy(6, northWestArr[index]);
        //SpawnEnemy(7, southEastArr[index]);
        //SpawnEnemy(8, southWestArr[index]);
        ListSpawn();
        waveNumber++;
        index++;
        //Wait 0.5 seconds before spawning next enemy
        yield return new WaitForSeconds(0.5f);
        

    }

    //In the arrays of the enemy controller object set 0 to not spawn enemy from spawnpoint for that wave index and set 1 to spawn enemy
    //Eventually will set it up to spawn specific enemy types based off of number(ex: ground enemy = 1, flyning enemy = 2, and so on)
    void SpawnEnemy(int spawnPosition, int enemyType)
    {
        //Switch case for spawns
        switch(spawnPosition)
        {
            //North Spawn
            case 1:
                if(enemyType == 0)
                {
                    break;
                }
                enemySpawn = GameObject.Find("NorthSpawn");
                Instantiate(enemyPrefab, enemySpawn.transform.position, enemySpawn.transform.rotation);
                Debug.Log("Spawn Enemy");
                break;
            //South Spawn
            case 2:
                if (enemyType == 0)
                {
                    break;
                }
                enemySpawn = GameObject.Find("SouthSpawn");
                Instantiate(enemyPrefab, enemySpawn.transform.position, enemySpawn.transform.rotation);
                Debug.Log("Spawn Enemy");
                break;
            //East Spawn
            case 3:
                if (enemyType == 0)
                {
                    break;
                }
                enemySpawn = GameObject.Find("EastSpawn");
                Instantiate(enemyPrefab, enemySpawn.transform.position, enemySpawn.transform.rotation);
                Debug.Log("Spawn Enemy");
                break;
            //West Spawn
            case 4:
                if (enemyType == 0)
                {
                    break;
                }
                enemySpawn = GameObject.Find("WestSpawn");
                Instantiate(enemyPrefab, enemySpawn.transform.position, enemySpawn.transform.rotation);
                Debug.Log("Spawn Enemy");
                break;
            case 5:
                if (enemyType == 0)
                {
                    break;
                }
                enemySpawn = GameObject.Find("NorthEastSpawn");
                Instantiate(enemyPrefab, enemySpawn.transform.position, enemySpawn.transform.rotation);
                Debug.Log("Spawn Enemy");
                break;
            case 6:
                if (enemyType == 0)
                {
                    break;
                }
                enemySpawn = GameObject.Find("NorthWestSpawn");
                Instantiate(enemyPrefab, enemySpawn.transform.position, enemySpawn.transform.rotation);
                Debug.Log("Spawn Enemy");
                break;
            case 7:
                if (enemyType == 0)
                {
                    break;
                }
                enemySpawn = GameObject.Find("SouthEastSpawn");
                Instantiate(enemyPrefab, enemySpawn.transform.position, enemySpawn.transform.rotation);
                Debug.Log("Spawn Enemy");
                break;
            case 8:
                if (enemyType == 0)
                {
                    break;
                }
                enemySpawn = GameObject.Find("SouthWestSpawn");
                Instantiate(enemyPrefab, enemySpawn.transform.position, enemySpawn.transform.rotation);
                Debug.Log("Spawn Enemy");
                break;
        }
        //Instantiate(enemyPrefab, enemySpawn.transform.position, enemySpawn.transform.rotation);
        Debug.Log("Spawn Enemy");
    }

    void ListSpawn()
    {
        Instantiate(testList[1].enemyPrefab, testList[1].spawnPoint.transform.position, testList[1].spawnPoint.transform.rotation);
    }


}
