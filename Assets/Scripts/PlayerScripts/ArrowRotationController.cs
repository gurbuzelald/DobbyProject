using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotationController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    
    private void Awake()
    {
        playerData.isSecondMapTarget = false;
        playerData.isThirdMapTarget = false;
        playerData.isFourthMapTarget = false;


        playerData.currentFinishArea = playerData.level1FinishArea;
    }
    void Update()
    {
        ArrowRotation();
    }
    void ArrowRotation()
    {
        if (playerData.currentMapName == PlayerData.MapNames.FirstMap)
        {
            playerData.currentFinishArea = playerData.level1FinishArea;
        }
        if (playerData.currentMapName == PlayerData.MapNames.SecondMap)
        {
            playerData.currentFinishArea = playerData.level2FinishArea;
        }
        if (playerData.currentMapName == PlayerData.MapNames.ThirdMap)
        {
            playerData.currentFinishArea = playerData.level3FinishArea;
        }
        if (playerData.currentMapName == PlayerData.MapNames.FourthMap)
        {
            playerData.currentFinishArea = playerData.level4FinishArea;
        }

        if (gameObject != null)
        {
            gameObject.transform.LookAt(playerData.currentFinishArea.position);
        }
        //Debug.Log(_currentFinishArea.position);

    }
}
