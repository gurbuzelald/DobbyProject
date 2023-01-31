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

    private void Awake()
    {
        for (int i = 0; i < enemyData.enemiesTransform.Length; i++)
        {
            GameObject obj = Instantiate(enemyData.enemiesObjects[i],
                                         enemyData.enemiesTransform[i].position, 
                                         Quaternion.identity,
                                         gameObject.transform);
            obj.transform.position = enemyData.enemiesTransform[i].position;
        }
        enemyCountText.text = gameObject.transform.childCount.ToString();
        //Debug.Log(gameObject.transform.childCount);
    }
    private void Update()
    {
        enemyCountText.text = gameObject.transform.childCount.ToString();
    }
}
