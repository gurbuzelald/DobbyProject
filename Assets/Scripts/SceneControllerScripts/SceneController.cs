using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : AbstractSceneController<SceneController>
{
    [Header("Audio Components")]
    [SerializeField] AudioSource _audioSource;

    [Header("Data")]
    public PlayerData _playerData;
    [SerializeField] PlayerCoinData playerCoinData;
    [SerializeField] LevelData levelData;
    [SerializeField] BulletData bulletData;

    private GameObject pausePanel;
    public static bool pauseGame = false;
    [HideInInspector]
    public static bool playAgain;

    [Header("RotationControl")]
    public static bool rotateTouchOrMousePos = false;

    private GameObject mouseOrTouch;
    private TextMeshProUGUI mouseOrTouchText;

    private GameObject lockWalking;
    private TextMeshProUGUI lockWalkingText;

    private TextMeshProUGUI currentLevelText;
    private TextMeshProUGUI currentWeaponText;
    private TextMeshProUGUI currentCharacterText;


    [SerializeField] GameObject levelButton;
    [SerializeField] GameObject levelsObject;
    void Start()
    {
        CreateLevelButtons();

        DefaulthVariableValues();
        SetCurrentLevelAtStart();
        SetCurrentWeaponAtStart();
        SetCurrentCharacterAtStart();
    }

    private void Update()
    {
        SetCurrentLevelAtUpdate();
        SetCurrentWeaponAtUpdate();
        SetCurrentCharacterAtUpdate();
    }

    void SetCurrentLevelAtStart()
    {
        if (GameObject.Find("CurrentLevelText"))
        {
            currentLevelText = GameObject.Find("CurrentLevelText").transform.GetComponent<TextMeshProUGUI>();

        }
        if (currentLevelText && levelData)
        {
            currentLevelText.text = levelData.currentLevel.ToString();
        }
    }
    void SetCurrentLevelAtUpdate()
    {
        if (currentLevelText && levelData)
        {
            if (levelData.isLevelUp && LevelData.levelCanBeSkipped)
            {
                currentLevelText.text = levelData.currentLevel.ToString();
                EnemyData.enemyDeathCount = 0;
            }
        }
    }

    void SetCurrentWeaponAtStart()
    {
        if (GameObject.Find("CurrentWeaponText"))
        {
            currentWeaponText = GameObject.Find("CurrentWeaponText").transform.GetComponent<TextMeshProUGUI>();

        }
        if (currentWeaponText && bulletData)
        {
            currentWeaponText.text = bulletData.currentWeaponName.ToString();
        }
    }

    void SetCurrentWeaponAtUpdate()
    {
        if (currentWeaponText && bulletData)
        {
            currentWeaponText.text = bulletData.currentWeaponName.ToString();
        }
    }

    void SetCurrentCharacterAtStart()
    {
        if (GameObject.Find("CurrentCharacterText"))
        {
            currentCharacterText = GameObject.Find("CurrentCharacterText").transform.GetComponent<TextMeshProUGUI>();

        }
        if (currentCharacterText && _playerData)
        {
            currentCharacterText.text = _playerData.currentCharacterName.ToString();
        }
    }

    void SetCurrentCharacterAtUpdate()
    {
        if (currentCharacterText && _playerData)
        {
            currentCharacterText.text = _playerData.currentCharacterName.ToString();
        }
    }

    void OnEnable()
    {
        if (pauseGame)
        {
            Time.timeScale = 0;
        }
    }
    void OnDisable()
    {
        if (!pauseGame)
        {
            Time.timeScale = 1;
        }
    }
    void FindGameObjects()
    {
        mouseOrTouch = GameObject.Find("MouseOrTouchText");
        lockWalking = GameObject.Find("LockWalkingText");
        pausePanel = GameObject.Find("PausePanel");

        if (mouseOrTouch != null && lockWalking != null && _playerData != null)
        {
            mouseOrTouchText= mouseOrTouch.GetComponent<TextMeshProUGUI>();
            lockWalkingText = lockWalking.GetComponent<TextMeshProUGUI>();
        }
    }

    void DefaulthVariableValues()
    {
        FindGameObjects();
        if (mouseOrTouchText != null && lockWalkingText != null && _playerData != null)
        {
            lockWalkingText.text = "Not Locked";
            mouseOrTouchText.text = "Touch";
            rotateTouchOrMousePos = false;
            _playerData.isLockedWalking = false;
        }
        playAgain = false;
        pauseGame = false;
    }
    public void LockWalking()
    {
        if (_playerData.isLockedWalking)
        {
            _playerData.isLockedWalking = false;

            lockWalkingText.text = "Not Locked";
        }
        else
        {
            _playerData.isLockedWalking = true;

            lockWalkingText.text = "Locked";
        }
    }
    public void LevelUpGame()
    {
        playAgain = true;

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Game.ToString());
    }
    public void PlayAgain()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        levelData.currentLevel = LevelData.Levels.Level1;

        playAgain = true;

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Game.ToString());

        DecreaseWeaponUsageLimit();
    }
    void DecreaseWeaponUsageLimit()
    {
        if (bulletData.currentWeaponName == BulletData.axe && bulletData.axeUsageLimit > 0)
        {
            bulletData.axeUsageLimit -= 1;
        }
        else if(bulletData.currentWeaponName == BulletData.axe && bulletData.axeUsageLimit == 0)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }

        if (bulletData.currentWeaponName == BulletData.bulldog && bulletData.bulldogUsageLimit > 0)
        {
            bulletData.bulldogUsageLimit -= 1;
        }
        else if (bulletData.currentWeaponName == BulletData.bulldog && bulletData.bulldogUsageLimit == 0)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }

        if (bulletData.currentWeaponName == BulletData.cow && bulletData.cowUsageLimit > 0)
        {
            bulletData.cowUsageLimit -= 1;
        }
        else if (bulletData.currentWeaponName == BulletData.cow && bulletData.cowUsageLimit == 0)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }

        if (bulletData.currentWeaponName == BulletData.crystal && bulletData.crystalUsageLimit > 0)
        {
            bulletData.crystalUsageLimit -= 1;
        }
        else if (bulletData.currentWeaponName == BulletData.crystal && bulletData.crystalUsageLimit == 0)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }

        if (bulletData.currentWeaponName == BulletData.demon && bulletData.demonUsageLimit > 0)
        {
            bulletData.demonUsageLimit -= 1;
        }
        else if (bulletData.currentWeaponName == BulletData.demon && bulletData.demonUsageLimit == 0)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }

        if (bulletData.currentWeaponName == BulletData.ice && bulletData.iceUsageLimit > 0)
        {
            bulletData.iceUsageLimit -= 1;
        }
        else if (bulletData.currentWeaponName == BulletData.ice && bulletData.iceUsageLimit == 0)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }

        if (bulletData.currentWeaponName == BulletData.electro && bulletData.electroUsageLimit > 0)
        {
            bulletData.electroUsageLimit -= 1;
        }
        else if (bulletData.currentWeaponName == BulletData.electro && bulletData.electroUsageLimit == 0)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }

        if (bulletData.currentWeaponName == BulletData.ak47 && bulletData.ak47UsageLimit > 0)
        {
            bulletData.ak47UsageLimit -= 1;
        }
        else if (bulletData.currentWeaponName == BulletData.ak47 && bulletData.ak47UsageLimit == 0)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }

        if (bulletData.currentWeaponName == BulletData.m4a4 && bulletData.m4a4UsageLimit > 0)
        {
            bulletData.m4a4UsageLimit -= 1;
        }
        else if (bulletData.currentWeaponName == BulletData.m4a4 && bulletData.m4a4UsageLimit == 0)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }
    }
    public void PlayAgainInLevel()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        playAgain = true;

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Game.ToString());

        DecreaseWeaponUsageLimit();
    }
    public void ContinueLastLevel()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        playAgain = true;

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Game.ToString());

        DecreaseWeaponUsageLimit();
    }

    void CreateLevelButtons()
    {
        if (levelData && CheckSceneName() == Scenes.Levels.ToString())
        {
            for(int i = 0; i < GetCurrentLevelID(levelData) + 1; i++)
            {
                GameObject levelButtonObject = Instantiate(levelButton, new Vector3(levelButton.transform.localPosition.x,
                    levelButton.transform.localPosition.y,
                    levelButton.transform.localPosition.z),
                    Quaternion.identity, levelsObject.transform);
                if (i < 5)
                {
                    levelButtonObject.transform.localPosition = new Vector3(-800 + 400 * i, 250, 0);
                }
                else if (i >= 5)
                {
                    levelButtonObject.transform.localPosition = new Vector3(2800 - 400 * i, -100, 0);
                }

                levelButtonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level " + (i + 1).ToString();
            }
        }
    }

    public void OpenCurrentLevel()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        playAgain = true;

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Game.ToString());

        DecreaseWeaponUsageLimit();
    }

    public void LoadLevelsScene()
    {
        DestroySingletonObjects();
        SceneManager.LoadScene(Scenes.Levels.ToString());
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




    public string CheckSceneName()
    {
        string _sceneName = SceneManager.GetActiveScene().name;
        return _sceneName;
    }
    public void LoadMenuScene()
    {//Load By Click Menu Scene

        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        if (CheckSceneName() != Scenes.End.ToString())
        {
            playAgain = true;
        }

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Menu.ToString());

    }

    public void LoadByCodeMenuScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        levelData.currentLevel = LevelData.Levels.Level1;

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Menu.ToString());

    }
    public void LoadMenuSceneByWinScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Menu.ToString());
    }

    public void LoadWinScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        //levelData.currentLevel = LevelData.Levels.Level1;

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Win.ToString());
    }
    public void LoadCharacterChoosingScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.PickCharacter.ToString());
    }
    public void LoadSwordChoosingScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.PickSword.ToString());
    }
    public void LoadWeaponChoosingScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.PickWeapon.ToString());
    }
    public void LoadEndScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.End.ToString());
    }
    void DestroySingletonObjects()
    {
        if (PlayerManager.GetInstance.gameObject != null)
        {
            Destroy(AudioManager.GetInstance.gameObject);
            Destroy(PlayerManager.GetInstance.gameObject);
        }
    }
    public void PauseGame()
    {
        if (pauseGame) {

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            GameObject.Find("Look").transform.localScale = Vector3.one;
            //_lookStick.transform.localScale = Vector3.one;
            pauseGame = false;
            pausePanel.transform.localScale = Vector3.zero;
            _playerData.isPlayable = true;
        }
        else if (!pauseGame) {

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            GameObject.Find("Look").transform.localScale = Vector3.zero;

            //_lookStick.transform.localScale = Vector3.zero;
            pauseGame = true;
            pausePanel.transform.localScale = Vector3.one;
            _playerData.isPlayable = false;

        }
    }
    public void ControlRotate()
    {
        if (rotateTouchOrMousePos == true)
        {
            mouseOrTouchText.text = "Touch";

            rotateTouchOrMousePos = false;
        }
        else
        {
            mouseOrTouchText.text = "Mouse";

            rotateTouchOrMousePos = true;
        }
    }
    public void LevelUp()
    {
        if (SceneManager.sceneCountInBuildSettings - 3 == SceneManager.GetActiveScene().buildIndex)
        {
            LoadWinScene();
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        Destroy(PlayerManager.GetInstance.gameObject);
        
    }
    public void QuitGame()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        PlayerManager.GetInstance._bulletData.currentWeaponName = BulletData.ak47;
        PlayerManager.GetInstance._bulletData.currentSwordName = BulletData.lowSword;

        Application.Quit();
    }
    public enum Tags
    {
        Ground,
        Bridge,
        Ladder,
        Enemy,
        Bullet,
        Sword,
        Player,
        Water,
        FanceWooden,
        LevelUpKey,
        

        Tree,

        //Coins
        Coin,
        CheeseCoin,
        RotateCoin,
        HealthCoin,
        MushroomCoin,
        BulletCoin,

        Magnet,
        Magma,
        Lava,
        FirstTarget,
        MainTarget,
        EnemyBullet, 
        CloneDobby,

        //Weapons
        m4a4,
        ak47,
        bulldog,
        cow,
        crystal,
        demon,
        ice,
        electro,
        axe,
        pistol,
        WeaponBox,

        //Speed
        NormalSpeed,
        ExtraSpeed
    }
    public enum Scenes
    {
        Menu, End, Win, Game, PickCharacter, PickSword, PickWeapon, Levels
    }
}
