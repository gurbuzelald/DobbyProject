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
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.isCompleteFirstMap)
        {
            if (currentMap != null)
            {
                Destroy(currentMap);
                CreateMap(Maps[1], gameObject.transform);
                playerData.isCompleteFirstMap = false;
            }
            
        }
        else if (playerData.isCompleteSecondMap)
        {
            Destroy(currentMap);
            CreateMap(Maps[2], gameObject.transform);
            playerData.isCompleteSecondMap = false;
        }
    }
    void CreateMap(GameObject mapObject, Transform mapTransform)
    {
        currentMap  = Instantiate(mapObject, mapTransform);
    }
}
