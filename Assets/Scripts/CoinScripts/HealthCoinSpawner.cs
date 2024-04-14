using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCoinSpawner : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] LevelData levelData;

    private GameObject _healtCoinTransform;
    void Awake()
    {
        _healtCoinTransform = Instantiate(levelData._healtCoinTransform[LevelData.currentLevelCount], gameObject.transform);

        for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
        {
            Instantiate(levelData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
        }
    }
    private void Update()
    {
        KeepCleanGameScene();
    }
    public void CreateMapHealthCoins(int levelCount)
    {
        if (gameObject)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }


        _healtCoinTransform = Instantiate(levelData._healtCoinTransform[levelCount], gameObject.transform);

        for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
        {
            Instantiate(levelData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
        }
    }
    void KeepCleanGameScene()
    {
        if (_healtCoinTransform)
        {
            for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
            {
                if (_healtCoinTransform.transform.GetChild(i).GetChild(0).GetChild(0).childCount == 0)
                {
                    Destroy(_healtCoinTransform.transform.GetChild(i).gameObject);
                }
            }
            if (_healtCoinTransform.transform.childCount == 0)
            {
                Destroy(_healtCoinTransform);
            }
        }
    }
}
