using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClownSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] clownsObjects;
    [SerializeField] Transform[] clownsTransform;
    public Transform targetTransform;
    public ObjectPool _objectPool;

    private void Awake()
    {
        for (int i = 0; i < clownsTransform.Length; i++)
        {
            GameObject obj = Instantiate(clownsObjects[i], clownsTransform[i].position, Quaternion.identity, clownsTransform[i]);
            obj.transform.position = clownsTransform[i].position;
        }
    }
}
