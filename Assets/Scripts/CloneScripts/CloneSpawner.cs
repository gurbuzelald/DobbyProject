using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSpawner : MonoBehaviour
{
    public Transform _firstTarget;
    public Transform _secondTarget;
    public Transform _currentTarget;

    public PlayerData cloneData;
    public PlayerData playerData;

    private void Awake()
    {
        for (int i = 0; i < cloneData.cloneTransforms.Length; i++)
        {
            GameObject obj = Instantiate(cloneData.cloneObjects[i], cloneData.cloneTransforms[i].position, Quaternion.identity, gameObject.transform);
            obj.transform.position = cloneData.cloneTransforms[i].position;
        }
    }
}
