using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    private Player playerInput;
    public bool growing;
    GameObject miniMapMask;
    
    private void Awake()
    {
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
        gameObject.transform.LookAt(PlayerManager.GetInstance.gameObject.transform.GetChild(0).GetChild(9));
        if (PlayerManager.GetInstance._xValue != 0 || PlayerManager.GetInstance._zValue != 0)
        {
            gameObject.transform.position = new Vector3(PlayerManager.GetInstance.transform.position.x,
                                                        gameObject.transform.position.y * Time.timeScale,
                                                        PlayerManager.GetInstance.transform.position.z + 0.01f * Time.timeScale);
        }
        else
        {
            gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                        gameObject.transform.position.y * Time.timeScale,
                                                        PlayerManager.GetInstance.transform.position.z + 0.01f * Time.timeScale);
           /* gameObject.transform.position = new Vector3(gameObject.transform.position.x,
                                                           30f,
                                                           PlayerManager.GetInstance.transform.position.z);*/
        }
        growing = playerInput.GrowMap.GrowingStuate.IsPressed();
        if (growing)
        {
            if (miniMapMask.transform.localScale == new Vector3(0.25f, 0.25f, 0.25f))
            {
                gameObject.GetComponent<Camera>().orthographicSize = 10;
                miniMapMask.transform.localScale = Vector3.one;
            }
            else
            {
                gameObject.GetComponent<Camera>().orthographicSize = 6;
                miniMapMask.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
            }
        }
    }
}
