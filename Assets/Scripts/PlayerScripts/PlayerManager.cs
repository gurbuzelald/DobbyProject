using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : AbstractSingleton<PlayerManager>
{
    [Header("Sound")]
    private AudioSource _audioSource;

    [Header("Particle")]
    [SerializeField] ParticleSystem _skateboardParticle;
    [SerializeField] ParticleSystem _touchParticle;
    [SerializeField] ParticleSystem _birthParticle;
    [SerializeField] ParticleSystem _deathParticle;
    [SerializeField] Transform _particleTransform;

    [Header("Data")]
    public PlayerData _playerData;
    public EnemyData _enemyData;

    [Header("Health")]
    public GameObject _healthBar;

    [Header("JolleenAnimation")]
    [SerializeField] GameObject _jolleenObject;
    [SerializeField] Transform _jolleenTransform;

    [Header("Bools")]
    public static bool isDestroyed;

    [Header("Fire")]
    public int firingRotation;
    private BulletManager _bulletManager;

    [Header("Camera")]
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    //[SerializeField] CinemachineExternalCamera _virtualCamera;

    [Header("Crosshair")]
    [SerializeField] CanvasGroup _crosshairImage;

    public float _xValue;
    public float _zValue;

    private int _jumpCount;
    private float _initJumpForce;

    private float _initPlayerSpeed;

    public int _clickTabCount;

    void Start()
    {
        _clickTabCount = 0;
        _audioSource = GetComponent<AudioSource>();
        _virtualCamera.transform.eulerAngles = new Vector3(0f, 270f, 0f);
        isDestroyed = false;
        firingRotation = 0;
        _jumpCount = 0;
        if (_playerData != null)
        {
            _playerData.isWinning = false;
            _playerData.isSkateBoarding = false;
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
                TouchEnemy(collision);                
            }
            if (collision.collider.CompareTag(SceneLoadController.Tags.Coin.ToString()))
            {
                PlaySoundEffect(SoundEffectTypes.PickUpCoin);
                collision.collider.gameObject.SetActive(false);
                ScoreController.GetInstance.SetScore(230);
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
            PlaySoundEffect(SoundEffectTypes.JumpToSea);
            StartCoroutine(DelayDestroy(5f));
        }
        if (other.CompareTag(SceneLoadController.Tags.FinishArea.ToString()))
        {
            StartCoroutine(DelayLevelUp(2f, 5f));
        }
        if (other.CompareTag(SceneLoadController.Tags.Coin.ToString()))
        {
            PlaySoundEffect(SoundEffectTypes.PickUpCoin);
            other.gameObject.SetActive(false);
            ScoreController.GetInstance.SetScore(23);
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
                Climb();
                SkateBoard();

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
                //VirtualCameraEulerAngle for Victory Dance
                _virtualCamera.transform.eulerAngles = new Vector3(0f, 270f, 0f);
            }
        }        
    }
    void SkateBoard()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && _zValue > 0 && !_playerData.isClimbing && !_playerData.isBackClimbing)
        {
            _clickTabCount++;
            _playerData.isSkateBoarding = true;
            if (_clickTabCount > 1)
            {
                //CreateParticle(ParticleNames.Skateboard);
                _skateboardParticle.Stop();
                _playerData.isSkateBoarding = false;
                _clickTabCount = 0;
            }            
        }
        if (_playerData.isSkateBoarding)
        {
            CreateParticle(ParticleNames.Skateboard);
            _skateboardParticle.Play();
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
        }

    }
    void Walk()
    {
        if (_zValue > 0 && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding)
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
            _playerData.isBackWalking = false;
            _playerData.isWalking = false;
        }  
        SideWalk();
        SpeedController();       
    }
    void Climb()
    {
        if (_zValue > 0 && _playerData.isClimbing && !_playerData.isBackClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, _zValue, 0f);
        }
        else if (_zValue < 0 && !_playerData.isClimbing && _playerData.isBackClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, _zValue, 0f);
        }
    }
    void SideWalk()
    {
        if (_xValue < 0)
        {
            GetInstance.GetComponent<Transform>().Translate(_xValue, 0f, 0f);
        }
        else if (_xValue > 0)
        {
            GetInstance.GetComponent<Transform>().Translate(_xValue, 0f, 0f);
        }
    }
    void SpeedController()
    {
        if ((_xValue > 0 && _zValue > 0) || (_xValue < 0 && _zValue > 0) || (_xValue < 0 && _zValue < 0) || (_xValue > 0 && _zValue < 0) || _zValue < 0)
        {
            _playerData.playerSpeed = _initPlayerSpeed / 1.75f;
        }
        else if (_playerData.isSkateBoarding && _zValue > 0)
        {

            _playerData.playerSpeed = _initPlayerSpeed * 1.3f;

        }
        else
        {
            _skateboardParticle.Stop();
            _playerData.playerSpeed = _initPlayerSpeed;
        }
    }
    void Jump()
    {
        if (_jumpCount == 0)
        {
            PlaySoundEffect(SoundEffectTypes.Jump);
            _playerData.jumpForce = _initJumpForce;
            _playerData.isJumping = true;
            GetInstance.GetComponent<Rigidbody>().AddForce(transform.up * _playerData.jumpForce, ForceMode.Impulse);
        }
        else
        {
            PlaySoundEffect(SoundEffectTypes.Jump);
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
    

    void Fire()
    {
        PlaySoundEffect(SoundEffectTypes.Shoot);
        _bulletManager.CreateBullet();
        _playerData.isFiring = true;
        _crosshairImage.alpha = 1;
        StartCoroutine(Delay(2f));
    }

    
    void CreateVictoryAnimation()
    {
        GameObject jolleenObject = Instantiate(_jolleenObject, _jolleenTransform.transform);
        jolleenObject.transform.position = _jolleenTransform.transform.position;
        Destroy(jolleenObject, 3f);
    }
    void CreateParticle(ParticleNames particleName)
    {
        if (particleName == ParticleNames.Skateboard)
        {
            GameObject particleObject = Instantiate(_skateboardParticle.gameObject, _particleTransform.transform);
            particleObject.transform.position = _particleTransform.transform.position;
            _skateboardParticle.Play();
            Destroy(particleObject, 3f);
        }
        else if (particleName == ParticleNames.Death)
        {
            GameObject particleObject = Instantiate(_deathParticle.gameObject, _particleTransform.transform);
            particleObject.transform.position = _particleTransform.transform.position;
            _deathParticle.Play();
            Destroy(particleObject, 3f);
        }
        else if (particleName == ParticleNames.Touch)
        {
            GameObject particleObject = Instantiate(_touchParticle.gameObject, _particleTransform.transform);
            particleObject.transform.position = _particleTransform.transform.position;
            _touchParticle.Play();
            Destroy(particleObject, 3f);
        }
        else if (particleName == ParticleNames.Birth)
        {
            GameObject particleObject = Instantiate(_birthParticle.gameObject, _particleTransform.transform);
            particleObject.transform.position = _particleTransform.transform.position;
            _birthParticle.Play();
            Destroy(particleObject, 3f);
        }        
    }
    
    void TouchEnemy(Collision collision)
    {
        if (_healthBar.transform.localScale.x <= 0.0625f)
        {
            PlaySoundEffect(SoundEffectTypes.GetHit);

            isDestroyed = true;

            //EnemyAnimation
            collision.gameObject.GetComponent<EnemyManager>().enemyData.isWalking = false;
            collision.gameObject.GetComponent<EnemyManager>().enemyData.enemySpeed = 0;
            //collision.collider.gameObject._enemyData.isWalking = false;
            //collision.collider._enemyData.enemySpeed = 0;

            //PlayerData
            _playerData.isDying = true;
            _playerData.isIdling = false;
            _playerData.isPlayable = false;

            Destroy(_healthBar);
            StartCoroutine(DelayDestroy(3f));
        }
        else
        {
            PlaySoundEffect(SoundEffectTypes.GetHit);

            _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / 1.2f, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
        }
    }
    public void PlaySoundEffect(SoundEffectTypes soundEffect)
    {
        if (soundEffect == SoundEffectTypes.Shoot)
        {
            _audioSource.PlayOneShot(_playerData.shootClip);
        }
        else if (soundEffect == SoundEffectTypes.GetHit)
        {
            _audioSource.PlayOneShot(_playerData.getHitClip);
        }
        else if (soundEffect == SoundEffectTypes.Jump)
        {
            _audioSource.PlayOneShot(_playerData.jumpingClip);
        }
        else if (soundEffect == SoundEffectTypes.Death)
        {
            _audioSource.PlayOneShot(_playerData.dyingClip);
        }
        else if (soundEffect == SoundEffectTypes.GetHit)
        {
            _audioSource.PlayOneShot(_playerData.getHitClip);
        }
        else if (soundEffect == SoundEffectTypes.PickUpCoin)
        {
            _audioSource.PlayOneShot(_playerData.pickupCoinClip);
        }
        else if (soundEffect == SoundEffectTypes.Trap)
        {
            _audioSource.PlayOneShot(_playerData.trapClip);
        }
        else if (soundEffect == SoundEffectTypes.LevelUp)
        {
            _audioSource.PlayOneShot(_playerData.levelUpClip);
        }
        else if (soundEffect == SoundEffectTypes.Jump)
        {
            _audioSource.PlayOneShot(_playerData.jumpingSeaClip);
        }
    }
    IEnumerator Delay(float value)
    {
        yield return new WaitForSeconds(value);
        _crosshairImage.alpha = 0;
    }
    IEnumerator DelayLevelUp(float delayWait, float delayDestroy)
    {
        PlaySoundEffect(SoundEffectTypes.LevelUp);

        yield return new WaitForSeconds(delayWait);
        _playerData.isPlayable = false;
        _playerData.isWinning = true;

        //JolleenAnimation
        CreateVictoryAnimation();

        yield return new WaitForSeconds(delayDestroy);
        Destroy(gameObject);
        SceneLoadController.GetInstance.LevelUp();
    }
    IEnumerator DelayDestroy(float delayDying)
    {
        PlaySoundEffect(SoundEffectTypes.JumpToSea);
        yield return new WaitForSeconds(delayDying);
        Destroy(gameObject);
        SceneLoadController.GetInstance.LoadEndScene();
    }
    public enum SoundEffectTypes
    {
        Shoot,
        GetHit,
        Jump,
        JumpToSea,
        Death,
        PickUpCoin,
        Trap,
        LevelUp
    }
    public enum ParticleNames
    {
        Skateboard,
        Death,
        Touch,
        Birth
    }
}