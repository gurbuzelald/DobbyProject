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

        CreateAwakeEnemies(LevelUpController.levelCount);

        //Debug.Log(gameObject.transform.childCount);
    }
    void CreateAwakeEnemies(int levelCount)
    {
        enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[levelCount].gameObject, gameObject.transform);

        for (int i = 0; i < levelData.enemyTransformsInMap[levelCount].transform.childCount; i++)
        {
            levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[levelCount];
            currentEnemyObjects = Instantiate(levelData.currentEnemyObjects[i],
                                         enemyTransformObject.transform.GetChild(i).position,
                                         Quaternion.identity,
                                         enemyTransformObject.transform.GetChild(i).transform);
            currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                 10f,
                                                                 enemyTransformObject.transform.GetChild(i).position.z);
        }
        //enemyCountText.text = gameObject.transform.GetChild(0).childCount.ToString();
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
                    CheckEnemyDeathForLevels(i, levelData.currentEnemyObjects);                    
                }
                if (gameObject.transform.GetChild(0).GetChild(i).childCount == 0)
                {
                    StartCoroutine(CreateBulletCoin(i));
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

            if (enemyData.isActivateCreateEnemy)
            {
                currentEnemyObjects = Instantiate(enemyObjects[i],
                                     enemyTransformObject.transform.GetChild(i).position,
                                     Quaternion.identity,
                                     enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = 
                    new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                10f,
                                enemyTransformObject.transform.GetChild(i).position.z);
                enemyData.isActivateCreateEnemy = false;
            }
        }
    }


    public void CreateEnemiesByMap(int levelCount)
    {
        levelData.currentEnemySpawnDelay = levelData.enemySpawnDelaysByLevel[levelCount];

        Destroy(enemyTransformObject);
        enemyTransformObject = Instantiate(levelData.enemyTransformsInMap[levelCount].gameObject, 
                                           gameObject.transform);


        CreateEnemyInUpdate(currentEnemyObjects, enemyTransformObject, levelData.currentEnemyObjects);
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
