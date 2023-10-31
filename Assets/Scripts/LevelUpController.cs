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
    private void Start()
    {
        SpawnPlayerObject();
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
        SetDetectionOfEnemyAtUpdate();
        ArrowLevelRotation();
    }
    private void SpawnPlayerObject()
    {
        if (levelData.currentMapName == LevelData.MapNames.FirstMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[0];

            //GetInstance.gameObject.transform.position = new Vector3(0f, 5f, 0f);
            PlayerManager.GetInstance.gameObject.transform.position = playerData.playerSpawns.GetChild(0).transform.position;
        }
        else if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[1];

            PlayerManager.GetInstance.gameObject.transform.position = playerData.playerSpawns.GetChild(1).transform.position;
        }
        else if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[2];

            PlayerManager.GetInstance.gameObject.transform.position = playerData.playerSpawns.GetChild(2).transform.position;
        }
        else if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[3];

            PlayerManager.GetInstance.gameObject.transform.position = playerData.playerSpawns.GetChild(3).transform.position;
        }
        else if (levelData.currentMapName == LevelData.MapNames.FifthMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[4];

            PlayerManager.GetInstance.gameObject.transform.position = playerData.playerSpawns.GetChild(4).transform.position;
        }
    }
    void CheckCompleteLevel()
    {
        if (levelData.isCompleteMaps[0])
        {
            levelData.currentMapName = LevelData.MapNames.SecondMap;

            weaponGiftBoxSpawner.CreateSecondMapGiftBoxes();
            healthCoinSpawner.CreateSecondtMapHealthCoin();
            coinSpawner.CreateSecondCoin();
            //mapController.CreateSecondMap();
            mapController.CreateMap(1);
            mapController.SetSecondSkybox();
            mirrorSpawner.CreateSecondMapMirror();
            enemySpawner.CreateSecondMapEnemies();

            

            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            levelData.isCompleteMaps[0] = false;
        }
        else if (levelData.isCompleteMaps[1])
        {
            levelData.currentMapName = LevelData.MapNames.ThirdMap;

            weaponGiftBoxSpawner.CreateThirdMapGiftBoxes();
            healthCoinSpawner.CreateThirdMapHealthCoin();
            coinSpawner.CreateThirdCoin();
            //mapController.CreateThirdMap();
            mapController.CreateMap(2);
            mapController.SetThirdSkyBox();
            mirrorSpawner.CreateThirdMapMirror();
            enemySpawner.CreateThirdMapEnemies();

            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            levelData.isCompleteMaps[1] = false;
        }
        else if (levelData.isCompleteMaps[2])
        {
            levelData.currentMapName = LevelData.MapNames.FourthMap;

            weaponGiftBoxSpawner.CreateFourthMapGiftBoxes();
            healthCoinSpawner.CreateFourthMapHealthCoin();
            coinSpawner.CreateFourthCoin();
            //mapController.CreateFourthMap();
            mapController.CreateMap(3);
            mapController.SetFourthSkybox();
            mirrorSpawner.CreateFourthMapMirror();
            enemySpawner.CreateFourthMapEnemies();

            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            levelData.isCompleteMaps[2] = false;
        }
        else if (levelData.isCompleteMaps[3])
        {
            levelData.currentMapName = LevelData.MapNames.FifthMap;

            weaponGiftBoxSpawner.CreateFifthMapGiftBoxes();
            healthCoinSpawner.CreateFifthMapHealthCoin();
            coinSpawner.CreateFifthCoin();
            //mapController.CreateFifthMap();
            mapController.CreateMap(4);
            mapController.SetFifthSkybox();
            mirrorSpawner.CreateFifthMapMirror();
            enemySpawner.CreateFifthMapEnemies();

            //cameraSpawner.colliders = FindObjectsOfType<MeshRenderer>();

            levelData.isCompleteMaps[3] = false;
        }
    }

    void SetDetectionOfEnemyAtUpdate()
    {
        if (levelData.currentMapName == LevelData.MapNames.FirstMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[0];
            bulletData.currentGiftBox = bulletData.bullDogGiftBox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[1];
            bulletData.currentGiftBox = bulletData.cowgunGiftBox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[2];
            bulletData.currentGiftBox = bulletData.demongunGiftBox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[3];
            bulletData.currentGiftBox = bulletData.negevGiftBox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.FifthMap)
        {
            levelData.currentEnemyDetectionDistance = levelData.enemyDetectionDistances[4];
            bulletData.currentGiftBox = bulletData.axegunGiftBox;
        }
    }
    public void ArrowLevelRotation()
    {
        if (levelData.currentMapName == LevelData.MapNames.FirstMap)
        {
            levelData.currentFinishArea = levelData.finishTransforms[0];
        }
        else if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            levelData.currentFinishArea = levelData.finishTransforms[1];
        }
        else if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            levelData.currentFinishArea = levelData.finishTransforms[2];
        }
        else if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            levelData.currentFinishArea = levelData.finishTransforms[3];
        }
        else if (levelData.currentMapName == LevelData.MapNames.FifthMap)
        {
            levelData.currentFinishArea = levelData.finishTransforms[4];
        }
    }
}
