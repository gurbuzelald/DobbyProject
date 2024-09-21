using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUpController : MonoBehaviour
{
    public LevelData.LevelUpRequirements[] levelUpRequirements = null;

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

    private SceneController _sceneController;

    private GameObject scoreControllerObject;
    private ScoreController scoreController;

    public static string requirementMessage;

    private TextMeshProUGUI enemyKillLevelUpRequirementText;
    private TextMeshProUGUI pickUpCoinLevelUpRequirementText;
    private TextMeshProUGUI levelUpKeysRequirementText;


    [SerializeField] TextMeshProUGUI currentLevelUpKeysText;

    [SerializeField] Image scoreMissionCompletedImage;
    [SerializeField] Image enemyKillMissionCompletedImage;
    [SerializeField] Image levelUpKeyMissionCompletedImage;


    void Awake()
    {
        CurrentLevelID();
        weaponGiftBoxSpawnerObject = GameObject.Find("WeaponGiftBoxSpawner");
        healthCoinSpawnerObject = GameObject.Find("HealthCoinSpawner");
        enemySpawnerObject = GameObject.Find("EnemySpawner");
        coinSpawnerObject = GameObject.Find("CoinSpawner");
        mirrorSpawnerObject = GameObject.Find("MirrorSpawner");
        cameraSpawnerObject = GameObject.Find("CameraSpawner");
        mapControllerObject = GameObject.Find("MapController");
        scoreControllerObject = GameObject.Find("ScoreController");
        _sceneController = FindObjectOfType<SceneController>();


        FindWarnTextObjects();


        InitStatements();        
    }
    private void Start()
    {
        if (coinSpawner)
        {
            coinSpawner.SetCoinValue(LevelData.currentLevelCount);
        }
    }


    void FindWarnTextObjects()
    {
        if (SceneController.Scenes.Game.ToString() == _sceneController.CheckSceneName())
        {
            if (GameObject.Find("EnemyKillLevelUpRequirementWarnText"))
            {
                enemyKillLevelUpRequirementText = GameObject.Find("EnemyKillLevelUpRequirementWarnText").GetComponent<TextMeshProUGUI>();
                enemyKillLevelUpRequirementText.gameObject.SetActive(true);

            }
            if (GameObject.Find("PickUpCoinLevelUpRequirementWarnText"))
            {
                pickUpCoinLevelUpRequirementText = GameObject.Find("PickUpCoinLevelUpRequirementWarnText").GetComponent<TextMeshProUGUI>();
            }
            if (GameObject.Find("LevelUpKeysRequirementText"))
            {
                levelUpKeysRequirementText = GameObject.Find("LevelUpKeysRequirementText").GetComponent<TextMeshProUGUI>();
            }
        }
        

        StartCoroutine(SetLevelUpRequirementWarnTextMessages());
    }

    IEnumerator SetLevelUpRequirementWarnTextMessages()
    {
        if (levelUpRequirements != null && pickUpCoinLevelUpRequirementText)
        {
            pickUpCoinLevelUpRequirementText.text = "";

            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                enemyKillLevelUpRequirementText.text = "Bölümü Geçmen İçin " + levelUpRequirements[LevelData.currentLevelUpRequirement].enemyKills.ToString() +
                "  Düşman Öldürmen, ";
            }
            else
            {
                enemyKillLevelUpRequirementText.text = "You Need To Take  " +
                levelUpRequirements[LevelData.currentLevelUpRequirement].enemyKills.ToString() +
                "  Kills...";
            }
            
            
            yield return new WaitForSeconds(4f);

            enemyKillLevelUpRequirementText.text = "";

            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                pickUpCoinLevelUpRequirementText.text = levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount.ToString() +
                "  Coin Toplaman ve";
            }
            else
            {
                pickUpCoinLevelUpRequirementText.text = "Pick Up  " +
                levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount.ToString() +
                "  Coins...";
            }

            

            yield return new WaitForSeconds(4f);

            pickUpCoinLevelUpRequirementText.text = "";

            if (playerData.currentLanguage == PlayerData.Languages.Turkish)
            {
                levelUpKeysRequirementText.text = levelUpRequirements[LevelData.currentLevelUpRequirement].levelUpKeys.ToString() +
                "  Adet Anahtar Bulman Gerekiyor!!!";
            }
            else
            {
                levelUpKeysRequirementText.text = "Pick Up  " +
                levelUpRequirements[LevelData.currentLevelUpRequirement].levelUpKeys.ToString() +
                "  Keys For Level Up!!!";
            }

                

            yield return new WaitForSeconds(4f);

            enemyKillLevelUpRequirementText.text = "";
            pickUpCoinLevelUpRequirementText.text = "";
            levelUpKeysRequirementText.text = "";
        }

    }

    void InitStatements()
    {
        if (levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount >= ScoreController._scoreAmount)
        {
            scoreMissionCompletedImage.gameObject.SetActive(false);
        }

        

        if (levelUpRequirements[LevelData.currentLevelUpRequirement].enemyKills >= EnemyData.enemyDeathCount)
        {
            enemyKillMissionCompletedImage.gameObject.SetActive(false);
        }
        


        if (levelUpRequirements[LevelData.currentLevelUpRequirement].levelUpKeys >= LevelData.currentOwnedLevelUpKeys)
        {
            levelUpKeyMissionCompletedImage.gameObject.SetActive(false);
        }
        


        LevelData.currentOwnedLevelUpKeys = 0;

        LevelData.levelCanBeSkipped = false;

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
        if (scoreControllerObject)
        {
            scoreController = scoreControllerObject.GetComponent<ScoreController>();
        }
              
    }

    private void Update()
    {
        CurrentLevelID();

        
        SetDetectionOfEnemyAtUpdate(LevelData.currentLevelCount);
        ArrowLevelRotation(LevelData.currentLevelCount);

        CheckCompleteLevel();
    }

    IEnumerator AbleToLevelUpMessageText()
    {
        if (playerData.currentLanguage == PlayerData.Languages.Turkish)
        {
            enemyKillLevelUpRequirementText.text = "Bitiş Alanına Git ve Bölümü Geç!!!";
        }
        else
        {
            enemyKillLevelUpRequirementText.text = "Go To Finish Area And Level Up!!!";
        }
        

        yield return new WaitForSeconds(4f);

        enemyKillLevelUpRequirementText.text = "";

        enemyKillLevelUpRequirementText.gameObject.SetActive(false);
    }

    int GetCurrentLevelID(LevelData levelData)
    {
        if (levelData.currentLevel == LevelData.Levels.Level1) return 0;
        else if (levelData.currentLevel == LevelData.Levels.Level2) return 1;
        else if (levelData.currentLevel == LevelData.Levels.Level3) return 2;
        else if (levelData.currentLevel == LevelData.Levels.Level4) return 3;
        else if (levelData.currentLevel == LevelData.Levels.Level5) return 4;
        else if (levelData.currentLevel == LevelData.Levels.Level6) return 5;
        else if (levelData.currentLevel == LevelData.Levels.Level7) return 6;
        else if (levelData.currentLevel == LevelData.Levels.Level8) return 7;
        else if (levelData.currentLevel == LevelData.Levels.Level9) return 8;
        else if (levelData.currentLevel == LevelData.Levels.Level10) return 9;
        return -1;

    }
    void CurrentLevelID()
    {
        if (levelData != null)
        {
            LevelData.currentLevelCount = GetCurrentLevelID(levelData);

            StartCoroutine(CheckLevelUpRequirementsWhenTriggerFinisArea());
        } 
    }
    IEnumerator CheckLevelUpRequirementsWhenTriggerFinisArea()
    {
        LevelData.currentLevelUpRequirement = GetCurrentLevelID(levelData);

        if (levelUpRequirements != null)
        {
            if (levelUpRequirements[LevelData.currentLevelUpRequirement].enemyKills != 0 &&
            levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount != 0 &&
            levelUpRequirements[LevelData.currentLevelUpRequirement].levelUpKeys != 0)
            {
                if (levelUpRequirements[LevelData.currentLevelUpRequirement].enemyKills <= EnemyData.enemyDeathCount &&
                    levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount <= ScoreController._scoreAmount &&
                    levelUpRequirements[LevelData.currentLevelUpRequirement].levelUpKeys <= LevelData.currentOwnedLevelUpKeys)
                {
                    LevelData.levelCanBeSkipped = true;
                    StartCoroutine(AbleToLevelUpMessageText());


                    scoreMissionCompletedImage.gameObject.SetActive(true);

                    enemyKillMissionCompletedImage.gameObject.SetActive(true);

                    levelUpKeyMissionCompletedImage.gameObject.SetActive(true);

                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        requirementMessage = "Bölümü Geçmek İçim Bitiş Alanını Bul!!!";
                    }
                    else
                    {
                        requirementMessage = "Go To Finish Area For Level Up!!!";
                    }
                        

                    yield return new WaitForSeconds(4f);

                    requirementMessage = "";
                }
                if (levelUpRequirements[LevelData.currentLevelUpRequirement].coinCollectAmount <= ScoreController._scoreAmount)
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        requirementMessage = "Yeterince Coinin Var!!!";
                    }
                    else
                    {
                        requirementMessage = "You Have Pretty Enough Coins!!!";
                    }                    

                    scoreMissionCompletedImage.gameObject.SetActive(true);

                    yield return new WaitForSeconds(4f);

                    requirementMessage = "";
                }
                if (levelUpRequirements[LevelData.currentLevelUpRequirement].enemyKills <= EnemyData.enemyDeathCount)
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        requirementMessage = "Öldürmen Gereken Düşman Sayısına Ulaştın!!!";
                    }
                    else
                    {
                        requirementMessage = "You Reached Pretty Enough Enemy Killing!!!";
                    }
                    

                    enemyKillMissionCompletedImage.gameObject.SetActive(true);

                    yield return new WaitForSeconds(4f);

                    requirementMessage = "";
                }
                if (levelUpRequirements[LevelData.currentLevelUpRequirement].levelUpKeys == LevelData.currentOwnedLevelUpKeys)
                {
                    currentLevelUpKeysText.text = LevelData.currentOwnedLevelUpKeys.ToString() + "/" +
                                                  levelUpRequirements[LevelData.currentLevelUpRequirement].levelUpKeys;

                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        requirementMessage = "Bütün Anahtarları Buldun!!!";
                    }
                    else
                    {
                        requirementMessage = "You Found All Keys!!!";
                    }
                    

                    levelUpKeyMissionCompletedImage.gameObject.SetActive(true);

                    yield return new WaitForSeconds(4f);

                    requirementMessage = "";
                }
                else if (levelUpKeysRequirementText &&
                    levelUpRequirements[LevelData.currentLevelUpRequirement].levelUpKeys > LevelData.currentOwnedLevelUpKeys &&
                    currentLevelUpKeysText)
                {
                    currentLevelUpKeysText.text = LevelData.currentOwnedLevelUpKeys.ToString() + "/" +
                                                  levelUpRequirements[LevelData.currentLevelUpRequirement].levelUpKeys; ;
                }
            }
            else
            {
                LevelData.levelCanBeSkipped = true;
            }           

        }
    }
    
    void CheckCompleteLevel()
    {
        if (levelData.isCompleteMaps[0])
        {
            ObjectPool.creatableEnemyBullet = true;

            levelData.currentLevel = LevelData.Levels.Level2;
            levelData.currentEnemyObjects = levelData.enemySecondObjects;
            bulletData.currentGiftBox = bulletData.cowGiftBox;
            CurrentLevelID();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, LevelData.currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(LevelData.currentLevelCount);
            coinSpawner.CreateCoins(LevelData.currentLevelCount);
            coinSpawner.SetCoinValue(LevelData.currentLevelCount);
            mapController.CreateMap(LevelData.currentLevelCount);
            mapController.SetSkybox(LevelData.currentLevelCount);
            mirrorSpawner.CreateTransportMirror(LevelData.currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(LevelData.currentLevelCount);
            }

            _sceneController.LevelUpGame();

            levelData.isCompleteMaps[0] = false;
        }
        else if (levelData.isCompleteMaps[1])
        {
            ObjectPool.creatableEnemyBullet = true;

            levelData.currentLevel = LevelData.Levels.Level3;
            levelData.currentEnemyObjects = levelData.enemyThirdObjects;
            bulletData.currentGiftBox = bulletData.demonGiftBox;
            CurrentLevelID();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, LevelData.currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(LevelData.currentLevelCount);
            coinSpawner.CreateCoins(LevelData.currentLevelCount);
            coinSpawner.SetCoinValue(LevelData.currentLevelCount);
            mapController.CreateMap(LevelData.currentLevelCount);
            mapController.SetSkybox(LevelData.currentLevelCount);
            mirrorSpawner.CreateTransportMirror(LevelData.currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(LevelData.currentLevelCount);
            }

            _sceneController.LevelUpGame();

            levelData.isCompleteMaps[1] = false;
        }
        else if (levelData.isCompleteMaps[2])
        {
            ObjectPool.creatableEnemyBullet = true;

            levelData.currentLevel = LevelData.Levels.Level4;
            levelData.currentEnemyObjects = levelData.enemyFourthObjects;
            bulletData.currentGiftBox = bulletData.electroGiftBox;
            CurrentLevelID();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, LevelData.currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(LevelData.currentLevelCount);
            coinSpawner.CreateCoins(LevelData.currentLevelCount);
            coinSpawner.SetCoinValue(LevelData.currentLevelCount);
            mapController.CreateMap(LevelData.currentLevelCount);
            mapController.SetSkybox(LevelData.currentLevelCount);
            mirrorSpawner.CreateTransportMirror(LevelData.currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(LevelData.currentLevelCount);
            }

            _sceneController.LevelUpGame();

            levelData.isCompleteMaps[2] = false;
        }
        else if (levelData.isCompleteMaps[3])
        {
            ObjectPool.creatableEnemyBullet = true;

            levelData.currentLevel = LevelData.Levels.Level5;
            levelData.currentEnemyObjects = levelData.enemyFifthObjects;
            bulletData.currentGiftBox = bulletData.axeGiftBox;
            CurrentLevelID();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, LevelData.currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(LevelData.currentLevelCount);
            coinSpawner.CreateCoins(LevelData.currentLevelCount);
            coinSpawner.SetCoinValue(LevelData.currentLevelCount);
            mapController.CreateMap(LevelData.currentLevelCount);
            mapController.SetSkybox(LevelData.currentLevelCount);
            mirrorSpawner.CreateTransportMirror(LevelData.currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(LevelData.currentLevelCount);
            }

            _sceneController.LevelUpGame();

            levelData.isCompleteMaps[3] = false;
        }
        else if (levelData.isCompleteMaps[4])
        {
            ObjectPool.creatableEnemyBullet = true;

            levelData.currentLevel = LevelData.Levels.Level6;
            levelData.currentEnemyObjects = levelData.enemySixthObjects;
            bulletData.currentGiftBox = bulletData.crystalGiftBox;
            CurrentLevelID();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, LevelData.currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(LevelData.currentLevelCount);
            coinSpawner.CreateCoins(LevelData.currentLevelCount);
            coinSpawner.SetCoinValue(LevelData.currentLevelCount);
            mapController.CreateMap(LevelData.currentLevelCount);
            mapController.SetSkybox(LevelData.currentLevelCount);
            mirrorSpawner.CreateTransportMirror(LevelData.currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(LevelData.currentLevelCount);
            }

            _sceneController.LevelUpGame();

            levelData.isCompleteMaps[4] = false;
        }
        else if (levelData.isCompleteMaps[5])
        {
            ObjectPool.creatableEnemyBullet = true;

            levelData.currentLevel = LevelData.Levels.Level7;
            levelData.currentEnemyObjects = levelData.enemySeventhObjects;
            bulletData.currentGiftBox = bulletData.iceGiftBox;
            CurrentLevelID();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, LevelData.currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(LevelData.currentLevelCount);
            coinSpawner.CreateCoins(LevelData.currentLevelCount);
            coinSpawner.SetCoinValue(LevelData.currentLevelCount);
            mapController.CreateMap(LevelData.currentLevelCount);
            mapController.SetSkybox(LevelData.currentLevelCount);
            mirrorSpawner.CreateTransportMirror(LevelData.currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(LevelData.currentLevelCount);
            }

            _sceneController.LevelUpGame();

            levelData.isCompleteMaps[5] = false;
        }
        else if (levelData.isCompleteMaps[6])
        {
            ObjectPool.creatableEnemyBullet = true;

            levelData.currentLevel = LevelData.Levels.Level8;
            levelData.currentEnemyObjects = levelData.enemyEightthObjects;
            bulletData.currentGiftBox = bulletData.pistolGiftBox;
            CurrentLevelID();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, LevelData.currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(LevelData.currentLevelCount);
            coinSpawner.CreateCoins(LevelData.currentLevelCount);
            coinSpawner.SetCoinValue(LevelData.currentLevelCount);
            mapController.CreateMap(LevelData.currentLevelCount);
            mapController.SetSkybox(LevelData.currentLevelCount);
            mirrorSpawner.CreateTransportMirror(LevelData.currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(LevelData.currentLevelCount);
            }

            _sceneController.LevelUpGame();

            levelData.isCompleteMaps[6] = false;
        }
        else if (levelData.isCompleteMaps[7])
        {
            ObjectPool.creatableEnemyBullet = true;

            levelData.currentLevel = LevelData.Levels.Level9;
            levelData.currentEnemyObjects = levelData.enemyNinethObjects;
            bulletData.currentGiftBox = bulletData.ak47GiftBox;
            CurrentLevelID();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, LevelData.currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(LevelData.currentLevelCount);
            coinSpawner.CreateCoins(LevelData.currentLevelCount);
            coinSpawner.SetCoinValue(LevelData.currentLevelCount);
            mapController.CreateMap(LevelData.currentLevelCount);
            mapController.SetSkybox(LevelData.currentLevelCount);
            mirrorSpawner.CreateTransportMirror(LevelData.currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(LevelData.currentLevelCount);
            }

            _sceneController.LevelUpGame();

            levelData.isCompleteMaps[7] = false;
        }
        else if (levelData.isCompleteMaps[8])
        {
            ObjectPool.creatableEnemyBullet = true;

            levelData.currentLevel = LevelData.Levels.Level10;
            levelData.currentEnemyObjects = levelData.enemyTenthObjects;
            bulletData.currentGiftBox = bulletData.m4a4GiftBox;
            CurrentLevelID();
            weaponGiftBoxSpawner.CreateMapGiftBoxes(bulletData.currentGiftBox, LevelData.currentLevelCount);
            healthCoinSpawner.CreateMapHealthCoins(LevelData.currentLevelCount);
            coinSpawner.CreateCoins(LevelData.currentLevelCount);
            coinSpawner.SetCoinValue(LevelData.currentLevelCount);
            mapController.CreateMap(LevelData.currentLevelCount);
            mapController.SetSkybox(LevelData.currentLevelCount);
            mirrorSpawner.CreateTransportMirror(LevelData.currentLevelCount);

            if (enemySpawner)
            {
                enemySpawner.CreateEnemiesByMap(LevelData.currentLevelCount);
            }

            _sceneController.LevelUpGame();

            levelData.isCompleteMaps[8] = false;
        }
        else if (levelData.isCompleteMaps[levelData.isCompleteMaps.Length - 1])
        {//When last level is passed
            playerData.isWinning = true;
            //SceneController.GetInstance.LoadWinScene();
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
