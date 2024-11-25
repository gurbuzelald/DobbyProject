using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class LevelUpController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;
    [SerializeField] BulletData bulletData;

    private GameObject weaponGiftBoxSpawnerObject;
    private WeaponGiftBoxSpawner weaponGiftBoxSpawner;

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

    public static string requirementMessage;

    private TextMeshProUGUI enemyKillLevelUpRequirementText;
    private TextMeshProUGUI pickUpCoinLevelUpRequirementText;
    private TextMeshProUGUI levelUpKeysRequirementText;


    [SerializeField] TextMeshProUGUI currentLevelUpKeysText;

    [SerializeField] Image scoreMissionCompletedImage;
    [SerializeField] Image enemyKillMissionCompletedImage;
    [SerializeField] Image levelUpKeyMissionCompletedImage;

    private int enoughKeyCount;
    private int notEnoughKeyCount;
    private int enoughEnemyKillsCount;
    private int notEnoughEnemyKillsCount;
    private int enoughCoinCount;
    private int notEnoughCoinCount;
    private int enoughBossDeadCount;
    private int notEnoughBossDeadCount;
    private int enoughForLevelUp;
    private int enoughAllAchievments;


    void Awake()
    {
        enoughKeyCount = 0;
        notEnoughKeyCount = 0;
        enoughEnemyKillsCount = 0;
        notEnoughEnemyKillsCount = 0;
        enoughCoinCount = 0;
        notEnoughCoinCount = 0;
        enoughBossDeadCount = 0;
        notEnoughBossDeadCount = 0;
        enoughForLevelUp = 0;
        enoughAllAchievments = 0;

        weaponGiftBoxSpawnerObject = GameObject.Find("WeaponGiftBoxSpawner");

        enemySpawnerObject = GameObject.Find("EnemySpawner");

        coinSpawnerObject = GameObject.Find("CoinSpawner");

        mirrorSpawnerObject = GameObject.Find("MirrorSpawner");

        cameraSpawnerObject = GameObject.Find("CameraSpawner");

        mapControllerObject = GameObject.Find("MapController");

        _sceneController = FindObjectOfType<SceneController>();


        FindWarnTextObjects();


        InitStatements();        
    }
    private void Start()
    {
        if (coinSpawner)
        {
            coinSpawner.SetCoinValue(LevelData.currentLevelId);
        }
    }


    void FindWarnTextObjects()
    {
        if (SceneController.Scenes.Game.ToString() == SceneController.CheckSceneName())
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
        if (levelData.levelUpRequirements == null || pickUpCoinLevelUpRequirementText == null)
            yield break;

        yield return ShowTimeMessage();

        yield return ShowEnemyKillRequirement();

        yield return ShowCoinCollectRequirement();

        yield return ShowKeyRequirement();

        yield return ShowBossRequirement();

        ClearAllRequirementsText();
    }

    IEnumerator ShowTimeMessage()
    {
        string timeMessage = playerData.currentLanguage == PlayerData.Languages.Turkish
            ? $"{TimeController.initialTimeValue} Saniyen Var:"
            : $"You Have {TimeController.initialTimeValue} Seconds:";

        enemyKillLevelUpRequirementText.text = timeMessage;
        yield return new WaitForSeconds(4f);
    }

    IEnumerator ShowEnemyKillRequirement()
    {
        string enemyKillMessage = playerData.currentLanguage == PlayerData.Languages.Turkish
            ? $"Bölümü Geçmen İçin {levelData.levelUpRequirements[LevelData.currentLevelId].enemyKills} Düşman Öldürmen,"
            : $"You Need To Take {levelData.levelUpRequirements[LevelData.currentLevelId].enemyKills} Kills";

        enemyKillLevelUpRequirementText.text = enemyKillMessage;
        yield return new WaitForSeconds(4f);
        enemyKillLevelUpRequirementText.text = ""; // Clear after showing
    }

    IEnumerator ShowCoinCollectRequirement()
    {
        string coinMessage = playerData.currentLanguage == PlayerData.Languages.Turkish
            ? $"{levelData.levelUpRequirements[LevelData.currentLevelId].coinCollectAmount} Coin Toplaman ve"
            : $"Pick Up {levelData.levelUpRequirements[LevelData.currentLevelId].coinCollectAmount} Coins and";

        pickUpCoinLevelUpRequirementText.text = coinMessage;
        yield return new WaitForSeconds(4f);
        pickUpCoinLevelUpRequirementText.text = ""; // Clear after showing
    }

    IEnumerator ShowKeyRequirement()
    {
        string keyMessage = playerData.currentLanguage == PlayerData.Languages.Turkish
            ? $"{levelData.levelUpRequirements[LevelData.currentLevelId].levelUpKeys} Adet Anahtar Bulman Gerekiyor!!!"
            : $"Pick Up {levelData.levelUpRequirements[LevelData.currentLevelId].levelUpKeys} Keys For Level Up!!!";

        levelUpKeysRequirementText.text = keyMessage;
        yield return new WaitForSeconds(4f);
        levelUpKeysRequirementText.text = ""; // Clear after showing
    }
    IEnumerator ShowBossRequirement()
    {
        string keyMessage = playerData.currentLanguage == PlayerData.Languages.Turkish
            ? $"Bölümü Geçmek İçin Bölümün Patron Düşmanını Öldürmen Gerekiyor!!!"
            : $"You Need to Kill This Level's Boss Enemy"; 

        levelUpKeysRequirementText.text = keyMessage;
        yield return new WaitForSeconds(4f);
        levelUpKeysRequirementText.text = ""; // Clear after showing
    }

    void ClearAllRequirementsText()
    {
        enemyKillLevelUpRequirementText.text = "";
        pickUpCoinLevelUpRequirementText.text = "";
        levelUpKeysRequirementText.text = "";
    }


    void InitStatements()
    {
        // Check mission completion for current level requirements
        var currentRequirements = levelData.levelUpRequirements[LevelData.currentLevelId];

        scoreMissionCompletedImage.gameObject.SetActive(currentRequirements.coinCollectAmount < ScoreController._scoreAmount);
        enemyKillMissionCompletedImage.gameObject.SetActive(currentRequirements.enemyKills < MainEnemyData.enemyDeathCount);
        levelUpKeyMissionCompletedImage.gameObject.SetActive(currentRequirements.levelUpKeys < LevelData.currentOwnedLevelUpKeys);

        // Reset level-related data
        LevelData.currentOwnedLevelUpKeys = 0;
        LevelData.levelCanBeSkipped = false;

        // Initialize spawners and controllers if the objects are assigned
        InitializeComponent(ref weaponGiftBoxSpawner, weaponGiftBoxSpawnerObject);
        InitializeComponent(ref enemySpawner, enemySpawnerObject);
        InitializeComponent(ref coinSpawner, coinSpawnerObject);
        InitializeComponent(ref mirrorSpawner, mirrorSpawnerObject);
        InitializeComponent(ref cameraSpawner, cameraSpawnerObject);
        InitializeComponent(ref mapController, mapControllerObject);

        // Reset boss enemy status for the current level
        if (levelData != null)
        {
            currentRequirements.isBossEnemyDead = false;
        }
        ArrowLevelRotation(LevelData.currentLevelId);
    }

    void InitializeComponent<T>(ref T component, GameObject obj) where T : Component
    {
        if (obj && component == null)
        {
            component = obj.GetComponent<T>();
        }
    }


    private void Update()
    {
        CheckCompleteLevel();

        levelData.levelUpRequirements[LevelData.currentLevelId].isBossEnemyDead = EnemySpawner.bossIsDead;

        CheckLevelUpRequirements();
    }

    void CheckLevelUpRequirements()
    {
        if (levelData == null) return;
        if (levelData.levelUpRequirements == null) return;

        var currentRequirements = levelData.levelUpRequirements[LevelData.currentLevelId];
        bool canLevelUp = false;

        // Check if level-up requirements exist
        if (currentRequirements.enemyKills != 0 || currentRequirements.coinCollectAmount != 0 || currentRequirements.levelUpKeys != 0)
        {
            if (IsRequirementsMet(currentRequirements) && enoughAllAchievments == 0)
            {
                canLevelUp = true;
                LevelData.levelCanBeSkipped = true;
                ShowRequirementMessage("Find To Finish Area For Level Up!!!", "Bölümü Geçmek İçin Bitiş Alanını Bul!!!");
                enoughAllAchievments++;
            }
            else
            {
                CheckNotMetRequirements(currentRequirements);
            }
        }
        else
        {
            LevelData.levelCanBeSkipped = true; // No requirements, skip level
        }
    }

    bool IsRequirementsMet(LevelData.LevelUpRequirements requirements)
    {
        return requirements.enemyKills <= MainEnemyData.enemyDeathCount &&
               requirements.coinCollectAmount <= ScoreController._scoreAmount &&
               requirements.levelUpKeys <= LevelData.currentOwnedLevelUpKeys &&
               requirements.isBossEnemyDead;
    }

    void CheckNotMetRequirements(LevelData.LevelUpRequirements requirements)
    {
        if (requirements.levelUpKeys <= LevelData.currentOwnedLevelUpKeys &&
            requirements.coinCollectAmount <= ScoreController._scoreAmount &&
            requirements.enemyKills > MainEnemyData.enemyDeathCount &&
            requirements.isBossEnemyDead && notEnoughEnemyKillsCount == 0)
        {
            ShowRequirementMessage($"You Need to Kill {requirements.enemyKills - MainEnemyData.enemyDeathCount} More Enemy!!!",
                                   $"Bölümü Geçmek İçin {requirements.enemyKills - MainEnemyData.enemyDeathCount} Tane Daha Düşman Öldürmen Gerekiyor!!!");
            ++notEnoughEnemyKillsCount;
        }
        else if (requirements.levelUpKeys <= LevelData.currentOwnedLevelUpKeys &&
            requirements.coinCollectAmount > ScoreController._scoreAmount &&
            requirements.enemyKills <= MainEnemyData.enemyDeathCount &&
            requirements.isBossEnemyDead && notEnoughCoinCount == 0)
        {
            ShowRequirementMessage($"You Need to Make {requirements.coinCollectAmount - ScoreController._scoreAmount} More Score!!!",
                                   $"Bölümü Geçmek İçin {requirements.coinCollectAmount - ScoreController._scoreAmount} Tane Daha Skor Elde Etmen Gerekiyor!!!");
            ++notEnoughCoinCount;
        }
        else if (requirements.levelUpKeys > LevelData.currentOwnedLevelUpKeys &&
            requirements.coinCollectAmount <= ScoreController._scoreAmount &&
            requirements.enemyKills <= MainEnemyData.enemyDeathCount &&
            requirements.isBossEnemyDead && notEnoughKeyCount == 0)
        {
            ShowRequirementMessage($"You Need to Find {requirements.levelUpKeys - LevelData.currentOwnedLevelUpKeys} More Key(s)!!!",
                                   $"Bölümü Geçmek İçin {requirements.levelUpKeys - LevelData.currentOwnedLevelUpKeys} Tane Daha Anahtar Bulman Gerekiyor!!!");
            ++notEnoughKeyCount;
        }
        else if (requirements.levelUpKeys <= LevelData.currentOwnedLevelUpKeys &&
            requirements.coinCollectAmount <= ScoreController._scoreAmount &&
            requirements.enemyKills <= MainEnemyData.enemyDeathCount &&
            !requirements.isBossEnemyDead && notEnoughBossDeadCount == 0)
        {
            ShowRequirementMessage("You Need to Kill This Level's Boss Enemy",
                                   "Bölümü Geçmek İçin Bölümün Patron Düşmanını Öldürmen Gerekiyor!!!");
            ++notEnoughBossDeadCount;
        }
        else
        {
            CheckAchievements(requirements);
        }
    }

    void CheckAchievements(LevelData.LevelUpRequirements requirements)
    {
        if (requirements.coinCollectAmount <= ScoreController._scoreAmount && enoughCoinCount == 0)
        {
            ShowAchievementMessage("You Have Pretty Enough Coins!!!", "Yeterince Coinin Var!!!");
            scoreMissionCompletedImage.gameObject.SetActive(true);
            ++enoughCoinCount;
        }
        if (requirements.enemyKills <= MainEnemyData.enemyDeathCount && enoughEnemyKillsCount == 0)
        {
            ShowAchievementMessage("You Reached Pretty Enough Enemy Killing!!!", "Öldürmen Gereken Düşman Sayısına Ulaştın!!!");
            enemyKillMissionCompletedImage.gameObject.SetActive(true);
            ++enoughEnemyKillsCount;
        }
        if (requirements.levelUpKeys == LevelData.currentOwnedLevelUpKeys && enoughKeyCount == 0)
        {
            currentLevelUpKeysText.text = $"{LevelData.currentOwnedLevelUpKeys}/{requirements.levelUpKeys}";
            ShowAchievementMessage("You Found All Keys!!!", "Bütün Anahtarları Buldun!!!");
            levelUpKeyMissionCompletedImage.gameObject.SetActive(true);
            ++enoughKeyCount;
        }
        else if (requirements.levelUpKeys > LevelData.currentOwnedLevelUpKeys && currentLevelUpKeysText)
        {
            currentLevelUpKeysText.text = $"{LevelData.currentOwnedLevelUpKeys}/{requirements.levelUpKeys}";
        }
        if (requirements.isBossEnemyDead && enoughBossDeadCount == 0)
        {
            ShowAchievementMessage("This Level's Boss Enemy is Defeated By You!!!", "Bu Bölümün Patron Düşmanını Öldürdün!!!");
            ++enoughBossDeadCount;
        }
    }

    void ShowRequirementMessage(string englishMessage, string turkishMessage)
    {
        requirementMessage = playerData.currentLanguage == PlayerData.Languages.Turkish ? turkishMessage : englishMessage;
        if (PlayerManager.GetInstance)
        {
            StartCoroutine(PlayerManager.GetInstance.ShowRequirements(requirementMessage, 3));
        }
    }

    void ShowAchievementMessage(string englishMessage, string turkishMessage)
    {
        requirementMessage = playerData.currentLanguage == PlayerData.Languages.Turkish ? turkishMessage : englishMessage;
        if (PlayerManager.GetInstance)
        {
            StartCoroutine(PlayerManager.GetInstance.ShowRequirements(requirementMessage, 3));
        }
    }


    void CheckCompleteLevel()
    {
        for (int i = 0; i < levelData.levelStates.Length; i++)
        {
            if (levelData.levelStates[i].isCompleteMap)
            {
                // Set current level ID and corresponding gift box
                ++LevelData.currentLevelId;

                PlayerPrefs.SetInt("CurrentLevelID", LevelData.currentLevelId);

                bulletData.currentGiftBox = bulletData.weaponStruct[LevelData.currentLevelId].giftBox;

                // Call necessary methods for the level transition
                CheckLevelUpRequirements();
                coinSpawner.SetCoinValue(LevelData.currentLevelId);
                _sceneController.LevelUpGame();

                // Reset the completion flag
                levelData.levelStates[i].isCompleteMap = false;

                return; // Exit the loop once the level is processed
            }
        }

        // Handle the case when the last level is passed
        if (levelData.levelStates[levelData.levelStates.Length - 1].isCompleteMap)
        {
            playerData.isWinning = true;
            Invoke("DelayGoToWinScene", 5);
        }
    }


    void DelayGoToWinScene()
    {
        _sceneController.LoadWinScene();
    }
    
    public void ArrowLevelRotation(int levelID)
    {
        levelData.currentFinishArea = levelData.levelStates[levelID].finishTransform;
    }
}
