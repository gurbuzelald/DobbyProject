using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCoinSpawner : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    private GameObject _healtCoinTransform;
    void Awake()
    {
        if (_playerData.currentMapName == PlayerData.MapNames.FirstMap)
        {
            _healtCoinTransform = Instantiate(_playerData._healtCoinTransform[0], gameObject.transform);
        }
        else if (_playerData.currentMapName == PlayerData.MapNames.SecondMap)
        {
            _healtCoinTransform = Instantiate(_playerData._healtCoinTransform[1], gameObject.transform);
        }
        else if (_playerData.currentMapName == PlayerData.MapNames.ThirdMap)
        {
            _healtCoinTransform = Instantiate(_playerData._healtCoinTransform[2], gameObject.transform);
        }
        else if (_playerData.currentMapName == PlayerData.MapNames.FourthMap)
        {
            _healtCoinTransform = Instantiate(_playerData._healtCoinTransform[3], gameObject.transform);
        }
        for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
        {
            Instantiate(_playerData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
        }
    }
    private void Update()
    {
        KeepCleanGameScene();
    }
    public void CreateSecondtMapHealthCoin()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);

        _healtCoinTransform = Instantiate(_playerData._healtCoinTransform[1], gameObject.transform);

        for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
        {
            Instantiate(_playerData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
        }
    }
    public void CreateThirdMapHealthCoin()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);

        _healtCoinTransform = Instantiate(_playerData._healtCoinTransform[2], gameObject.transform);

        for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
        {
            Instantiate(_playerData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
        }
    }
    public void CreateFourthMapHealthCoin()
    {
        Destroy(gameObject.transform.GetChild(0).gameObject);

        _healtCoinTransform = Instantiate(_playerData._healtCoinTransform[3], gameObject.transform);

        for (int i = 0; i < _healtCoinTransform.transform.childCount; i++)
        {
            Instantiate(_playerData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
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
