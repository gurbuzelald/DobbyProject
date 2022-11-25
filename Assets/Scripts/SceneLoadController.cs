using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadController : AbstractSingleton<SceneLoadController>
{
    public void PlayAgain()
    {
        Destroy(PlayerManager.GetInstance.gameObject);
        SceneManager.LoadScene(0);
    }
    public string CheckSceneName()
    {
        string _sceneName = SceneManager.GetActiveScene().name;
        return _sceneName;
    }
    public enum Tags
    {
        Ground,
        Bridge,
        Ladder,
        Enemy,
        Bullet,
        Player
    }
    public enum Scenes
    {
        Menu,
        End
    }
}
