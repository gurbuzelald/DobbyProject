using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUpButtonController : MonoBehaviour
{
    [SerializeField] SceneController sceneController;
    [SerializeField] LevelData levelData;

    public void OnClick()
    {
        if (levelData && sceneController)
        {
            if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 1")
            {
                levelData.currentLevel = LevelData.Levels.Level1;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 2")
            {
                levelData.currentLevel = LevelData.Levels.Level2;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 3")
            {
                levelData.currentLevel = LevelData.Levels.Level3;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 4")
            {
                levelData.currentLevel = LevelData.Levels.Level4;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 5")
            {
                levelData.currentLevel = LevelData.Levels.Level5;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 6")
            {
                levelData.currentLevel = LevelData.Levels.Level6;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 7")
            {
                levelData.currentLevel = LevelData.Levels.Level7;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 8")
            {
                levelData.currentLevel = LevelData.Levels.Level8;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 9")
            {
                levelData.currentLevel = LevelData.Levels.Level9;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 10")
            {
                levelData.currentLevel = LevelData.Levels.Level10;

                sceneController.OpenCurrentLevel();
            }
        }
        
    }
}
