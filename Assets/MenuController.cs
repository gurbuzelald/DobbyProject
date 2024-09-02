using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    [SerializeField] LevelData levelData;
    private GameObject continueButtonObject;
    private GameObject playButtonObject;
    void Start()
    {
        SetContinueButtonName();
        SetPlayButtonName();
    }

    void SetContinueButtonName()
    {
        continueButtonObject = GameObject.Find("ContinueButton");

        if (continueButtonObject && levelData)
        {
            continueButtonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level " + (GetCurrentLevelID(levelData) + 1).ToString();
        }
    }

    void SetPlayButtonName()
    {
        playButtonObject = GameObject.Find("PlayButton");

        if (playButtonObject && continueButtonObject)
        {
            if (continueButtonObject.transform.localScale.x == 0)
            {
                playButtonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Play";
            }
            else if(continueButtonObject.transform.localScale.x > 0)
            {
                playButtonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level 1";
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
