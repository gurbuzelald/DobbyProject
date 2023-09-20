using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    private GameObject weaponGiftBoxSpawnerObject;
    private WeaponGiftBoxSpawner weaponGiftBoxSpawner;

    private GameObject healthCoinSpawnerObject;
    private HealthCoinSpawner healthCoinSpawner;

    private GameObject enemySpawnerObject;
    private EnemySpawner enemySpawner;

    private GameObject coinSpawnerObject;
    private CoinSpawner coinSpawner;

    private GameObject mirrorSpawnerObject;
    private MirrorSpawner mirrorSpawner;

    private GameObject cameraSpawnerObject;
    private CameraSpawner cameraSpawner;

    private GameObject mapControllerObject;
    private MapController mapController;

    void Awake()
    {
        weaponGiftBoxSpawnerObject = GameObject.Find("WeaponGiftBoxSpawner");
        healthCoinSpawnerObject = GameObject.Find("HealthCoinSpawner");
        enemySpawnerObject = GameObject.Find("EnemySpawner");
        coinSpawnerObject = GameObject.Find("CoinSpawner");
        mirrorSpawnerObject = GameObject.Find("MirrorSpawner");
        cameraSpawnerObject = GameObject.Find("CameraSpawner");
        mapControllerObject = GameObject.Find("MapController");

        InitStatements();
    }
    void InitStatements()
    {
        weaponGiftBoxSpawner = weaponGiftBoxSpawnerObject.GetComponent<WeaponGiftBoxSpawner>();
        healthCoinSpawner = healthCoinSpawnerObject.GetComponent<HealthCoinSpawner>();
        if (enemySpawnerObject)
        {
            enemySpawner = enemySpawnerObject.GetComponent<EnemySpawner>();
        }
        coinSpawner = coinSpawnerObject.GetComponent<CoinSpawner>();
        mirrorSpawner = mirrorSpawnerObject.GetComponent<MirrorSpawner>();
        cameraSpawner = cameraSpawnerObject.GetComponent<CameraSpawner>();
        if (mapControllerObject)
        {
            mapController = mapControllerObject.GetComponent<MapController>();
            mapController = mapControllerObject.GetComponent<MapController>();
        }
        
    }

    private void Update()
    {
        if (playerData.isCompleteFirstMap)
        {
            weaponGiftBoxSpawner.CreateSecondMapGiftBoxes();
            healthCoinSpawner.CreateSecondtMapHealthCoin();
            coinSpawner.CreateSecondCoin();
            mapController.CreateSecondMap();
            mapController.SetSecondSkybox();
            mirrorSpawner.CreateSecondMapMirror();
            enemySpawner.CreateSecondMapEnemies();
            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            playerData.isCompleteFirstMap = false;
        }
        else if (playerData.isCompleteSecondMap)
        {
            weaponGiftBoxSpawner.CreateThirdMapGiftBoxes();
            healthCoinSpawner.CreateThirdMapHealthCoin();
            coinSpawner.CreateThirdCoin();
            mapController.CreateThirdMap();
            mapController.SetThirdSkyBox();
            mirrorSpawner.CreateThirdMapMirror();
            enemySpawner.CreateThirdMapEnemies();
            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            playerData.isCompleteSecondMap = false;
        }
        else if (playerData.isCompleteThirdMap)
        {
            weaponGiftBoxSpawner.CreateFourthMapGiftBoxes();
            healthCoinSpawner.CreateFourthMapHealthCoin();
            coinSpawner.CreateFourthCoin();
            mapController.CreateFourthMap();
            mapController.SetFourthSkybox();
            mirrorSpawner.CreateFourthMapMirror();
            enemySpawner.CreateFourthMapEnemies();
            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            playerData.isCompleteThirdMap = false;
        }
        else if (playerData.isCompleteFourthMap)
        {

        }
    }
}
