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

    private void Awake()
    {
        enemyTransformObject = Instantiate(enemyData.enemyTransformsFirstMap.gameObject, gameObject.transform);

        for (int i = 0; i < enemyData.enemyTransformsFirstMap.transform.childCount; i++)
        {
            currentEnemyObjects = Instantiate(enemyData.enemyFirstObjects[i],
                                         enemyTransformObject.transform.GetChild(i).position, 
                                         Quaternion.identity,
                                         enemyTransformObject.transform.GetChild(i).transform);
            currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                 10f,
                                                                 enemyTransformObject.transform.GetChild(i).position.z);
        }
        enemyCountText.text = gameObject.transform.GetChild(0).childCount.ToString();
        //Debug.Log(gameObject.transform.childCount);
    }
    private void Update()
    {
        for (int i = 0; i < enemyTransformObject.transform.childCount; i++)
        {//if enemyTransformObject's childCount equals zero, destroy enemyTransformObject. This code is for getting enemies amount.
            if (enemyTransformObject.transform.GetChild(i).childCount == 0)
            {
                Destroy(enemyTransformObject.transform.GetChild(i).gameObject);
            }
        }
        
        enemyCountText.text = gameObject.transform.GetChild(0).childCount.ToString();
        if (playerData.isCompleteFirstMap)
        {
            Destroy(enemyTransformObject);
            enemyTransformObject = Instantiate(enemyData.enemyTransformsSecondMap.gameObject, gameObject.transform);

            for (int i = 0; i < enemyData.enemySecondObjects.Length; i++)
            {
                currentEnemyObjects = Instantiate(enemyData.enemySecondObjects[i],
                                         enemyTransformObject.transform.GetChild(i).position,
                                         Quaternion.identity,
                                         enemyTransformObject.transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                 10f,
                                                                 enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
        if (playerData.isCompleteSecondMap)
        {
            Destroy(enemyTransformObject);
            enemyTransformObject = Instantiate(enemyData.enemyTransformsThirdMap.gameObject, gameObject.transform);

            for (int i = 0; i < enemyData.enemyThirdObjects.Length; i++)
            {
                currentEnemyObjects = Instantiate(enemyData.enemyThirdObjects[i],
                                         enemyTransformObject.transform.GetChild(i).position,
                                         Quaternion.identity,
                                         enemyTransformObject.transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                 10f,
                                                                 enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
        if (playerData.isCompleteThirdMap)
        {
            Destroy(enemyTransformObject);
            enemyTransformObject = Instantiate(enemyData.enemyTransformsFourthMap.gameObject, gameObject.transform);

            for (int i = 0; i < enemyData.enemyFourthObjects.Length; i++)
            {
                currentEnemyObjects = Instantiate(enemyData.enemyFourthObjects[i],
                                         enemyTransformObject.transform.GetChild(i).position,
                                         Quaternion.identity,
                                         enemyTransformObject.transform);
                currentEnemyObjects.transform.position = new Vector3(enemyTransformObject.transform.GetChild(i).position.x,
                                                                 10f,
                                                                 enemyTransformObject.transform.GetChild(i).position.z);
            }
        }
    }
}
