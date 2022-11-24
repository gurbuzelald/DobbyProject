using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadController : MonoBehaviour
{
    public void PlayAgain()
    {
        Destroy(PlayerManager.GetInstance.gameObject);
        SceneManager.LoadScene(0);
    }
    public enum Tags
    {
        Ground,
        Bridge,
        Ladder,
        Enemy
    }
}
