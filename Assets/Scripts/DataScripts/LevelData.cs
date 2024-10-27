using System;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLevelData", menuName = "Scriptable Objects/LevelData")]
public class LevelData : ScriptableObject
{

    [Header("Player Level Spawns")]
    public Transform playerSpawns;

    [Serializable]
    public struct LevelUpRequirements
    {
        public int enemyKills;
        public int coinCollectAmount;
        public int levelUpKeys;
        public bool isBossEnemyDead;
    }
    public LevelUpRequirements[] levelUpRequirements = new LevelUpRequirements[10];

    [Serializable]
    public struct Levels
    {
        public int id;
        public string name;
        public string finishAreaName;//FirstFinishArea
    }
    public Levels[] levels = new Levels[10];

    [Serializable]
    public struct LevelStates
    {
        public GameObject mapObject;
        public GameObject mirrorCouple;
        public GameObject levelRectangle;
        public GameObject enemySpawnInMap;
        public Transform finishTransform;
        public Material levelSkybox;
        public float enemyDetectionDistance;
        public int coinlevelValue;
        public float backToWalkingDelay;
        public bool isCompleteMap;
    }
    public LevelStates[] levelStates = new LevelStates[10];

    public string GetCurrentLevelName()
    {
        for (int i = 0; i < levels.Length; i++)
        {
            if (currentLevelId == levels[i].id)
            {
                return $"Level {i + 1}";
            }
        }
        return string.Empty; // Return an empty string if no match is found
    }

    public GameObject _rotaterCoinObject;
    public GameObject _rotaterBulletCoinObject;
    public GameObject _coinGroupObject;
    public GameObject _cheeseObject;
    public GameObject _mushroomObject;
    public GameObject _levelUpKeyObject;
    public GameObject _healtCoinObject;

    public static int highestLevel;
    public static bool levelCanBeSkipped;
    public static bool isLevelUp;

    public float currentEnemyDetectionDistance;
    public static int currentOwnedLevelUpKeys;
    public static int currentLevelId;
    public static string currentLevelName;
    public string currentMirrorName;
    public float currentBackToWalkingValue;
    public int currentStaticCoinValue;
    public Transform currentFinishArea;
    
}
