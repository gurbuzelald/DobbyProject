using System.Collections;
using System.Collections.Generic;
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
        if (playerData.isCompleteFirstMap)
        {
            if (currentMap != null)
            {
                playerData.isPlayable = false;
                DarknessCubesActivity();
                Destroy(currentMap, 1);
                CreateMap(Maps[1], gameObject.transform);
                playerData.isCompleteFirstMap = false;
                StartCoroutine(DelayTruePlayable());
            }
            
        }
        else if (playerData.isCompleteSecondMap)
        {
            playerData.isPlayable = false;
            DarknessCubesActivity();
            Destroy(currentMap, 1);
            CreateMap(Maps[2], gameObject.transform);
            playerData.isCompleteSecondMap = false;
            StartCoroutine(DelayTruePlayable());
        }
        else if (playerData.isCompleteThirdMap)
        {
            playerData.isPlayable = false;
            DarknessCubesActivity();
            Destroy(currentMap, 1);
            CreateMap(Maps[3], gameObject.transform);
            playerData.isCompleteThirdMap = false;
            StartCoroutine(DelayTruePlayable());
        }
    }
    void CreateMap(GameObject mapObject, Transform mapTransform)
    {
        currentMap  = Instantiate(mapObject, mapTransform);
    }
}
