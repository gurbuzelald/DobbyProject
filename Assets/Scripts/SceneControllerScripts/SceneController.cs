using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
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


    [SerializeField] GameObject[] levelButtons;
    [SerializeField] GameObject levelsObject;

    public static float buttonTimer;


    TextMeshProUGUI[] currentTexts = new TextMeshProUGUI[200];

    private GameObject menuMap;

    private void Awake()
    {
        SetCurrentLevelCount();
    }


    void Start()
    {
        CreateMenuMap();

        ChangeLanguage();
        OpenLevelButtons();

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

        buttonTimer += Time.deltaTime;
    }

    void CreateMenuMap()
    {
        if (CheckSceneName() != Scenes.Game.ToString() && CheckSceneName() != Scenes.PickCharacter.ToString() &&
            CheckSceneName() != Scenes.PickWeapon.ToString())
        {
            if (_playerData)
            {
                if (_playerData.menuMap)
                {
                    menuMap = Instantiate(_playerData.menuMap);
                }
            }
        }
        if (CheckSceneName() == Scenes.PickCharacter.ToString() ||
            CheckSceneName() == Scenes.PickWeapon.ToString())
        {
            if (_playerData)
            {
                if (_playerData.menuMap)
                {
                    menuMap = Instantiate(_playerData.menuMap);
                    menuMap.transform.position = new Vector3(menuMap.transform.position.x,
                                                             menuMap.transform.position.y,
                                                             -100);
                }
            }
        }
    }



    #region Change Language Functions

    public void ClickChangeLanguageButton()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        if (_playerData.currentLanguage == PlayerData.Languages.Turkish)
        {
            _playerData.currentLanguage = PlayerData.Languages.English;
        }
        else
        {
            _playerData.currentLanguage = PlayerData.Languages.Turkish;
        }
        ChangeLanguage();
    }

    public void ChangeLanguage()
    {
        if (_playerData)
        {
            currentTexts = FindObjectsOfType<TextMeshProUGUI>();
            ChangeMenuSceneLanguage();

            ChangeGameSceneLanguage();

            ChangeEndSceneLanguage();

            ChangeWinSceneLanguage();

            ChangePickCharacterSceneLanguage();

            ChangePickWeaponSceneLanguage();
        }
        
    }

    void ChangeMenuSceneLanguage()
    {
        if (Scenes.Menu.ToString() == CheckSceneName() && _playerData.currentLanguage == PlayerData.Languages.Turkish)
        {
            foreach (var currentText in currentTexts)
            {
                switch (currentText.text)
                {
                    case "Türkçe":
                        currentText.text = "English";
                        continue;
                    case "Game :":
                        currentText.text = "Oyun :";
                        continue;
                    case "Level 1":
                        currentText.text = "Bölüm 1";
                        continue;
                    case "Pick Character":
                        currentText.text = "Karakter Seç";
                        continue;
                    case "Pick Weapon":
                        currentText.text = "Silah Seç";
                        continue;
                    case "Avaliable Coin":
                        currentText.text = "Mevcut Coinler";
                        continue;
                    case "Coins":
                        currentText.text = "Coinler";
                        continue;
                    case "Default":
                        currentText.text = "Varsayılan";
                        continue;
                    case "X Sensivity :":
                        currentText.text = "Yatay Yön Hassasiyeti :";
                        continue;
                    case "Y Sensivity :":
                        currentText.text = "Dikey Yön Hassasiyeti :";
                        continue;
                    case "Play":
                        currentText.text = "Oyna";
                        continue;
                    case "Levels":
                        currentText.text = "Bölümler";
                        continue;
                    case "Quit":
                        currentText.text = "Çıkış";
                        continue;
                    case "Settings":
                        currentText.text = "Ayarlar";
                        continue;
                    case "Game":
                        currentText.text = "Oyun";
                        continue;
                    case "Player Sound Effects :":
                        currentText.text = "Oyuncu Ses Efekti :";
                        continue;
                    case "Enemy Sound Effects :":
                        currentText.text = "Düşman Ses Efekti :";
                        continue;
                    case "Menu Sound Effects :":
                        currentText.text = "Menü Ses Efekti :";
                        continue;
                }
            }
        }
        else if (Scenes.Menu.ToString() == CheckSceneName() && _playerData.currentLanguage == PlayerData.Languages.English)
        {
            foreach (var currentText in currentTexts)
            {
                switch (currentText.text)
                {
                    case "English":
                        currentText.text = "Türkçe";
                        continue;
                    case "Oyun :":
                        currentText.text = "Game :";
                        continue;
                    case "Bölüm 1":
                        currentText.text = "Level 1";
                        continue;
                    case "Karakter Seç":
                        currentText.text = "Pick Character";
                        continue;
                    case "Silah Seç":
                        currentText.text = "Pick Weapon";
                        continue;
                    case "Mevcut Coinler":
                        currentText.text = "Avaliable Coin";
                        continue;
                    case "Coinler":
                        currentText.text = "Coins";
                        continue;
                    case "Varsayılan":
                        currentText.text = "Default";
                        continue;
                    case "Yatay Yön Hassasiyeti :":
                        currentText.text = "X Sensivity :";
                        continue;
                    case "Dikey Yön Hassasiyeti :":
                        currentText.text = "X Sensivity :";
                        continue;
                    case "Oyna":
                        currentText.text = "Play";
                        continue;
                    case "Bölümler":
                        currentText.text = "Levels";
                        continue;
                    case "Çıkış":
                        currentText.text = "Quit";
                        continue;
                    case "Ayarlar":
                        currentText.text = "Settings";
                        continue;
                    case "Oyun":
                        currentText.text = "Game";
                        continue;
                    case "Oyuncu Ses Efekti :":
                        currentText.text = "Player Sound Effects :";
                        continue;
                    case "Düşman Ses Efekti :":
                        currentText.text = "Enemy Sound Effects :";
                        continue;
                    case "Menü Ses Efekti :":
                        currentText.text = "Menu Sound Effects :";
                        continue;
                }
            }
        }
    }

    void ChangeGameSceneLanguage()
    {
        if (Scenes.Game.ToString() == CheckSceneName() && _playerData.currentLanguage == PlayerData.Languages.Turkish)
        {
            foreach (var currentText in currentTexts)
            {
                switch (currentText.text)
                {
                    case "Health":
                        currentText.text = "Sağlık";
                        continue;
                    case "Teleporter":
                        currentText.text = "Işinlayici";
                        continue;
                    case "Resume":
                        currentText.text = "Devam";
                        continue;
                    case "Active":
                        currentText.text = "Aktif";
                        continue;
                    case "Sword":
                        currentText.text = "Kılıç";
                        continue;
                    case "Faster":
                        currentText.text = "Daha Hızlı";
                        continue;
                    case "Jump":
                        currentText.text = "Zıpla";
                        continue;
                    case "Shoot":
                        currentText.text = "Ateş Et";
                        continue;
                    case "Keys:":
                        currentText.text = "Anahtarlar:";
                        continue;
                    case "Kills:":
                        currentText.text = "Öldürmeler:";
                        continue;
                    case "Level1":
                        currentText.text = "Bölüm 1";
                        continue;
                    case "Level2":
                        currentText.text = "Bölüm 2";
                        continue;
                    case "Level3":
                        currentText.text = "Bölüm 3";
                        continue;
                    case "Level4":
                        currentText.text = "Bölüm 4";
                        continue;
                    case "Level5":
                        currentText.text = "Bölüm 5";
                        continue;
                    case "Level6":
                        currentText.text = "Bölüm 6";
                        continue;
                    case "Level7":
                        currentText.text = "Böülüm 7";
                        continue;
                    case "Level8":
                        currentText.text = "Bölüm 8";
                        continue;
                    case "Level9":
                        currentText.text = "Bölüm 9";
                        continue;
                    case "Level10":
                        currentText.text = "Bölüm 10";
                        continue;
                    case "Avaliable Coin":
                        currentText.text = "Mevcut Coinler";
                        continue;
                    case "Score :":
                        currentText.text = "Skor :";
                        continue;
                    case "Time : ":
                        currentText.text = "Zaman:";
                        continue;
                    case "X Sensivity :":
                        currentText.text = "Yatay Hassasiyet :";
                        continue;
                    case "Y Sensivity :":
                        currentText.text = "Dikey Hassasiyet :";
                        continue;
                    case "Player Sound Effects :":
                        currentText.text = "Oyuncu Ses Efekti";
                        continue;
                    case "Enemy Sound Effects :":
                        currentText.text = "Düşman Ses Efekti";
                        continue;
                    case "Menu Sound Effects :":
                        currentText.text = "Menü Ses Efekti";
                        continue;
                    case "Default":
                        currentText.text = "Varsayılan";
                        continue;
                    case "Game :":
                        currentText.text = "Oyun : ";
                        continue;
                    case "Menu":
                        currentText.text = "Menü";
                        continue;
                }
            }
        }
    }

    void ChangeEndSceneLanguage()
    {
        if (Scenes.End.ToString() == CheckSceneName() && _playerData.currentLanguage == PlayerData.Languages.Turkish)
        {
            foreach (var currentText in currentTexts)
            {
                switch (currentText.text)
                {
                    case "You Lost!! Maybe You need a better Character or Weapon!!":
                        currentText.text = "Kaybettin!!! Belki Daha İyi Bir Karaktere ya da Silaha İhtiyacın Var!!!";
                        continue;
                    case "Quit":
                        currentText.text = "Çıkış";
                        continue;
                    case "Menu":
                        currentText.text = "Menü";
                        continue;
                    case "Avaliable Coins:":
                        currentText.text = "Mevcut Coinler:";
                        continue;
                    case "Or Go to Menu and Keep On Adventuring!!":
                        currentText.text = "Ya da Menüye Git ve Macerada Kal!!!";
                        continue;
                    case "Maybe You Need A Better Character Or Weapon!!!":
                        currentText.text = "Belki Daha İyi Bir Karaktere ya da Silaha İhtiyacın Var!!!";
                        continue;
                    case "Game Coins:":
                        currentText.text = "Oyun Coinleri:";
                        continue;
                    case "Let's Start From The Beginning!":
                        currentText.text = "Hadi En Baştan Başlayalım!!!";
                        continue;
                    case "Play":
                        currentText.text = "Oyna";
                        continue;
                    case "Levels":
                        currentText.text = "Bölümler";
                        continue;
                    case "Settings":
                        currentText.text = "Ayarlar";
                        continue;
                    case "Game":
                        currentText.text = "Oyun";
                        continue;
                    case "Player Sound Effects :":
                        currentText.text = "Oyuncu Ses Efekti :";
                        continue;
                    case "Enemy Sound Effects :":
                        currentText.text = "Düşman Ses Efekti :";
                        continue;
                    case "Menu Sound Effects :":
                        currentText.text = "Menü Ses Efekti :";
                        continue;
                }
            }
        }
    }

    void ChangeWinSceneLanguage()
    {
        if (Scenes.Win.ToString() == CheckSceneName() && _playerData.currentLanguage == PlayerData.Languages.Turkish)
        {            
            foreach (var currentText in currentTexts)
            {
                switch (currentText.text)
                {
                    case "You Won!!":
                        currentText.text = "Kazandın!!!";
                        continue;
                    case "Quit":
                        currentText.text = "Çıkış";
                        continue;
                    case "Congratulations!!!":
                        currentText.text = "Tebrikler!!!";
                        continue;
                    case "Go To Menu      or":
                        currentText.text = "Menüye Git ya da";
                        continue;
                    case "Play Again":
                        currentText.text = "Tekrar Oyna";
                        continue;
                    case "Avaliable Coin:":
                        currentText.text = "Mevcut Coin:";
                        continue;
                    case "Maybe You Need A Better Character Or Weapon!!!":
                        currentText.text = "Belki Daha İyi Bir Karaktere ya da Silaha İhtiyacın Var!!!";
                        continue;
                    case "Game Coins:":
                        currentText.text = "Oyun Coinleri:";
                        continue;
                    case "Menu":
                        currentText.text = "Menü";
                        continue;
                    case "Score:":
                        currentText.text = "Skor:";
                        continue;                    
                }
            }
        }
    }

    void ChangePickCharacterSceneLanguage()
    {
        if (Scenes.PickCharacter.ToString() == CheckSceneName() && _playerData.currentLanguage == PlayerData.Languages.Turkish)
        {
            foreach (var currentText in currentTexts)
            {
                switch (currentText.text)
                {
                    case "Locked":
                        currentText.text = "Kilitli";
                        continue;
                    case "Menu":
                        currentText.text = "Menü";
                        continue;
                    case "Choose Weapon":
                        currentText.text = "Silah Seç";
                        continue;
                    case "Speed:":
                        currentText.text = "Hız:";
                        continue;
                    case "Jump Force:":
                        currentText.text = "Zıplama Gücü:";
                        continue;
                    case "Durability:":
                        currentText.text = "Dayanıklılık:";
                        continue;
                    case "Game Coins:":
                        currentText.text = "Oyun Paraları:";
                        continue;
                    case "Score:":
                        currentText.text = "Skor:";
                        continue;
                }
            }
        }
    }

    void ChangePickWeaponSceneLanguage()
    {
        if (Scenes.PickWeapon.ToString() == CheckSceneName() && _playerData.currentLanguage == PlayerData.Languages.Turkish)
        {
            foreach (var currentText in currentTexts)
            {
                switch (currentText.text)
                {
                    case "locked":
                        currentText.text = "Kilitli";
                        continue;
                    case "Pick Character":
                        currentText.text = "Karakter Seç";
                        continue;
                    case "Strength:":
                        currentText.text = "Silah Kuvveti:";
                        continue;
                    case "Menu:":
                        currentText.text = "Menü:";
                        continue;
                    case "Avaliable Coin:":
                        currentText.text = "Mevcut Coinler:";
                        continue;
                    case "Game Coins:":
                        currentText.text = "Oyun Paraları:";
                        continue;
                    case "Score:":
                        currentText.text = "Skor:";
                        continue;
                }
            }
        }
    }
    #endregion


    public void CheckNeedResetWeaponsAndCharacters()
    {//For Developer

        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        PlayerPrefs.GetInt("ResetGame", 1);


        PlayerPrefs.SetFloat("PistolLock", 0);
        PlayerPrefs.SetFloat("AxeLock", 0);
        PlayerPrefs.SetFloat("BulldogLock", 0);
        PlayerPrefs.SetFloat("CowLock", 0);
        PlayerPrefs.SetFloat("CrystalLock", 0);
        PlayerPrefs.SetFloat("DemonLock", 0);
        PlayerPrefs.SetFloat("IceLock", 0);
        PlayerPrefs.SetFloat("ElectroLock", 0);
        PlayerPrefs.SetFloat("Ak47Lock", 0);
        PlayerPrefs.SetFloat("M4A4Lock", 0);

        PlayerPrefs.SetFloat("AxeUsageCount", 0);
        PlayerPrefs.SetFloat("BulldogUsageCount", 0);
        PlayerPrefs.SetFloat("CowUsageCount", 0);
        PlayerPrefs.SetFloat("CrystalUsageCount", 0);
        PlayerPrefs.SetFloat("DemonUsageCount", 0);
        PlayerPrefs.SetFloat("IceUsageCount", 0);
        PlayerPrefs.SetFloat("ElectroUsageCount", 0);
        PlayerPrefs.SetFloat("Ak47UsageCount", 0);
        PlayerPrefs.SetFloat("M4A4UsageCount", 0);

        if (bulletData)
        {
            bulletData.axeLock = BulletData.locked;
            bulletData.bulldogLock = BulletData.locked;
            bulletData.cowLock = BulletData.locked;
            bulletData.crystalLock = BulletData.locked;
            bulletData.demonLock = BulletData.locked;
            bulletData.iceLock = BulletData.locked;
            bulletData.electroLock = BulletData.locked;
            bulletData.ak47Lock = BulletData.locked;
            bulletData.m4a4Lock = BulletData.locked;
        }
        PlayerPrefs.SetFloat("DobbyLock", 0);
        PlayerPrefs.SetFloat("JoleenLock", 0);
        PlayerPrefs.SetFloat("GlassyLock", 0);
        PlayerPrefs.SetFloat("LusthLock", 0);
        PlayerPrefs.SetFloat("GuardLock", 0);
        PlayerPrefs.SetFloat("MichelleLock", 0);
        PlayerPrefs.SetFloat("EveLock", 0);
        PlayerPrefs.SetFloat("AjLock", 0);
        PlayerPrefs.SetFloat("BossLock", 0);
        PlayerPrefs.SetFloat("TyLock", 0);
        PlayerPrefs.SetFloat("MremirehLock", 0);


        PlayerPrefs.SetInt("AxeUsageCount", 0);
        PlayerPrefs.SetInt("BulldogUsageCount", 0);
        PlayerPrefs.SetInt("CowUsageCount", 0);
        PlayerPrefs.SetInt("CrystalUsageCount", 0);
        PlayerPrefs.SetInt("DemonUsageCount", 0);
        PlayerPrefs.SetInt("IceUsageCount", 0);
        PlayerPrefs.SetInt("NegevUsageCount", 0);
        PlayerPrefs.SetInt("Ak47UsageCount", 0);
        PlayerPrefs.SetInt("M4A4UsageCount", 0);

        if (_playerData)
        {
            _playerData.joleenLock = _playerData.locked;
            _playerData.lusthLock = _playerData.locked;
            _playerData.guardLock = _playerData.locked;
            _playerData.michelleLock = _playerData.locked;
            _playerData.eveLock = _playerData.locked;
            _playerData.ajLock = _playerData.locked;
            _playerData.bossLock = _playerData.locked;
            _playerData.tyLock = _playerData.locked;
            _playerData.mremirehLock = _playerData.locked;
            _playerData.glassyLock = _playerData.locked;


            _playerData.currentCharacterName = PlayerData.CharacterNames.Dobby;
        }


        PlayerPrefs.SetInt("AvaliableCoin", 0);

        if (levelData)
        {
            levelData.currentLevel = LevelData.Levels.Level1;
        }

        LevelData.highestLevel = 0;
        PlayerPrefs.SetInt("HighestLevel", 0);
        LevelData.currentLevelCount = 0;
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
        if (pausePanel)
        {
            pausePanel.transform.localPosition = new Vector3(5000,
                                                             pausePanel.transform.localPosition.y,
                                                             pausePanel.transform.localPosition.z);
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

        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
    }
    public void PlayAgain()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        levelData.currentLevel = LevelData.Levels.Level1;

        
        DestroySingletonObjects();
        if (levelData.currentLevel == LevelData.Levels.Level1)
        {
            LevelData.currentLevelCount = 0;
            playAgain = true;

            SceneManager.LoadScene(Scenes.Game.ToString());

            DecreaseWeaponUsageLimit();
        }
        
    }
    public void DecreaseWeaponUsageLimit()
    {
        if (bulletData)
        {
            if (bulletData.currentWeaponName == BulletData.axe && bulletData.axeUsageLimit > 0)
            {
                --bulletData.axeUsageLimit;
                PlayerPrefs.SetInt("AxeUsageCount", bulletData.axeUsageLimit);
            }
            else if (bulletData.currentWeaponName == BulletData.axe && bulletData.axeUsageLimit == 0)
            {
                bulletData.currentWeaponName = BulletData.pistol;
            }

            if (bulletData.currentWeaponName == BulletData.bulldog && bulletData.bulldogUsageLimit > 0)
            {
                --bulletData.bulldogUsageLimit;
                PlayerPrefs.SetInt("BulldogUsageCount", bulletData.bulldogUsageLimit);
            }
            else if (bulletData.currentWeaponName == BulletData.bulldog && bulletData.bulldogUsageLimit == 0)
            {
                bulletData.currentWeaponName = BulletData.pistol;
            }

            if (bulletData.currentWeaponName == BulletData.cow && bulletData.cowUsageLimit > 0)
            {
                --bulletData.cowUsageLimit;
                PlayerPrefs.SetInt("CowUsageCount", bulletData.cowUsageLimit);
            }
            else if (bulletData.currentWeaponName == BulletData.cow && bulletData.cowUsageLimit == 0)
            {
                bulletData.currentWeaponName = BulletData.pistol;
            }

            if (bulletData.currentWeaponName == BulletData.crystal && bulletData.crystalUsageLimit > 0)
            {
                --bulletData.crystalUsageLimit;
                PlayerPrefs.SetInt("CrystalUsageCount", bulletData.crystalUsageLimit);
            }
            else if (bulletData.currentWeaponName == BulletData.crystal && bulletData.crystalUsageLimit == 0)
            {
                bulletData.currentWeaponName = BulletData.pistol;
            }

            if (bulletData.currentWeaponName == BulletData.demon && bulletData.demonUsageLimit > 0)
            {
                --bulletData.demonUsageLimit;
                PlayerPrefs.SetInt("DemonUsageCount", bulletData.demonUsageLimit);
            }
            else if (bulletData.currentWeaponName == BulletData.demon && bulletData.demonUsageLimit == 0)
            {
                bulletData.currentWeaponName = BulletData.pistol;
            }

            if (bulletData.currentWeaponName == BulletData.ice && bulletData.iceUsageLimit > 0)
            {
                --bulletData.iceUsageLimit;
                PlayerPrefs.SetInt("IceUsageCount", bulletData.iceUsageLimit);
            }
            else if (bulletData.currentWeaponName == BulletData.ice && bulletData.iceUsageLimit == 0)
            {
                bulletData.currentWeaponName = BulletData.pistol;
            }

            if (bulletData.currentWeaponName == BulletData.electro && bulletData.electroUsageLimit > 0)
            {
                --bulletData.electroUsageLimit;
                PlayerPrefs.SetInt("ElectroUsageCount", bulletData.electroUsageLimit);
            }
            else if (bulletData.currentWeaponName == BulletData.electro && bulletData.electroUsageLimit == 0)
            {
                bulletData.currentWeaponName = BulletData.pistol;
            }

            if (bulletData.currentWeaponName == BulletData.ak47 && bulletData.ak47UsageLimit > 0)
            {
                --bulletData.ak47UsageLimit;
                PlayerPrefs.SetInt("Ak47UsageCount", bulletData.ak47UsageLimit);
            }
            else if (bulletData.currentWeaponName == BulletData.ak47 && bulletData.ak47UsageLimit == 0)
            {
                bulletData.currentWeaponName = BulletData.pistol;
            }

            if (bulletData.currentWeaponName == BulletData.m4a4 && bulletData.m4a4UsageLimit > 0)
            {
                --bulletData.m4a4UsageLimit;
                PlayerPrefs.SetInt("M4A4UsageCount", bulletData.m4a4UsageLimit);
            }
            else if (bulletData.currentWeaponName == BulletData.m4a4 && bulletData.m4a4UsageLimit == 0)
            {
                bulletData.currentWeaponName = BulletData.pistol;
            }
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

        SetCurrentLevelCount();

        SceneManager.LoadScene(Scenes.Game.ToString());

        DecreaseWeaponUsageLimit();
    }

    void SetCurrentLevelCount()
    {
        if (levelData.currentLevel == LevelData.Levels.Level1)
        {
            LevelData.currentLevelCount = 0;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level2)
        {
            LevelData.currentLevelCount = 1;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level3)
        {
            LevelData.currentLevelCount = 2;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level4)
        {
            LevelData.currentLevelCount = 3;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level5)
        {
            LevelData.currentLevelCount = 4;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level6)
        {
            LevelData.currentLevelCount = 5;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level7)
        {
            LevelData.currentLevelCount = 6;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level8)
        {
            LevelData.currentLevelCount = 7;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level9)
        {
            LevelData.currentLevelCount = 8;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level10)
        {
            LevelData.currentLevelCount = 9;
        }
    }

    

    void SetHighestLevel()
    {
        if (levelData)
        {
            if ((PlayerPrefs.GetInt("ResetGame") == 1))
            {
                PlayerPrefs.SetInt("HighestLevel", 0);
                LevelData.highestLevel = 0;
                PlayerPrefs.SetInt("ResetGame", 0);
            }
            else if (LevelData.currentLevelCount == 0)
            {
                if (PlayerPrefs.GetInt("HighestLevel") == 0)
                {
                    LevelData.highestLevel = 0;
                    PlayerPrefs.SetInt("HighestLevel", 0);
                }                
            }
            else if (LevelData.currentLevelCount == 1)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 1)
                {
                    LevelData.highestLevel = 1;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelCount == 2)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 2)
                {
                    LevelData.highestLevel = 2;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelCount == 3)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 3)
                {
                    LevelData.highestLevel = 3;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelCount == 4)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 4)
                {
                    LevelData.highestLevel = 4;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelCount == 5)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 5)
                {
                    LevelData.highestLevel = 5;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelCount == 6)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 6)
                {
                    LevelData.highestLevel = 6;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelCount == 7)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 7)
                {
                    LevelData.highestLevel = 7;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelCount == 8)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 8)
                {
                    LevelData.highestLevel = 8;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelCount == 9)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 9)
                {
                    LevelData.highestLevel = 9;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelCount == 10)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 10)
                {
                    LevelData.highestLevel = 10;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
        }

    }

    void OpenLevelButtons()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        SetHighestLevel();
        if (levelData && CheckSceneName() == Scenes.Levels.ToString() && levelsObject)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("HighestLevel") + 1; i++)
            {
                levelButtons[i].SetActive(true);

                if (PlayerData.Languages.Turkish == _playerData.currentLanguage)
                {
                    levelButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Bölüm " + (i + 1).ToString();
                }
                else
                {
                    levelButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level " + (i + 1).ToString();
                }                
            }
        }
    }


    public void LoadLevelsScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();
        SceneManager.LoadScene(Scenes.Levels.ToString());
    }

    public static string CheckSceneName()
    {
        string _sceneName = SceneManager.GetActiveScene().name;
        return _sceneName;
    }

    public static void LoadMenuScene()
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
    public static void LoadMenuSceneByWinScene()
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
    public static void LoadCharacterChoosingScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.PickCharacter.ToString());
    }
    public void LoadWeaponChoosingScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.PickWeapon.ToString());
    }
    public static void LoadEndScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.End.ToString());
    }
    public static void DestroySingletonObjects()
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
            pausePanel.transform.localPosition = new Vector3(5000,
                                                             pausePanel.transform.localPosition.y,
                                                             pausePanel.transform.localPosition.z);
            _playerData.isPlayable = true;
        }
        else if (!pauseGame) {

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            GameObject.Find("Look").transform.localScale = Vector3.zero;

            //_lookStick.transform.localScale = Vector3.zero;
            pauseGame = true;
            pausePanel.transform.localPosition = new Vector3(0,
                                                             pausePanel.transform.localPosition.y,
                                                             pausePanel.transform.localPosition.z);
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
