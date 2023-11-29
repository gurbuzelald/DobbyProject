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
        currentMapCoins = Instantiate(levelData.mapCoins[LevelUpController.currentLevelCount], gameObject.transform);
        
    }
    public void CreateCoins(int levelCount)
    {
        Destroy(currentMapCoins);
        currentMapCoins = Instantiate(levelData.mapCoins[levelCount], gameObject.transform);
    }
}
