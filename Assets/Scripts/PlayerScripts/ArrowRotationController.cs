using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotationController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] LevelData levelData;
    
    void Update()
    {
        ArrowRotation();
    }
    
    void ArrowRotation()
    {       

        if (gameObject != null)
        {
            gameObject.transform.LookAt(levelData.currentFinishArea.position);
        }
        //Debug.Log(_currentFinishArea.position);

    }
}
