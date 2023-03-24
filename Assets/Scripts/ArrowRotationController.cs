using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotationController : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    public Transform _currentFinishArea;

    public Transform _currentFirstFinishArea;
    public Transform _currentSecondFinishArea;
    public Transform _currentThirdFinishArea;
    public Transform _currentFourthFinishArea;
    private void Awake()
    {
        playerData.isSecondMapTarget = false;
        playerData.isThirdMapTarget = false;
        playerData.isFourthMapTarget = false;

        _currentFirstFinishArea = playerData._finishAreas.transform.GetChild(0).transform;
        _currentSecondFinishArea = playerData._finishAreas.transform.GetChild(1).transform;
        _currentThirdFinishArea = playerData._finishAreas.transform.GetChild(2).transform;
        _currentFourthFinishArea = playerData._finishAreas.transform.GetChild(3).transform;

        _currentFinishArea = _currentFirstFinishArea;
    }
    void Update()
    {
        ArrowRotation();
    }
    void ArrowRotation()
    {
        if (playerData.isSecondMapTarget)
        {
            _currentFinishArea.position = _currentSecondFinishArea.position;
        }
        if (playerData.isThirdMapTarget)
        {
            _currentFinishArea.position = _currentThirdFinishArea.position;
        }
        if (playerData.isFourthMapTarget)
        {
            _currentFinishArea.position = _currentFourthFinishArea.position;
        }

        if (gameObject != null)
        {
            gameObject.transform.LookAt(_currentFinishArea.position);
        }
        //Debug.Log(_currentFinishArea.position);

    }
}
