using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpPanelController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;
    private Image levelUpImage;
    private CanvasGroup levelUpCanvasGroup;
    void Awake()
    {
        levelUpImage = gameObject.GetComponent<Image>();
        levelUpCanvasGroup = gameObject.GetComponent<CanvasGroup>();

        levelUpImage.enabled = true;
    }

    void Update()
    {
        if (levelData.isLevelUp && LevelData.levelCanBeSkipped)
        {
            //LevelData.highestLevel++;
            levelUpCanvasGroup.alpha = 1;
            levelUpImage.enabled = true;
            levelUpCanvasGroup.alpha -= 0.01f;
            if (levelUpCanvasGroup.alpha == 0)
            {
                levelUpImage.enabled = false;
            }
        }
        else if (levelUpImage && !levelData.isLevelUp && !LevelData.levelCanBeSkipped)
        {
            levelUpCanvasGroup.alpha -= 0.05f;
            if (levelUpCanvasGroup.alpha == 0)
            {
                levelUpImage.enabled = false;
            }
        }
    }
}
