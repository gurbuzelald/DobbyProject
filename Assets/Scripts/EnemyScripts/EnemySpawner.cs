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

    [SerializeField] Transform enemySpawnTransform;
    private GameObject enemyTransformObject;

    private void Awake()
    {
        enemyTransformObject = Instantiate(enemySpawnTransform.gameObject, gameObject.transform);

        for (int i = 0; i < enemyData.enemyTransformsFirstMap.transform.childCount; i++)
        {
            currentEnemyObjects = Instantiate(enemyData.enemyFirstObjects[i],
                                         enemyData.enemyTransformsFirstMap.transform.GetChild(i).position, 
                                         Quaternion.identity,
                                         enemyTransformObject.transform);
            currentEnemyObjects.transform.position = new Vector3(enemyData.enemyTransformsFirstMap.transform.GetChild(i).position.x,
                                                                 10f,
                                                                 enemyData.enemyTransformsFirstMap.transform.GetChild(i).position.z);
        }
        enemyCountText.text = gameObject.transform.GetChild(0).childCount.ToString();
        //Debug.Log(gameObject.transform.childCount);
    }
    private void Update()
    {
        enemyCountText.text = gameObject.transform.GetChild(0).childCount.ToString();
        if (playerData.isCompleteFirstMap)
        {
            Destroy(enemyTransformObject);
            enemyTransformObject = Instantiate(enemySpawnTransform.gameObject, gameObject.transform);

            for (int i = 0; i < enemyData.enemySecondObjects.Length; i++)
            {
                currentEnemyObjects = Instantiate(enemyData.enemySecondObjects[i],
                                         enemyData.enemyTransformsSecondMap.transform.GetChild(i).position,
                                         Quaternion.identity,
                                         enemyTransformObject.transform);
                currentEnemyObjects.transform.position = new Vector3(enemyData.enemyTransformsSecondMap.transform.GetChild(i).position.x,
                                                                 10f,
                                                                 enemyData.enemyTransformsSecondMap.transform.GetChild(i).position.z);
            }
        }
        if (playerData.isCompleteSecondMap)
        {
            Destroy(enemyTransformObject);
            enemyTransformObject = Instantiate(enemySpawnTransform.gameObject, gameObject.transform);

            for (int i = 0; i < enemyData.enemyThirdObjects.Length; i++)
            {
                currentEnemyObjects = Instantiate(enemyData.enemyThirdObjects[i],
                                         enemyData.enemyTransformsThirdMap.transform.GetChild(i).position,
                                         Quaternion.identity,
                                         enemyTransformObject.transform);
                currentEnemyObjects.transform.position = new Vector3(enemyData.enemyTransformsThirdMap.transform.GetChild(i).position.x,
                                                                 10f,
                                                                 enemyData.enemyTransformsThirdMap.transform.GetChild(i).position.z);
            }
        }
    }
}
