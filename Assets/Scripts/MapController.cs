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
        //DarknesCubesActivity();
        currentMap.transform.GetChild(1).gameObject.SetActive(true);
    }
    void DarknesCubesActivity()
    {
        //StartCoroutine(DelayDarknesCubesClose());
    }
    IEnumerator DelayDarknesCubesClose()
    {
        currentMap.transform.GetChild(1).gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);
        currentMap.transform.GetChild(1).gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (playerData.isCompleteFirstMap)
        {
            if (currentMap != null)
            {
                DarknesCubesActivity();
                Destroy(currentMap);
                CreateMap(Maps[1], gameObject.transform);
                playerData.isCompleteFirstMap = false;
            }
            
        }
        else if (playerData.isCompleteSecondMap)
        {
            DarknesCubesActivity();
            Destroy(currentMap);
            CreateMap(Maps[2], gameObject.transform);
            playerData.isCompleteSecondMap = false;
        }
        else if (playerData.isCompleteThirdMap)
        {
            DarknesCubesActivity();
            Destroy(currentMap);
            CreateMap(Maps[3], gameObject.transform);
            playerData.isCompleteThirdMap = false;
        }
    }
    void CreateMap(GameObject mapObject, Transform mapTransform)
    {
        currentMap  = Instantiate(mapObject, mapTransform);
    }
}
