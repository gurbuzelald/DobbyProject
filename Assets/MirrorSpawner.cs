using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSpawner : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;

    private GameObject _currentMirrorCouple;
    void Awake()
    {
        if (_playerData.currentMapName == PlayerData.MapNames.FirstMap)
        {
            for (int i = 0; i < _playerData._firstMapMirrorCouples.Length; i++)
            {
                _currentMirrorCouple = Instantiate(_playerData._firstMapMirrorCouples[i], gameObject.transform);
            }
        }
        if (_playerData.currentMapName == PlayerData.MapNames.SecondMap)
        {
            for (int i = 0; i < _playerData._secondMapMirrorCouples.Length; i++)
            {
                _currentMirrorCouple = Instantiate(_playerData._secondMapMirrorCouples[i], gameObject.transform);
            }
        }
        if (_playerData.currentMapName == PlayerData.MapNames.ThirdMap)
        {
            for (int i = 0; i < _playerData._thirdMapMirrorCouples.Length; i++)
            {
                _currentMirrorCouple = Instantiate(_playerData._thirdMapMirrorCouples[i], gameObject.transform);
            }
        }
        if (_playerData.currentMapName == PlayerData.MapNames.FourthMap)
        {
            for (int i = 0; i < _playerData._fourthMapMirrorCouples.Length; i++)
            {
                _currentMirrorCouple = Instantiate(_playerData._fourthMapMirrorCouples[i], gameObject.transform);
            }
        }
    }
    public void CreateSecondMapMirror()
    {
        Destroy(_currentMirrorCouple);


        for (int i = 0; i < _playerData._secondMapMirrorCouples.Length; i++)
        {
            _currentMirrorCouple = Instantiate(_playerData._secondMapMirrorCouples[i], gameObject.transform);
        }
    }
    public void CreateThirdMapMirror()
    {
        Destroy(_currentMirrorCouple);

        for (int i = 0; i < _playerData._thirdMapMirrorCouples.Length; i++)
        {
            _currentMirrorCouple = Instantiate(_playerData._thirdMapMirrorCouples[i], gameObject.transform);
        }
    }
    public void CreateFourthMapMirror()
    {
        Destroy(_currentMirrorCouple);

        for (int i = 0; i < _playerData._fourthMapMirrorCouples.Length; i++)
        {
            _currentMirrorCouple = Instantiate(_playerData._fourthMapMirrorCouples[i], gameObject.transform);
        }
    }
}
