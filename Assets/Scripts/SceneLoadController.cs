using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadController : AbstractSingleton<SceneLoadController>
{
    [Header("Audio Components")]
    [SerializeField] AudioSource _audioSource;
    public void PlayAgain()
    {
        _audioSource.Stop();
        if (PlayerManager.GetInstance.gameObject != null)
        {
            Destroy(PlayerManager.GetInstance.gameObject);
        }
        SceneManager.LoadScene("Level1");
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
        SceneManager.LoadScene("Menu");
    }
    public void LoadEndScene()
    {
        _audioSource.Stop();
        if (PlayerManager.GetInstance.gameObject != null)
        {
            Destroy(PlayerManager.GetInstance.gameObject);
        }
        SceneManager.LoadScene("End");
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
        End
    }
}
