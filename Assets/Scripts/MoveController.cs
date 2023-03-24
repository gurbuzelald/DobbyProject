using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    public PlayerData _playerData;
    [SerializeField] GameObject extraSpeedObject;
    [SerializeField] GameObject normalSpeedObject;
    private void Update()
    {
        ActivateSpeedButtons(_playerData, extraSpeedObject, normalSpeedObject);
    }
    void ActivateSpeedButtons(PlayerData _playerData, GameObject extraSpeed, GameObject normalSpeed)
    {//Activated with z value
        if (PlayerManager.GetInstance._playerController.movement.y != 0)
        {
            if (_playerData.normalSpeed)
            {
                extraSpeed.GetComponent<RectTransform>().localScale = Vector3.one;
                normalSpeed.GetComponent<RectTransform>().localScale = Vector3.zero;
            }
            else if (_playerData.extraSpeed)
            {
                extraSpeed.GetComponent<RectTransform>().localScale = Vector3.zero;
                normalSpeed.GetComponent<RectTransform>().localScale = Vector3.one;
            }
            StartCoroutine(DelaySpeedState(_playerData, extraSpeedObject, normalSpeedObject));
        }
        else
        {
            extraSpeed.GetComponent<RectTransform>().localScale = Vector3.zero;
            normalSpeed.GetComponent<RectTransform>().localScale = Vector3.zero;
        }
    }
    IEnumerator DelaySpeedState(PlayerData _playerData, GameObject extraSpeedObject, GameObject normalSpeedObject)
    {
        if (extraSpeedObject.GetComponent<RectTransform>().localScale.x > 0)
        {
            yield return new WaitForSeconds(1f);

            if (gameObject.transform.GetComponent<RectTransform>().position.x >= extraSpeedObject.GetComponent<RectTransform>().position.x && gameObject.transform.GetComponent<RectTransform>().position.y >= extraSpeedObject.GetComponent<RectTransform>().position.y)
            {
                extraSpeedObject.GetComponent<Image>().color = Color.red;
                normalSpeedObject.GetComponent<Image>().color = Color.green;

                _playerData.normalSpeed = false;
                _playerData.extraSpeed = true;
            }
        }
        else if (normalSpeedObject.GetComponent<RectTransform>().localScale.x > 0)
        {
            yield return new WaitForSeconds(1f);

            if (gameObject.transform.GetComponent<RectTransform>().position.x >= normalSpeedObject.GetComponent<RectTransform>().position.x && gameObject.transform.GetComponent<RectTransform>().position.y >= normalSpeedObject.GetComponent<RectTransform>().position.y)
            {

                extraSpeedObject.GetComponent<Image>().color = Color.green;
                normalSpeedObject.GetComponent<Image>().color = Color.red;

                _playerData.normalSpeed = true;
                _playerData.extraSpeed = false;

                normalSpeedObject.GetComponent<RectTransform>().localScale = Vector3.zero;
                extraSpeedObject.GetComponent<RectTransform>().localScale = Vector3.one;
            }
        }
    }
}
