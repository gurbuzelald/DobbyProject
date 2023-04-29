using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSpawner : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] GameObject[] _mirrorCouple;

    private GameObject _currentMirrorCouple;
    void Awake()
    {
        for (int i = 0; i < _mirrorCouple.Length; i++)
        {
            _currentMirrorCouple = Instantiate(_mirrorCouple[i], gameObject.transform);
        }
    }
    void Update()
    {
        if (_playerData.isCompleteFirstMap)
        {
            Destroy(_currentMirrorCouple);

            Debug.Log("Test");
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
            }
        }
        else if (_playerData.isCompleteSecondMap)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Destroy(_currentMirrorCouple);
            }
        }
        else if (_playerData.isCompleteThirdMap)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Destroy(_currentMirrorCouple);
            }
        }
        else if (_playerData.isCompleteFourthMap)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                Destroy(_currentMirrorCouple);
            }
        }
    }
}
