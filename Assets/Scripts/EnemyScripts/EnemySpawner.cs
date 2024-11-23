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

    private GameObject currentLevelRectangle;

    [System.Serializable]
    public struct AnimatorStruct
    {
        public RuntimeAnimatorController[] runtimeAnimatorControllers;
        public RuntimeAnimatorController[] exampleRunAnimatorController;
    }

    public AnimatorStruct[] animatorStruct = new AnimatorStruct[4];
    

    private int animatorAmount;

    private void Start()
    {
        if (GameObject.Find("PlayerSpawner"))
        {
            if (GameObject.Find("PlayerSpawner").transform.childCount > 0)
            {
                targetTransform = GameObject.Find("PlayerSpawner").transform.GetChild(0);
            }
        }  

        bossIsDead = false;

        MainEnemyData.enemyDeathCount = 0;
        enemyData.isActivateCreateEnemy = false;

        currentLevelRectangle = levelData.levelStates[LevelData.currentLevelId].levelRectangle;

        SetTrueEnemy();
        SetTrueBoss();
        SetTrueChestMonster();
        SetTrueTazo();

        animatorAmount = 0;
        
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            for (int j = 0; j < gameObject.transform.GetChild(i).childCount; j++)
            {
                animatorAmount++;
            }
        }
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            animatorStruct[i].exampleRunAnimatorController = new RuntimeAnimatorController[gameObject.transform.childCount];
            animatorStruct[i].runtimeAnimatorControllers = new RuntimeAnimatorController[gameObject.transform.GetChild(i).childCount];
        }
        

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            animatorStruct[i].exampleRunAnimatorController[i] =
                gameObject.transform.GetChild(i).GetChild(0).GetChild(1).GetComponent<EnemyAnimationController>().exampleRunAnimatorController;

            for (int j = 0; j < gameObject.transform.GetChild(i).childCount; j++)
            {
                animatorStruct[i].runtimeAnimatorControllers[j] = Instantiate(animatorStruct[i].exampleRunAnimatorController[i]);
            }            
        }
    }



    public void SetTrueEnemy()
    {
        if (enemyObjectPool)
        {
            if (!currentLevelRectangle) return;
            

            for (int i = 0; i < currentLevelRectangle.transform.childCount; i++)
            {
                for (int j = 0; j < 5 + LevelData.currentLevelId; j++)
                {
                    GameObject currentEnemyObjects = enemyObjectPool.GetPooledObject(playerData.enemyPrefabObjectPoolID);

                    currentEnemyObjects.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;

                    SetRandomPosition(currentEnemyObjects.transform, currentLevelRectangle.transform.GetChild(i).transform);
                }
            }
        }

    }

    public void SetTrueBoss()
    {
        if (enemyObjectPool)
        {
            if (!currentLevelRectangle) return;

            for (int i = 0; i < currentLevelRectangle.transform.childCount; i++)
            {
                for (int j = 0; j < 5 + LevelData.currentLevelId; j++)
                {
                    GameObject currentEnemyObjects = enemyObjectPool.GetPooledObject(playerData.bossEnemyPrefabObjectPoolID);

                    currentEnemyObjects.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;

                    SetRandomPosition(currentEnemyObjects.transform, currentLevelRectangle.transform.GetChild(i).transform);
                }
            }
        }
    }

    public void SetTrueChestMonster()
    {
        if (enemyObjectPool)
        {
            if (!currentLevelRectangle) return;

            for (int i = 0; i < currentLevelRectangle.transform.childCount; i++)
            {
                for (int j = 0; j < 5 + LevelData.currentLevelId; j++)
                {
                    GameObject currentEnemyObjects = enemyObjectPool.GetPooledObject(playerData.chestMonsterEnemyPrefabObjectPoolID);

                    currentEnemyObjects.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;

                    SetRandomPosition(currentEnemyObjects.transform, currentLevelRectangle.transform.GetChild(i).transform);
                }                   
            }
        }
    }

    public void SetTrueTazo()
    {
        if (enemyObjectPool)
        {
            if (!currentLevelRectangle) return;

            for (int i = 0; i < currentLevelRectangle.transform.childCount; i++)
            {
                for (int j = 0; j < 5 + LevelData.currentLevelId; j++)
                {
                    GameObject currentEnemyObjects = enemyObjectPool.GetPooledObject(playerData.tazoEnemyPrefabObjectPoolID);

                    currentEnemyObjects.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;

                    SetRandomPosition(currentEnemyObjects.transform, currentLevelRectangle.transform.GetChild(i).transform);
                }
            }
        }
    }

    void SetRandomPosition(Transform enemyTransform, Transform parentTransform)
    {
        Vector3 corner1 = parentTransform.GetChild(1).position;
        Vector3 corner2 = parentTransform.GetChild(3).position;
        Vector3 corner3 = parentTransform.GetChild(0).position;
        Vector3 corner4 = parentTransform.GetChild(2).position;

        enemyTransform.position = new Vector3(
            Random.Range(corner1.x, corner2.x),
            enemyTransform.position.y,
            Random.Range(corner3.z, corner4.z)
        );
    }
}
