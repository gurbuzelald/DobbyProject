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

    public Image scoreMissionCompletedImage;
    public Image enemyKillMissionCompletedImage;


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
        _sceneController = GameObject.FindObjectOfType<SceneController>();


        FindWarnTextObjects();


        InitStatements();
    }

    void FindWarnTextObjects()
    {
        if (GameObject.Find("EnemyKillLevelUpRequirementWarnText").GetComponent<TextMeshProUGUI>())
        {
            enemyKillLevelUpRequirementText = GameObject.Find("EnemyKillLevelUpRequirementWarnText").GetComponent<TextMeshProUGUI>();
            enemyKillLevelUpRequirementText.gameObject.SetActive(true);

        }
        if (GameObject.Find("PickUpCoinLevelUpRequirementWarnText").GetComponent<TextMeshProUGUI>())
        {
            pickUpCoinLevelUpRequirementText = GameObject.Find("PickUpCoinLevelUpRequirementWarnText").GetComponent<TextMeshProUGUI>();
        }

        StartCoroutine(SetLevelUpRequirementWarnTextMessages());
    }

    IEnumerator SetLevelUpRequirementWarnTextMessages()
    {
        if (levelUpRequirements != null)
        {
            pickUpCoinLevelUpRequirementText.text = "";

            enemyKillLevelUpRequirementText.text = "You Need To Take  " +
                levelUpRequirements[LevelData.currentLevelUpRequirement].EnemyKills.ToString() +
                "  Kills...";
            
            yield return new WaitForSeconds(2f);

            enemyKillLevelUpRequirementText.text = "";

            pickUpCoinLevelUpRequirementText.text = "Pick Up  " +
                levelUpRequirements[LevelData.currentLevelUpRequirement].CoinCollectAmount.ToString() +
                "  Coins For Level Up!!!";

            yield return new WaitForSeconds(3f);

            enemyKillLevelUpRequirementText.text = "";
            pickUpCoinLevelUpRequirementText.text = "";
        }

    }

    void InitStatements()
    {
        if (GameObject.Find("ScoreMissionCompletedImage"))
        {
            //scoreMissionCompletedImage = GameObject.Find("ScoreMissionCompletedImage").GetComponent<Image>();

            if (levelUpRequirements[LevelData.currentLevelUpRequirement].CoinCollectAmount >= ScoreController._scoreAmount)
            {
                scoreMissionCompletedImage.gameObject.SetActive(false);
            }
        }

        if (GameObject.Find("EnemyKillMissionCompletedImage"))
        {
            //enemyKillMissionCompletedImage = GameObject.Find("EnemyKillMissionCompletedImage").GetComponent<Image>();

            if (levelUpRequirements[LevelData.currentLevelUpRequirement].EnemyKills >= EnemyData.enemyDeathCount)
            {
                enemyKillMissionCompletedImage.gameObject.SetActive(false);
            }
        }


        LevelData.levelCanUp = false;

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
        coinSpawner.SetCoinValue(LevelData.currentLevelCount);
    }

    private void Update()
    {
        CurrentLevelID();

        
        
        SetDetectionOfEnemyAtUpdate(LevelData.currentLevelCount);
        ArrowLevelRotation(LevelData.currentLevelCount);
        SetEnemySpeed();

        CheckCompleteLevel();
    }

    IEnumerator AbleToLevelUpMessageText()
    {
        if (enemyKillLevelUpRequirementText)
        {
            
        }
        enemyKillLevelUpRequirementText.text = "You Can Level Up!!";

        yield return new WaitForSeconds(2f);

        enemyKillLevelUpRequirementText.text = "Go To Finish Area!!";

        yield return new WaitForSeconds(2f);

        enemyKillLevelUpRequirementText.text = "Or You Can Pick Up More Coins!!";

        yield return new WaitForSeconds(2f);

        enemyKillLevelUpRequirementText.text = "For Buying New Characters And Weapons!!";

        yield return new WaitForSeconds(3f);

        enemyKillLevelUpRequirementText.text = "";

        enemyKillLevelUpRequirementText.gameObject.SetActive(false);
    }

    int GetCurrentLevelID(LevelData levelData)
    {
        if (levelData.currentLevel == LevelData.Levels.Level1) return 0;
        if (levelData.currentLevel == LevelData.Levels.Level2) return 1;
        if (levelData.currentLevel == LevelData.Levels.Level3) return 2;
        if (levelData.currentLevel == LevelData.Levels.Level4) return 3;
        if (levelData.currentLevel == LevelData.Levels.Level5) return 4;
        if (levelData.currentLevel == LevelData.Levels.Level6) return 5;
        if (levelData.currentLevel == LevelData.Levels.Level7) return 6;
        if (levelData.currentLevel == LevelData.Levels.Level8) return 7;
        if (levelData.currentLevel == LevelData.Levels.Level9) return 8;
        if (levelData.currentLevel == LevelData.Levels.Level9) return 9;
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
            if (levelUpRequirements[LevelData.currentLevelUpRequirement].EnemyKills <= EnemyData.enemyDeathCount &&
            levelUpRequirements[LevelData.currentLevelUpRequirement].CoinCollectAmount <= ScoreController._scoreAmount)
            {
                LevelData.levelCanUp = true;
                StartCoroutine(AbleToLevelUpMessageText());

                scoreMissionCompletedImage.gameObject.SetActive(true);

                enemyKillMissionCompletedImage.gameObject.SetActive(true);

            }
             if ((levelUpRequirements[LevelData.currentLevelUpRequirement].EnemyKills >= EnemyData.enemyDeathCount) &&
            levelUpRequirements[LevelData.currentLevelUpRequirement].CoinCollectAmount <= ScoreController._scoreAmount)
            {
                requirementMessage = "You Need To Kill  " +
                    (levelUpRequirements[LevelData.currentLevelUpRequirement].EnemyKills - EnemyData.enemyDeathCount).ToString() +
                    "  More Enemy For Level Up";

                scoreMissionCompletedImage.gameObject.SetActive(true);

                yield return new WaitForSeconds(3f);

                requirementMessage = "";
            }
             if (levelUpRequirements[LevelData.currentLevelUpRequirement].EnemyKills <= EnemyData.enemyDeathCount &&
            (levelUpRequirements[LevelData.currentLevelUpRequirement].CoinCollectAmount >= ScoreController._scoreAmount))
            {
                requirementMessage = "You Need To Collect  " +
                    (levelUpRequirements[LevelData.currentLevelUpRequirement].CoinCollectAmount - ScoreController._scoreAmount).ToString() +
                    "  More Coin  For Level Up";

                enemyKillMissionCompletedImage.gameObject.SetActive(true);

                yield return new WaitForSeconds(3f);

                requirementMessage = "";
            }
            /*else if ((levelUpRequirements[LevelData.currentLevelUpRequirement].EnemyKills > EnemyData.enemyDeathCount) &&
            (levelUpRequirements[LevelData.currentLevelUpRequirement].CoinCollectAmount > ScoreController._scoreAmount))
            {
                requirementMessage = "You Need To Kill  " +
                    (levelUpRequirements[LevelData.currentLevelUpRequirement].EnemyKills - EnemyData.enemyDeathCount).ToString() +
                    "  More Enemy ";

                scoreMissionCompletedImage.gameObject.SetActive(true);
                enemyKillMissionCompletedImage.gameObject.SetActive(true);

                yield return new WaitForSeconds(2f);

                requirementMessage = "You Need To Collect  " +
                    (levelUpRequirements[LevelData.currentLevelUpRequirement].CoinCollectAmount - ScoreController._scoreAmount).ToString() +
                    "  More Coin For Level Up";

                yield return new WaitForSeconds(3f);

                requirementMessage = "";

            }*/
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
            bulletData.currentGiftBox = bulletData.negevGiftBox;
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
