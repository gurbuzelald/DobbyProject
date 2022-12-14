using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneController : AbstractSingleton<SceneController>
{
    [Header("Audio Components")]
    [SerializeField] AudioSource _audioSource;

    [Header("Data")]
    public PlayerData _playerData;

    [Header("Buttons")]
    [SerializeField] GameObject pausePanel;
    private bool pauseGame = false;
    public static bool playAgain;

    [Header("RotationControl")]
    public static bool RotateTouchOrMousePos = false;
    [SerializeField] TextMeshProUGUI mouseOrTouchText;

    void Start()
    {
        //mouseOrTouchText.text = "Touch";
        RotateTouchOrMousePos = false;
        playAgain = false;
        pauseGame = false;
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
    public void PlayAgain()
    {
        playAgain = true;
        
        _audioSource.Stop();
        if (PlayerManager.GetInstance.gameObject != null)
        {
            Destroy(PlayerManager.GetInstance.gameObject);
            Destroy(AudioManager.GetInstance.gameObject);
        }
        SceneManager.LoadScene(Scenes.Level1.ToString());
    }
    public string CheckSceneName()
    {
        string _sceneName = SceneManager.GetActiveScene().name;
        return _sceneName;
    }
    public void LoadMenuScene()
    {
        _audioSource.Stop();
        if (PlayerManager.GetInstance.gameObject != null)
        {
            Destroy(PlayerManager.GetInstance.gameObject);
        }
        SceneManager.LoadScene(Scenes.Menu.ToString());
    }
    public void LoadWinScene()
    {
        if (PlayerManager.GetInstance.gameObject != null)
        {
            Destroy(AudioManager.GetInstance.gameObject);
            Destroy(PlayerManager.GetInstance.gameObject);
        }
        SceneManager.LoadScene(Scenes.Win.ToString());
    }
    public void LoadEndScene()
    {
        if (PlayerManager.GetInstance.gameObject != null)
        {
            Destroy(AudioManager.GetInstance.gameObject);
            Destroy(PlayerManager.GetInstance.gameObject);
        }
        SceneManager.LoadScene(Scenes.End.ToString());
    }
    public void PauseGame()
    {
        if (pauseGame) {
            pauseGame = false;
            pausePanel.transform.localScale = Vector3.zero;
            _playerData.isPlayable = true;
        }
        else if (!pauseGame) {
            pauseGame = true;
            pausePanel.transform.localScale = Vector3.one;
            _playerData.isPlayable = false;
        }
    }
    public void ControlRotate()
    {
        if (RotateTouchOrMousePos == true)
        {
            mouseOrTouchText.text = "Touch";

            RotateTouchOrMousePos = false;
        }
        else
        {
            mouseOrTouchText.text = "Mouse";

            RotateTouchOrMousePos = true;
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
        Application.Quit();
    }
    public enum Tags
    {
        Ground,
        Bridge,
        Ladder,
        Enemy,
        Bullet,
        Player,
        Water,
        FanceWooden,
        FinishArea,
        Coin,
        Magnet,
        Lava,
        FirstTarget,
        MainTarget,
        RotateCoin,
        EnemyBullet, 
        CloneDobby
    }
    public enum Scenes
    {
        Menu, End, Win, Level1
    }
}
