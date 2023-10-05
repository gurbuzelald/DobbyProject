using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MapController : MonoBehaviour
{
    [SerializeField] GameObject[] Maps;
    [SerializeField] GameObject[] WeaponGiftBoxes;
    [SerializeField] PlayerData playerData;
    public static GameObject currentMap;

    private JsonReadAndWriteSystem readWrite;


    // Start is called before the first frame update
    void Awake()
    {
        readWrite = FindObjectOfType<JsonReadAndWriteSystem>();

        if (playerData.currentMapName == PlayerData.MapNames.FirstMap) {

            currentMap = Instantiate(Maps[0], gameObject.transform);
            RenderSettings.skybox = playerData.firstSkybox;
        }
        else if (playerData.currentMapName == PlayerData.MapNames.SecondMap)
        {
            currentMap = Instantiate(Maps[1], gameObject.transform);
            RenderSettings.skybox = playerData.secondMapSkyBox;
        }
        else if (playerData.currentMapName == PlayerData.MapNames.ThirdMap)
        {
            currentMap = Instantiate(Maps[2], gameObject.transform);
            RenderSettings.skybox = playerData.thirdSkybox;
        }
        else if (playerData.currentMapName == PlayerData.MapNames.FourthMap)
        {
            currentMap = Instantiate(Maps[3], gameObject.transform);
            RenderSettings.skybox = playerData.fourthSkybox;
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
        playerData.currentMapName = PlayerData.MapNames.SecondMap;

        playerData.isPlayable = false;
        DarknessCubesActivity();
        Destroy(currentMap, 1);
        CreateMap(Maps[1], gameObject.transform);
        StartCoroutine(DelayTruePlayable());
    }
    public void CreateThirdMap()
    {
        playerData.currentMapName = PlayerData.MapNames.ThirdMap;

        playerData.isPlayable = false;
        DarknessCubesActivity();
        Destroy(currentMap, 1);
        CreateMap(Maps[2], gameObject.transform);
        StartCoroutine(DelayTruePlayable());
    }
    public void CreateFourthMap()
    {
        playerData.currentMapName = PlayerData.MapNames.FourthMap;

        playerData.isPlayable = false;
        DarknessCubesActivity();
        Destroy(currentMap, 1);
        CreateMap(Maps[3], gameObject.transform);
        StartCoroutine(DelayTruePlayable());
    }
    void CreateMap(GameObject mapObject, Transform mapTransform)
    {
        currentMap  = Instantiate(mapObject, mapTransform);
    }
    public void SetSecondSkybox()
    {
        RenderSettings.skybox = playerData.secondMapSkyBox;
    }
    public void SetThirdSkyBox()
    {
        RenderSettings.skybox = playerData.thirdSkybox;
    }
    public void SetFourthSkybox()
    {
        RenderSettings.skybox = playerData.fourthSkybox;
    }
}
