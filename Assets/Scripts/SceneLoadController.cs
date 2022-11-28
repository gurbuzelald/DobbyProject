using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadController : AbstractSingleton<SceneLoadController>
{
    public void PlayAgain()
    {
        Destroy(PlayerManager.GetInstance.gameObject);
        SceneManager.LoadScene("Level1");
    }
    public string CheckSceneName()
    {
        string _sceneName = SceneManager.GetActiveScene().name;
        return _sceneName;
    }
    public void LoadMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadEndScene()
    {
        Destroy(PlayerManager.GetInstance.gameObject);
        SceneManager.LoadScene("End");
    }
    public void LevelUp()
    {
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
        Coin
    }
    public enum Scenes
    {
        Menu,
        End
    }
}
