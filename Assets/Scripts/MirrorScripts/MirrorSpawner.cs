using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSpawner : MonoBehaviour
{
    [SerializeField] PlayerData _playerData;
    [SerializeField] LevelData levelData;

    private GameObject _currentMirrorCouple;
    void Awake()
    {
        if (levelData.currentMapName == LevelData.MapNames.FirstMap)
        {
            for (int i = 0; i < levelData._firstMapMirrorCouples.Length; i++)
            {
                _currentMirrorCouple = Instantiate(levelData._firstMapMirrorCouples[i], gameObject.transform);
            }
        }
        if (levelData.currentMapName == LevelData.MapNames.SecondMap)
        {
            for (int i = 0; i < levelData._secondMapMirrorCouples.Length; i++)
            {
                _currentMirrorCouple = Instantiate(levelData._secondMapMirrorCouples[i], gameObject.transform);
            }
        }
        if (levelData.currentMapName == LevelData.MapNames.ThirdMap)
        {
            for (int i = 0; i < levelData._thirdMapMirrorCouples.Length; i++)
            {
                _currentMirrorCouple = Instantiate(levelData._thirdMapMirrorCouples[i], gameObject.transform);
            }
        }
        if (levelData.currentMapName == LevelData.MapNames.FourthMap)
        {
            for (int i = 0; i < levelData._fourthMapMirrorCouples.Length; i++)
            {
                _currentMirrorCouple = Instantiate(levelData._fourthMapMirrorCouples[i], gameObject.transform);
            }
        }
    }
    public void CreateSecondMapMirror()
    {
        Destroy(_currentMirrorCouple);


        for (int i = 0; i < levelData._secondMapMirrorCouples.Length; i++)
        {
            _currentMirrorCouple = Instantiate(levelData._secondMapMirrorCouples[i], gameObject.transform);
        }
    }
    public void CreateThirdMapMirror()
    {
        Destroy(_currentMirrorCouple);

        for (int i = 0; i < levelData._thirdMapMirrorCouples.Length; i++)
        {
            _currentMirrorCouple = Instantiate(levelData._thirdMapMirrorCouples[i], gameObject.transform);
        }
    }
    public void CreateFourthMapMirror()
    {
        Destroy(_currentMirrorCouple); 

        for (int i = 0; i < levelData._fourthMapMirrorCouples.Length; i++)
        {
            _currentMirrorCouple = Instantiate(levelData._fourthMapMirrorCouples[i], gameObject.transform);
        }
    }
}  