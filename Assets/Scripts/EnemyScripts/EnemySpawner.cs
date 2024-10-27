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

        MainEnemyData.enemyDeathCount = 0;
        enemyData.isActivateCreateEnemy = false;

        CreateEnemiesAtStart(LevelData.currentLevelId);
    }

    
    void CreateEnemiesAtStart(int levelID)
    {
        enemyTransformsObject = Instantiate(levelData.levelStates[levelID].enemySpawnInMap.gameObject, gameObject.transform);

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
}
