using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    [Header("Coin Values")]
    public int currentStaticCoinValue;
    public int firstLevelStaticCoinValue;
    public int secondLevelStaticCoinValue;
    public int thirdLevelStaticCoinValue;
    public int fourthLevelStaticCoinValue;

    [Header("Level SkyBoxes")]
    public Material firstSkybox;
    public Material secondMapSkyBox;
    public Material thirdSkybox;
    public Material fourthSkybox;

    [Header("Level Difficulty")]
    public float currentEnemyDetectionDistance;
    public float level1EnemyDetectionDistance;
    public float level2EnemyDetectionDistance;
    public float level3EnemyDetectionDistance;
    public float level4EnemyDetectionDistance;

    [Header("Enemy Spawn")]
    public int currentEnemySpawnDelay;
    public int firstMapEnemySpawnDelay;
    public int secondMapEnemySpawnDelay;
    public int thirdMapEnemySpawnDelay;
    public int fourthMapEnemySpawnDelay;

    [Header("Mirror")]
    public string currentMirrorName;
    public GameObject[] _firstMapMirrorCouples;
    public GameObject[] _secondMapMirrorCouples;
    public GameObject[] _thirdMapMirrorCouples;
    public GameObject[] _fourthMapMirrorCouples;


    [Header("Finishes")]
    public Transform currentFinishArea;
    public Transform level1FinishArea;
    public Transform level2FinishArea;
    public Transform level3FinishArea;
    public Transform level4FinishArea;

    [Header("MapCompleteBools")]
    public bool isCompleteFirstMap;
    public bool isCompleteSecondMap;
    public bool isCompleteThirdMap;
    public bool isCompleteFourthMap;

    [Header("MapFinishTargetBools")]
    public bool isFirstMapTarget;
    public bool isSecondMapTarget;
    public bool isThirdMapTarget;
    public bool isFourthMapTarget;
    public bool isLevelUp;

    [Header("Clone Target")]
    public Transform firstTarget;
    public Transform secondTarget;
    public Transform thirdTarget;
    public Transform finishTarget;
    public Transform currentTarget;

    [Header("Level SkyBoxes")]
    public MapNames currentMapName;

    [Header("Current Level")]
    public Levels currentLevel;

    public enum MapNames
    {
        FirstMap,
        SecondMap,
        ThirdMap,
        FourthMap
    }
    public enum Levels
    {
        Level1,
        Level2,
        Level3,
        Level4
    }

    

}
