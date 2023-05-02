using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public GameObject ShootPrefab, Footsteps2Prefab, GasEmitPrefab, MenuMoveLongPrefab, MenuMoveShortPrefab, MenuSelectPrefab,
        MoneyGetPrefab, PitchforkThrowPrefab, PlayerDamagedPrefab, ShotgunTowerShoot2Prefab, TowerDestroyPrefab, TowerPlace1Prefab,
        WaveIncomingPrefab, assassinDeathPrefab, BasicTowerShootPrefab, chainShootPrefab, EnemyHitPrefab, EvilLaughBentPrefab, GlassDeathPrefab, guardDeathPrefab, HarvestPrefab,
        LazerPrefab, mouseOverTower1Prefab, mouseOverTower2Prefab, SoldierDeathPrefab, StephenDeath8BitPrefab, Whistle1, Whistle2, Whistle3, Whistle4;
    public float DestroyTime;
   
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpawnSound(string SFXPlay)
    {
        switch (SFXPlay)
        {
            case "Footsteps2": //PlayerMovement.cs
                GameObject footsteps2 = Instantiate(Footsteps2Prefab);
                Destroy(footsteps2, DestroyTime);
                break;
            case "Gas_Emit": //TowerAttack.cs
                GameObject gasEmit = Instantiate(GasEmitPrefab);
                Destroy(gasEmit, DestroyTime);
                break;
            case "MenuMoveLong": //
                GameObject menuMoveLong = Instantiate(MenuMoveLongPrefab);
                Destroy(menuMoveLong, DestroyTime);
                break;
            case "MenuMoveShort": //
                GameObject menuMoveShort = Instantiate(MenuMoveShortPrefab);
                Destroy(menuMoveShort, DestroyTime);
                break;
            case "MenuSelect": //PauseMenuScript.cs
                GameObject menuSelect = Instantiate(MenuSelectPrefab);
                Destroy(menuSelect, DestroyTime);
                break;
            case "MoneyGet": //CurrencyManager.cs
                GameObject moneyGet = Instantiate(MoneyGetPrefab);
                Destroy(moneyGet, DestroyTime);
                break;
            case "PitchforkThrow": //Shooting.cs
                GameObject pitchforkThrow = Instantiate(PitchforkThrowPrefab);
                Destroy(pitchforkThrow, DestroyTime);
                break;
            case "PlayerDamaged": //PlayerHealth.cs
                GameObject playerDamaged = Instantiate(PlayerDamagedPrefab);
                Destroy(playerDamaged, DestroyTime);
                break;
            case "ShotgunTowerShoot2": //TowerAttack.cs
                GameObject shotgunTowerShoot2 = Instantiate(ShotgunTowerShoot2Prefab);
                Destroy(shotgunTowerShoot2, DestroyTime);
                break;
            case "TowerDestroy": //TowerHealth.cs
                GameObject towerDestroy = Instantiate(TowerDestroyPrefab);
                Destroy(towerDestroy, DestroyTime);
                break;
            case "TowerPlace1": //BuildManager.cs
                GameObject towerPlace1 = Instantiate(TowerPlace1Prefab);
                Destroy(towerPlace1, DestroyTime);
                break;
            case "WaveIncoming": //EnemyController.cs
                GameObject waveIncoming = Instantiate(WaveIncomingPrefab);
                Destroy(waveIncoming, DestroyTime);
                break;
            case "assassin_death": //
                GameObject assassinDeath = Instantiate(assassinDeathPrefab);
                Destroy(assassinDeath, DestroyTime);
                break;
            case "BasicTowerShoot": //
                GameObject basicTowerShoot = Instantiate(BasicTowerShootPrefab);
                Destroy(basicTowerShoot, DestroyTime);
                break;
            case "chain_shoot": //
                GameObject chainShoot = Instantiate(chainShootPrefab);
                Destroy(chainShoot, DestroyTime);
                break;
            case "EnemyHit": //
                GameObject enemyHit = Instantiate(EnemyHitPrefab);
                Destroy(enemyHit, DestroyTime);
                break;
            case "evil_laugh_bent": //
                GameObject evilLaughBent = Instantiate(EvilLaughBentPrefab);
                Destroy(evilLaughBent, DestroyTime);
                break;
            case "Glass_Death": //
                GameObject glassDeath = Instantiate(GlassDeathPrefab);
                Destroy(glassDeath, DestroyTime);
                break;
            case "guard_death": //
                GameObject guardDeath = Instantiate(guardDeathPrefab);
                Destroy(guardDeath, DestroyTime);
                break;
            case "Harvest": //
                GameObject harvest = Instantiate(HarvestPrefab);
                Destroy(harvest, DestroyTime);
                break;
            case "Lazer": //
                GameObject lazer = Instantiate(LazerPrefab);
                Destroy(lazer, DestroyTime);
                break;
            case "mouse_over_tower1": //
                GameObject mouseOverTower1 = Instantiate(mouseOverTower1Prefab);
                Destroy(mouseOverTower1, DestroyTime);
                break;
            case "mouse_over_tower2": //
                GameObject mouseOverTower2 = Instantiate(mouseOverTower2Prefab);
                Destroy(mouseOverTower2, DestroyTime);
                break;
            case "Soldier_death": //
                GameObject soldierDeath = Instantiate(SoldierDeathPrefab);
                Destroy(soldierDeath, DestroyTime);
                break;
            case "Stephen_Death_8Bit": //
                GameObject stephenDeath8Bit = Instantiate(StephenDeath8BitPrefab);
                Destroy(stephenDeath8Bit, DestroyTime);
                break;
            case "Whistle_1": //
                GameObject whistle1 = Instantiate(Whistle1);
                Destroy(whistle1, DestroyTime);
                break;
            case "Whistle_2": //
                GameObject whistle2 = Instantiate(Whistle2);
                Destroy(whistle2, DestroyTime);
                break;
            case "Whistle_3": //
                GameObject whistle3 = Instantiate(Whistle3);
                Destroy(whistle3, DestroyTime);
                break;
            case "Whistle_4": //
                GameObject whistle4 = Instantiate(Whistle4);
                Destroy(whistle4, DestroyTime);
                break;
        }

    }
}
