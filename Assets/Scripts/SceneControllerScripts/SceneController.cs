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

    private GameObject pausePanel;
    private bool pauseGame = false;
    [HideInInspector]
    public static bool playAgain;

    [Header("RotationControl")]
    public static bool rotateTouchOrMousePos = false;

    private GameObject mouseOrTouch;
    private TextMeshProUGUI mouseOrTouchText;

    private GameObject lockWalking;
    private TextMeshProUGUI lockWalkingText;
    void Start()
    {
        DefaulthVariableValues();
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
    public void PlayAgain()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        levelData.currentMapName = LevelData.MapNames.FirstMap;

        playAgain = true;

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Level1.ToString());
    }
    public void ContinueLastLevel()
    {
        playAgain = true;

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Level1.ToString());        
    }
    public string CheckSceneName()
    {
        string _sceneName = SceneManager.GetActiveScene().name;
        return _sceneName;
    }
    public void LoadMenuScene()
    {//Load By Click Menu Scene

        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        if (CheckSceneName() != SceneController.Scenes.End.ToString())
        {
            playAgain = true;
        }

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Menu.ToString());

    }

    public void LoadByCodeMenuScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        levelData.currentMapName = LevelData.MapNames.FirstMap;

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Menu.ToString());

    }

    public void LoadWinScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.Win.ToString());
    }
    public void LoadCharacterChoosingScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.CharacterChoose.ToString());
    }
    public void LoadSwordChoosingScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.SwordChoose.ToString());
    }
    public void LoadWeaponChoosingScene()
    {
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        DestroySingletonObjects();

        SceneManager.LoadScene(Scenes.WeaponChoose.ToString());
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
        //Debug.Log(SceneManager.sceneCountInBuildSettings - 3);
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
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
        FirstFinishArea,
        SecondFinishArea,
        ThirdFinishArea,
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
        Rifle,
        Ak47,
        Bulldog,
        Cowgun,
        Crystalgun,
        Demongun,
        Icegun,
        Negev,
        Axegun,
        WeaponBox,

        //Speed
        NormalSpeed,
        ExtraSpeed
    }
    public enum Scenes
    {
        Menu, End, Win, Level1, CharacterChoose, SwordChoose, WeaponChoose
    }
}
