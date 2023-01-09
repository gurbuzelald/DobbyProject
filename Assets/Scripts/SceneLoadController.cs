using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadController : AbstractSingleton<SceneLoadController>
{
    [Header("Audio Components")]
    [SerializeField] AudioSource _audioSource;

    [Header("Data")]
    public PlayerData _playerData;

    [Header("Buttons")]
    [SerializeField] GameObject pausePanel;
    private bool pauseGame = false;
    public bool playAgain;
    public static bool rotateControl = false;

    private void Start()
    {
        rotateControl = false;
        playAgain = false;
        pauseGame = false;
    }
    private void OnEnable()
    {
        if (pauseGame)
        {
            Time.timeScale = 0;
        }
    }
    private void OnDisable()
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
    public void LoadEndScene()
    {
        _audioSource.Stop();
        if (PlayerManager.GetInstance.gameObject != null)
        {
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
        if (rotateControl == true)
        {
            rotateControl = false;
        }
        else
        {
            rotateControl = true;
        }
    }
    public void LevelUp()
    {
        if (SceneManager.sceneCountInBuildSettings - 2 == SceneManager.GetActiveScene().buildIndex)
        {
            _audioSource.Stop();
        }
        Destroy(PlayerManager.GetInstance.gameObject);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        Menu,
        End,
        Level1
    }
}
