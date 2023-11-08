using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    public static int levelCount;

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
        LevelCount();
        weaponGiftBoxSpawnerObject = GameObject.Find("WeaponGiftBoxSpawner");
        healthCoinSpawnerObject = GameObject.Find("HealthCoinSpawner");
        enemySpawnerObject = GameObject.Find("EnemySpawner");
        coinSpawnerObject = GameObject.Find("CoinSpawner");
        mirrorSpawnerObject = GameObject.Find("MirrorSpawner");
        cameraSpawnerObject = GameObject.Find("CameraSpawner");
        mapControllerObject = GameObject.Find("MapController");
        
        InitStatements();
    }
    private void Start()
    {
        
    }
    void InitStatements()
    {
        if (weaponGiftBoxSpawnerObject)
        {
            weaponGiftBoxSpawner = weaponGiftBoxSpawnerObject.GetComponent<WeaponGiftBoxSpawner>();
        }
        if (healthCoinSpawnerObject)
        {
            healthCoinSpawner = healthCoinSpawnerObject.GetComponent<HealthCoinSpawner>();
        }
        if (enemySpawnerObject)
        {
            enemySpawner = enemySpawnerObject.GetComponent<EnemySpawner>();
        }
        if (coinSpawnerObject)
        {
            coinSpawner = coinSpawnerObject.GetComponent<CoinSpawner>();
        }
        if (mirrorSpawnerObject)
        {
            mirrorSpawner = mirrorSpawnerObject.GetComponent<MirrorSpawner>();

        }
        if (cameraSpawnerObject)
        {
            cameraSpawner = cameraSpawnerObject.GetComponent<CameraSpawner>();
        }
        if (mapControllerObject)
        {
            mapController = mapControllerObject.GetComponent<MapController>();
        }
        
    }

    private void Update()
    {
        CheckCompleteLevel();
        
        SetDetectionOfEnemyAtUpdate(levelCount);
        ArrowLevelRotation(levelCount);
    }
    void LevelCount()
    {
        switch (levelData.currentLevel)
        {
            case LevelData.Levels.Level1:
                levelCount = 0;
                break;
            case LevelData.Levels.Level2:
                levelCount = 1;
                break;
            case LevelData.Levels.Level3:
                levelCount = 2;
                break;
            case LevelData.Levels.Level4:
                levelCount = 3;
                break;
            case LevelData.Levels.Level5:
                levelCount = 4;
                break;
            case LevelData.Levels.Level6:
                levelCount = 5;
                break;
            case LevelData.Levels.Level7:
                levelCount = 6;
                break;
            case LevelData.Levels.Level8:
                levelCount = 7;
                break;
            case LevelData.Levels.Level9:
                levelCount = 8;
                break;
            case LevelData.Levels.Level10:
                levelCount = 9;
                break;
        }
    }
    
    void CheckCompleteLevel()
    {
        
        if (levelData.isCompleteMaps[0])
        {
            levelData.currentLevel = LevelData.Levels.Level2;
            levelData.currentEnemyObjects = levelData.enemySecondObjects;
            bulletData.currentGiftBox = bulletData.cowgunGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, levelCount);
            healthCoinSpawner.CreateMapHealthCoins(levelCount);
            coinSpawner.CreateCoins(levelCount);
            //mapController.CreateSecondMap();
            mapController.CreateMap(levelCount);
            mapController.SetSkybox(levelCount);
            mirrorSpawner.CreateTransportMirror(levelCount);
            enemySpawner.CreateEnemiesByMap(levelCount);


            levelData.isCompleteMaps[0] = false;
        }
        else if (levelData.isCompleteMaps[1])
        {
            levelData.currentLevel = LevelData.Levels.Level3;
            levelData.currentEnemyObjects = levelData.enemyThirdObjects;
            bulletData.currentGiftBox = bulletData.demongunGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, levelCount);
            healthCoinSpawner.CreateMapHealthCoins(levelCount);
            coinSpawner.CreateCoins(levelCount);
            mapController.CreateMap(levelCount);
            mapController.SetSkybox(levelCount);
            mirrorSpawner.CreateTransportMirror(levelCount);
            enemySpawner.CreateEnemiesByMap(levelCount);


            levelData.isCompleteMaps[1] = false;
        }
        else if (levelData.isCompleteMaps[2])
        {
            levelData.currentLevel = LevelData.Levels.Level4;
            levelData.currentEnemyObjects = levelData.enemyFourthObjects;
            bulletData.currentGiftBox = bulletData.negevGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, levelCount);
            healthCoinSpawner.CreateMapHealthCoins(levelCount);
            coinSpawner.CreateCoins(levelCount);
            mapController.CreateMap(levelCount);
            mapController.SetSkybox(levelCount);
            mirrorSpawner.CreateTransportMirror(levelCount);
            enemySpawner.CreateEnemiesByMap(levelCount);


            levelData.isCompleteMaps[2] = false;
        }
        else if (levelData.isCompleteMaps[3])
        {
            levelData.currentLevel = LevelData.Levels.Level5;
            levelData.currentEnemyObjects = levelData.enemyFifthObjects;
            bulletData.currentGiftBox = bulletData.axegunGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, levelCount);
            healthCoinSpawner.CreateMapHealthCoins(levelCount);
            coinSpawner.CreateCoins(levelCount);
            mapController.CreateMap(levelCount);
            mapController.SetSkybox(levelCount);
            mirrorSpawner.CreateTransportMirror(levelCount);
            enemySpawner.CreateEnemiesByMap(levelCount);

            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            levelData.isCompleteMaps[3] = false;
        }
        else if (levelData.isCompleteMaps[4])
        {
            levelData.currentLevel = LevelData.Levels.Level6;
            levelData.currentEnemyObjects = levelData.enemySixthObjects;
            bulletData.currentGiftBox = bulletData.crsytalgunGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, levelCount);
            healthCoinSpawner.CreateMapHealthCoins(levelCount);
            coinSpawner.CreateCoins(levelCount);
            mapController.CreateMap(levelCount);
            mapController.SetSkybox(levelCount);
            mirrorSpawner.CreateTransportMirror(levelCount);
            enemySpawner.CreateEnemiesByMap(levelCount);

            levelData.isCompleteMaps[4] = false;
        }
        else if (levelData.isCompleteMaps[5])
        {
            levelData.currentLevel = LevelData.Levels.Level7;
            levelData.currentEnemyObjects = levelData.enemySeventhObjects;
            bulletData.currentGiftBox = bulletData.icegunGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, levelCount);
            healthCoinSpawner.CreateMapHealthCoins(levelCount);
            coinSpawner.CreateCoins(levelCount);
            mapController.CreateMap(levelCount);
            mapController.SetSkybox(levelCount);
            mirrorSpawner.CreateTransportMirror(levelCount);
            enemySpawner.CreateEnemiesByMap(levelCount);

            levelData.isCompleteMaps[5] = false;
        }
        else if (levelData.isCompleteMaps[6])
        {
            levelData.currentLevel = LevelData.Levels.Level8;
            levelData.currentEnemyObjects = levelData.enemyEightthObjects;
            bulletData.currentGiftBox = bulletData.pistolGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, levelCount);
            healthCoinSpawner.CreateMapHealthCoins(levelCount);
            coinSpawner.CreateCoins(levelCount);
            mapController.CreateMap(levelCount);
            mapController.SetSkybox(levelCount);
            mirrorSpawner.CreateTransportMirror(levelCount);
            enemySpawner.CreateEnemiesByMap(levelCount);

            levelData.isCompleteMaps[6] = false;
        }
        else if (levelData.isCompleteMaps[7])
        {
            levelData.currentLevel = LevelData.Levels.Level9;
            levelData.currentEnemyObjects = levelData.enemyNinethObjects;
            bulletData.currentGiftBox = bulletData.ak47GiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, levelCount);
            healthCoinSpawner.CreateMapHealthCoins(levelCount);
            coinSpawner.CreateCoins(levelCount);
            mapController.CreateMap(levelCount);
            mapController.SetSkybox(levelCount);
            mirrorSpawner.CreateTransportMirror(levelCount);
            enemySpawner.CreateEnemiesByMap(levelCount);

            levelData.isCompleteMaps[7] = false;
        }
        else if (levelData.isCompleteMaps[8])
        {
            levelData.currentLevel = LevelData.Levels.Level10;
            levelData.currentEnemyObjects = levelData.enemyTenthObjects;
            bulletData.currentGiftBox = bulletData.rifleGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, levelCount);
            healthCoinSpawner.CreateMapHealthCoins(levelCount);
            coinSpawner.CreateCoins(levelCount);
            mapController.CreateMap(levelCount);
            mapController.SetSkybox(levelCount);
            mirrorSpawner.CreateTransportMirror(levelCount);
            enemySpawner.CreateEnemiesByMap(levelCount);

            levelData.isCompleteMaps[8] = false;
        }
        else
        {//Level1 Condition
            bulletData.currentGiftBox = bulletData.cowgunGiftBox;
            levelData.currentEnemyObjects = levelData.enemyFirstObjects;
        }
    }
    void SetDetectionOfEnemyAtUpdate(int levelCount)
    {
        levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[levelCount];
    }
    public void ArrowLevelRotation(int levelCount)
    {
        levelData.currentFinishArea = levelData.finishTransforms[levelCount];
    }
}
