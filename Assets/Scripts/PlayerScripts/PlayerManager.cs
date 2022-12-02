using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : AbstractSingleton<PlayerManager>
{
    [Header("Sound")]
    private AudioSource _audioSource;

    [Header("Particle Transform")]
    public Transform _particleTransform;

    [Header("Data")]
    public PlayerData _playerData;
    public EnemyData _enemyData;

    [Header("Health")]
    public GameObject _healthBar;

    [Header("JolleenAnimation Transform")]
    [SerializeField] Transform _jolleenTransform;

    [Header("Fire")]
    public int firingRotation;
    private BulletManager _bulletManager;

    [Header("Camera")]
    [SerializeField] CinemachineVirtualCamera _currentCamera;
    [SerializeField] CinemachineVirtualCamera _upCamera;
    [SerializeField] CinemachineVirtualCamera _downCamera;
    //[SerializeField] CinemachineExternalCamera _virtualCamera;

    [Header("Crosshair")]
    public CanvasGroup crosshairImage;

    [Header("Input Movement")]
    public float _xValue;
    public float _zValue;

    [Header("Coin")]
    public GameObject _coinObject;

    [Header("Initial Situations")]
    private float _initJumpForce;
    private float _initPlayerSpeed;

    void Start()
    {
        CreateParticle(ParticleNames.Birth);
        _playerData.clickTabCount = 0;
        _audioSource = GetComponent<AudioSource>();

        //Camera
        _currentCamera = _downCamera;
        _currentCamera.transform.eulerAngles = new Vector3(0f, 270f, 0f);

        _coinObject.SetActive(false);

        _playerData.isDestroyed = false;
        firingRotation = 0;
        _playerData.jumpCount = 0;
        if (_playerData != null)
        {
            _playerData.isPicking = false;
            _playerData.isPickRotateCoin = false;
            _playerData.isLookingUp = false;
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
                _playerData.jumpCount = 0;
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
        if (other.CompareTag(SceneLoadController.Tags.FinishArea.ToString()))
        {
            StartCoroutine(DelayLevelUp(2f, _playerData.danceTime));
        }
        if (other.CompareTag(SceneLoadController.Tags.Coin.ToString()))
        {
            _coinObject.SetActive(true);
            _playerData.isPicking = true;
            PlaySoundEffect(SoundEffectTypes.PickUpCoin);
            other.gameObject.SetActive(false);
            ScoreController.GetInstance.SetScore(23);
        }
        if (other.CompareTag(SceneLoadController.Tags.RotateCoin.ToString()))
        {
            _coinObject.SetActive(true);
            _playerData.isPickRotateCoin = true;
            PlaySoundEffect(SoundEffectTypes.PickUpCoin);
            other.gameObject.SetActive(false);
            ScoreController.GetInstance.SetScore(23);
        }
        if (other.CompareTag(SceneLoadController.Tags.Lava.ToString()))
        {
            _playerData.isDestroyed = true;

            //collision.collider.gameObject._enemyData.isWalking = false;
            //collision.collider._enemyData.enemySpeed = 0;

            //PlayerData
            _playerData.isDying = true;
            _playerData.isIdling = false;
            _playerData.isPlayable = false;
            CreateParticle(ParticleNames.Fire);
            StartCoroutine(DelayDestroy(3f));
        }
        if (other.CompareTag(SceneLoadController.Tags.Water.ToString()))
        {
            _playerData.isDestroyed = true;
            //collision.collider.gameObject._enemyData.isWalking = false;
            //collision.collider._enemyData.enemySpeed = 0;

            //PlayerData
            _playerData.isDying = true;
            _playerData.isIdling = false;
            _playerData.isPlayable = false;
            PlaySoundEffect(SoundEffectTypes.JumpToSea);
            StartCoroutine(DelayDestroy(5f));
        }
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SceneLoadController.Tags.Ladder.ToString()))
        {
            TriggerLadder(false, true);
        }
        if (other.CompareTag(SceneLoadController.Tags.Coin.ToString()))
        {
            //_playerData.isPicking = false;
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

                if (Input.GetKeyDown(KeyCode.Space) && _playerData.isGround && _playerData.jumpCount <= 1)
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
                _currentCamera.transform.eulerAngles = new Vector3(0f, 270f, 0f);
            }
        }        
    }
    void SkateBoard()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && _zValue > 0 && !_playerData.isClimbing && !_playerData.isBackClimbing)
        {
            _playerData.clickTabCount++;
            _playerData.isSkateBoarding = true;
            if (_playerData.clickTabCount > 1)
            {
                //CreateParticle(ParticleNames.Skateboard);
                _playerData.skateboardParticle.Stop();
                _playerData.isSkateBoarding = false;
                _playerData.clickTabCount = 0;
            }            
        }
        if (_playerData.isSkateBoarding)
        {
            CreateParticle(ParticleNames.Skateboard);
            //_skateboardParticle.Play();
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
            _playerData.skateboardParticle.Stop();
            _playerData.playerSpeed = _initPlayerSpeed;
        }
    }
    void Jump()
    {
        if (_playerData.jumpCount == 0)
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
        _playerData.jumpCount++;
    }
    void Rotation()
    {
        float _mousePosX = Input.GetAxis("Mouse X") * _playerData.rotateSpeed * Time.timeScale;
        float _mousePosY = Input.GetAxis("Mouse Y") * _playerData.rotateSpeed * Time.timeScale;

        GetInstance.GetComponent<Transform>().Rotate(0f, _mousePosX, 0f);

        _currentCamera.transform.Rotate(-_mousePosY * Time.timeScale, 0, 0);        

        if (_currentCamera.transform.eulerAngles.x > 74 && _currentCamera.transform.eulerAngles.x <= 75)
        {
            _playerData.isLookingUp = false;
            _currentCamera.transform.eulerAngles = new Vector3(73f, _currentCamera.transform.eulerAngles.y, _currentCamera.transform.eulerAngles.z);
        }
        else if (_currentCamera.transform.eulerAngles.x > 75 && _currentCamera.transform.eulerAngles.x <= 270)
        {
            _playerData.isLookingUp = false;
            _currentCamera.transform.eulerAngles = new Vector3(0f, _currentCamera.transform.eulerAngles.y, _currentCamera.transform.eulerAngles.z);
        }
        else if (_currentCamera.transform.eulerAngles.x < 0)
        {
            _playerData.isLookingUp = true;
            //_currentCamera.transform.eulerAngles = new Vector3(0f, _currentCamera.transform.eulerAngles.y, _currentCamera.transform.eulerAngles.z);
        }
        else if (_currentCamera.transform.eulerAngles.x > 270 && _currentCamera.transform.eulerAngles.x <= 360)
        {
            _playerData.isLookingUp = true;
            _currentCamera = _upCamera;
        }
        else
        {
            _playerData.isLookingUp = false;
        }

        if (_playerData.isLookingUp)
        {
            if (_downCamera.enabled == false)
            {
                _upCamera.gameObject.SetActive(true);
            }
            if (_upCamera.enabled == true )
            {
                _downCamera.gameObject.SetActive(false);
            }
            _currentCamera = _upCamera;
        }
        else
        {
            if (_downCamera.enabled == true)
            {
                _upCamera.gameObject.SetActive(false);
            }
            if (_upCamera.enabled == false)
            {
                _downCamera.gameObject.SetActive(true);
            }
            _currentCamera = _downCamera;
        }
    }
    void Fire()
    {
        PlaySoundEffect(SoundEffectTypes.Shoot);
        _bulletManager.CreateBullet();
        _playerData.isFiring = true;
        crosshairImage.GetComponent<CanvasGroup>().alpha = 1;
        StartCoroutine(Delay(2f));
    }

    void TouchEnemy(Collision collision)
    {
        if (_healthBar.transform.localScale.x <= 0.0625f)
        {
            PlaySoundEffect(SoundEffectTypes.GetHit);

            _playerData.isDestroyed = true;

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
            CreateParticle(ParticleNames.Touch);

            PlaySoundEffect(SoundEffectTypes.GetHit);

            _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / 1.2f, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
        }
    }
    void CreateVictoryAnimation()
    {
        GameObject jolleenObject = Instantiate(_playerData.jolleenObject, _jolleenTransform.transform);
        jolleenObject.transform.position = _jolleenTransform.transform.position;
        Destroy(jolleenObject, _playerData.danceTime);
    }
    void CreateParticle(ParticleNames particleName)
    {
        if (particleName == ParticleNames.Skateboard)
        {            
            GameObject particleObject = Instantiate(_playerData.skateboardParticle.gameObject, _particleTransform.transform);
            particleObject.transform.position = _particleTransform.transform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            Destroy(particleObject, 0.5f);
        }
        if (particleName == ParticleNames.Death)
        {
            GameObject particleObject = Instantiate(_playerData.deathParticle.gameObject, _particleTransform.transform);
            particleObject.transform.position = _particleTransform.transform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            Destroy(particleObject, 5f);
        }
        if (particleName == ParticleNames.Touch)
        {
            GameObject particleObject = Instantiate(_playerData.touchParticle.gameObject, _particleTransform.transform);
            particleObject.transform.position = _particleTransform.transform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            Destroy(particleObject, 0.5f);
        }
        if (particleName == ParticleNames.Birth)
        {
            GameObject particleObject = Instantiate(_playerData.birthParticle.gameObject, _particleTransform.transform);
            particleObject.transform.position = _particleTransform.transform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            StartCoroutine(DelayStopParticle(2f, particleObject));
        }
        if (particleName == ParticleNames.Fire)
        {
            GameObject particleObject = Instantiate(_playerData.firingParticle.gameObject, _particleTransform.transform);
            particleObject.transform.position = _particleTransform.transform.position;
            particleObject.GetComponent<ParticleSystem>().Play();
            StartCoroutine(DelayStopParticle(3f, particleObject));
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
        crosshairImage.GetComponent<CanvasGroup>().alpha = 0;
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
        CreateParticle(ParticleNames.Death);

        yield return new WaitForSeconds(delayDying);
        Destroy(gameObject);
        SceneLoadController.GetInstance.LoadEndScene();
    }
    IEnumerator DelayStopParticle(float value, GameObject particleObject)
    {
        yield return new WaitForSeconds(value);

        Destroy(particleObject);
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
        Birth,
        Fire
    }
}