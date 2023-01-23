using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    void Start()
    {
        gameObject.transform.localScale = new Vector3(1, 0.1f, 0.1f);
    }
    void Update()
    {
        gameObject.transform.localScale = playerData.objects[3].transform.localScale;
    }
}
