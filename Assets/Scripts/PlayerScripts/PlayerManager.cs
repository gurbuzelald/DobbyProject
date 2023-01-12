using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerManager : AbstractSingleton<PlayerManager>
{
    [Header("Scripts")]
    [SerializeField] CloneManager _cloneManager;
    private PlayerController _playerController;

    [Header("Sound")]
    [HideInInspector] public AudioSource audioSource;
    //public PlayerSoundEffect playerSFX;

    [Header("Particle Transform")]
    public Transform _particleTransform;

    [Header("Data")]
    public PlayerData _playerData;
    public EnemyData _enemyData;

    [Header("Health")]
    public GameObject _healthBar;

    [Header("Jolleen Animation Transform")]
    [SerializeField] Transform _jolleenTransform;

    [Header("Fire")]
    public int firingRotation;

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

    [Header("Coin In The Right Hand")]
    public GameObject _coinObject;

    [Header("Initial Situations")]
    private float _initJumpForce;
    private float _initPlayerSpeed;

    [SerializeField] GameObject playerIcon;

    void Start()
    {
        TriggerLadder(false, true); 
        playerIcon.GetComponent<MeshRenderer>().enabled = true;
        DataStatesOnInitial();

        //Particle
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Birth, _particleTransform.transform);

        //Audio
        audioSource = GetComponent<AudioSource>();    


        //GameObjects
        _coinObject.SetActive(false);

        //Camera
        _currentCamera = _downCamera;
        firingRotation = 0;

        //Scripts
        _playerController = Object.FindObjectOfType<PlayerController>();
    }
    void DataStatesOnInitial()
    {
        if (_playerData != null)
        {
            _playerData.clickTabCount = 0;
            _playerData.clickShiftCount = 0;
            _playerData.isDestroyed = false;
            _playerData.jumpCount = 0;
            _playerData.isLose = false;
            _playerData.isTouchFinish = false;
            _playerData.isPicking = false;
            _playerData.isPickRotateCoin = false;
            _playerData.isLookingUp = false;
            _playerData.isWinning = false;
            _playerData.isSkateBoarding = false;
            _playerData.isRunning = false;
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
            if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneController.Tags.Bridge.ToString()) || collision.collider.CompareTag(SceneController.Tags.FanceWooden.ToString()))
            {
                _playerData.isGround = true;
                _playerData.jumpCount = 0;
            }
            else
            {
                _playerData.isGround = false;
            }
            if (collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()) || collision.collider.CompareTag(SceneController.Tags.CloneDobby.ToString()))
            {
                TouchEnemy(collision);
            }
            if (collision.collider.CompareTag(SceneController.Tags.Coin.ToString()))
            {//For Big Coins
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
                collision.collider.gameObject.SetActive(false);
                ScoreController.GetInstance.SetScore(230);
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneController.Tags.Bridge.ToString()))
        {
            //_playerData.isGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.EnemyBullet.ToString()))
        {
            TriggerBullet(other);
        }
        if (other.CompareTag(SceneController.Tags.Ladder.ToString()))
        {
            TriggerLadder(true, false);
        }
        if (other.CompareTag(SceneController.Tags.FinishArea.ToString()))
        {
            StartCoroutine(DelayLevelUp(2f, _playerData.danceTime));
        }
        if (other.CompareTag(SceneController.Tags.Coin.ToString()))
        {
            PickUpCoin(SceneController.Tags.Coin, other);
        }
        if (other.CompareTag(SceneController.Tags.RotateCoin.ToString()))
        {
            PickUpCoin(SceneController.Tags.RotateCoin, other);
        }
        if (other.CompareTag(SceneController.Tags.Lava.ToString()))
        {
            DestroyByLava();
        }
        if (other.CompareTag(SceneController.Tags.Water.ToString()))
        {
            DestroyByWater();
        }
    }    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Ladder.ToString()))
        {
            TriggerLadder(false, true);
        }
    }

    void Movement()
    {
        if (_playerData != null)
        {
            Rotation();
            if (_playerData.isPlayable && !_playerData.isWinning)
            {
                //Getting left stick values
                _xValue = _playerController.movement.x*Time.deltaTime*2f;
                _zValue = _playerController.movement.y*Time.deltaTime*2f;

                //float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * _playerData.playerSpeed / 2f;
                //float zValue = Input.GetAxis("Vertical") * Time.deltaTime * _playerData.playerSpeed;

                //Moves
                Walk();
                Climb();
                SkateBoard();
                Run();
                Jump();
                Fire();
            }
            else if (_playerData.isWinning)
            {
                //VirtualCameraEulerAngle for Salsa Dance
                _currentCamera.transform.eulerAngles = new Vector3(_currentCamera.transform.eulerAngles.x, 180f, _currentCamera.transform.eulerAngles.z);
            }
            else
            {
                _playerData.isFiring = false;
            }
        }
    }
    void SkateBoard()
    {
        if (PlayerController.skateBoard && _zValue > 0 && !_playerData.isClimbing && !_playerData.isBackClimbing)
        {
            _playerData.clickTabCount++;
            _playerData.isSkateBoarding = true;
            if (_playerData.clickTabCount > 1)
            {
                _playerData.skateboardParticle.Stop();
                _playerData.isSkateBoarding = false;
                _playerData.clickTabCount = 0;
            }
        }
        if (_playerData.isSkateBoarding)
        {
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Skateboard, _particleTransform.transform);
            //_skateboardParticle.Play();
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
        }
    }
    void Run()
    {
        if (PlayerController.run && _zValue > 0 && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding)
        {
            _playerData.clickShiftCount++;
            _playerData.isRunning = true;
            if (_playerData.clickShiftCount > 1)
            {
                _playerData.skateboardParticle.Stop();
                _playerData.isRunning = false;
                _playerData.clickShiftCount = 0;
            }
        }
        if (_playerData.isRunning)
        {
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Skateboard, _particleTransform.transform);
            //_skateboardParticle.Play();
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
        }

    }

    void Walk()
    {
        if (_zValue > 0 && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding && !_playerData.isRunning)
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
    void SideWalk()
    {
        if (_xValue < -0.02f || _xValue > 0.02f)
        {
            GetInstance.GetComponent<Transform>().Translate(_xValue, 0f, 0f);
        }
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
    
    void SpeedController()
    {
        if ((_xValue > 0 && _zValue > 0) || (_xValue < 0 && _zValue > 0) || (_xValue < 0 && _zValue < 0) || (_xValue > 0 && _zValue < 0) || _zValue < 0)
        {
            _playerData.playerSpeed = _initPlayerSpeed;
        }
        else if (_playerData.isSkateBoarding && _zValue > 0)
        {
            _playerData.playerSpeed = _initPlayerSpeed * 1.6f;

        }
        else if (_playerData.isRunning && _zValue > 0)
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
        if (_playerController.jump && _playerData.isGround && _playerData.jumpCount <= 1)
        {
            if (_playerData.jumpCount == 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);
                _playerData.jumpForce = _initJumpForce;
                _playerData.isJumping = true;
                GetInstance.GetComponent<Rigidbody>().AddForce(transform.up * _playerData.jumpForce, ForceMode.Impulse);
            }
            else
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);
                _playerData.jumpForce = _initJumpForce / 1.5f;
                _playerData.isJumping = true;
                GetInstance.GetComponent<Rigidbody>().AddForce(transform.up * _playerData.jumpForce, ForceMode.Impulse);
            }
            _playerData.jumpForce = _initJumpForce;
            _playerData.jumpCount++;
        }
        else
        {
            _playerData.isJumping = false;
        }        
    }
    public void Fire()
    {
        if (_playerData.isPlayable)
        {
            if (_playerController.fire)
            {

                _playerData.isFiring = true;
                crosshairImage.GetComponent<CanvasGroup>().alpha = 1;
                StartCoroutine(Delay(2f));
            }
            else
            {
                _playerData.isFiring = false;
            }
        }
        else
        {
            _playerData.isFiring = false;
        }
    }
    void Rotation()
    {
        float _touchX;
        float _touchY;
        if (SceneController.RotateTouchOrMousePos == true)
        {
            //Mouse Rotation Controller
            _touchX = Input.GetAxis("Mouse X") * _playerData.rotateSpeed * Time.timeScale;
            _touchY = Input.GetAxis("Mouse Y") * _playerData.rotateSpeed * Time.timeScale;
        }
        else
        {
            //Touch Rotation Controller
            _touchX = _playerController.lookRotation.x * _playerData.sensivityX * Time.deltaTime;
            _touchY = _playerController.lookRotation.y * _playerData.sensivityY * Time.deltaTime;
        }    
        GetInstance.GetComponent<Transform>().Rotate(0f, _touchX, 0f);
        _currentCamera.transform.Rotate(-_touchY * Time.timeScale, 0, 0);


        //Debug.Log(_playerController.lookRotation.x);
        CheckCameraEulerX();

        //Debug.Log(_currentCamera.transform.eulerAngles.x);
        ChooseCamera();
    }
    
    void CheckCameraEulerX()
    {
        if (_currentCamera.transform.eulerAngles.x > 74 && _currentCamera.transform.eulerAngles.x <= 80)
        {
            _playerData.isLookingUp = false;
            _currentCamera.transform.eulerAngles = new Vector3(0f, _currentCamera.transform.eulerAngles.y, _currentCamera.transform.eulerAngles.z);
        }
        else if (_currentCamera.transform.eulerAngles.x > 355)
        {
            _playerData.isLookingUp = false;
            _currentCamera.transform.eulerAngles = new Vector3(0f, _currentCamera.transform.eulerAngles.y, _currentCamera.transform.eulerAngles.z);
        }
        else if (_currentCamera.transform.eulerAngles.x < 0)
        {
            _playerData.isLookingUp = true;
            _currentCamera.transform.eulerAngles = new Vector3(0f, _currentCamera.transform.eulerAngles.y, _currentCamera.transform.eulerAngles.z);
        }
        else if (_currentCamera.transform.eulerAngles.x > 270 && _currentCamera.transform.eulerAngles.x <= 360)
        {
            _playerData.isLookingUp = true;
            //_currentCamera = _upCamera;
        }
        else
        {
            _playerData.isLookingUp = false;
        }
    }
    void ChooseCamera()
    {
        //if (_playerData.isLookingUp)
        //{
        //    if (_downCamera.enabled == false)
        //    {
        //        _upCamera.gameObject.SetActive(true);
        //    }
        //    if (_upCamera.enabled == true)
        //    {
        //        _downCamera.gameObject.SetActive(false);
        //    }
        //    _currentCamera = _upCamera;
        //}
        //else
        //{
        //    if (_downCamera.enabled == true)
        //    {
        //        _upCamera.gameObject.SetActive(false);
        //    }
        //    if (_upCamera.enabled == false)
        //    {
        //        _downCamera.gameObject.SetActive(true);
        //    }
        //    _currentCamera = _downCamera;
        //}
    }

    //Collision
    void TouchEnemy(Collision collision)
    {
        if (_healthBar.transform.localScale.x <= 0.0625f)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetHit);

            _playerData.isDestroyed = true;

            //EnemyAnimation
            if (collision.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()))
            {
                collision.gameObject.GetComponent<EnemyManager>().enemyData.isWalking = false;
                collision.gameObject.GetComponent<EnemyManager>().enemyData.enemySpeed = 0;
            }
            if (collision.gameObject.CompareTag(SceneController.Tags.CloneDobby.ToString()))
            {
                collision.gameObject.GetComponent<CloneManager>().cloneData.isCloneDancing = true;
                collision.gameObject.GetComponent<CloneManager>().cloneData.isCloneWalking = false;
            }

            //PlayerData
            _playerData.isDying = true;
            _playerData.isIdling = false;
            _playerData.isPlayable = false;

            Destroy(_healthBar);
            StartCoroutine(DelayDestroy(3f));
        }
        else
        {
            if (collision.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()) && collision.gameObject.GetComponent<EnemyManager>()._healthBar == null)
            {
                collision.gameObject.GetComponent<EnemyManager>().enemyData.isTouchable = false;
            }
            if (collision.gameObject.GetComponent<EnemyManager>().enemyData.isTouchable)
            {
                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);

                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetHit);

                _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / 1.1f, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
            }
        }
    }

    //Triggers
    void TriggerBullet(Collider other)
    {
        if (_healthBar != null)
        {
            if (_healthBar.transform.localScale.x <= 0.0625f)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetHit);

                _playerData.isDestroyed = true;

                //EnemyAnimation
                if (other.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()))
                {
                    other.gameObject.GetComponent<EnemyManager>().enemyData.isWalking = false;
                    other.gameObject.GetComponent<EnemyManager>().enemyData.enemySpeed = 0;
                }
                if (other.gameObject.CompareTag(SceneController.Tags.CloneDobby.ToString()))
                {
                    other.gameObject.GetComponent<CloneManager>().cloneData.isCloneDancing = true;
                    other.gameObject.GetComponent<CloneManager>().cloneData.isCloneWalking = false;
                }


                //PlayerData
                _playerData.isDying = true;
                _playerData.isIdling = false;
                _playerData.isPlayable = false;

                Destroy(_healthBar);
                StartCoroutine(DelayDestroy(3f));
            }
            else
            {
                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);
                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.TouchBurning, _particleTransform.transform);

                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetHit);

                _healthBar.transform.localScale = new Vector3(_healthBar.transform.localScale.x / 1.05f, _healthBar.transform.localScale.y, _healthBar.transform.localScale.z);
            }
        }
    }
    void PickUpCoin(SceneController.Tags value, Collider other)
    {
        if (value == SceneController.Tags.Coin)
        {
            _playerData.playerSpeed = 0.5f;
            _coinObject.SetActive(true);
            _playerData.isPicking = true;
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
            other.gameObject.SetActive(false);
            ScoreController.GetInstance.SetScore(23);
        }
        else if (value == SceneController.Tags.RotateCoin)
        {
            _playerData.playerSpeed = 0.5f;
            _coinObject.SetActive(true);
            _playerData.isPickRotateCoin = true;
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
            other.gameObject.SetActive(false);
            ScoreController.GetInstance.SetScore(23);
        }
    }
    void DestroyByWater()
    {
        _playerData.isDestroyed = true;
        //collision.collider.gameObject._enemyData.isWalking = false;
        //collision.collider._enemyData.enemySpeed = 0;

        //PlayerData
        _playerData.isDying = true;
        _playerData.isIdling = false;
        _playerData.isPlayable = false;
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.JumpToSea);
        StartCoroutine(DelayDestroy(5f));
    }
    void DestroyByLava()
    {
        _playerData.isDestroyed = true;

        //collision.collider.gameObject._enemyData.isWalking = false;
        //collision.collider._enemyData.enemySpeed = 0;

        //PlayerData
        _playerData.isDying = true;
        _playerData.isIdling = false;
        _playerData.isPlayable = false;
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Burn, _particleTransform.transform);
        StartCoroutine(DelayDestroy(3f));
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


    void CreateVictoryAnimation()
    {
        GameObject jolleenObject = Instantiate(_playerData.jolleenObject, _jolleenTransform.transform);
        jolleenObject.transform.position = _jolleenTransform.transform.position;
        Destroy(jolleenObject, _playerData.danceTime);
    }

    IEnumerator Delay(float value)
    {        
        yield return new WaitForSeconds(value);
        crosshairImage.GetComponent<CanvasGroup>().alpha = 0;
    }
    IEnumerator DelayLevelUp(float delayWait, float delayDestroy)
    {
        Destroy(_healthBar);
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.LevelUp);
        _playerData.isTouchFinish = true;

        yield return new WaitForSeconds(delayWait);
        _playerData.isPlayable = false;
        _playerData.isWinning = true;

        //JolleenAnimation
        CreateVictoryAnimation();

        yield return new WaitForSeconds(delayDestroy);
        //Destroy(gameObject);
        SceneController.GetInstance.LevelUp();
    }
    IEnumerator DelayDestroy(float delayDying)
    {
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Death, _particleTransform.transform);

        yield return new WaitForSeconds(delayDying);
        Destroy(gameObject);
        SceneController.GetInstance.LoadEndScene();
    }
}