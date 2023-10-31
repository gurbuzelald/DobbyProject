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

        if (levelData.currentMapName == LevelData.MapNames.FirstMap) {

            currentMap = Instantiate(levelData.Maps[0], gameObject.transform);
            RenderSettings.skybox = levelData.levelSkyboxes[0];
        }
        else if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            currentMap = Instantiate(levelData.Maps[1], gameObject.transform);
            RenderSettings.skybox = levelData.levelSkyboxes[1];
        }
        else if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            currentMap = Instantiate(levelData.Maps[2], gameObject.transform);
            RenderSettings.skybox = levelData.levelSkyboxes[2];
        }
        else if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            currentMap = Instantiate(levelData.Maps[3], gameObject.transform);
            RenderSettings.skybox = levelData.levelSkyboxes[3];
        }
        else if (levelData.currentMapName == LevelData.MapNames.FifthMap)
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

        switch (levelData.currentMapName)
        {
            case LevelData.MapNames.FirstMap:
                levelCount = 0;
                break;
            case LevelData.MapNames.SecondMap:
                levelCount = 1;
                break;
            case LevelData.MapNames.ThirdMap:
                levelCount = 2;
                break;
            case LevelData.MapNames.FourthMap:
                levelCount = 3;
                break;
            case LevelData.MapNames.FifthMap:
                levelCount = 4;
                break;
        }

        playerData.isPlayable = false;
        Destroy(currentMap, levelCount);
        CreateMap(levelData.Maps[levelCount], gameObject.transform);
        StartCoroutine(DelayTruePlayable());
    }
    void CreateMap(GameObject mapObject, Transform mapTransform)
    {
        currentMap  = Instantiate(mapObject, mapTransform);
    }
    public void SetSecondSkybox()
    {
        RenderSettings.skybox = levelData.levelSkyboxes[1];
    }
    public void SetThirdSkyBox()
    {
        RenderSettings.skybox = levelData.levelSkyboxes[2];
    }
    public void SetFourthSkybox()
    {
        RenderSettings.skybox = levelData.levelSkyboxes[3];
    }
    public void SetFifthSkybox()
    {
        RenderSettings.skybox = levelData.levelSkyboxes[4];
    }
}
