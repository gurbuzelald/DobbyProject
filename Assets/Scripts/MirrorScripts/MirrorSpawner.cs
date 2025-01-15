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
        CreateTransportMirror(levelData.currentLevelId);
    }
    public void CreateTransportMirror(int levelID)
    {
        _currentMirrorCouple = Instantiate(levelData.levelStates[levelID].mirrorCouple, gameObject.transform);
    }
    
}  