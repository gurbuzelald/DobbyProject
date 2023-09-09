using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveController : MonoBehaviour
{
    public PlayerData _playerData;
    [SerializeField] GameObject extraSpeedObject;
    private RectTransform extraSpeedObjectRectTransform;

    [SerializeField] GameObject normalSpeedObject;
    private RectTransform normalSpeedObjectRectTransform;

    private Image normalSpeedObjectImage;
    private Image extraSpeedObjectImage;

    private RectTransform gameObjectTransform;

    private void Awake()
    {
        extraSpeedObjectRectTransform = extraSpeedObject.GetComponent<RectTransform>();
        normalSpeedObjectRectTransform = normalSpeedObject.GetComponent<RectTransform>();
        normalSpeedObjectImage = normalSpeedObject.GetComponent<Image>();
        extraSpeedObjectImage = extraSpeedObject.GetComponent<Image>();

        gameObjectTransform = gameObject.GetComponent<RectTransform>();
    }
    private void Update()
    {
        ActivateSpeedButtons(_playerData, gameObjectTransform, extraSpeedObjectRectTransform, normalSpeedObjectRectTransform, extraSpeedObjectImage, normalSpeedObjectImage);
    }
    void ActivateSpeedButtons(PlayerData _playerData, RectTransform gameObjectTransform, RectTransform extraSpeedObjectRectTransform, 
                              RectTransform normalSpeedObjectRectTransform, Image extraSpeedObjectImage,
                              Image normalSpeedObjectImage)
    {//Activated with z value
        if (PlayerManager.GetInstance._playerController.movement.y != 0)
        {
            if (_playerData.normalSpeed)
            {
                extraSpeedObjectRectTransform.localScale = Vector3.one;
                normalSpeedObjectRectTransform.localScale = Vector3.zero;
            }
            else if (_playerData.extraSpeed)
            {
                extraSpeedObjectRectTransform.localScale = Vector3.zero;
                normalSpeedObjectRectTransform.localScale = Vector3.one;
            }
            StartCoroutine(DelaySpeedState(_playerData, gameObjectTransform, extraSpeedObjectRectTransform, normalSpeedObjectRectTransform, extraSpeedObjectImage, normalSpeedObjectImage));
        }
        else
        {
            extraSpeedObjectRectTransform.localScale = Vector3.zero;
            normalSpeedObjectRectTransform.localScale = Vector3.zero;
        }
    }
    IEnumerator DelaySpeedState(PlayerData _playerData, RectTransform gameObjectTransform, RectTransform extraSpeedObjectRectTransform, 
                                RectTransform normalSpeedObjectRectTransform, Image extraSpeedObjectImage,
                                Image normalSpeedObjectImage)
    {
        if (extraSpeedObjectRectTransform.localScale.x > 0)
        {
            yield return new WaitForSeconds(1f);

            if (gameObjectTransform.position.x >= extraSpeedObjectRectTransform.position.x &&
                gameObjectTransform.position.y >= extraSpeedObjectRectTransform.position.y)
            {
                extraSpeedObjectImage.color = Color.red;
                normalSpeedObjectImage.color = Color.green;

                _playerData.normalSpeed = false;
                _playerData.extraSpeed = true;
            }
        }
        else if (normalSpeedObjectRectTransform.localScale.x > 0)
        {
            yield return new WaitForSeconds(1f);

            if (gameObjectTransform.position.x >= normalSpeedObjectRectTransform.position.x &&
                gameObjectTransform.position.y >= normalSpeedObjectRectTransform.position.y)
            {

                extraSpeedObjectImage.color = Color.green;
                normalSpeedObjectImage.color = Color.red;

                _playerData.normalSpeed = true;
                _playerData.extraSpeed = false;

                normalSpeedObjectRectTransform.localScale = Vector3.zero;
                extraSpeedObjectRectTransform.localScale = Vector3.one;
            }
        }
    }
}
