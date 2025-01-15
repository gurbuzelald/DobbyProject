using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuController : AbstractPlayer<MenuController>
{
    [SerializeField] LevelData levelData;
    [SerializeField] PlayerData playerData;
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

        if (continueButtonObject && levelData  && playerData)
        {
            if (PlayerData.Languages.Turkish == PlayerData.currentLanguage)
            {
                continueButtonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Bölüm " + (levelData.currentLevelId + 1).ToString();
            }
            else
            {
                continueButtonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level " + (levelData.currentLevelId + 1).ToString();
            }

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
                if (PlayerData.currentLanguage == PlayerData.Languages.Turkish)
                {
                    playButtonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Bölüm 1";
                }
                else
                {
                    playButtonObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "Level 1";
                }
                
            }
        }
    }
}
