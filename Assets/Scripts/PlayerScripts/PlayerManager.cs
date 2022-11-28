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
    private float _initJumpForce;
    private float _initPlayerSpeed;

    [SerializeField] GameObject _jolleenObject;
    [SerializeField] Transform _jolleenTransform;
    // Start is called before the first frame update
    void Start()
    {
        _virtualCamera.transform.eulerAngles = new Vector3(0f, 270f, 0f);
        isDestroyed = false;
        firingRotation = 0;
        _jumpCount = 0;
        if (_playerData != null)
        {
            _playerData.isWinning = false;
            _playerData.isPlayable = true;
            _playerData.playerSpeed = 2f;
            _initPlayerSpeed = _playerData.playerSpeed;
            _initJumpForce = _playerData.jumpForce;
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
                TouchEnemy();                
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
            TriggerLadder(true, false);
        }
        if (other.CompareTag(SceneLoadController.Tags.Water.ToString()))
        {
            StartCoroutine(DelayDestroy(5f));
        }
        if (other.CompareTag(SceneLoadController.Tags.FinishArea.ToString()))
        {
            
            StartCoroutine(DelayLevelUp(2f, 5f));
        }
        if (other.CompareTag(SceneLoadController.Tags.Coin.ToString()))
        {
            other.gameObject.SetActive(false);
            ScoreController.GetInstance.SetScore(35);
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SceneLoadController.Tags.Ladder.ToString()))
        {
            TriggerLadder(false, true);
        }
    }
    void TriggerLadder(bool isTouch, bool isTouchExit)
    {
        GetInstance.GetComponent<Rigidbody>().isKinematic = isTouch;
        if (PlayerManager.GetInstance._zValue > 0 && !isTouchExit)
        {
            _playerData.isClimbing = isTouch;
            _playerData.isBackClimbing = !isTouch;
        }
        else if (PlayerManager.GetInstance._zValue < 0 && !isTouchExit)
        {
            _playerData.isBackClimbing = isTouch;
            _playerData.isClimbing = !isTouch;
        }
        else if (isTouchExit && PlayerManager.GetInstance._zValue != 0)
        {
            _playerData.isBackClimbing = isTouch;
            _playerData.isClimbing = isTouch;
            if (PlayerManager.GetInstance._zValue < 0)
            {
                _playerData.isBackWalking = !isTouch;
            }
            else if (PlayerManager.GetInstance._zValue > 0)
            {
                _playerData.isWalking = !isTouch;
            }
        }
    }

    void Movement()
    {
        if (_playerData != null)
        {
            Rotation();
            if (_playerData.isPlayable && !_playerData.isWinning)
            {
                _xValue = Input.GetAxis("Horizontal") * Time.deltaTime * _playerData.playerSpeed / 2f;
                _zValue = Input.GetAxis("Vertical") * Time.deltaTime * _playerData.playerSpeed;
                Walk();

                if (Input.GetKeyDown(KeyCode.Space) && _playerData.isGround && _jumpCount <= 1)
                {
                    Jump();
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
            else if (_playerData.isWinning)
            {
                //VirtualCameraEulerAngle
                _virtualCamera.transform.eulerAngles = new Vector3(0f, 270f, 0f);
            }
        }        
    }
    void Jump()
    {
        if (_jumpCount == 0)
        {
            _playerData.jumpForce = _initJumpForce;
            _playerData.isJumping = true;
            GetInstance.GetComponent<Rigidbody>().AddForce(transform.up * _playerData.jumpForce, ForceMode.Impulse);
        }
        else
        {
            _playerData.jumpForce = _initJumpForce / 1.5f;
            _playerData.isJumping = true;
            GetInstance.GetComponent<Rigidbody>().AddForce(transform.up * _playerData.jumpForce, ForceMode.Impulse);
        }
        _playerData.jumpForce = _initJumpForce;
        _jumpCount++;
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
        if (_zValue > 0 && !_playerData.isClimbing && !_playerData.isBackClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
            _playerData.isWalking = true;
            _playerData.isBackWalking = false;
        }
        else if (_zValue < 0 && !_playerData.isClimbing && !_playerData.isBackClimbing)
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
        else if (_zValue > 0 && _playerData.isClimbing && !_playerData.isBackClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, _zValue, 0f);
        }
        else if (_zValue < 0 && !_playerData.isClimbing && _playerData.isBackClimbing)
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
        if ((_xValue > 0 && _zValue > 0) || (_xValue < 0 && _zValue > 0) || (_xValue < 0 && _zValue < 0) || (_xValue > 0 && _zValue < 0) || _zValue < 0)
        {
            _playerData.playerSpeed = _initPlayerSpeed / 1.75f;
        }
        else
        {
            _playerData.playerSpeed = _initPlayerSpeed;
        }
    }

    void Fire()
    {
        _bulletManager.CreateBullet();
        _playerData.isFiring = true;
        _crosshairImage.alpha = 1;
        StartCoroutine(Delay(2f));
    }

    IEnumerator Delay(float value)
    {
        yield return new WaitForSeconds(value);
        _crosshairImage.alpha = 0;
    }
    IEnumerator DelayLevelUp(float delayWait, float delayDestroy)
    {
        yield return new WaitForSeconds(delayWait);
        _playerData.isPlayable = false;
        _playerData.isWinning = true;

        //JolleenAnimation
        GameObject jolleenObject = Instantiate(_jolleenObject, _jolleenTransform.transform);
        jolleenObject.transform.position = _jolleenTransform.transform.position;

        yield return new WaitForSeconds(delayDestroy);
        Destroy(jolleenObject);
        Destroy(gameObject);
        SceneLoadController.GetInstance.LevelUp();
    }
    IEnumerator DelayDestroy(float delayDying)
    {
        yield return new WaitForSeconds(delayDying);
        Destroy(gameObject);
        SceneLoadController.GetInstance.LoadEndScene();
    }
    
    void TouchEnemy()
    {
        if (_healthBar.transform.localScale.x <= 0.0625f)
        {
            isDestroyed = true;           

            //EnemyAnimation
            EnemyAnimationController.isWalking = false;
            _enemyManager._enemySpeed = 0;

            //PlayerData
            _playerData.isDying = true;
            _playerData.isIdling = false;
            _playerData.isPlayable = false;

            Destroy(_healthBar);
            StartCoroutine(DelayDestroy(3f));
        }
        else
        {
            _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / 1.2f, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
        }
    }
}