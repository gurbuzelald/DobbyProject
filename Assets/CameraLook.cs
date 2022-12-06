using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

//[RequireComponent(typeof(CinemachineFreeLook))]
public class CameraLook : MonoBehaviour
{
    private Player playerInput;
    [SerializeField] float lookSpeed = 1;
    //public Vector2 delta;
    private CinemachineVirtualCamera cinemachine;

    private void Awake()
    {
        playerInput = new Player();
        //cinemachine = FindObjectOfType<CinemachineFreeLook>();  
        cinemachine = GetComponent<CinemachineVirtualCamera>();
    }
    private void OnEnable()
    {
        playerInput.Enable();
    }
    private void OnDisable()
    {
        //playerInput.Disable();
    }
    private void Update()
    {
        Vector2 delta = playerInput.PlayerMain.Look.ReadValue<Vector2>();
        //PlayerManager.GetInstance.gameObject.transform.eulerAngles = new Vector3(PlayerManager.GetInstance.gameObject.transform.eulerAngles.x, cinemachine.transform.eulerAngles.y, PlayerManager.GetInstance.gameObject.transform.eulerAngles.z);
        //if (delta.x > 0f)
        //{
        //    PlayerManager.GetInstance.gameObject.transform.eulerAngles = new Vector3(0f, PlayerManager.GetInstance.gameObject.transform.eulerAngles.y + 100f *Time.deltaTime, 0f);

        //}
        //else if (delta.x < 0f)
        //{
        //    PlayerManager.GetInstance.gameObject.transform.eulerAngles = new Vector3(0f, PlayerManager.GetInstance.gameObject.transform.eulerAngles.y - 100f * Time.deltaTime, 0f);           
        //}
        //PlayerManager.GetInstance._currentCamera.transform.eulerAngles = new Vector3(delta.y*_playerData.rotateSpeed*10f, delta.x * _playerData.rotateSpeed * 10f, 0f);
        //PlayerManager.GetInstance.gameObject.GetComponent<Transform>().Rotate(new Vector3(0f, delta.x*_playerData.rotateSpeed * Time.deltaTime, 0f));
    }

}
