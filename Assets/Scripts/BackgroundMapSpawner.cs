using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMapSpawner : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    void Awake()
    {
        Instantiate(playerData.backgroundMap, gameObject.transform);
    }
}
