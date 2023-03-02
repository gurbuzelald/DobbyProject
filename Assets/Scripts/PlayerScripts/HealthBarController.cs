using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    void Update()
    {
        gameObject.transform.localScale = playerData.objects[3].transform.localScale;
    }
}
