using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    [Header("Coin Transforms")]
    public GameObject[] mapCoins;
    public GameObject[] _healtCoinTransform;
    public GameObject _healtCoinObject;

    [Header("Map Objects")]
    public GameObject[] Maps;

    [Header("Enemy Level Objects")]
    public GameObject[] enemyFirstObjects;
    public GameObject[] enemySecondObjects;
    public GameObject[] enemyThirdObjects;
    public GameObject[] enemyFourthObjects;
    public GameObject[] enemyFifthObjects;
    public GameObject enemyTransformsFirstMap;
    public GameObject enemyTransformsSecondMap;
    public GameObject enemyTransformsThirdMap;
    public GameObject enemyTransformsFourthMap;
    public GameObject enemyTransformsFifthMap;

    [Header("Coin Values")]
    public int currentStaticCoinValue;
    public int firstLevelStaticCoinValue;
    public int secondLevelStaticCoinValue;
    public int thirdLevelStaticCoinValue;
    public int fourthLevelStaticCoinValue;
    public int fifthLevelStaticCoinValue;

    [Header("Level SkyBoxes")]
    public Material firstSkybox;
    public Material secondMapSkyBox;
    public Material thirdSkybox;
    public Material fourthSkybox;
    public Material fifthSkybox;

    [Header("Level Difficulty")]
    public float currentEnemyDetectionDistance;
    public float level1EnemyDetectionDistance;
    public float level2EnemyDetectionDistance;
    public float level3EnemyDetectionDistance;
    public float level4EnemyDetectionDistance;
    public float level5EnemyDetectionDistance;

    [Header("Enemy Spawn")]
    public int currentEnemySpawnDelay;
    public int firstMapEnemySpawnDelay;
    public int secondMapEnemySpawnDelay;
    public int thirdMapEnemySpawnDelay;
    public int fourthMapEnemySpawnDelay;
    public int fifthMapEnemySpawnDelay;

    [Header("Mirror")]
    public string currentMirrorName;
    public GameObject[] _firstMapMirrorCouples;
    public GameObject[] _secondMapMirrorCouples;
    public GameObject[] _thirdMapMirrorCouples;
    public GameObject[] _fourthMapMirrorCouples;
    public GameObject[] _fifthMapMirrorCouples;


    [Header("Finishes")]
    public Transform currentFinishArea;
    public Transform level1FinishArea;
    public Transform level2FinishArea;
    public Transform level3FinishArea;
    public Transform level4FinishArea;
    public Transform level5FinishArea;

    [Header("MapCompleteBools")]
    public bool isCompleteFirstMap;
    public bool isCompleteSecondMap;
    public bool isCompleteThirdMap;
    public bool isCompleteFourthMap;
    public bool isCompleteFifthMap;

    [Header("MapFinishTargetBools")]
    public bool isFirstMapTarget;
    public bool isSecondMapTarget;
    public bool isThirdMapTarget;
    public bool isFourthMapTarget;
    public bool isFifthMapTarget;
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
        FourthMap,
        FifthMap
    }
    public enum Levels
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }

    

}
