using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] cloneObjects;
    [SerializeField] Transform[] cloneTransform;
    public Transform _firstTarget;
    public Transform _secondTarget;
    public Transform _currentTarget;

    private void Awake()
    {
        for (int i = 0; i < cloneTransform.Length; i++)
        {
            GameObject obj = Instantiate(cloneObjects[i], cloneTransform[i].position, Quaternion.identity, cloneTransform[i]);
            obj.transform.position = cloneTransform[i].position;
        }
    }
}
