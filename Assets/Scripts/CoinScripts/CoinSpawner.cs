using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;

    private GameObject currentMapCoins;
    private GameObject _coinObject;


    Transform randomTransform;

    public void SetCoinValue(int levelID)
    {
        levelData.currentStaticCoinValue = levelData.levelStates[levelID].coinlevelValue;
    }


    void Awake()
    {
        GameObject currentLevelRectangle = levelData.levelStates[levelData.currentLevelId].levelRectangle;

        CreateMultipleObjects(currentLevelRectangle, new (GameObject, float)[]
        {
        (levelData._rotaterCoinObject, 0),
        (levelData._rotaterBulletCoinObject, 0),
        (levelData._coinGroupObject, 0),
        (levelData._cheeseObject, 0),
        (levelData._mushroomObject, 0),
        (levelData._levelUpKeyObject, 0),
        (levelData._healtCoinObject, 0)
        });
    }

    void CreateMultipleObjects(GameObject currentLevelRectangleObject, (GameObject coinObject, float maxValueDecreaser)[] objectDataArray)
    {
        // Instantiate level rectangle object once
        _coinObject = Instantiate(currentLevelRectangleObject, gameObject.transform);

        for (int i = 0; i < objectDataArray.Length; i++)
        {
            CreateObjects(objectDataArray[i].coinObject, objectDataArray[i].maxValueDecreaser);
        }
    }

    void CreateObjects(GameObject coinObject, float maxValueDecreaser)
    {
        // Loop through children of the _coinObject transform
        for (int i = 0; i < _coinObject.transform.childCount; i++)
        {
            // Calculate the number of objects to create
            int objectCount = CalculateCountOfCreateableObject(i, maxValueDecreaser);

            // Cache the current child transform
            Transform currentChild = _coinObject.transform.GetChild(i);

            // Instantiate coin objects
            for (int j = 0; j < objectCount; j++)
            {
                GameObject newCoin = Instantiate(coinObject, currentChild);

                // Set random position for the newly created coin
                SetRandomPosition(newCoin.transform, currentChild);
            }
        }
    }

    int CalculateCountOfCreateableObject(int i, float maxValueDecreaser)
    {
        // Cache the current child
        Transform child = _coinObject.transform.GetChild(i);

        // Cache the corner points of the current child for better performance
        Vector3 corner1 = child.GetChild(1).localPosition;
        Vector3 corner2 = child.GetChild(3).localPosition;
        Vector3 corner3 = child.GetChild(0).localPosition;
        Vector3 corner4 = child.GetChild(2).localPosition;

        // Calculate differences
        float xDifference = Mathf.Abs(corner1.x - corner2.x);
        float zDifference = Mathf.Abs(corner3.z - corner4.z);

        // Return the maximum difference scaled by maxValueDecreaser
        return (int)(Mathf.Max(xDifference, zDifference) * maxValueDecreaser);
    }

    void SetRandomPosition(Transform coinTransform, Transform parentTransform)
    {
        // Cache the corner points of the parent to avoid repeated access
        Vector3 corner1 = parentTransform.GetChild(1).localPosition;
        Vector3 corner2 = parentTransform.GetChild(3).localPosition;
        Vector3 corner3 = parentTransform.GetChild(0).localPosition;
        Vector3 corner4 = parentTransform.GetChild(2).localPosition;

        // Set random position within the defined area
        coinTransform.localPosition = new Vector3(
            Random.Range(corner1.x, corner2.x),
            coinTransform.localPosition.y, // Maintain the y-position
            Random.Range(corner3.z, corner4.z)
        );
    }
}
