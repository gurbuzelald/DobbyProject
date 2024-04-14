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

        currentMap = Instantiate(levelData.Maps[LevelData.currentLevelCount], gameObject.transform);
        RenderSettings.skybox = levelData.levelSkyboxes[LevelData.currentLevelCount];

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
