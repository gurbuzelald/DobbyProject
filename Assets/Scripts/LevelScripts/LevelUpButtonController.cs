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

            levelData.currentLevel = LevelData.Levels.Level1;

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgain = true;

            //DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            //DecreaseWeaponUsageLimit();
        }
    }
    public void Level2()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            levelData.currentLevel = LevelData.Levels.Level2;

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgain = true;

            //DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            //DecreaseWeaponUsageLimit();
        }
    }
    public void Level3()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            levelData.currentLevel = LevelData.Levels.Level3;

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgain = true;

            //DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            //DecreaseWeaponUsageLimit();
        }
    }
    public void Level4()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            levelData.currentLevel = LevelData.Levels.Level4;

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgain = true;

            //DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            //DecreaseWeaponUsageLimit();
        }
    }
    public void Level5()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            levelData.currentLevel = LevelData.Levels.Level5;

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgain = true;

            //DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            //DecreaseWeaponUsageLimit();
        }
    }
    public void Level6()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            levelData.currentLevel = LevelData.Levels.Level6;

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgain = true;

            //DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            //DecreaseWeaponUsageLimit();
        }
    }
    public void Level7()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            levelData.currentLevel = LevelData.Levels.Level7;

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgain = true;

            //DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            //DecreaseWeaponUsageLimit();
        }
    }
    public void Level8()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            levelData.currentLevel = LevelData.Levels.Level8;

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgain = true;

            //DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            //DecreaseWeaponUsageLimit();
        }
    }
    public void Level9()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            levelData.currentLevel = LevelData.Levels.Level9;

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgain = true;

            //DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            //DecreaseWeaponUsageLimit();
        }
    }
    public void Level10()
    {
        if (levelData && sceneController)
        {
            sceneController.DecreaseWeaponUsageLimit();

            levelData.currentLevel = LevelData.Levels.Level10;

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            SceneController.playAgain = true;

            //DestroySingletonObjects();

            SceneManager.LoadScene(SceneController.Scenes.Game.ToString());

            //DecreaseWeaponUsageLimit();
        }
    }
}
