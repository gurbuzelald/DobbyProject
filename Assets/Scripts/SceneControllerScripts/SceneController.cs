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
    public static bool playAgainForScore;

    [Header("RotationControl")]
    public static bool rotateTouchOrMousePos = false;

    private TextMeshProUGUI currentLevelText;
    private TextMeshProUGUI currentWeaponText;
    private TextMeshProUGUI currentCharacterText;


    [SerializeField] GameObject[] levelButtons;
    [SerializeField] GameObject levelsObject;

    public static float buttonTimer;


    TextMeshProUGUI[] currentTexts = new TextMeshProUGUI[200];
    private void Awake()
    {
        pauseGame = false;//Important for passing Game Scene to Menu Scene

        PlayerData.currentCharacterID = PlayerPrefs.GetInt("CurrentCharacterID");
        BulletData.currentWeaponID = PlayerPrefs.GetInt("CurrentWeaponID");

        bulletData.currentWeaponName = bulletData?.weaponStruct[BulletData.currentWeaponID].weaponName;
    }

    void Start()
    {
        AudioManager.GetInstance.SetCurrentMusic();
        ChangeLanguage();
        OpenLevelButtons();

        DefaulthVariableValues();
        SetCurrentLevelAtStart();
        SetCurrentWeaponAtStart();
        SetCurrentCharacterAtStart();

        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
    }

    private void Update()
    {
        SetCurrentWeaponAtUpdate();

        buttonTimer += Time.deltaTime;
    }



    #region Change Language Functions

    public void ClickChangeLanguageButton()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        if (PlayerData.currentLanguage == PlayerData.Languages.Turkish)
        {
            PlayerData.currentLanguage = PlayerData.Languages.English;
        }
        else
        {
            PlayerData.currentLanguage = PlayerData.Languages.Turkish;
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
        if (Scenes.Menu.ToString() == CheckSceneName() && PlayerData.currentLanguage == PlayerData.Languages.Turkish)
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
                    case "Sifirla":
                        currentText.text = "Rest Game";
                        continue;
                }
            }
        }
        else if (Scenes.Menu.ToString() == CheckSceneName() && PlayerData.currentLanguage == PlayerData.Languages.English)
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
                    case "Reset Game":
                        currentText.text = "Sifirla";
                        continue;
                }
            }
        }
    }

    void ChangeGameSceneLanguage()
    {
        if (Scenes.Game.ToString() == CheckSceneName() && PlayerData.currentLanguage == PlayerData.Languages.Turkish)
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
        if (Scenes.End.ToString() == CheckSceneName() && PlayerData.currentLanguage == PlayerData.Languages.Turkish)
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
        if (Scenes.Win.ToString() == CheckSceneName() && PlayerData.currentLanguage == PlayerData.Languages.Turkish)
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
        if (Scenes.PickCharacter.ToString() == CheckSceneName() && PlayerData.currentLanguage == PlayerData.Languages.Turkish)
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
        if (Scenes.PickWeapon.ToString() == CheckSceneName() && PlayerData.currentLanguage == PlayerData.Languages.Turkish)
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
    {
        // For Developer
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        PlayerPrefs.SetInt("ResetGame", 1);

        // Reset all weapon lock and usage count data
        for (int i = 1; i <= 9; i++)
        {
            var weaponName = bulletData.weaponStruct[i].weaponName;
            PlayerPrefs.SetFloat($"{weaponName}Lock", 0);
            PlayerPrefs.SetInt($"{weaponName}UsageCount", 0);
            bulletData.weaponStruct[i].lockState = BulletData.locked;
        }

        // Reset any other lock flags (A-K)
        char[] lockFlags = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K' };
        foreach (var flag in lockFlags)
        {
            PlayerPrefs.SetFloat($"{flag}Lock", 0);
        }

        // Reset character lock states
        if (_playerData)
        {
            for (int i = 1; i <= 10; i++)
            {
                _playerData.characterStruct[i].lockState = PlayerData.locked;
            }
            PlayerData.currentCharacterID = _playerData.characterStruct[0].id;
        }

        // Reset other game data
        PlayerPrefs.SetInt("AvaliableCoin", 0);
        LevelData.currentLevelId = 0;
        LevelData.highestLevel = 0;
        PlayerPrefs.SetInt("HighestLevel", 0);

        PlayerData.currentCharacterID = 0;
        PlayerPrefs.SetInt("CurrentCharacterID", PlayerData.currentCharacterID);

        BulletData.currentWeaponID = 0;
        PlayerPrefs.SetInt("CurrentWeaponID", BulletData.currentWeaponID);

        bulletData.currentWeaponName = bulletData.weaponStruct[BulletData.currentWeaponID].weaponName;

        bulletData.currentWeaponName = "pistol";
    }




    void SetCurrentLevelAtStart()
    {
        if (GameObject.Find("CurrentLevelText"))
        {
            currentLevelText = GameObject.Find("CurrentLevelText").transform.GetComponent<TextMeshProUGUI>();

        }
        if (currentLevelText && levelData)
        {
            currentLevelText.text = levelData.GetCurrentLevelName();
        }
        if (pausePanel)
        {
            pausePanel.transform.localPosition = new Vector3(5000,
                                                             pausePanel.transform.localPosition.y,
                                                             pausePanel.transform.localPosition.z);
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
            SetCurrentCharacterName();
        }
    }
    void SetCurrentCharacterName()
    {
        for (int i = 0; i < _playerData.characterStruct.Length; i++)
        {
            if (PlayerData.currentCharacterID == _playerData.characterStruct[i].id)
            {
                currentCharacterText.text = _playerData.characterStruct[i].name;
                break; // Exit loop once a match is found
            }
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
        pausePanel = GameObject.Find("PausePanel");
    }

    void DefaulthVariableValues()
    {
        FindGameObjects();
        playAgainForScore = false;
        pauseGame = false;
    }

    void CleanUpUnusedAssets()
    {
        StartCoroutine(CleanupRoutine());
    }

    IEnumerator CleanupRoutine()
    {
        // Temizleme işlemi CPU yoğun olduğundan asenkron yap
        yield return Resources.UnloadUnusedAssets();

        // Garbage Collector'ı çalıştır
        System.GC.Collect();

        Debug.Log("Kullanılmayan varlıklar temizlendi.");
    }
    public void LevelUpGame()
    {
        playAgainForScore = true;

        SceneManager.LoadSceneAsync(Scenes.Game.ToString());

        CleanUpUnusedAssets();
    }
    public void PlayAgain()
    {
        LevelData.currentLevelId = 0;
        PlayerPrefs.SetInt("CurrentLevelID", LevelData.currentLevelId);

        playAgainForScore = true;

        SceneManager.LoadSceneAsync(Scenes.Game.ToString());

        DecreaseWeaponUsageLimit();

        CleanUpUnusedAssets();
    }
    public void DecreaseWeaponUsageLimit()
    {
        if (bulletData)
        {
            // Iterate through the weaponStruct array to find the current weapon
            for (int i = 1; i < bulletData.weaponStruct.Length; i++)
            {
                if (BulletData.currentWeaponID == bulletData.weaponStruct[i].id)
                {
                    // Decrease usage limit if it's greater than zero
                    if (bulletData.weaponStruct[i].usageLimit > 0)
                    {
                        bulletData.weaponStruct[i].usageLimit--;
                        PlayerPrefs.SetInt($"{bulletData.weaponStruct[i].weaponName}UsageCount", bulletData.weaponStruct[i].usageLimit);
                    }
                    // If usage limit reaches zero, switch to default weapon
                    else if (bulletData.weaponStruct[i].usageLimit == 0)
                    {
                        BulletData.currentWeaponID = 0;

                        PlayerPrefs.SetInt("CurrentWeaponID", BulletData.currentWeaponID);

                        bulletData.currentWeaponName = bulletData.weaponStruct[BulletData.currentWeaponID].weaponName;
                    }

                    break; // Exit loop once the matching weapon is found
                }
            }
        }
    }

    public void PlayAgainInLevel()
    {
        playAgainForScore = true;

        SceneManager.LoadSceneAsync(Scenes.Game.ToString());

        DecreaseWeaponUsageLimit();

        CleanUpUnusedAssets();
    }
    public void ContinueLastLevel()
    {
        playAgainForScore = true;

        AudioManager.GetInstance.SetCurrentMusic();

        SceneManager.LoadSceneAsync(Scenes.Game.ToString());

        DecreaseWeaponUsageLimit();

        CleanUpUnusedAssets();
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
            else if (LevelData.currentLevelId == 0)
            {
                if (PlayerPrefs.GetInt("HighestLevel") == 0)
                {
                    LevelData.highestLevel = 0;
                    PlayerPrefs.SetInt("HighestLevel", 0);
                }                
            }
            else if (LevelData.currentLevelId == 1)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 1)
                {
                    LevelData.highestLevel = 1;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelId == 2)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 2)
                {
                    LevelData.highestLevel = 2;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelId == 3)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 3)
                {
                    LevelData.highestLevel = 3;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelId == 4)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 4)
                {
                    LevelData.highestLevel = 4;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelId == 5)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 5)
                {
                    LevelData.highestLevel = 5;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelId == 6)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 6)
                {
                    LevelData.highestLevel = 6;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelId == 7)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 7)
                {
                    LevelData.highestLevel = 7;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelId == 8)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 8)
                {
                    LevelData.highestLevel = 8;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelId == 9)
            {
                if (PlayerPrefs.GetInt("HighestLevel") <= 9)
                {
                    LevelData.highestLevel = 9;
                    PlayerPrefs.SetInt("HighestLevel", LevelData.highestLevel);
                }
            }
            else if (LevelData.currentLevelId == 10)
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
        SetHighestLevel();
        if (levelData && CheckSceneName() == Scenes.Levels.ToString() && levelsObject)
        {
            for (int i = 0; i < PlayerPrefs.GetInt("HighestLevel") + 1; i++)
            {
                levelButtons[i].SetActive(true);

                if (PlayerData.Languages.Turkish == PlayerData.currentLanguage)
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
        SceneManager.LoadSceneAsync(Scenes.Levels.ToString());

        CleanUpUnusedAssets();
    }

    public static string CheckSceneName()
    {
        string _sceneName = SceneManager.GetActiveScene().name;
        return _sceneName;
    }

    public static void LoadMenuScene()
    {//Load By Click Menu Scene

        if (CheckSceneName() != Scenes.End.ToString())
        {
            playAgainForScore = true;
        }

        SceneManager.LoadSceneAsync(Scenes.Menu.ToString());
    }

    public void LoadByCodeMenuScene()
    {
        SceneManager.LoadSceneAsync(Scenes.Menu.ToString());
        CleanUpUnusedAssets();
    }
    public static void LoadMenuSceneByWinScene()
    {
        SceneManager.LoadSceneAsync(Scenes.Menu.ToString());
    }

    public void LoadWinScene()
    {
        SceneManager.LoadSceneAsync(Scenes.Win.ToString());
    }
    public static void LoadCharacterChoosingScene()
    {
        SceneManager.LoadSceneAsync(Scenes.PickCharacter.ToString());
    }
    public void LoadWeaponChoosingScene()
    {
        SceneManager.LoadSceneAsync(Scenes.PickWeapon.ToString());
    }
    public static void LoadEndScene()
    {
        SceneManager.LoadSceneAsync(Scenes.End.ToString());
    }
    public void QuitGame()
    {
        Application.Quit();
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
            PlayerData.isPlayable = true;
        }
        else if (!pauseGame) {

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            GameObject.Find("Look").transform.localScale = Vector3.zero;

            //_lookStick.transform.localScale = Vector3.zero;
            pauseGame = true;
            pausePanel.transform.localPosition = new Vector3(0,
                                                             pausePanel.transform.localPosition.y,
                                                             pausePanel.transform.localPosition.z);
            PlayerData.isPlayable = false;
        }
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
        Wall,
        FanceWooden,
        LevelUpKey,
        EnemyTriggerBox,
        BossTriggerBox,
        ChestTriggerBox,
        ChestTrigger2Box,
        

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

        //Weapons
        machine,
        shotGun,
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
