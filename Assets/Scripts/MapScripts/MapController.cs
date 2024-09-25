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
    void Start()
    {
        readWrite = FindObjectOfType<JsonReadAndWriteSystem>();

        if (levelData)
        {
            currentMap = Instantiate(levelData.Maps[LevelData.currentLevelCount], gameObject.transform);
        }
        if (levelData)
        {
            RenderSettings.skybox = levelData.levelSkyboxes[LevelData.currentLevelCount];
        }    
    }
    IEnumerator DelayTruePlayable()
    {
        yield return new WaitForSeconds(0.5f);
        if (playerData)
        {
            playerData.isPlayable = true;
        }
    }
    void Update()
    {
        if (readWrite)
        {
            readWrite.SavePlayerDataToJson();
        }
    }
    public void CreateMap(int levelCount)
    {
        if (playerData && currentMap && levelData)
        {
            playerData.isPlayable = false;
            Destroy(currentMap, levelCount);
            CreateMap(levelData.Maps[levelCount], gameObject.transform);
            StartCoroutine(DelayTruePlayable());
        }
    }

    void CreateMap(GameObject mapObject, Transform mapTransform)
    {
        if (currentMap && mapObject != null)
        {
            currentMap = Instantiate(mapObject, mapTransform);
        }        
    }
    public void SetSkybox(int levelCount)
    {
        if (levelData)
        {
            RenderSettings.skybox = levelData.levelSkyboxes[levelCount];
        }
    }
}
