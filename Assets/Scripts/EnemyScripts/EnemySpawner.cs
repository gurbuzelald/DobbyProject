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

        /*for (int i = 0; i < enemyTransformsObject.transform.childCount; i++)
        {
            iValue = i;
            levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[levelCount];

            currentEnemyObjects = Instantiate(levelData.currentEnemyObjects[i],
                                         enemyTransformsObject.transform.GetChild(i).position,
                                         Quaternion.identity,
                                         enemyTransformsObject.transform.GetChild(i).transform);
            if (PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(17))
            {
                currentEnemyObjects = PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(17);

                currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyDataNumber = i;
                currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyBulletDataNumber = i;
                currentEnemyObjects.transform.position = new Vector3(enemyTransformsObject.transform.GetChild(i).position.x,
                                                                     10f,
                                                                     enemyTransformsObject.transform.GetChild(i).position.z);
            }            
        }*/
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
    IEnumerator CreateBulletCoin(int i)
    {
        yield return new WaitForSeconds(2);

        if (gameObject.transform.GetChild(0).GetChild(i).transform.childCount == 0)
        {
            if (enemyData)
                playerBulletObject = Instantiate(enemyData._playerBulletObject,
                                                new Vector3(gameObject.transform.GetChild(0).GetChild(i).transform.position.x,
                                                            enemyData._playerBulletObject.transform.position.y,
                                                            gameObject.transform.GetChild(0).GetChild(i).transform.position.z),
                                                Quaternion.identity,
                                                gameObject.transform.GetChild(0).GetChild(i).transform);


            //bulletCoinCount++;

            playerBulletObject.transform.eulerAngles = new Vector3(0f,
                                                                   gameObject.transform.GetChild(0).GetChild(i).transform.eulerAngles.y + 90f,
                                                                   90f);

            //Destroy(_bulletCoinSpawn.transform.GetChild(0).GetChild(i).GetChild(0).gameObject, 10f);


            StartCoroutine(DelayDestroy());
        }
        

    }
    IEnumerator DelayDestroy()
    {
        yield return new WaitForSeconds(5f);
        if (_bulletCoinSpawn.childCount != 0)
        {
            Destroy(_bulletCoinSpawn.transform.GetChild(0).gameObject);
        }
        Destroy(playerBulletObject);

    }
    private void Update()
    {
        CheckEnemyDeath();

        if (bossEnemyTransformObject != null)
        {
            if (bossEnemyTransformObject.transform.childCount == 0 ||
                (bossEnemyTransformObject.transform.childCount == 1 &&
                bossEnemyTransformObject.transform.GetChild(0).name == "Bullet(Clone)"))
            {
                bossIsDead = true;
            }
        }        
    }
    void CheckEnemyDeath()
    {
        if (gameObject.transform.childCount != 0)
        {
            for (int i = 0; i < gameObject.transform.GetChild(0).transform.childCount; i++)
            {//if enemyTransformObject's childCount equals zero, destroy enemyTransformObject.
             //This code is for getting enemies amount.                

                if ((gameObject.transform.GetChild(0).GetChild(i).name == "BulletCoin(Clone)" || 
                    gameObject.transform.GetChild(0).GetChild(i).childCount == 0) &&
                    gameObject.transform.GetChild(0).GetChild(i).name != "bossEnemyTransform")
                {
                    CheckEnemyDeathForLevels(i, levelData.currentEnemyObjects);                    
                }
                if (gameObject.transform.GetChild(0).GetChild(i).childCount == 0)
                {
                    //StartCoroutine(CreateBulletCoin(i));
                }
            }
        }
    }
    void CheckEnemyDeathForLevels(int i, GameObject[] enemyObjects)
    {
        CheckEnemyDeathWithLevels(i, enemyObjects);
    }
    void CheckEnemyDeathWithLevels(int i, GameObject[] enemyObjects)
    {
        if (levelData.currentLevel == LevelData.Levels.Level1)
        {

            
        }
        if (enemyData.isActivateCreateEnemy)
        {
            currentEnemyObjects = Instantiate(enemyObjects[i],
                                 enemyTransformsObject.transform.GetChild(i).position,
                                 Quaternion.identity,
                                 enemyTransformsObject.transform.GetChild(i).transform);

            currentEnemyObjects.transform.position =
                new Vector3(enemyTransformsObject.transform.GetChild(i).position.x,
                            10f,
                            enemyTransformsObject.transform.GetChild(i).position.z);
            enemyData.isActivateCreateEnemy = false;
        }
    }


    public void CreateEnemiesByMap(int levelCount)
    {
        levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[levelCount];

        Destroy(enemyTransformsObject);
        enemyTransformsObject = Instantiate(levelData.enemyTransformsInMap[levelCount].gameObject, 
                                           gameObject.transform);


        CreateEnemyInUpdate(currentEnemyObjects, enemyTransformsObject, levelData.currentEnemyObjects);
    }
    void CreateEnemyInUpdate(GameObject currentEnemyObjects, GameObject enemyTransformObject, GameObject[] enemyObjects)
    {
        for (int i = 0; i < levelData.enemySecondObjects.Length; i++)
        {
            currentEnemyObjects = Instantiate(enemyObjects[i],//enemySecondObjects[i]
                                     enemyTransformObject.transform.GetChild(i).position,
                                     Quaternion.identity,
                                     enemyTransformObject.transform.GetChild(i).transform);
            currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                             10f,
                                                             enemyTransformObject.transform.GetChild(i).position.z);
            currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyDataNumber = i;
            currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyBulletDataNumber = i;
        }
    }
}
