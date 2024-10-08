using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;

    private GameObject currentMapCoins;
    private GameObject _coinObject;

    float max1 = 0;
    float max2 = 0;
    int max = 0;


    Transform randomTransform;

    public void SetCoinValue(int levelCount)
    {
        levelData.currentStaticCoinValue = levelData.coinlevelValues[levelCount];
    }

    
    void Awake()
    {
        CreateObjects(levelData.levelRectangles[LevelData.currentLevelCount], levelData._rotaterCoinObject, .5f);
        CreateObjects(levelData.levelRectangles[LevelData.currentLevelCount], levelData._rotaterBulletCoinObject, .25f);
        CreateObjects(levelData.levelRectangles[LevelData.currentLevelCount], levelData._coinGroupObject, .2f);
        CreateObjects(levelData.levelRectangles[LevelData.currentLevelCount], levelData._cheeseObject, .2f);
        CreateObjects(levelData.levelRectangles[LevelData.currentLevelCount], levelData._mushroomObject, .1f);
        CreateObjects(levelData.levelRectangles[LevelData.currentLevelCount], levelData._levelUpKeyObject, .1f);
        CreateObjects(levelData.levelRectangles[LevelData.currentLevelCount], levelData._healtCoinObject, .2f);
    }

    void CreateObjects(GameObject currentLevelRectangleObject, GameObject coinObject, float maxValueDecreaser)
    {
        _coinObject = Instantiate(currentLevelRectangleObject, gameObject.transform);

        for (int i = 0; i < _coinObject.transform.childCount; i++)
        {
            CalculateCountOfCreateableObject(i, maxValueDecreaser);
            for (int j = 0; j < max; j++)
            {
                GameObject randomy = Instantiate(coinObject, _coinObject.transform.GetChild(i));
                randomTransform = randomy.transform;
                CreateRandomPosition(coinObject, i);
            }            
        }
    }
    void CalculateCountOfCreateableObject(int i, float maxValueDecreaser)
    {
        max1 = 0;
        max2 = 0;
        max = 0;
        max1 = Mathf.Abs(Mathf.Abs(_coinObject.transform.GetChild(i).GetChild(1).localPosition.x) - Mathf.Abs(_coinObject.transform.GetChild(i).GetChild(3).localPosition.x));
        max2 = Mathf.Abs(Mathf.Abs(_coinObject.transform.GetChild(i).GetChild(0).localPosition.z) - Mathf.Abs(_coinObject.transform.GetChild(i).GetChild(2).localPosition.z));
        if (max1 > max2)
        {
            max = (int)(max1 * maxValueDecreaser);
        }
        else
        {
            max = (int)(max2 * maxValueDecreaser);
        }
    }

    void CreateRandomPosition(GameObject coinObject, int i)
    {
        randomTransform.localPosition = new Vector3(Random.Range(_coinObject.transform.GetChild(i).GetChild(1).localPosition.x,
                                                                     _coinObject.transform.GetChild(i).GetChild(3).localPosition.x),
                                                        coinObject.transform.localPosition.y,
                                                        Random.Range(_coinObject.transform.GetChild(i).GetChild(0).localPosition.z,
                                                                     _coinObject.transform.GetChild(i).GetChild(2).localPosition.z));
    }
}
