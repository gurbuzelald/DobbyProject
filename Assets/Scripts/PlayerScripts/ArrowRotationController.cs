using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotationController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;
    
    private void Awake()
    {
        levelData.isSecondMapTarget = false;
        levelData.isThirdMapTarget = false;
        levelData.isFourthMapTarget = false;


        levelData.currentFinishArea = levelData.level1FinishArea;
    }
    void Update()
    {
        ArrowRotation();
    }
    void ArrowRotation()
    {
        if (levelData.currentMapName == LevelData.MapNames.FirstMap)
        {
            levelData.currentFinishArea = levelData.level1FinishArea;
        }
        if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            levelData.currentFinishArea = levelData.level2FinishArea;
        }
        if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            levelData.currentFinishArea = levelData.level3FinishArea;
        }
        if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            levelData.currentFinishArea = levelData.level4FinishArea;
        }

        if (gameObject != null)
        {
            gameObject.transform.LookAt(levelData.currentFinishArea.position);
        }
        //Debug.Log(_currentFinishArea.position);

    }
}
