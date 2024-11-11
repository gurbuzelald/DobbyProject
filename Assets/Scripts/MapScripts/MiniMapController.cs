using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    private GameInput gameInput;
    public bool growing;
    GameObject miniMapMask;
    private bool _isMiniMapTouchable;
    [SerializeField] float delayTouching;
    private Camera miniMapCamera;
    
    private void Awake()
    {
        miniMapCamera = gameObject.GetComponent<Camera>();
        _isMiniMapTouchable = true;
        gameInput = new GameInput();

        miniMapMask = GameObject.Find("MiniMapMask");
    }
    private void OnEnable()
    {
        if (gameInput != null)
        {
            gameInput.Enable();
        }
    }
    private void OnDisable()
    {
        if (gameInput != null)
        {
            gameInput.Disable();
        }
    }
    void Update()
    {
        MiniMapRotation();

        TouchMiniMap(miniMapCamera);
    }
    void MiniMapRotation()
    {
        if (PlayerManager.GetInstance.gameObject)
        {
            if (PlayerManager.GetInstance.gameObject.transform.childCount >= 1)
            {
                if (PlayerManager.GetInstance.gameObject.transform.GetChild(0).childCount >= 8)
                {
                    if (PlayerManager.GetInstance.gameObject.transform.GetChild(0).GetChild(8))
                    {
                        gameObject.transform.LookAt(PlayerManager.GetInstance.gameObject.transform.GetChild(0).GetChild(8));
                        gameObject.transform.position = new Vector3(PlayerManager.GetInstance.transform.position.x,
                                                                    gameObject.transform.position.y,
                                                                    PlayerManager.GetInstance.transform.position.z);
                    }
                }                
            }            
        }        
    }
    void TouchMiniMap(Camera miniMapCamera)
    {
        growing = gameInput.GrowMap.GrowingState.IsPressed();
        if (growing && _isMiniMapTouchable && miniMapMask.transform.localScale == new Vector3(0.2f, 0.2f, 0.2f))
        {
            miniMapCamera.orthographicSize = 30;
            miniMapMask.transform.localScale = Vector3.one;

            _isMiniMapTouchable = false;

            StartCoroutine(OpenSmoothMiniMap(delayTouching));
        }
        else if (growing && _isMiniMapTouchable)
        {
            miniMapCamera.orthographicSize = 7;
            miniMapMask.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);

            _isMiniMapTouchable = false;

            StartCoroutine(OpenSmoothMiniMap(delayTouching));
        }
    }
    IEnumerator OpenSmoothMiniMap(float delay)
    {
        yield return new WaitForSeconds(delay);

        _isMiniMapTouchable = true;
    }
}
