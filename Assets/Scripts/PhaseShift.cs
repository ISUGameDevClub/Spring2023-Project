using System.Collections;
using UnityEngine;


public class PhaseShift : MonoBehaviour
{
    public bool activePhase; //True if in active phase, False if in setup
    public bool enemiesRemain; //True if there are still enemies, false if there are no enemies
    public bool skip; //True if skip setup button is pressed, false otherwise
    public int numberOfEnemies;
    [SerializeField] float setupTime;
    

    // Start is called before the first frame update
    void Start()
    {
        activePhase = false;    //Start in setup phase im guessing...
        enemiesRemain = true;
        StartCoroutine(setupWait());
    }

    // Update is called once per frame
    void Update()
    {
        
        //Use a try that looks for gameobject of type "enemy"

        //Testing if skip button is pressed during setup phase
        if (skip && (activePhase == false))
         {
              enemiesRemain = true;
              activePhase = true;
              skip = false;
         }
               
        if (activePhase)
        {
            if (GameObject.FindGameObjectsWithTag("Enemy/Ground").Length == 0)
            {
                activePhase = false;
                StartCoroutine(setupWait());
            }
            
        }
    }
    public bool isActivePhase()
    {
        return activePhase;
    }
    IEnumerator setupWait()
    {
        yield return new WaitForSeconds(setupTime);
        activePhase = true;
        enemiesRemain = true;
        
    }
    public void skipPhase()
    {
        skip = true;
    }
}
