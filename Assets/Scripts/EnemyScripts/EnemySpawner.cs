using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemySpawner : MonoBehaviour
{
    public Transform targetTransform;
    public ObjectPool _objectPool;
    public EnemyData enemyData;
    public TextMeshProUGUI enemyCountText;
    public PlayerData playerData;
    private GameObject currentEnemyObjects;

    public LayerMask layerMask;


    [SerializeField] Transform enemySpawnTransform;
    private GameObject enemyTransformObject;

    private static int bulletCoinCount;
    private GameObject playerBulletObject;

    [SerializeField] Transform _bulletCoinSpawn;


    public bool isActivateCreateEnemy = false;
    private void Awake()
    {
        isActivateCreateEnemy = false;
        bulletCoinCount = 0;

        CreateAwakeEnemies();

        //Debug.Log(gameObject.transform.childCount);
    }
    void CreateAwakeEnemies()
    {
        if (playerData.currentMapName == PlayerData.MapNames.FirstMap)
        {
            enemyTransformObject = Instantiate(enemyData.enemyTransformsFirstMap.gameObject, gameObject.transform);

            for (int i = 0; i < enemyData.enemyTransformsFirstMap.transform.childCount; i++)
            {
                playerData.enemySpawnDelay = 10;
                currentEnemyObjects = Instantiate(enemyData.enemyFirstObjects[i],
                                             enemyTransformObject.transform.GetChild(i).position,
                                             Quaternion.identity,
                                             enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                     10f,
                                                                     enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
       else if (playerData.currentMapName == PlayerData.MapNames.SecondMap)
       {
            enemyTransformObject = Instantiate(enemyData.enemyTransformsSecondMap.gameObject, gameObject.transform);

            for (int i = 0; i < enemyData.enemyTransformsSecondMap.transform.childCount; i++)
            {
                playerData.enemySpawnDelay = 7;
                currentEnemyObjects = Instantiate(enemyData.enemySecondObjects[i],
                                             enemyTransformObject.transform.GetChild(i).position,
                                             Quaternion.identity,
                                             enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                     10f,
                                                                     enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
        else if (playerData.currentMapName == PlayerData.MapNames.ThirdMap)
        {
            enemyTransformObject = Instantiate(enemyData.enemyTransformsThirdMap.gameObject, gameObject.transform);

            for (int i = 0; i < enemyData.enemyTransformsThirdMap.transform.childCount; i++)
            {
                playerData.enemySpawnDelay = 5;
                currentEnemyObjects = Instantiate(enemyData.enemyThirdObjects[i],
                                             enemyTransformObject.transform.GetChild(i).position,
                                             Quaternion.identity,
                                             enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                     10f,
                                                                     enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
        else if (playerData.currentMapName == PlayerData.MapNames.FourthMap)
        {
            enemyTransformObject = Instantiate(enemyData.enemyTransformsFourthMap.gameObject, gameObject.transform);

            for (int i = 0; i < enemyData.enemyTransformsFourthMap.transform.childCount; i++)
            {
                playerData.enemySpawnDelay = 3;
                currentEnemyObjects = Instantiate(enemyData.enemyFourthObjects[i],
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
        if (bulletCoinCount <= 2)
        {
            yield return new WaitForSeconds(2);
            if (_bulletCoinSpawn.childCount == 0)
            {
                if(enemyData)
                    playerBulletObject = Instantiate(enemyData._playerBulletObject,
                                                    new Vector3(gameObject.transform.GetChild(0).GetChild(i).transform.position.x,
                                                                enemyData._playerBulletObject.transform.position.y,
                                                                gameObject.transform.GetChild(0).GetChild(i).transform.position.z),
                                                    Quaternion.identity,
                                                    _bulletCoinSpawn);

                bulletCoinCount++;

                playerBulletObject.transform.eulerAngles = new Vector3(0f, gameObject.transform.GetChild(0).GetChild(i).transform.eulerAngles.y + 90f, 90f);
            }
            Destroy(_bulletCoinSpawn.transform.GetChild(0).gameObject, 10f);

            //StartCoroutine(DelayDestroy());
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
                if (gameObject.transform.GetChild(0).transform.GetChild(i).childCount == 0)
                {
                    StartCoroutine(CreateBulletCoin(i));
                    CheckEnemyDeathForLevels(i);
                    
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
        if (playerData.currentMapName == PlayerData.MapNames.FirstMap)
        {
            if (isActivateCreateEnemy)
            {
                currentEnemyObjects = Instantiate(enemyData.enemyFirstObjects[i],
                                     enemyTransformObject.transform.GetChild(i).position,
                                     Quaternion.identity,
                                     enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                 10f,
                                                 enemyTransformObject.transform.GetChild(i).position.z);
                isActivateCreateEnemy = false;
            }
        }
    }
    void CheckEnemyDeathSecondMap(int i)
    {
        if (playerData.currentMapName == PlayerData.MapNames.SecondMap)
        {
            if (isActivateCreateEnemy)
            {
                currentEnemyObjects = Instantiate(enemyData.enemySecondObjects[i],
                                     enemyTransformObject.transform.GetChild(i).position,
                                     Quaternion.identity,
                                     enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                 10f,
                                                 enemyTransformObject.transform.GetChild(i).position.z);
                isActivateCreateEnemy = false;
            }
        }
    }
    void CheckEnemyDeathThirdMap(int i)
    {
        if (playerData.currentMapName == PlayerData.MapNames.ThirdMap)
        {
            if (isActivateCreateEnemy)
            {
                currentEnemyObjects = Instantiate(enemyData.enemyThirdObjects[i],
                                     enemyTransformObject.transform.GetChild(i).position,
                                     Quaternion.identity,
                                     enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                 10f,
                                                 enemyTransformObject.transform.GetChild(i).position.z);
                isActivateCreateEnemy = false;
            }
        }
    }
    void CheckEnemyDeathFourthMap(int i)
    {
        if (playerData.currentMapName == PlayerData.MapNames.FourthMap)
        {
            if (isActivateCreateEnemy)
            {
                currentEnemyObjects = Instantiate(enemyData.enemyFourthObjects[i],
                                     enemyTransformObject.transform.GetChild(i).position,
                                     Quaternion.identity,
                                     enemyTransformObject.transform.GetChild(i).transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                 10f,
                                                 enemyTransformObject.transform.GetChild(i).position.z);
                isActivateCreateEnemy = false;
            }
        }
    }
    public void CreateSecondMapEnemies()
    {
        playerData.enemySpawnDelay = 7;

        Destroy(enemyTransformObject);
        enemyTransformObject = Instantiate(enemyData.enemyTransformsSecondMap.gameObject, gameObject.transform);

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
        CreateEnemyInUpdate(currentEnemyObjects, enemyTransformObject, enemyData.enemySecondObjects);
    }
   
    public void CreateThirdMapEnemies()
    {
        playerData.enemySpawnDelay = 5;

        Destroy(enemyTransformObject);
        enemyTransformObject = Instantiate(enemyData.enemyTransformsThirdMap.gameObject, gameObject.transform);

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
        CreateEnemyInUpdate(currentEnemyObjects, enemyTransformObject, enemyData.enemyThirdObjects);

    }
    public void CreateFourthMapEnemies()
    {
        playerData.enemySpawnDelay = 3;

        Destroy(enemyTransformObject);
        enemyTransformObject = Instantiate(enemyData.enemyTransformsFourthMap.gameObject, gameObject.transform);

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
        CreateEnemyInUpdate(currentEnemyObjects, enemyTransformObject, enemyData.enemyFourthObjects);

    }

    void CreateEnemyInUpdate(GameObject currentEnemyObjects, GameObject enemyTransformObject, GameObject[] enemyObjects)
    {
        for (int i = 0; i < enemyData.enemySecondObjects.Length; i++)
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
