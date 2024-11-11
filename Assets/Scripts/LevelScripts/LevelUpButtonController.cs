using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelUpButtonController : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] LevelData levelData;


    public void Level1()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            LevelData.currentLevelId = 0;

            PlayerPrefs.SetInt("CurrentLevelID", 0);

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgainForScore = true;

            //SceneController.DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            sceneController.DecreaseWeaponUsageLimit();
        }
    }
    public void Level2()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            LevelData.currentLevelId = 1;

            PlayerPrefs.SetInt("CurrentLevelID", 1);

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgainForScore = true;

            //SceneController.DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            sceneController.DecreaseWeaponUsageLimit();
        }
    }
    public void Level3()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            LevelData.currentLevelId = 2;

            PlayerPrefs.SetInt("CurrentLevelID", 2);

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgainForScore = true;

            //SceneController.DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            sceneController.DecreaseWeaponUsageLimit();
        }
    }
    public void Level4()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            LevelData.currentLevelId = 3;

            PlayerPrefs.SetInt("CurrentLevelID", 3);

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgainForScore = true;

            //SceneController.DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            sceneController.DecreaseWeaponUsageLimit();
        }
    }
    public void Level5()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            LevelData.currentLevelId = 4;

            PlayerPrefs.SetInt("CurrentLevelID", 4);

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgainForScore = true;

            //SceneController.DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            sceneController.DecreaseWeaponUsageLimit();
        }
    }
    public void Level6()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            LevelData.currentLevelId = 5;

            PlayerPrefs.SetInt("CurrentLevelID", 5);

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgainForScore = true;

            //SceneController.DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            sceneController.DecreaseWeaponUsageLimit();
        }
    }
    public void Level7()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            LevelData.currentLevelId = 6;

            PlayerPrefs.SetInt("CurrentLevelID", 6);

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgainForScore = true;

            //SceneController.DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            sceneController.DecreaseWeaponUsageLimit();
        }
    }
    public void Level8()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            LevelData.currentLevelId = 7;

            PlayerPrefs.SetInt("CurrentLevelID", 7);

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgainForScore = true;

            //SceneController.DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            sceneController.DecreaseWeaponUsageLimit();
        }
    }
    public void Level9()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            LevelData.currentLevelId = 8;

            PlayerPrefs.SetInt("CurrentLevelID", 8);

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgainForScore = true;

            //SceneController.DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            sceneController.DecreaseWeaponUsageLimit();
        }
    }
    public void Level10()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            LevelData.currentLevelId = 9;

            PlayerPrefs.SetInt("CurrentLevelID", 9);

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgainForScore = true;

            //SceneController.DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            sceneController.DecreaseWeaponUsageLimit();
        }
    }
}
