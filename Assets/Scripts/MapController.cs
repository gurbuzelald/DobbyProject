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

    // Start is called before the first frame update
    void Awake()
    {

        currentMap = Instantiate(Maps[0], gameObject.transform);
        RenderSettings.skybox = playerData.firstSkybox;

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
        SetLevelSkybox();
        SetNewMap();
    }
    void SetNewMap()
    {
        if (playerData.isCompleteFirstMap)
        {
            playerData.isPlayable = false;
            DarknessCubesActivity();
            Destroy(currentMap, 1);
            CreateMap(Maps[1], gameObject.transform);
            StartCoroutine(DelayTruePlayable());
        }
        else if (playerData.isCompleteSecondMap)
        {
            playerData.isPlayable = false;
            DarknessCubesActivity();
            Destroy(currentMap, 1);
            CreateMap(Maps[2], gameObject.transform);
            StartCoroutine(DelayTruePlayable());
        }
        else if (playerData.isCompleteThirdMap)
        {
            playerData.isPlayable = false;
            DarknessCubesActivity();
            Destroy(currentMap, 1);
            CreateMap(Maps[3], gameObject.transform);
            StartCoroutine(DelayTruePlayable());
        }
    }
    void CreateMap(GameObject mapObject, Transform mapTransform)
    {
        currentMap  = Instantiate(mapObject, mapTransform);
    }
    private void SetLevelSkybox()
    {
        if (playerData.isCompleteFirstMap)
        {
            RenderSettings.skybox = playerData.secondMapSkyBox;
        }
        else if (playerData.isCompleteSecondMap)
        {
            RenderSettings.skybox = playerData.thirdSkybox;
        }
        else if (playerData.isCompleteThirdMap)
        {
            RenderSettings.skybox = playerData.fourthSkybox;
        }
    }
}
