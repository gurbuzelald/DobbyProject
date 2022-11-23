using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : AbstractSingleton<PlayerManager>
{
    public PlayerData _playerData;

    private float _xValue;
    private float _zValue;
    // Start is called before the first frame update
    void Start()
    {
        _playerData.isWalking = false;
        _playerData.isBackWalking = false;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    void Movement()
    {
        _xValue = Input.GetAxis("Horizontal") * Time.deltaTime * _playerData.playerSpeed / 2f;
        _zValue = Input.GetAxis("Vertical") * Time.deltaTime * _playerData.playerSpeed;
        float _mousePosX = Input.GetAxis("Mouse X") * _playerData.rotateSpeed * Time.deltaTime;
        float _mousePosY = Input.GetAxis("Mouse Y") * _playerData.rotateSpeed * Time.deltaTime;
        if (_mousePosX <= 0 && _mousePosX > 90)
        {
            //Debug.Log(_mousePosX);
            _mousePosX = Mathf.Clamp(_mousePosY, -90, 0);
        }
        else if (_mousePosX <= -90 && _mousePosX > -180)
        {
            Debug.Log(_mousePosX);

            _mousePosX = Mathf.Clamp(_mousePosX, -180, -90);
        }
        if (_zValue > 0)
        {
            _playerData.isWalking = true;
            _playerData.isBackWalking = false;
        }
        else if (_zValue < 0)
        {
            _playerData.isBackWalking = true;
            _playerData.isWalking = false;
        }
        else if (_zValue == 0)
        {
            _playerData.isBackWalking = false;
            _playerData.isWalking = false;
        }
        //GetInstance.GetComponent<Transform>().localRotation = Quaternion.AngleAxis(_mousePosX, Vector3.right);
        //float _mousePosZ = Input.GetAxis("Mouse Z") * _rotateSpeed * -Time.deltaTime;
        GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
        GetInstance.GetComponent<Transform>().Translate(_xValue, 0f, 0f);
        GetInstance.GetComponent<Transform>().Rotate(0f, _mousePosX, 0f);
        if (Input.GetKeyDown(KeyCode.Space) && _playerData.isGround)
        {
            Jump();
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
    }

    void Jump()
    {

    }
    void Fire()
    {

    }
}