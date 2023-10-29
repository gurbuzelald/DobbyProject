using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;
    [SerializeField] BulletData bulletData;

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
        CheckCompleteLevel();
        SetDetectionOfEnemyAtUpdate();
        ArrowLevelRotation();
    }
    void CheckCompleteLevel()
    {
        if (levelData.isCompleteFirstMap)
        {
            weaponGiftBoxSpawner.CreateSecondMapGiftBoxes();
            healthCoinSpawner.CreateSecondtMapHealthCoin();
            coinSpawner.CreateSecondCoin();
            mapController.CreateSecondMap();
            mapController.SetSecondSkybox();
            mirrorSpawner.CreateSecondMapMirror();
            enemySpawner.CreateSecondMapEnemies();
            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            levelData.isCompleteFirstMap = false;
        }
        else if (levelData.isCompleteSecondMap)
        {
            weaponGiftBoxSpawner.CreateThirdMapGiftBoxes();
            healthCoinSpawner.CreateThirdMapHealthCoin();
            coinSpawner.CreateThirdCoin();
            mapController.CreateThirdMap();
            mapController.SetThirdSkyBox();
            mirrorSpawner.CreateThirdMapMirror();
            enemySpawner.CreateThirdMapEnemies();
            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            levelData.isCompleteSecondMap = false;
        }
        else if (levelData.isCompleteThirdMap)
        {
            weaponGiftBoxSpawner.CreateFourthMapGiftBoxes();
            healthCoinSpawner.CreateFourthMapHealthCoin();
            coinSpawner.CreateFourthCoin();
            mapController.CreateFourthMap();
            mapController.SetFourthSkybox();
            mirrorSpawner.CreateFourthMapMirror();
            enemySpawner.CreateFourthMapEnemies();
            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            levelData.isCompleteThirdMap = false;
        }
        else if (levelData.isCompleteFourthMap)
        {
            weaponGiftBoxSpawner.CreateFifthMapGiftBoxes();
            healthCoinSpawner.CreateFifthMapHealthCoin();
            coinSpawner.CreateFifthCoin();
            mapController.CreateFifthMap();
            mapController.SetFifthSkybox();
            mirrorSpawner.CreateFifthMapMirror();
            enemySpawner.CreateFifthMapEnemies();
            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            levelData.isCompleteFourthMap = false;
        }
    }

    void SetDetectionOfEnemyAtUpdate()
    {
        if (levelData.currentMapName == LevelData.MapNames.FirstMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.level1EnemyDetectionDistance;
            bulletData.currentGiftBox = bulletData.bullDogGiftBox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.level2EnemyDetectionDistance;
            bulletData.currentGiftBox = bulletData.cowgunGiftBox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.level3EnemyDetectionDistance;
            bulletData.currentGiftBox = bulletData.demongunGiftBox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.level4EnemyDetectionDistance;
            bulletData.currentGiftBox = bulletData.negevGiftBox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.FifthMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.level5EnemyDetectionDistance;
            bulletData.currentGiftBox = bulletData.axegunGiftBox;
        }
    }
    public void ArrowLevelRotation()
    {
        if (levelData.currentMapName == LevelData.MapNames.FirstMap)
        {
            levelData.currentFinishArea = levelData.level1FinishArea;
        }
        else if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            levelData.currentFinishArea = levelData.level2FinishArea;
        }
        else if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            levelData.currentFinishArea = levelData.level3FinishArea;
        }
        else if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            levelData.currentFinishArea = levelData.level4FinishArea;
        }
        else if (levelData.currentMapName == LevelData.MapNames.FifthMap)
        {
            levelData.currentFinishArea = levelData.level5FinishArea;
        }
    }
}
