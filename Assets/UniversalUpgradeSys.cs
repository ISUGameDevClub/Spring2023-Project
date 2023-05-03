using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UniversalUpgradeSys : MonoBehaviour
{
    private Animator shopAnims;
    private bool shopActive;
    private CurrencyManager currencyManager;

    [SerializeField] private TowerUI towerUI;
    [SerializeField] private List<TowerUpgrade> towerUpgrades = new List<TowerUpgrade>();

    private void Start()
    {
        towerUI = FindObjectOfType<TowerUI>();
        shopAnims = GetComponent<Animator>();
        currencyManager = FindObjectOfType<CurrencyManager>();
        shopActive = false;

        // Initialize the tower levels to 0
        for (int i = 0; i < towerUpgrades.Count; i++)
        {
            towerUpgrades[i].level = 0;
        }
    }

    public void UpgradeTower(int towerIndex)
    {
        if (towerIndex < 0 || towerIndex >= towerUI.towerPrefabs.Length)
        {
            Debug.LogError("Invalid tower index!");
            return;
        }
        if(!CanUpgradeFurther(towerIndex))
        {
            Debug.Log("Can't upgrade further!");
            return;
        }

        GameObject towerPrefab = towerUI.towerPrefabs[towerIndex];

        // Get the tower health and attack components
        TowerHealth towerHealth = towerPrefab.GetComponent<TowerHealth>();
        TowerAttack towerAttack = towerPrefab.GetComponent<TowerAttack>();

        if (towerHealth == null || towerAttack == null)
        {
            Debug.LogError("Tower prefab is missing health or attack component!");
            return;
        }

        // Get the upgrade values for the current level of the tower
        TowerUpgrade upgrade = towerUpgrades[towerIndex];
        int health = upgrade.healthLevels[upgrade.level];
        int damage = upgrade.damageLevels[upgrade.level];
        float attackSpeed = upgrade.attackSpeedLevels[upgrade.level];
        int range = upgrade.rangeLevels[upgrade.level];
        int cost = upgrade.costLevels[upgrade.level];

        if(!currencyManager.CanPlayerAfford(cost))
        {
            Debug.Log("Can't afford this...");
            return;
        }

        // Upgrade the tower health and attack components
        towerHealth.setHealth(health);
        towerAttack.UpgradeAttackDamage(damage);
        towerAttack.UpgradeAttackSpeed(attackSpeed);
        towerAttack.UpgradeRange(range);
        currencyManager.SubtractCurrency(cost);
        Debug.Log("Upgraded " + towerPrefab.name + " to level " + (upgrade.level+1));

        // Upgrade all instances of the tower in the scene
        GameObject[] activeTowers = GameObject.FindGameObjectsWithTag("Tower");
        foreach (GameObject tower in activeTowers)
        {
            if (tower.name == towerPrefab.name + "(Clone)")
            {
                // Upgrade the tower health and attack components
                TowerHealth healthComponent = tower.GetComponent<TowerHealth>();
                TowerAttack attackComponent = tower.GetComponent<TowerAttack>();

                healthComponent.setHealth(health);
                attackComponent.UpgradeAttackDamage(damage);
                attackComponent.UpgradeAttackSpeed(attackSpeed);
                attackComponent.UpgradeRange(range);
            }
        }

        // Increase the tower level for the next upgrade
        upgrade.level = Mathf.Min(upgrade.level + 1, upgrade.healthLevels.Count - 1);
    }

    //Animation-Button Shtuff
    public void ShopButton()
    {
        if (!shopActive)
        {
            shopActive = true;
            shopAnims.SetTrigger("openshop");
        }
        else
        {
            shopActive = false;
            shopAnims.SetTrigger("closeshop");
        }
    }
    public int GetCurrentCost(int towerIndex)
    {
        int currCost = towerUpgrades[towerIndex].costLevels[towerUpgrades[towerIndex].level];
        return currCost;
    }
    public bool CanUpgradeFurther(int towerIndex)
    {
        if(towerUpgrades[towerIndex].level + 1 >= towerUpgrades[towerIndex].costLevels.Count)
        {
            return false;
        }
        return true;
    }
}

[System.Serializable]
public class TowerUpgrade
{
    public List<int> costLevels = new List<int>();
    public List<int> healthLevels = new List<int>();
    public List<int> damageLevels = new List<int>();
    public List<float> attackSpeedLevels = new List<float>();
    public List<int> rangeLevels = new List<int>();
    public int level;
}