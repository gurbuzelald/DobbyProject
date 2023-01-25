using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownSpawner : MonoBehaviour
{
    public Transform targetTransform;
    public ObjectPool _objectPool;
    public EnemyData enemyData;

    private void Awake()
    {
        for (int i = 0; i < enemyData.clownsTransform.Length; i++)
        {
            GameObject obj = Instantiate(enemyData.clownsObjects[i],
                                         enemyData.clownsTransform[i].position, 
                                         Quaternion.identity,
                                         gameObject.transform);
            obj.transform.position = enemyData.clownsTransform[i].position;
        }
    }
}
