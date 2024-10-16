using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "LevelData")]
public class LevelData : ScriptableObject
{
    [Serializable]
    public struct LevelUpRequirements
    {
        public int enemyKills;
        public int coinCollectAmount;
        public int levelUpKeys;
        public bool isBossEnemyDead;
    }
    public LevelUpRequirements[] levelUpRequirements = new LevelUpRequirements[10];

    public GameObject _rotaterCoinObject;
    public GameObject _rotaterBulletCoinObject;
    public GameObject _coinGroupObject;
    public GameObject _cheeseObject;
    public GameObject _mushroomObject;
    public GameObject _levelUpKeyObject;

    public static int highestLevel;

    public static int currentLevelUpRequirement;
    public static int currentOwnedLevelUpKeys;
    public static bool levelCanBeSkipped;

    [Header("Enemy Level Speeds Ranges")]    
    public float[] levelEnemyMinSpeed;
    public float[] levelEnemyMaxSpeed;

    [Header("Level Finish Area Names")]
    public const string FirstFinishArea = "FirstFinishArea";
    public const string SecondFinishArea = "SecondFinishArea";
    public const string ThirdFinishArea = "ThirdFinishArea";
    public const string FourthFinishArea = "FourthFinishArea";
    public const string FifthFinishArea = "FifthFinishArea";
    public const string SixthFinishArea = "SixthFinishArea";
    public const string SeventhFinishArea = "SeventhFinishArea";
    public const string EighthFinishArea = "EighthFinishArea";
    public const string NinethFinishArea = "NinethFinishArea";
    public const string TenthFinishArea = "TenthFinishArea";

    [Header("Coin Transforms")]
    public GameObject[] mapCoins;
    public GameObject[] levelRectangles;
    public GameObject _healtCoinObject;

    [Header("Map Objects")]
    public GameObject[] Maps;

    [Header("Enemy Back To Walking")]
    public float currentBackToWalkingValue;
    public float[] backToWalkingDelays; 

    [Header("Enemy Level Objects")]
    public GameObject[] currentEnemyObjects;
    public GameObject[] enemyFirstObjects;
    public GameObject[] enemySecondObjects;
    public GameObject[] enemyThirdObjects;
    public GameObject[] enemyFourthObjects;
    public GameObject[] enemyFifthObjects;
    public GameObject[] enemySixthObjects;
    public GameObject[] enemySeventhObjects;
    public GameObject[] enemyEightthObjects;
    public GameObject[] enemyNinethObjects;
    public GameObject[] enemyTenthObjects;

    public GameObject[] enemyTransformsInMap;

    [Header("Coin Values")]
    public int currentStaticCoinValue;

    public int[] coinlevelValues;

    [Header("Level SkyBoxes")]
    public Material[] levelSkyboxes;

    [Header("Level Difficulty")]
    public float currentEnemyDetectionDistance;
    public float[] enemyDetectionDistances;

    [Header("Mirror")]
    public string currentMirrorName;
    public GameObject[] mirrorCouples;


    [Header("Finishes")]
    public Transform currentFinishArea;
    public Transform[] finishTransforms;

    [Header("MapCompleteBools")]
    public bool[] isCompleteMaps;

    [Header("MapFinishTargetBools")]
    public bool isLevelUp;

    [Header("Current Level")]
    public Levels currentLevel;
    public static int currentLevelId;

    public enum Levels
    {
        Level1,
        Level2,
        Level3,
        Level4,
        Level5,
        Level6,
        Level7,
        Level8,
        Level9,
        Level10,
    }

    

}
