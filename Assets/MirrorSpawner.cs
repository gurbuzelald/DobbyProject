using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _mirrorCouple;
    void Awake()
    {
        for (int i = 0; i < _mirrorCouple.Length; i++)
        {
            Instantiate(_mirrorCouple[i], gameObject.transform);
        }
    }
}
