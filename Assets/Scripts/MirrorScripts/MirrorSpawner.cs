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
        CreateTransportMirror(LevelUpController.currentLevelCount);
    }
    public void CreateTransportMirror(int levelCount)
    {
        Destroy(_currentMirrorCouple);
        _currentMirrorCouple = Instantiate(levelData.mirrorCouples[levelCount], gameObject.transform);
    }
    
}  