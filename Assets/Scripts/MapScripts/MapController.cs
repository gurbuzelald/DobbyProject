using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapController : MonoBehaviour
{
    
    [SerializeField] GameObject[] WeaponGiftBoxes;
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;
    public static GameObject currentMap;

    private JsonReadAndWriteSystem readWrite;


    // Start is called before the first frame update
    void Awake()
    {
        readWrite = FindObjectOfType<JsonReadAndWriteSystem>();

        if (levelData)
        {
            currentMap = Instantiate(levelData.levelStates[LevelData.currentLevelId].mapObject, gameObject.transform);
        }
        if (levelData)
        {
            RenderSettings.skybox = levelData.levelStates[LevelData.currentLevelId].levelSkybox;
        }    
    }
    void Update()
    {
        if (readWrite)
        {
            readWrite.SavePlayerDataToJson();
        }
    }
}
