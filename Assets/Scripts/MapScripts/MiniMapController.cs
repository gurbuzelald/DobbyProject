using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    private Player playerInput;
    public bool growing;
    GameObject miniMapMask;
    private bool _isMiniMapTouchable;
    [SerializeField] float delayTouching;
    private Camera miniMapCamera;
    
    private void Awake()
    {
        miniMapCamera = gameObject.GetComponent<Camera>();
        _isMiniMapTouchable = true;
        playerInput = new Player();

        miniMapMask = GameObject.Find("MiniMapMask");
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        playerInput.Disable();
    }
    void Update()
    {
        MiniMapRotation();

        TouchMiniMap(miniMapCamera);
    }
    void MiniMapRotation()
    {
        gameObject.transform.LookAt(PlayerManager.GetInstance.gameObject.transform.GetChild(0).GetChild(8));
        gameObject.transform.position = new Vector3(PlayerManager.GetInstance.transform.position.x,
                                                    gameObject.transform.position.y,
                                                    PlayerManager.GetInstance.transform.position.z);
    }
    void TouchMiniMap(Camera miniMapCamera)
    {
        growing = playerInput.GrowMap.GrowingStuate.IsPressed();
        if (growing && _isMiniMapTouchable && miniMapMask.transform.localScale == new Vector3(0.25f, 0.25f, 0.25f))
        {
            miniMapCamera.orthographicSize = 25;
            miniMapMask.transform.localScale = Vector3.one;

            _isMiniMapTouchable = false;

            StartCoroutine(OpenSmoothMiniMap(delayTouching));
        }
        else if (growing && _isMiniMapTouchable)
        {
            miniMapCamera.orthographicSize = 7;
            miniMapMask.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);

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
