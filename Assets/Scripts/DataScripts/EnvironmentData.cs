using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnvironmentData", menuName = "Scriptable Objects/EnvironmentData")]
public class EnvironmentData : ScriptableObject
{
    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects;
        public GameObject[] objectPrefab;
        public int poolSize;
    }

    public Pool[] pools = null;
}
