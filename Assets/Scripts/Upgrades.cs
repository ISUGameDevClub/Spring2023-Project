using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Upgrades : MonoBehaviour
{

    [SerializeField] int max_level = 5;
    [SerializeField] int curr_level = 0;
    [SerializeField] int[] health;
    [SerializeField] int[] attack;
    [SerializeField] float[] attackRate;
    [SerializeField] int[] range;
    [SerializeField] int[] upgradeCost;
    [SerializeField] GameObject text; // Assign the FloatingText Prefab Here
    private CurrencyManager curManager;
    /// /////////////////////////////////////////////////
        // Code for testing remove before normal use.
    private bool canFire;
    private int booletcooldown;
    /// /////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        curManager = CurrencyManager.instance;
        /// /////////////////////////////////////////////////
        // Code for testing remove before normal use.
        canFire = true;
        booletcooldown = 1;
        /// /////////////////////////////////////////////////
    }
  
    /// /////////////////////////////////////////////////
    // Code for testing remove before normal use.
    private void Update()
    {
        if (Input.GetButton("Fire1") && canFire)
        {
            levelUp();
            Debug.Log("LEVEL UP to " + curr_level + " max_level is supposed to be " + max_level);
            canFire = false;
            StartCoroutine(fireWait());
        }
    }
    IEnumerator fireWait()
    {
        yield return new WaitForSeconds(booletcooldown);
        canFire = true;
    }

    /// /////////////////////////////////////////////////

    public void levelUp()
    {
        if(curr_level < max_level - 1 && curManager.CanPlayerAfford(upgradeCost[curr_level]))
        {
            var textspawn = Instantiate(text, gameObject.transform.position, gameObject.transform.rotation, GameObject.FindGameObjectWithTag("FXCanvas").transform);
            Destroy(textspawn, 2f);
            curManager.SubtractCurrency(upgradeCost[curr_level]);
            curr_level++;
            textspawn.transform.Find("Floating Currency").GetComponent<TMP_Text>().text = "LEVEL UP to " + (curr_level + 1) + "/" + max_level;
            gameObject.GetComponent<TowerHealth>().levelUpHealth(health[curr_level]);
            GetComponent<TowerAttack>().UpgradeAttackDamage(attack[curr_level]);
            GetComponent<TowerAttack>().UpgradeRange(range[curr_level]);
            GetComponent<TowerAttack>().UpgradeAttackSpeed(attackRate[curr_level]);
        } else if (curr_level >= max_level - 1)
        {
            var textspawn = Instantiate(text, gameObject.transform.position, gameObject.transform.rotation, GameObject.FindGameObjectWithTag("FXCanvas").transform);
            textspawn.transform.Find("Floating Currency").GetComponent<TMP_Text>().text = "Tower At Max Level!";
            Destroy(textspawn, 2f);
        }
        else
        {
            var textspawn = Instantiate(text, gameObject.transform.position, gameObject.transform.rotation, GameObject.FindGameObjectWithTag("FXCanvas").transform);
            textspawn.transform.Find("Floating Currency").GetComponent<TMP_Text>().text = "Not Enough Currency To Upgrade!";
            textspawn.transform.Find("Floating Currency").GetComponent<TMP_Text>().color = new Color(1,0,0,1);
            Destroy(textspawn, 2f);
        }
    }
    public int getCurrentLevel()
    {
        return curr_level + 1;
    }
    public int getHealth()
    {
        return health[curr_level];
    }
    public int getPrevHealth()
    {
        if (curr_level > 0)
            return health[curr_level - 1];
        else
            return health[curr_level];
    }
    public int getAttack()
    {
        return attack[curr_level];
    }
    public float getAttackRate()
    {
        return attackRate[curr_level];
    }
    public float getRange()
    {
        return range[curr_level];
    }
    public int getUpgradeCost()
    {
        return upgradeCost[curr_level];
    }
}

