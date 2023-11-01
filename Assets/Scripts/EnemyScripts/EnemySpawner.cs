using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public PlayerData playerData;
    public EnemyData enemyData;
    public LevelData levelData;

    public Transform targetTransform;
    public ObjectPool _objectPool;
    public TextMeshProUGUI enemyCountText;   
    private GameObject currentEnemyObjects;

    public LayerMask layerMask;


    [SerializeField] Transform enemySpawnTransform;
    private GameObject enemyTransformObject;

    private static int bulletCoinCount;
    private GameObject playerBulletObject;

    [SerializeField] Transform _bulletCoinSpawn;


   
    private void Awake()
    {
        enemyData.isActivateCreateEnemy = false;
        bulletCoinCount = 0;

        CreateAwakeEnemies();

        //Debug.Log(gameObject.transform.childCount);
    }
    void CreateAwakeEnemies()
    {
        if (levelData.currentLevel == LevelData.Levels.Level1)
        {
            enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[0].gameObject, gameObject.transform);

            for (int i = 0; i < levelData.enemyTransformsInMap[0].transform.childCount; i++)
            {
                levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[0];
                currentEnemyObjects = Instantiate(levelData.enemyFirstObjects[i],
                                             enemyTransformObject.transform.GetChild(i).position,
                                             Quaternion.identity,
                                             enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                     10f,
                                                                     enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
       else if (levelData.currentLevel == LevelData.Levels.Level2)
       {
            enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[1].gameObject, gameObject.transform);

            for (int i = 0; i < levelData.enemyTransformsInMap[1].transform.childCount; i++)
            {
                levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[1];
                currentEnemyObjects = Instantiate(levelData.enemySecondObjects[i],
                                             enemyTransformObject.transform.GetChild(i).position,
                                             Quaternion.identity,
                                             enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                     10f,
                                                                     enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
        else if (levelData.currentLevel == LevelData.Levels.Level3)
        {
            enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[2].gameObject, gameObject.transform);

            for (int i = 0; i < levelData.enemyTransformsInMap[2].transform.childCount; i++)
            {
                levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[2];
                currentEnemyObjects = Instantiate(levelData.enemyThirdObjects[i],
                                             enemyTransformObject.transform.GetChild(i).position,
                                             Quaternion.identity,
                                             enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                     10f,
                                                                     enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
        else if (levelData.currentLevel == LevelData.Levels.Level4)
        {
            enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[3].gameObject, gameObject.transform);

            for (int i = 0; i < levelData.enemyTransformsInMap[3].transform.childCount; i++)
            {
                levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[3];
                currentEnemyObjects = Instantiate(levelData.enemyFourthObjects[i],
                                             enemyTransformObject.transform.GetChild(i).position,
                                             Quaternion.identity,
                                             enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                     10f,
                                                                     enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
        else if (levelData.currentLevel == LevelData.Levels.Level5)
        {
            enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[4].gameObject, gameObject.transform);

            for (int i = 0; i < levelData.enemyTransformsInMap[4].transform.childCount; i++)
            {
                levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[4];
                currentEnemyObjects = Instantiate(levelData.enemyFourthObjects[i],
                                             enemyTransformObject.transform.GetChild(i).position,
                                             Quaternion.identity,
                                             enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                     10f,
                                                                     enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
        //enemyCountText.text = gameObject.transform.GetChild(0).childCount.ToString();
    }
    IEnumerator CreateBulletCoin(int i)
    {
        //if (bulletCoinCount <= 0)
        //{
        //    if (_bulletCoinSpawn.childCount <= 3)
        //    {
                
        //    }

        //    
        //}
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
        yield return new WaitForSeconds(20f);
        if (_bulletCoinSpawn.childCount != 0)
        {
            Destroy(_bulletCoinSpawn.transform.GetChild(0).gameObject);
            //for (int i = 0; i < _bulletCoinSpawn.childCount; i++)
            //{
                
            //}
        }
        bulletCoinCount = 0;
        Destroy(playerBulletObject);

    }
    private void Update()
    {
        CheckEnemyDeath();
    }
    void CheckEnemyDeath()
    {
        if (gameObject.transform.childCount != 0)
        {
            for (int i = 0; i < gameObject.transform.GetChild(0).transform.childCount; i++)
            {//if enemyTransformObject's childCount equals zero, destroy enemyTransformObject. This code is for getting enemies amount.
                if (gameObject.transform.GetChild(0).GetChild(i).name == "BulletCoin(Clone)" || gameObject.transform.GetChild(0).GetChild(i).childCount == 0)
                {
                    CheckEnemyDeathForLevels(i);                    
                }
                if (gameObject.transform.GetChild(0).GetChild(i).childCount == 0)
                {
                    StartCoroutine(CreateBulletCoin(i));
                }
            }
        }
    }
    void CheckEnemyDeathForLevels(int i)
    {
        CheckEnemyDeathFirstMap(i);
        CheckEnemyDeathSecondMap(i);
        CheckEnemyDeathThirdMap(i);
        CheckEnemyDeathFourthMap(i);
    }
    void CheckEnemyDeathFirstMap(int i)
    {
        if (levelData.currentLevel == LevelData.Levels.Level1)
        {

            if (enemyData.isActivateCreateEnemy)
            {
                currentEnemyObjects = Instantiate(levelData.enemyFirstObjects[i],
                                     enemyTransformObject.transform.GetChild(i).position,
                                     Quaternion.identity,
                                     enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                 10f,
                                                 enemyTransformObject.transform.GetChild(i).position.z);
                enemyData.isActivateCreateEnemy = false;
            }
        }
    }
    void CheckEnemyDeathSecondMap(int i)
    {
        if (levelData.currentLevel == LevelData.Levels.Level2)
        {
            if (enemyData.isActivateCreateEnemy)
            {
                currentEnemyObjects = Instantiate(levelData.enemySecondObjects[i],
                                     enemyTransformObject.transform.GetChild(i).position,
                                     Quaternion.identity,
                                     enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                 10f,
                                                 enemyTransformObject.transform.GetChild(i).position.z);
                enemyData.isActivateCreateEnemy = false;
            }
        }
    }
    void CheckEnemyDeathThirdMap(int i)
    {
        if (levelData.currentLevel == LevelData.Levels.Level3)
        {
            if (enemyData.isActivateCreateEnemy)
            {
                currentEnemyObjects = Instantiate(levelData.enemyThirdObjects[i],
                                     enemyTransformObject.transform.GetChild(i).position,
                                     Quaternion.identity,
                                     enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                 10f,
                                                 enemyTransformObject.transform.GetChild(i).position.z);
                enemyData.isActivateCreateEnemy = false;
            }
        }
    }
    void CheckEnemyDeathFourthMap(int i)
    {
        if (levelData.currentLevel == LevelData.Levels.Level4)
        {
            if (enemyData.isActivateCreateEnemy)
            {
                currentEnemyObjects = Instantiate(levelData.enemyFourthObjects[i],
                                     enemyTransformObject.transform.GetChild(i).position,
                                     Quaternion.identity,
                                     enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                 10f,
                                                 enemyTransformObject.transform.GetChild(i).position.z);
                enemyData.isActivateCreateEnemy = false;
            }
        }
    }
    public void CreateSecondMapEnemies()
    {
        levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[1];

        Destroy(enemyTransformObject);
        enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[1].gameObject, gameObject.transform);

        //for (int i = 0; i < enemyData.enemySecondObjects.Length; i++)
        //{
        //    currentEnemyObjects = Instantiate(enemyData.enemySecondObjects[i],
        //                             enemyTransformObject.transform.GetChild(i).position,
        //                             Quaternion.identity,
        //                             enemyTransformObject.transform.GetChild(i).transform);
        //    currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
        //                                                     10f,
        //                                                     enemyTransformObject.transform.GetChild(i).position.z);
        //}
        CreateEnemyInUpdate(currentEnemyObjects, enemyTransformObject, levelData.enemySecondObjects);
    }
   
    public void CreateThirdMapEnemies()
    {
        levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[2];

        Destroy(enemyTransformObject);
        enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[2].gameObject, gameObject.transform);

        //for (int i = 0; i < enemyData.enemyThirdObjects.Length; i++)
        //{
        //    currentEnemyObjects = Instantiate(enemyData.enemyThirdObjects[i],
        //                             enemyTransformObject.transform.GetChild(i).position,
        //                             Quaternion.identity,
        //                             enemyTransformObject.transform.GetChild(i).transform);
        //    currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
        //                                                     10f,
        //                                                     enemyTransformObject.transform.GetChild(i).position.z);
        //}
        CreateEnemyInUpdate(currentEnemyObjects, enemyTransformObject, levelData.enemyThirdObjects);

    }
    public void CreateFourthMapEnemies()
    {
        levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[3];

        Destroy(enemyTransformObject);
        enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[3].gameObject, gameObject.transform);

        //for (int i = 0; i < enemyData.enemyFourthObjects.Length; i++)
        //{
        //    currentEnemyObjects = Instantiate(enemyData.enemyFourthObjects[i],
        //                             enemyTransformObject.transform.GetChild(i).position,
        //                             Quaternion.identity,
        //                             enemyTransformObject.transform.GetChild(i).transform);
        //    currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
        //                                                     10f,
        //                                                     enemyTransformObject.transform.GetChild(i).position.z);
        //}
        CreateEnemyInUpdate(currentEnemyObjects, enemyTransformObject, levelData.enemyFourthObjects);

    }
    public void CreateFifthMapEnemies()
    {
        levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[4];

        Destroy(enemyTransformObject);
        enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[4].gameObject, gameObject.transform);

        //for (int i = 0; i < enemyData.enemyFourthObjects.Length; i++)
        //{
        //    currentEnemyObjects = Instantiate(enemyData.enemyFourthObjects[i],
        //                             enemyTransformObject.transform.GetChild(i).position,
        //                             Quaternion.identity,
        //                             enemyTransformObject.transform.GetChild(i).transform);
        //    currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
        //                                                     10f,
        //                                                     enemyTransformObject.transform.GetChild(i).position.z);
        //}
        CreateEnemyInUpdate(currentEnemyObjects, enemyTransformObject, levelData.enemyFifthObjects);

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
        }
    }
}
