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
            RenderSettings.skybox = levelData.firstSkybox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            currentMap = Instantiate(levelData.Maps[1], gameObject.transform);
            RenderSettings.skybox = levelData.secondMapSkyBox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            currentMap = Instantiate(levelData.Maps[2], gameObject.transform);
            RenderSettings.skybox = levelData.thirdSkybox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            currentMap = Instantiate(levelData.Maps[3], gameObject.transform);
            RenderSettings.skybox = levelData.fourthSkybox;
        }
        else if (levelData.currentMapName == LevelData.MapNames.FifthMap)
        {
            currentMap = Instantiate(levelData.Maps[4], gameObject.transform);
            RenderSettings.skybox = levelData.fourthSkybox;
        }



        //DarknessCubesActivity();
        //currentMap.transform.GetChild(1).gameObject.SetActive(true);
    }
    void DarknessCubesActivity()
    {
        //StartCoroutine(DelayDarknesCubesClose());
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
    public void CreateSecondMap()
    {
        levelData.currentMapName = LevelData.MapNames.SecondMap;

        playerData.isPlayable = false;
        DarknessCubesActivity();
        Destroy(currentMap, 1);
        CreateMap(levelData.Maps[1], gameObject.transform);
        StartCoroutine(DelayTruePlayable());
    }
    public void CreateThirdMap()
    {
        levelData.currentMapName = LevelData.MapNames.ThirdMap;

        playerData.isPlayable = false;
        DarknessCubesActivity();
        Destroy(currentMap, 1);
        CreateMap(levelData.Maps[2], gameObject.transform);
        StartCoroutine(DelayTruePlayable());
    }
    public void CreateFourthMap()
    {
        levelData.currentMapName = LevelData.MapNames.FourthMap;

        playerData.isPlayable = false;
        DarknessCubesActivity();
        Destroy(currentMap, 1);
        CreateMap(levelData.Maps[3], gameObject.transform);
        StartCoroutine(DelayTruePlayable());
    }
    public void CreateFifthMap()
    {
        levelData.currentMapName = LevelData.MapNames.FifthMap;

        playerData.isPlayable = false;
        DarknessCubesActivity();
        Destroy(currentMap, 1);
        CreateMap(levelData.Maps[4], gameObject.transform);
        StartCoroutine(DelayTruePlayable());
    }
    void CreateMap(GameObject mapObject, Transform mapTransform)
    {
        currentMap  = Instantiate(mapObject, mapTransform);
    }
    public void SetSecondSkybox()
    {
        RenderSettings.skybox = levelData.secondMapSkyBox;
    }
    public void SetThirdSkyBox()
    {
        RenderSettings.skybox = levelData.thirdSkybox;
    }
    public void SetFourthSkybox()
    {
        RenderSettings.skybox = levelData.fourthSkybox;
    }
    public void SetFifthSkybox()
    {
        RenderSettings.skybox = levelData.fifthSkybox;
    }
}
