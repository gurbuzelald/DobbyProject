using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCoinSpawner : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    private GameObject _healtCoinTransform;
    void Awake()
    {
        _healtCoinTransform = Instantiate(_playerData._healtCoinTransform[0], gameObject.transform);
        for (int i = 0; i < _playerData._healtCoinTransform[0].transform.childCount; i++)
        {
            Instantiate(_playerData._healtCoinObject, _healtCoinTransform.transform.GetChild(i).position, Quaternion.identity, _healtCoinTransform.transform.GetChild(i));
        }
    }
    private void Update()
    {
        KeepClearTheScene();
    }

    void KeepClearTheScene()
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
