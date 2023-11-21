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
        if (levelData.currentLevel == LevelData.Levels.Level1)
        {
            currentMapCoins = Instantiate(levelData.mapCoins[0], gameObject.transform);
        }
        else if (levelData.currentLevel == LevelData.Levels.Level2)
        {
            currentMapCoins = Instantiate(levelData.mapCoins[1], gameObject.transform);
        }
        else if (levelData.currentLevel == LevelData.Levels.Level3)
        {
            currentMapCoins = Instantiate(levelData.mapCoins[2], gameObject.transform);
        }
        else if (levelData.currentLevel == LevelData.Levels.Level4)
        {
            currentMapCoins = Instantiate(levelData.mapCoins[3], gameObject.transform);
        }
        else if (levelData.currentLevel == LevelData.Levels.Level5)
        {
            currentMapCoins = Instantiate(levelData.mapCoins[4], gameObject.transform);
        }
        else if (levelData.currentLevel == LevelData.Levels.Level6)
        {
            currentMapCoins = Instantiate(levelData.mapCoins[5], gameObject.transform);
        }
        else if (levelData.currentLevel == LevelData.Levels.Level7)
        {
            currentMapCoins = Instantiate(levelData.mapCoins[6], gameObject.transform);
        }
        else if (levelData.currentLevel == LevelData.Levels.Level8)
        {
            currentMapCoins = Instantiate(levelData.mapCoins[7], gameObject.transform);
        }
        else if (levelData.currentLevel == LevelData.Levels.Level9)
        {
            currentMapCoins = Instantiate(levelData.mapCoins[8], gameObject.transform);
        }
        else if (levelData.currentLevel == LevelData.Levels.Level10)
        {
            currentMapCoins = Instantiate(levelData.mapCoins[9], gameObject.transform);
        }

    }
    public void CreateCoins(int levelCount)
    {
        Destroy(currentMapCoins);
        currentMapCoins = Instantiate(levelData.mapCoins[levelCount], gameObject.transform);
    }
}
