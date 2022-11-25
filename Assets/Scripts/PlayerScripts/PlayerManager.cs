using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : AbstractSingleton<PlayerManager>
{
    public PlayerData _playerData;
    public int firingRotation;
    [SerializeField] CinemachineExternalCamera _virtualCamera;
    private BulletManager _bulletManager;

    public float _xValue;
    public float _zValue;
    private int _jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        firingRotation = 0;
        _jumpCount = 0;
        _playerData.isFiring = false;
        _playerData.isWalking = false;
        _playerData.isClimbing = false;
        _playerData.isBackWalking = false;
        _playerData.isGround = true;
        _bulletManager = Object.FindObjectOfType<BulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag(SceneLoadController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneLoadController.Tags.Bridge.ToString()))
        {
            _playerData.isGround = true;
            _jumpCount = 0;
        }
        else
        {
            _playerData.isGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneLoadController.Tags.Ladder.ToString()))
        {
            GetInstance.GetComponent<Rigidbody>().isKinematic = true;
            _playerData.isClimbing = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SceneLoadController.Tags.Ladder.ToString()))
        {
            GetInstance.GetComponent<Rigidbody>().isKinematic = false;
            _playerData.isClimbing = false;
        }
    }

    void Movement()
    {
        _xValue = Input.GetAxis("Horizontal") * Time.deltaTime * _playerData.playerSpeed / 2f;
        _zValue = Input.GetAxis("Vertical") * Time.deltaTime * _playerData.playerSpeed;

        Rotation();

        if (Input.GetKeyDown(KeyCode.Space) && _playerData.isGround && _jumpCount <= 1)
        {
            Jump();
            _jumpCount++;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
        else
        {
            _playerData.isFiring = false;
        }
        Walk();
    }
    void Rotation()
    {
        float _mousePosX = Input.GetAxis("Mouse X") * _playerData.rotateSpeed * Time.timeScale;
        float _mousePosY = Input.GetAxis("Mouse Y") * _playerData.rotateSpeed * Time.timeScale;

        GetInstance.GetComponent<Transform>().Rotate(0f, _mousePosX, 0f);

        _virtualCamera.transform.Rotate(-_mousePosY * Time.timeScale, 0, 0);
        if (_virtualCamera.transform.eulerAngles.x > 60 && _virtualCamera.transform.eulerAngles.x <= 65)
        {
            _virtualCamera.transform.eulerAngles = new Vector3(60f, _virtualCamera.transform.eulerAngles.y, _virtualCamera.transform.eulerAngles.z);
        }
        else if(_virtualCamera.transform.eulerAngles.x > 65)
        {
            _virtualCamera.transform.eulerAngles = new Vector3(0f, _virtualCamera.transform.eulerAngles.y, _virtualCamera.transform.eulerAngles.z);
        }
    }
    void Walk()
    {
        if (_zValue > 0 && !_playerData.isClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
            _playerData.isWalking = true;
            _playerData.isBackWalking = false;
        }
        else if (_zValue < 0 && !_playerData.isClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
            _playerData.isBackWalking = true;
            _playerData.isWalking = false;
        }
        else if (_zValue == 0)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
            _playerData.isBackWalking = false;
            _playerData.isWalking = false;
        }
        else if (_zValue > 0 && _playerData.isClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, _zValue, 0f);
        }
        else if (_zValue < 0 && _playerData.isClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, _zValue, 0f);
        }
        if (_xValue < 0)
        {
            GetInstance.GetComponent<Transform>().Translate(_xValue, 0f, 0f);
        }
        else if (_xValue > 0)
        {
            GetInstance.GetComponent<Transform>().Translate(_xValue, 0f, 0f);
        }
    }
    void Jump()
    {
        GetInstance.GetComponent<Rigidbody>().AddForce(transform.up*_playerData.jumpForce, ForceMode.Impulse);
    }
    void Fire()
    {
        _bulletManager.CreateBullet();
        _playerData.isFiring = true;
    }
}