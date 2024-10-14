using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public PlayerData playerData;
    public EnemyData enemyData;
    public LevelData levelData;

    public Transform targetTransform;

    public ObjectPool _objectPool;

    public EnemyObjectPool enemyObjectPool;
    private GameObject currentEnemyObjects;

    public LayerMask layerMask;


    [SerializeField] Transform enemySpawnTransform;

    public static GameObject enemyTransformsObject;
    public static int iValue;

    private GameObject playerBulletObject;

    [SerializeField] Transform _bulletCoinSpawn;

    private GameObject bossEnemyTransformObject;//For Checking Boss is Dead OR Not
    public static GameObject[] bossEnemyBoxes = new GameObject[2];

    public static bool bossIsDead;

    

    private void Start()
    {
        targetTransform = PlayerManager.GetInstance.gameObject.transform;

        bossIsDead = false;

        EnemyData.enemyDeathCount = 0;
        enemyData.isActivateCreateEnemy = false;

        CreateEnemiesAtStart(LevelData.currentLevelCount);
    }

    
    void CreateEnemiesAtStart(int levelCount)
    {
        enemyTransformsObject = Instantiate(levelData.enemyTransformsInMap[levelCount].gameObject, gameObject.transform);

        SetEnemyObjectsAtStart(); //Setted Enemy Object Character Before Instantiate Enemy Objects

        if (GameObject.Find("bossEnemyTransform"))
        {
            bossEnemyTransformObject = GameObject.Find("bossEnemyTransform");
        }
        if (GameObject.Find("bossEnemyBox"))
        {
            bossEnemyBoxes[0] = GameObject.Find("bossEnemyBox");
        }
        if (GameObject.Find("bossEnemyBox1"))
        {
            bossEnemyBoxes[1] = GameObject.Find("bossEnemyBox1");
        }
        else
        {
            bossEnemyBoxes[1] = GameObject.Find("bossEnemyBox");
        }
    }
    void SetEnemyObjectsAtStart()
    {
        if (levelData.currentLevel == LevelData.Levels.Level1)
        {
            levelData.currentEnemyObjects = levelData.enemyFirstObjects;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level2)
        {
            levelData.currentEnemyObjects = levelData.enemySecondObjects;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level3)
        {
            levelData.currentEnemyObjects = levelData.enemyThirdObjects;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level4)
        {
            levelData.currentEnemyObjects = levelData.enemyFourthObjects;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level5)
        {
            levelData.currentEnemyObjects = levelData.enemyFifthObjects;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level6)
        {
            levelData.currentEnemyObjects = levelData.enemySixthObjects;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level7)
        {
            levelData.currentEnemyObjects = levelData.enemySeventhObjects;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level8)
        {
            levelData.currentEnemyObjects = levelData.enemyEightthObjects;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level9)
        {
            levelData.currentEnemyObjects = levelData.enemyNinethObjects;
        }
        else if (levelData.currentLevel == LevelData.Levels.Level10)
        {
            levelData.currentEnemyObjects = levelData.enemyTenthObjects;
        }
    }
}
