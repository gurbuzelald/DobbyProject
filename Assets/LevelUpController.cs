using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    private GameObject weaponGiftBoxSpawner;
    private GameObject healthCoinSpawner;
    private GameObject enemySpawner;
    private GameObject coinSpawner;
    private GameObject mirrorSpawner;
    private GameObject mapController;

    private void Awake()
    {
        weaponGiftBoxSpawner = GameObject.Find("WeaponGiftBoxSpawner");
        healthCoinSpawner = GameObject.Find("HealthCoinSpawner");
        enemySpawner = GameObject.Find("EnemySpawner");
        coinSpawner = GameObject.Find("CoinSpawner");
        mirrorSpawner = GameObject.Find("MirrorSpawner");
        mapController = GameObject.Find("MapController");
    }

    private void Update()
    {
        if (playerData.isCompleteFirstMap)
        {
            weaponGiftBoxSpawner.GetComponent<WeaponGiftBoxSpawner>().CreateSecondMapGiftBoxes();
            healthCoinSpawner.GetComponent<HealthCoinSpawner>().CreateSecondtMapHealthCoin();
            coinSpawner.GetComponent<CoinSpawner>().CreateSecondCoin();
            mapController.GetComponent<MapController>().CreateSecondMap();
            mapController.GetComponent<MapController>().SetSecondSkybox();
            mirrorSpawner.GetComponent<MirrorSpawner>().CreateSecondMapMirror();
            enemySpawner.GetComponent<EnemySpawner>().CreateSecondMapEnemies();

            playerData.isCompleteFirstMap = false;
        }
        else if (playerData.isCompleteSecondMap)
        {
            weaponGiftBoxSpawner.GetComponent<WeaponGiftBoxSpawner>().CreateThirdMapGiftBoxes();
            healthCoinSpawner.GetComponent<HealthCoinSpawner>().CreateThirdMapHealthCoin();
            coinSpawner.GetComponent<CoinSpawner>().CreateThirdCoin();
            mapController.GetComponent<MapController>().CreateThirdMap();
            mapController.GetComponent<MapController>().SetThirdSkyBox();
            mirrorSpawner.GetComponent<MirrorSpawner>().CreateThirdMapMirror();
            enemySpawner.GetComponent<EnemySpawner>().CreateThirdMapEnemies();

            playerData.isCompleteSecondMap = false;
        }
        else if (playerData.isCompleteThirdMap)
        {
            weaponGiftBoxSpawner.GetComponent<WeaponGiftBoxSpawner>().CreateFourthMapGiftBoxes();
            healthCoinSpawner.GetComponent<HealthCoinSpawner>().CreateFourthMapHealthCoin();
            coinSpawner.GetComponent<CoinSpawner>().CreateFourthCoin();
            mapController.GetComponent<MapController>().CreateFourthMap();
            mapController.GetComponent<MapController>().SetFourthSkybox();
            mirrorSpawner.GetComponent<MirrorSpawner>().CreateFourthMapMirror();
            enemySpawner.GetComponent<EnemySpawner>();

            playerData.isCompleteThirdMap = false;
        }
        else if (playerData.isCompleteFourthMap)
        {

        }
    }
}
