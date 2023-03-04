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

    private void Awake()
    {
        for (int i = 0; i < enemyData.enemyTransformsFirstMap.transform.childCount; i++)
        {
            currentEnemyObjects = Instantiate(enemyData.enemyFirstObjects[i],
                                         enemyData.enemyTransformsFirstMap.transform.GetChild(i).position, 
                                         Quaternion.identity,
                                         enemySpawnTransform.transform);
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
            GameObject currentEnemiesTransform = GameObject.Find("EnemySpawns");
            for (int i = 0; i < currentEnemiesTransform.transform.childCount; i++)
            {
                Destroy(currentEnemiesTransform.transform.GetChild(i).gameObject);
            }

            for (int i = 0; i < enemyData.enemySecondObjects.Length; i++)
            {
                currentEnemyObjects = Instantiate(enemyData.enemySecondObjects[i],
                                         enemyData.enemyTransformsSecondMap.transform.GetChild(i).position,
                                         Quaternion.identity,
                                         currentEnemiesTransform.transform);
                currentEnemyObjects.transform.position = new Vector3(enemyData.enemyTransformsFirstMap.transform.GetChild(i).position.x,
                                                                 10f,
                                                                 enemyData.enemyTransformsFirstMap.transform.GetChild(i).position.z);
            }
        }
    }
}
