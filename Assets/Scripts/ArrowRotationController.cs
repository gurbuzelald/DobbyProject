using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotationController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    private Transform _finishArea;
    private void Awake()
    {
        _finishArea = playerData._finishAreas[0].transform;
    }
    void Update()
    {
        ArrowRotation();
    }
    void ArrowRotation()
    {

        if (playerData.isCompleteFirstMap && !playerData.isCompleteSecondMap && !playerData.isCompleteThirdMap)
        {
            _finishArea = playerData._finishAreas[1].transform;
        }
        else if (!playerData.isCompleteFirstMap && playerData.isCompleteSecondMap && !playerData.isCompleteThirdMap)
        {
            _finishArea = playerData._finishAreas[2].transform;
        }

        if (gameObject != null)
        {
            gameObject.transform.LookAt(_finishArea);
        }
    }
}
