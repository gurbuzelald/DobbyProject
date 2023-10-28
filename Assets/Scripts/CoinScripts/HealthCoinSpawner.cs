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
        if (levelData.currentMapName == LevelData.MapNames.FirstMap)
        {
            _healtCoinTransform = Instantiate(levelData._healtCoinTransform[0], gameObject.transform);
        }
        else if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            _healtCoinTransform = Instantiate(levelData._healtCoinTransform[1], gameObject.transform);
        }
        else if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            _healtCoinTransform = Instantiate(levelData._healtCoinTransform[2], gameObject.transform);
        }
        else if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            _healtCoinTransform = Instantiate(levelData._healtCoinTransform[3], gameObject.transform);
        }
        else if (levelData.currentMapName == LevelData.MapNames.FifthMap)
        {
            _healtCoinTransform = Instantiate(levelData._healtCoinTransform[4], gameObject.transform);
        }
        for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
        {
            Instantiate(levelData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
        }
    }
    private void Update()
    {
        KeepCleanGameScene();
    }
    public void CreateSecondtMapHealthCoin()
    {
        if (gameObject)
        {
            Destroy(gameObject.transform.GetChild(0).gameObject);
        }
       

        _healtCoinTransform = Instantiate(levelData._healtCoinTransform[1], gameObject.transform);

        for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
        {
            Instantiate(levelData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
        }
    }
    public void CreateThirdMapHealthCoin()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);

        _healtCoinTransform = Instantiate(levelData._healtCoinTransform[2], gameObject.transform);

        for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
        {
            Instantiate(levelData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
        }
    }
    public void CreateFourthMapHealthCoin()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);

        _healtCoinTransform = Instantiate(levelData._healtCoinTransform[3], gameObject.transform);

        for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
        {
            Instantiate(levelData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
        }
    }
    public void CreateFifthMapHealthCoin()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);

        _healtCoinTransform = Instantiate(levelData._healtCoinTransform[4], gameObject.transform);

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
