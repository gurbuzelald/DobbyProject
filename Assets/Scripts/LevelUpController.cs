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
        coinSpawner.SetCoinValue(currentLevelCount);
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
            bulletData.currentGiftBox = bulletData.cowGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            coinSpawner.SetCoinValue(currentLevelCount);
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
            bulletData.currentGiftBox = bulletData.demonGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            coinSpawner.SetCoinValue(currentLevelCount);
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
            coinSpawner.SetCoinValue(currentLevelCount);
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
            bulletData.currentGiftBox = bulletData.axeGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            coinSpawner.SetCoinValue(currentLevelCount);
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
            bulletData.currentGiftBox = bulletData.crsytalGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            coinSpawner.SetCoinValue(currentLevelCount);
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
            bulletData.currentGiftBox = bulletData.iceGiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            coinSpawner.SetCoinValue(currentLevelCount);
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
            coinSpawner.SetCoinValue(currentLevelCount);
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
            coinSpawner.SetCoinValue(currentLevelCount);
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
            bulletData.currentGiftBox = bulletData.m4a4GiftBox;
            LevelCount();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(currentLevelCount);
            coinSpawner.CreateCoins(currentLevelCount);
            coinSpawner.SetCoinValue(currentLevelCount);
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
                levelData.currentEnemySpeed = Random.Range(levelData.levelEnemyMinSpeed[0], levelData.levelEnemyMaxSpeed[0]);
                break;
            case LevelData.Levels.Level2:
                levelData.currentEnemySpeed = Random.Range(levelData.levelEnemyMinSpeed[1], levelData.levelEnemyMaxSpeed[1]);
                break;
            case LevelData.Levels.Level3:
                levelData.currentEnemySpeed = Random.Range(levelData.levelEnemyMinSpeed[2], levelData.levelEnemyMaxSpeed[2]);
                break;
            case LevelData.Levels.Level4:
                levelData.currentEnemySpeed = Random.Range(levelData.levelEnemyMinSpeed[3], levelData.levelEnemyMaxSpeed[3]);
                break;
            case LevelData.Levels.Level5:
                levelData.currentEnemySpeed = Random.Range(levelData.levelEnemyMinSpeed[4], levelData.levelEnemyMaxSpeed[4]);
                break;
            case LevelData.Levels.Level6:
                levelData.currentEnemySpeed = Random.Range(levelData.levelEnemyMinSpeed[5], levelData.levelEnemyMaxSpeed[5]);
                break;
            case LevelData.Levels.Level7:
                levelData.currentEnemySpeed = Random.Range(levelData.levelEnemyMinSpeed[6], levelData.levelEnemyMaxSpeed[6]);
                break;
            case LevelData.Levels.Level8:
                levelData.currentEnemySpeed = Random.Range(levelData.levelEnemyMinSpeed[7], levelData.levelEnemyMaxSpeed[7]);
                break;
            case LevelData.Levels.Level9:
                levelData.currentEnemySpeed = Random.Range(levelData.levelEnemyMinSpeed[8], levelData.levelEnemyMaxSpeed[8]);
                break;
            case LevelData.Levels.Level10:
                levelData.currentEnemySpeed = Random.Range(levelData.levelEnemyMinSpeed[9], levelData.levelEnemyMaxSpeed[9]);
                break;
        }
    }
    public void ArrowLevelRotation(int levelCount)
    {
        levelData.currentFinishArea = levelData.finishTransforms[levelCount];
    }
}
