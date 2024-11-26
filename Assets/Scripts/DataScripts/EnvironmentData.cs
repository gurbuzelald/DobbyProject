using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEnvironmentData", menuName = "Scriptable Objects/EnvironmentData")]
public class EnvironmentData : ScriptableObject
{
    [Serializable]
    public struct Pool
    {
        public GameObject[] objectPrefab; // Addressable Asset
        public int poolSize;
        public Queue<GameObject> pooledObjects;
    }
    public Pool[] pools = null;
}
