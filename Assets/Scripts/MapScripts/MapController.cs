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

        if (levelData.currentLevel == LevelData.Levels.Level1) {

            currentMap = Instantiate(levelData.Maps[0], gameObject.transform);
            RenderSettings.skybox = levelData.levelSkyboxes[0];
        }
        else if (levelData.currentLevel == LevelData.Levels.Level2)
        {
            currentMap = Instantiate(levelData.Maps[1], gameObject.transform);
            RenderSettings.skybox = levelData.levelSkyboxes[1];
        }
        else if (levelData.currentLevel == LevelData.Levels.Level3)
        {
            currentMap = Instantiate(levelData.Maps[2], gameObject.transform);
            RenderSettings.skybox = levelData.levelSkyboxes[2];
        }
        else if (levelData.currentLevel == LevelData.Levels.Level4)
        {
            currentMap = Instantiate(levelData.Maps[3], gameObject.transform);
            RenderSettings.skybox = levelData.levelSkyboxes[3];
        }
        else if (levelData.currentLevel == LevelData.Levels.Level5)
        {
            currentMap = Instantiate(levelData.Maps[4], gameObject.transform);
            RenderSettings.skybox = levelData.levelSkyboxes[4];
        }



        //DarknessCubesActivity();
        //currentMap.transform.GetChild(1).gameObject.SetActive(true);
    }
    IEnumerator DelayDarknesCubesClose()
    {
        currentMap.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        currentMap.transform.GetChild(1).gameObject.SetActive(false);
    }
    IEnumerator DelayTruePlayable()
    {
        yield return new WaitForSeconds(0.5f);
        playerData.isPlayable = true;
    }
    void Update()
    {
        readWrite.SavePlayerDataToJson();
    }
    public void CreateMap(int levelCount)
    {
        playerData.isPlayable = false;
        Destroy(currentMap, levelCount);
        CreateMap(levelData.Maps[levelCount], gameObject.transform);
        StartCoroutine(DelayTruePlayable());
    }

    void CreateMap(GameObject mapObject, Transform mapTransform)
    {
        currentMap  = Instantiate(mapObject, mapTransform);
    }
    public void SetSkybox(int levelCount)
    {
        RenderSettings.skybox = levelData.levelSkyboxes[levelCount];
    }
}
