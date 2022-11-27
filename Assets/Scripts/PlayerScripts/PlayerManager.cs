using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : AbstractSingleton<PlayerManager>
{
    public PlayerData _playerData;
    public int firingRotation;
    public GameObject _healthBar;
    [SerializeField] CinemachineExternalCamera _virtualCamera;
    private BulletManager _bulletManager;
    private EnemyManager _enemyManager;
    public static bool isDestroyed;
    [SerializeField] CanvasGroup _crosshairImage;

    public float _xValue;
    public float _zValue;
    private int _jumpCount;
    private float initJumpForce;
    // Start is called before the first frame update
    void Start()
    {
        initJumpForce = _playerData.jumpForce;
        isDestroyed = false;
        firingRotation = 0;
        _jumpCount = 0;
        if (_playerData != null)
        {
            _playerData.isDying = false;
            _playerData.isFiring = false;
            _playerData.isWalking = false;
            _playerData.isClimbing = false;
            _playerData.isBackWalking = false;
            _playerData.isGround = true;
        }        
        _bulletManager = Object.FindObjectOfType<BulletManager>();
        _enemyManager = Object.FindObjectOfType<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject != null)
        {
            Movement();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (gameObject != null && _healthBar != null)
        {
            if (collision.collider.CompareTag(SceneLoadController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneLoadController.Tags.Bridge.ToString()) || collision.collider.CompareTag(SceneLoadController.Tags.FanceWooden.ToString()))
            {
                _playerData.isGround = true;
                _jumpCount = 0;
            }
            else
            {
                _playerData.isGround = false;
            }
            if (collision.collider.CompareTag(SceneLoadController.Tags.Enemy.ToString()))
            {
                if (_healthBar.transform.localScale.x <= 0.0625f)
                {
                    isDestroyed = true;
                    EnemyAnimationController.isWalking = false;
                    _playerData.isDying = true;
                    _playerData.isIdling = false;
                    _enemyManager._enemySpeed = 0;
                    //StartCoroutine(_enemyManager.DelayStopEnemy());
                    Destroy(_healthBar);
                    StartCoroutine(DelayDestroy(3f));
                }
                else
                {
                    _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / 1.2f, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
                }
            }
        }        
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(SceneLoadController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneLoadController.Tags.Bridge.ToString()))
        {
            //_playerData.isGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneLoadController.Tags.Ladder.ToString()))
        {
            GetInstance.GetComponent<Rigidbody>().isKinematic = true;
            _playerData.isClimbing = true;
        }
        if (other.CompareTag(SceneLoadController.Tags.Water.ToString()))
        {
            StartCoroutine(DelayDestroy(5f));
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
        if (_playerData != null)
        {
            _xValue = Input.GetAxis("Horizontal") * Time.deltaTime * _playerData.playerSpeed / 2f;
            _zValue = Input.GetAxis("Vertical") * Time.deltaTime * _playerData.playerSpeed;
            Walk();

            Rotation();

            if (Input.GetKeyDown(KeyCode.Space) && _playerData.isGround && _jumpCount <= 1)
            {
                if (_jumpCount == 0)
                {
                    _playerData.jumpForce = initJumpForce;
                    _playerData.isJumping = true;
                    Jump();
                }
                else
                {
                    _playerData.jumpForce = initJumpForce / 1.5f;
                    _playerData.isJumping = true;
                    Jump();
                }
                _playerData.jumpForce = initJumpForce;
                _jumpCount++;
            }
            else
            {
                _playerData.isJumping = false;
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Fire();
            }
            else
            {
                _playerData.isFiring = false;
            }
        }
        void Rotation()
        {
            float _mousePosX = Input.GetAxis("Mouse X") * _playerData.rotateSpeed * Time.timeScale;
            float _mousePosY = Input.GetAxis("Mouse Y") * _playerData.rotateSpeed * Time.timeScale;

            GetInstance.GetComponent<Transform>().Rotate(0f, _mousePosX, 0f);

            _virtualCamera.transform.Rotate(-_mousePosY * Time.timeScale, 0, 0);
            if (_virtualCamera.transform.eulerAngles.x > 70 && _virtualCamera.transform.eulerAngles.x <= 75)
            {
                _virtualCamera.transform.eulerAngles = new Vector3(70f, _virtualCamera.transform.eulerAngles.y, _virtualCamera.transform.eulerAngles.z);
            }
            else if (_virtualCamera.transform.eulerAngles.x > 75)
            {
                _virtualCamera.transform.eulerAngles = new Vector3(0f, _virtualCamera.transform.eulerAngles.y, _virtualCamera.transform.eulerAngles.z);
            }
            else if (_virtualCamera.transform.eulerAngles.x < 0)
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
                //GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
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
            GetInstance.GetComponent<Rigidbody>().AddForce(transform.up * _playerData.jumpForce, ForceMode.Impulse);
        }
        void Fire()
        {
            _bulletManager.CreateBullet();
            _playerData.isFiring = true;
            _crosshairImage.alpha = 1;
            StartCoroutine(Delay(2f));
        }         
    }
    IEnumerator Delay(float value)
    {
        yield return new WaitForSeconds(value);
        _crosshairImage.alpha = 0;
    }
    IEnumerator DelayDestroy(float delayDying)
    {
        yield return new WaitForSeconds(delayDying);
        Destroy(gameObject);
        SceneLoadController.GetInstance.LoadEndScene();
    }
}