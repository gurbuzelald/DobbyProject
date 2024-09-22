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
            if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 1" ||
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Bölüm 1")
            {
                levelData.currentLevel = LevelData.Levels.Level1;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 2" ||
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Bölüm 2")
            {
                levelData.currentLevel = LevelData.Levels.Level2;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 3" ||
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Bölüm 3")
            {
                levelData.currentLevel = LevelData.Levels.Level3;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 4" ||
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Bölüm 4")
            {
                levelData.currentLevel = LevelData.Levels.Level4;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 5" ||
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Bölüm 5")
            {
                levelData.currentLevel = LevelData.Levels.Level5;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 6" ||
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Bölüm 6")
            {
                levelData.currentLevel = LevelData.Levels.Level6;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 7" ||
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Bölüm 7")
            {
                levelData.currentLevel = LevelData.Levels.Level7;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 8" ||
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Bölüm 8")
            {
                levelData.currentLevel = LevelData.Levels.Level8;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 9" ||
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Bölüm 9")
            {
                levelData.currentLevel = LevelData.Levels.Level9;

                sceneController.OpenCurrentLevel();
            }
            else if (gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Level 10" ||
                gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text == "Bölüm 10")
            {
                levelData.currentLevel = LevelData.Levels.Level10;

                sceneController.OpenCurrentLevel();
            }
        }
        
    }

    int GetCurrentLevelID(LevelData levelData)
    {
        if (levelData.currentLevel == LevelData.Levels.Level1) return 0;
        else if (levelData.currentLevel == LevelData.Levels.Level2) return 1;
        else if (levelData.currentLevel == LevelData.Levels.Level3) return 2;
        else if (levelData.currentLevel == LevelData.Levels.Level4) return 3;
        else if (levelData.currentLevel == LevelData.Levels.Level5) return 4;
        else if (levelData.currentLevel == LevelData.Levels.Level6) return 5;
        else if (levelData.currentLevel == LevelData.Levels.Level7) return 6;
        else if (levelData.currentLevel == LevelData.Levels.Level8) return 7;
        else if (levelData.currentLevel == LevelData.Levels.Level9) return 8;
        else if (levelData.currentLevel == LevelData.Levels.Level10) return 9;
        return -1;
    }
}
