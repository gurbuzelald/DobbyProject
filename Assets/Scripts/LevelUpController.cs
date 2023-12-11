using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUpController : MonoBehaviour
{
    public static int currentLevelCount;

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
        LevelCount();

        CheckCompleteLevel();
        
        SetDetectionOfEnemyAtUpdate(currentLevelCount);
        ArrowLevelRotation(currentLevelCount);
        SetEnemySpeed();
    }
    
    void LevelCount()
    {
        switch (levelData.currentLevel)
        {
            case LevelData.Levels.Level1:
                currentLevelCount = 0;
                break;
            case LevelData.Levels.Level2:
                currentLevelCount = 1;
                break;
            case LevelData.Levels.Level3:
                currentLevelCount = 2;
                break;
            case LevelData.Levels.Level4:
                currentLevelCount = 3;
                break;
            case LevelData.Levels.Level5:
                currentLevelCount = 4;
                break;
            case LevelData.Levels.Level6:
                currentLevelCount = 5;
                break;
            case LevelData.Levels.Level7:
                currentLevelCount = 6;
                break;
            case LevelData.Levels.Level8:
                currentLevelCount = 7;
                break;
            case LevelData.Levels.Level9:
                currentLevelCount = 8;
                break;
            case LevelData.Levels.Level10:
                currentLevelCount = 9;
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
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            mapController.CreateMap(currentLevelCount);
            mapController.SetSkybox(currentLevelCount);
            mirrorSpawner.CreateTransportMirror(currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(currentLevelCount);
            }


            levelData.isCompleteMaps[0] = false;
        }
        else if (levelData.isCompleteMaps[1])
        {
            levelData.currentLevel = LevelData.Levels.Level3;
            levelData.currentEnemyObjects = levelData.enemyThirdObjects;
            bulletData.currentGiftBox = bulletData.demongunGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            mapController.CreateMap(currentLevelCount);
            mapController.SetSkybox(currentLevelCount);
            mirrorSpawner.CreateTransportMirror(currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(currentLevelCount);
            }

            levelData.isCompleteMaps[1] = false;
        }
        else if (levelData.isCompleteMaps[2])
        {
            levelData.currentLevel = LevelData.Levels.Level4;
            levelData.currentEnemyObjects = levelData.enemyFourthObjects;
            bulletData.currentGiftBox = bulletData.negevGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            mapController.CreateMap(currentLevelCount);
            mapController.SetSkybox(currentLevelCount);
            mirrorSpawner.CreateTransportMirror(currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(currentLevelCount);
            }

            levelData.isCompleteMaps[2] = false;
        }
        else if (levelData.isCompleteMaps[3])
        {
            levelData.currentLevel = LevelData.Levels.Level5;
            levelData.currentEnemyObjects = levelData.enemyFifthObjects;
            bulletData.currentGiftBox = bulletData.axegunGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            mapController.CreateMap(currentLevelCount);
            mapController.SetSkybox(currentLevelCount);
            mirrorSpawner.CreateTransportMirror(currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(currentLevelCount);
            }


            levelData.isCompleteMaps[3] = false;
        }
        else if (levelData.isCompleteMaps[4])
        {
            levelData.currentLevel = LevelData.Levels.Level6;
            levelData.currentEnemyObjects = levelData.enemySixthObjects;
            bulletData.currentGiftBox = bulletData.crsytalgunGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            mapController.CreateMap(currentLevelCount);
            mapController.SetSkybox(currentLevelCount);
            mirrorSpawner.CreateTransportMirror(currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(currentLevelCount);
            }

            levelData.isCompleteMaps[4] = false;
        }
        else if (levelData.isCompleteMaps[5])
        {
            levelData.currentLevel = LevelData.Levels.Level7;
            levelData.currentEnemyObjects = levelData.enemySeventhObjects;
            bulletData.currentGiftBox = bulletData.icegunGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            mapController.CreateMap(currentLevelCount);
            mapController.SetSkybox(currentLevelCount);
            mirrorSpawner.CreateTransportMirror(currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(currentLevelCount);
            }

            levelData.isCompleteMaps[5] = false;
        }
        else if (levelData.isCompleteMaps[6])
        {
            levelData.currentLevel = LevelData.Levels.Level8;
            levelData.currentEnemyObjects = levelData.enemyEightthObjects;
            bulletData.currentGiftBox = bulletData.pistolGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            mapController.CreateMap(currentLevelCount);
            mapController.SetSkybox(currentLevelCount);
            mirrorSpawner.CreateTransportMirror(currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(currentLevelCount);
            }

            levelData.isCompleteMaps[6] = false;
        }
        else if (levelData.isCompleteMaps[7])
        {
            levelData.currentLevel = LevelData.Levels.Level9;
            levelData.currentEnemyObjects = levelData.enemyNinethObjects;
            bulletData.currentGiftBox = bulletData.ak47GiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            mapController.CreateMap(currentLevelCount);
            mapController.SetSkybox(currentLevelCount);
            mirrorSpawner.CreateTransportMirror(currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(currentLevelCount);
            }

            levelData.isCompleteMaps[7] = false;
        }
        else if (levelData.isCompleteMaps[8])
        {
            levelData.currentLevel = LevelData.Levels.Level10;
            levelData.currentEnemyObjects = levelData.enemyTenthObjects;
            bulletData.currentGiftBox = bulletData.rifleGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            mapController.CreateMap(currentLevelCount);
            mapController.SetSkybox(currentLevelCount);
            mirrorSpawner.CreateTransportMirror(currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(currentLevelCount);
            }

            levelData.isCompleteMaps[8] = false;
        }
        else if (levelData.isCompleteMaps[levelData.isCompleteMaps.Length - 1])
        {
            SceneController.GetInstance.LoadWinScene();
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
    void SetEnemySpeed()
    {
        switch (levelData.currentLevel)
        {
            case LevelData.Levels.Level1:
                levelData.currentEnemySpeed = Random.Range(0.2f, 0.5f);
                break;
            case LevelData.Levels.Level2:
                levelData.currentEnemySpeed = Random.Range(0.25f, 0.55f);
                break;
            case LevelData.Levels.Level3:
                levelData.currentEnemySpeed = Random.Range(0.3f, 0.6f);
                break;
            case LevelData.Levels.Level4:
                levelData.currentEnemySpeed = Random.Range(0.35f, 0.65f);
                break;
            case LevelData.Levels.Level5:
                levelData.currentEnemySpeed = Random.Range(0.4f, 0.7f);
                break;
            case LevelData.Levels.Level6:
                levelData.currentEnemySpeed = Random.Range(0.45f, 0.75f);
                break;
            case LevelData.Levels.Level7:
                levelData.currentEnemySpeed = Random.Range(0.5f, 0.8f);
                break;
            case LevelData.Levels.Level8:
                levelData.currentEnemySpeed = Random.Range(0.55f, 0.85f);
                break;
            case LevelData.Levels.Level9:
                levelData.currentEnemySpeed = Random.Range(0.6f, 0.9f);
                break;
            case LevelData.Levels.Level10:
                levelData.currentEnemySpeed = Random.Range(0.65f, 0.95f);
                break;
        }
    }
    public void ArrowLevelRotation(int levelCount)
    {
        levelData.currentFinishArea = levelData.finishTransforms[levelCount];
    }
}
