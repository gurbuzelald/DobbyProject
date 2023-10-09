using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;

    private GameObject currentMapCoins;

    void Start()
    {
        if (levelData.currentMapName == LevelData.MapNames.FirstMap)
        {
            currentMapCoins = Instantiate(playerData.mapCoins[0], gameObject.transform);
        }
        else if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            currentMapCoins = Instantiate(playerData.mapCoins[1], gameObject.transform);
        }
        else if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            currentMapCoins = Instantiate(playerData.mapCoins[2], gameObject.transform);
        }
        else if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            currentMapCoins = Instantiate(playerData.mapCoins[3], gameObject.transform);
        }
    }
    public void CreateSecondCoin()
    {
        Destroy(currentMapCoins);
        currentMapCoins = Instantiate(playerData.mapCoins[1], gameObject.transform);

    }
    public void CreateThirdCoin()
    {
        Destroy(currentMapCoins);
        currentMapCoins = Instantiate(playerData.mapCoins[2], gameObject.transform);

    }
    public void CreateFourthCoin()
    {
        Destroy(currentMapCoins);
        currentMapCoins = Instantiate(playerData.mapCoins[3], gameObject.transform);

    }
}
