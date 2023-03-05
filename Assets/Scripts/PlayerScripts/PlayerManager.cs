using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : AbstractSingleton<PlayerManager>
{
    [Header("Scripts")]
    private PlayerController _playerController;

    [Header("Sound")]
    [HideInInspector] public AudioSource audioSource;

    [Header("Data")]
    public PlayerData _playerData;
    public EnemyData _enemyData;
    public BulletData _bulletData;

    [Header("Current Spawn Transforms")]
    public Transform _particleTransform;
    public Transform _currentCameraTransform;

    [HideInInspector]
    public Transform bulletCoinTransform;

    [SerializeField] Transform _jolleenTransform;
    [SerializeField] Transform playerIconTransform;
    [SerializeField] Transform healthBarTransform;
    [SerializeField] Transform _bulletsTransform;    
    [SerializeField] Transform _cameraWasherTransform;

    public Transform[] _slaveTransforms;
    public Transform slaves;
    private GameObject slaveObject;

    [Header("CinemachineVirtualCamera")]
    public CinemachineVirtualCamera _currentCamera;
    //public CinemachineVirtualCamera _farCamera;
    //public CinemachineVirtualCamera _closeCamera;
    public GameObject cameraSpawner;
    //public CinemachineVirtualCamera _upCamera;
    //public CinemachineVirtualCamera _downCamera;

    [Header("Crosshair")]
    public CanvasGroup crosshairImage;

    [Header("Input Movement")]
    public float _xValue;
    public float _zValue;
    private float _touchX;
    private float _touchY;        

    [Header("Initial Situations")]
    private float _initPlayerSpeed;

    public ObjectPool _objectPool;

    [SerializeField] GameObject _warmArrow;

    [HideInInspector]
    public GameObject _gunTransform;
    [HideInInspector]
    public GameObject _swordTransform;
    [HideInInspector]
    public GameObject _coinObject;
    [HideInInspector]
    public GameObject _cheeseObject;

    [Header("Character Hands")]
    [HideInInspector]
    public GameObject _pinkyGlassy;
    [HideInInspector]
    public GameObject _pinkySpartacus;
    [HideInInspector]
    public GameObject _pinkyDobby;
    [HideInInspector]
    public GameObject _pinkyLusth;
    [HideInInspector]
    public GameObject _pinkyGuard;
    [HideInInspector]

    [Header("Character Object")]
    public GameObject _currentCharacterObject;
    [SerializeField] GameObject _characterObject;
    private GameObject characterObject;

    [Header("Show Bullet Amoun")]
    private GameObject bulletAmountCanvas;
    private GameObject _healthBarObject;
    [SerializeField] GameObject _topCanvasHealthBarObject;

    void Start()
    {
        //Scripts
        _playerController = FindObjectOfType<PlayerController>();

        CreateCharacterObject();

        FindHandObjectTransforms();

        CreateStartPlayerStaff(_playerData);

        DataStatesOnInitial(_playerData);

        TriggerLadder(false, true, _playerData);

        PlayerRandomSpawn(_playerData);

        //Particle
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Birth, _particleTransform.transform);

        //Audio
        audioSource = GetComponent<AudioSource>();        
    }

    private void FixedUpdate()
    {
        if (_playerData.isPlayable && !_playerData.isWinning)
        {
            Fire(_playerData);            
        }
        
    }
    void Update()
    {
        ChangeCamera();

        if (_warmArrow != null)
        {
            if (_warmArrow.transform.localScale == Vector3.one)
            {
                StartCoroutine(DelayWarmArrowDirection());
            }
        }
        if (gameObject != null)
        {
            Movement(_playerData);//PlayerStatements
        }
        
    }
    void ChangeCamera()
    {
        if (_zValue == 0 && _xValue == 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y == 0)
        {
            cameraSpawner.transform.GetChild(1).gameObject.transform.position = cameraSpawner.transform.GetChild(0).gameObject.transform.position;
            cameraSpawner.transform.GetChild(1).gameObject.transform.rotation = cameraSpawner.transform.GetChild(0).gameObject.transform.rotation;
            cameraSpawner.transform.GetChild(0).gameObject.SetActive(false);
            cameraSpawner.transform.GetChild(1).gameObject.SetActive(true);
            _currentCamera = cameraSpawner.transform.GetChild(1).gameObject.GetComponent<CinemachineVirtualCamera>();
            _currentCamera.m_Follow = gameObject.transform;
            _currentCamera.m_LookAt = gameObject.transform;
        }
        else if (_zValue != 0 && _xValue == 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y == 0)
        {
            cameraSpawner.transform.GetChild(0).gameObject.transform.position = cameraSpawner.transform.GetChild(1).gameObject.transform.position;
            cameraSpawner.transform.GetChild(0).gameObject.transform.rotation = cameraSpawner.transform.GetChild(1).gameObject.transform.rotation;

            cameraSpawner.transform.GetChild(1).gameObject.SetActive(false);
            cameraSpawner.transform.GetChild(0).gameObject.SetActive(true);
            _currentCamera = cameraSpawner.transform.GetChild(0).gameObject.GetComponent<CinemachineVirtualCamera>();
            _currentCamera.m_Follow = gameObject.transform;
            _currentCamera.m_LookAt = gameObject.transform;
        }
        else if (_zValue == 0 && _xValue != 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y == 0)
        {
            cameraSpawner.transform.GetChild(0).gameObject.transform.position = cameraSpawner.transform.GetChild(1).gameObject.transform.position;
            cameraSpawner.transform.GetChild(0).gameObject.transform.rotation = cameraSpawner.transform.GetChild(1).gameObject.transform.rotation;

            cameraSpawner.transform.GetChild(1).gameObject.SetActive(false);
            cameraSpawner.transform.GetChild(0).gameObject.SetActive(true);
            _currentCamera = cameraSpawner.transform.GetChild(0).gameObject.GetComponent<CinemachineVirtualCamera>();
            _currentCamera.m_Follow = gameObject.transform;
            _currentCamera.m_LookAt = gameObject.transform;
        }
        else if (_zValue != 0 && _xValue != 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y == 0)
        {
            cameraSpawner.transform.GetChild(0).gameObject.transform.position = cameraSpawner.transform.GetChild(1).gameObject.transform.position;
            cameraSpawner.transform.GetChild(0).gameObject.transform.rotation = cameraSpawner.transform.GetChild(1).gameObject.transform.rotation;

            cameraSpawner.transform.GetChild(1).gameObject.SetActive(false);
            cameraSpawner.transform.GetChild(0).gameObject.SetActive(true);
            _currentCamera = cameraSpawner.transform.GetChild(0).gameObject.GetComponent<CinemachineVirtualCamera>();
            _currentCamera.m_Follow = gameObject.transform;
            _currentCamera.m_LookAt = gameObject.transform;
        }
        else if (_zValue == 0 && _xValue == 0 && _playerController.lookRotation.x != 0 && _playerController.lookRotation.y == 0)
        {
            //Do Nothing
        }
        else if (_zValue != 0 && _xValue == 0 && _playerController.lookRotation.x != 0 && _playerController.lookRotation.y == 0)
        {
            //Do Nothing
        }
        else if (_zValue == 0 && _xValue != 0 && _playerController.lookRotation.x != 0 && _playerController.lookRotation.y == 0)
        {
            //Do Nothing
        }
        else if (_zValue != 0 && _xValue != 0 && _playerController.lookRotation.x != 0 && _playerController.lookRotation.y == 0)
        {
            //Do Nothing
        }
        else if (_zValue == 0 && _xValue == 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y != 0)
        {
            //Do Nothing
        }
        else if (_zValue != 0 && _xValue == 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y != 0)
        {
            //Do Nothing
        }
        else if (_zValue == 0 && _xValue != 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y != 0)
        {
            //Do Nothing
        }
        else if (_zValue != 0 && _xValue != 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y != 0)
        {
            //Do Nothing
        }
        else if (_zValue == 0 && _xValue == 0 && _playerController.lookRotation.x != 0 && _playerController.lookRotation.y != 0)
        {
            //Do Nothing
        }
        else if (_zValue != 0 && _xValue == 0 && _playerController.lookRotation.x != 0 && _playerController.lookRotation.y != 0)
        {
            //Do Nothing
        }
        else if (_zValue == 0 && _xValue != 0 && _playerController.lookRotation.x != 0 && _playerController.lookRotation.y != 0)
        {
            //Do Nothing
        }
        else if (_zValue != 0 && _xValue != 0 && _playerController.lookRotation.x != 0 && _playerController.lookRotation.y != 0)
        {
            //Do Nothing
        }
        else
        {
            //Do Nothing
        }
    }
    private void OnCollisionEnter(Collision collision)
    {        
        if (gameObject != null && _playerData.objects[3] != null)
        {
            if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneController.Tags.Bridge.ToString()) || 
                collision.collider.CompareTag(SceneController.Tags.FanceWooden.ToString()) || collision.collider.CompareTag(SceneController.Tags.Magma.ToString()))
            {//Ground, Bridge, FanceWooden, Magma
             //PlayerData
                _playerData.isGround = true;
                _playerData.jumpCount = 0;
            }
            else
            {
                //PlayerData
                _playerData.isGround = false;
            }
            if (collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()) || collision.collider.CompareTag(SceneController.Tags.CloneDobby.ToString()))
            {
                TouchEnemy(collision, _playerData);
            }
            if (collision.collider.CompareTag(SceneController.Tags.Coin.ToString()))
            {//For Big Coins
                //SoundEffect
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
                //PickUpCoinSFX(_playerData);

                //HitCoinBigObject
                collision.collider.gameObject.SetActive(false);

                //SettingScore
                ScoreController.GetInstance.SetScore(230);
                ScoreTextGrowing(0, 255, 0);
                //CreateSlaveObject();
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(SceneController.Tags.Magma.ToString()))
        {
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneController.Tags.Bridge.ToString()))
        {
            //_playerData.isGround = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.EnemyBullet.ToString()))
        {
            TriggerBullet(other, _playerData);
        }
        if (other.CompareTag(SceneController.Tags.Ladder.ToString()))
        {
            TriggerLadder(true, false, _playerData);
        }
        if (other.CompareTag(SceneController.Tags.FirstFinishArea.ToString()))
        {
            StartCoroutine(DelayLevelUp(2f, _playerData.danceTime, _playerData, other));//LevelUpWithCoroutine
        }
        else if (other.CompareTag(SceneController.Tags.SecondFinishArea.ToString()))
        {
            StartCoroutine(DelayLevelUp(2f, _playerData.danceTime, _playerData, other));//LevelUpWithCoroutine
        }
        else if (other.CompareTag(SceneController.Tags.ThirdFinishArea.ToString()))
        {
            StartCoroutine(DelayLevelUp(2f, _playerData.danceTime, _playerData, other));//LevelUpWithCoroutine
        }


        if (other.CompareTag(SceneController.Tags.Coin.ToString()))
        {
            PickUpCoin(SceneController.Tags.Coin, other, _playerData);//GetScore
        }
        if (other.CompareTag(SceneController.Tags.CheeseCoin.ToString()))
        {
            PickUpCoin(SceneController.Tags.CheeseCoin, other, _playerData);//GetScore
        }
        if (other.CompareTag(SceneController.Tags.RotateCoin.ToString()))
        {
            PickUpCoin(SceneController.Tags.RotateCoin, other, _playerData);//GetScore
        }
        if (other.CompareTag(SceneController.Tags.MushroomCoin.ToString()))
        {
            PickUpCoin(SceneController.Tags.MushroomCoin, other, _playerData);//GetScore
        }
        if (other.CompareTag(SceneController.Tags.BulletCoin.ToString()))
        {
            PickUpCoin(SceneController.Tags.BulletCoin, other, _playerData);//FreshBulletAmount
        }


        if (other.CompareTag(SceneController.Tags.Lava.ToString()))
        {
            DestroyByLava(_playerData);//DeathByLava
        }
        if (other.CompareTag(SceneController.Tags.Water.ToString()))
        {
            DestroyByWater(_playerData);//DeathByLadder
        }
        CheckWeaponTrigger(other);

    }
    public void CheckWeaponTrigger(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Rifle.ToString()) && _bulletData.currentWeaponName != BulletData.rifle)
        {
            Destroy(other.gameObject);
            _bulletData.isRifle = true;
        }
        else if(other.CompareTag(SceneController.Tags.Rifle.ToString()) && _bulletData.currentWeaponName == BulletData.rifle)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }
        if (other.CompareTag(SceneController.Tags.Ak47.ToString()) && _bulletData.currentWeaponName != BulletData.ak47)
        {
            Destroy(other.gameObject);
            _bulletData.isAk47 = true;
        }
        else if(other.CompareTag(SceneController.Tags.Ak47.ToString()) && _bulletData.currentWeaponName == BulletData.ak47)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }
        if (other.CompareTag(SceneController.Tags.Axegun.ToString()) && _bulletData.currentWeaponName != BulletData.axegun)
        {
            Destroy(other.gameObject);
            _bulletData.isAxegun = true;
        }
        else if(other.CompareTag(SceneController.Tags.Axegun.ToString()) && _bulletData.currentWeaponName == BulletData.axegun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }
        if (other.CompareTag(SceneController.Tags.Bulldog.ToString()) && _bulletData.currentWeaponName != BulletData.bulldog)
        {
            Destroy(other.gameObject);
            _bulletData.isBulldog = true;
        }
        else if (other.CompareTag(SceneController.Tags.Bulldog.ToString()) && _bulletData.currentWeaponName == BulletData.bulldog)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }
        if (other.CompareTag(SceneController.Tags.Cowgun.ToString()) && _bulletData.currentWeaponName != BulletData.cowgun)
        {
            Destroy(other.gameObject);
            _bulletData.isCowgun = true;
        }
        else if(other.CompareTag(SceneController.Tags.Cowgun.ToString()) && _bulletData.currentWeaponName == BulletData.cowgun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }
        if (other.CompareTag(SceneController.Tags.Crystalgun.ToString()) && _bulletData.currentWeaponName != BulletData.crystalgun)
        {
            Destroy(other.gameObject);
            _bulletData.isCrystalgun = true;
        }
        else if(other.CompareTag(SceneController.Tags.Crystalgun.ToString()) && _bulletData.currentWeaponName == BulletData.crystalgun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }
        if (other.CompareTag(SceneController.Tags.Demongun.ToString()) && _bulletData.currentWeaponName != BulletData.demongun)
        {
            Destroy(other.gameObject);
            _bulletData.isDemongun = true;
        }
        else if(other.CompareTag(SceneController.Tags.Demongun.ToString()) && _bulletData.currentWeaponName != BulletData.demongun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }
        if (other.CompareTag(SceneController.Tags.Icegun.ToString()) && _bulletData.currentWeaponName != BulletData.icegun)
        {
            Destroy(other.gameObject);
            _bulletData.isIcegun = true;
        }
        else if(other.CompareTag(SceneController.Tags.Icegun.ToString()) && _bulletData.currentWeaponName == BulletData.icegun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }
        if (other.CompareTag(SceneController.Tags.Negev.ToString()) && _bulletData.currentWeaponName != BulletData.negev)
        {
            Destroy(other.gameObject);
            _bulletData.isNegev = true;
        }
        else if(other.CompareTag(SceneController.Tags.Negev.ToString()) && _bulletData.currentWeaponName == BulletData.negev)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }
    }
    IEnumerator DelayTransformOneGiftBoxWarmText(Collider other)
    {
        yield return new WaitForSeconds(1f);
        other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.zero;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Ladder.ToString()))
        {
            TriggerLadder(false, true, _playerData);//ExitLadder
        }
    }

    void Movement(PlayerData _playerData)
    {
        if (_playerData != null)
        {
            Rotation(_playerData);
            if (_playerData.isPlayable && !_playerData.isWinning)
            {
                //Getting left stick values
                _xValue = _playerController.movement.x * Time.deltaTime * 2f;
                _zValue = _playerController.movement.y * Time.deltaTime * 2f;

                //float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * _playerData.playerSpeed / 2f;
                //float zValue = Input.GetAxis("Vertical") * Time.deltaTime * _playerData.playerSpeed;

                //Moves
                Walk(_playerData);
                Climb(_playerData);
                SkateBoard(_playerData);
                Run(_playerData);
                Jump(_playerData);
                //Fire(_playerData);
                Sword(_playerData);
            }
            else if (_playerData.isWinning)
            {
                //VirtualCameraEulerAngle for Salsa Dance
                _currentCameraTransform.transform.eulerAngles = new Vector3(_currentCameraTransform.transform.eulerAngles.x, 
                                                                            180f, 
                                                                            _currentCameraTransform.transform.eulerAngles.z);
            }
            else
            {
                //PlayerData
                _playerData.isFiring = false;
            }
        }
    }
    void SkateBoard(PlayerData _playerData)
    {//StyleWalking
        if (PlayerController.skateBoard && _zValue > 0 && !_playerData.isClimbing && !_playerData.isBackClimbing)
        {
            //PlayerData
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
            //ParticleEffect
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Skateboard, _particleTransform.transform);

            //_skateboardParticle.Play();
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
        }
    }
    void Run(PlayerData _playerData)
    {//FasterWalking
        if (PlayerController.run && _zValue > 0 && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding)
        {
            //PlayerData
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
            //ParticleEffect
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Skateboard, _particleTransform.transform);

            //_skateboardParticle.Play();
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
        }

    }

    void Walk(PlayerData _playerData)
    {//ForwardAndBackWalking
        if (!_playerData.isLockedWalking)
        {
            if ((_zValue > 0.01f && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding && !_playerData.isRunning))
            {
                GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
                //PlayerData
                _playerData.isWalking = true;
                _playerData.isBackWalking = false;
            }
            else if (_zValue < 0 && !_playerData.isClimbing && !_playerData.isBackClimbing)
            {
                //PlayerData
                GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue);
                _playerData.isBackWalking = true;
                _playerData.isWalking = false;
            }
            else if (_zValue == 0)
            {
                //PlayerData
                _playerData.isBackWalking = false;
                _playerData.isWalking = false;
            }

        }
        else
        {
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _playerData.playerSpeed * Time.deltaTime / 4f);
        }
        SideWalk(_playerData);
        SpeedController(_playerData);
    }
    void SideWalk(PlayerData _playerData)
    {//LeftAndRightWalking
        if ((!_playerData.isClimbing && !_playerData.isBackClimbing) && (_xValue < -0.02f || _xValue > 0.02f))
        {
            GetInstance.GetComponent<Transform>().Translate(_xValue, 0f, 0f);
        }

    }
    void Climb(PlayerData _playerData)
    {//WhenEnterToTheLadderGoToClimb
        if (_zValue > 0 && _playerData.isClimbing && !_playerData.isBackClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, _zValue, 0f);
        }
        else if (_zValue < 0 && !_playerData.isClimbing && _playerData.isBackClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, _zValue, 0f);
        }
    }

    void SpeedController(PlayerData _playerData)
    {
        if (!_playerData.isLockedWalking)
        {
            if ((_xValue > 0 && _zValue > 0) || (_xValue < 0 && _zValue > 0) || (_xValue < 0 && _zValue < 0) || (_xValue > 0 && _zValue < 0) || _zValue < 0)
            {
                //PlayerData
                _playerData.playerSpeed = _initPlayerSpeed;
            }
            else if (_playerData.isSkateBoarding && _zValue > 0)
            {
                //PlayerData
                _playerData.playerSpeed = _initPlayerSpeed * 1.6f;

            }
            else if (_playerData.isRunning && _zValue > 0)
            {
                //PlayerData
                _playerData.playerSpeed = _initPlayerSpeed * 1.3f;
            }
            else
            {
                //PlayerData
                _playerData.skateboardParticle.Stop();
                _playerData.playerSpeed = _initPlayerSpeed;
            }
        }
    }
    void Jump(PlayerData _playerData)
    {      
        if (_playerController.jump  && _playerData.jumpCount == 0 && _playerData.isGround)
        {

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);
            //JumpSFX(_playerData);

            //PlayerData
            _playerData.isJumping = true;

            //AddForceForJump
            GetInstance.GetComponent<Rigidbody>().AddForce(transform.up * _playerData.jumpForce, ForceMode.Impulse);
            _playerData.jumpCount++;
        }
        else
        {
            //PlayerData
            _playerData.isJumping = false;
        }
        
    }
    public void Fire(PlayerData _playerData)
    {
        if (_playerData.isPlayable && _playerController.fire)
        {
            if (_playerData.bulletAmount <= 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
            }
            //PlayerData
            if (_playerData.bulletAmount <= 0)
            {
                bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = _playerData.bulletAmount.ToString();
                _playerData.isFiring = false;

            }
            else if (_playerData.bulletAmount <= _playerData.bulletPack / 2f)
            {
                _playerData.bulletAmount--;
                bulletAmountCanvas.transform.GetChild(0).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = _playerData.bulletAmount.ToString();
                //_bulletAmountText.gameObject.transform.GetChild(0).gameObject.transform.GetComponent<Material>().color = Color.red;
                _playerData.isFiring = true;

            }
            else if(_playerData.bulletAmount >= _playerData.bulletPack / 2f)
            {
                bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().gameObject.transform.localScale = Vector3.one;
                //_bulletAmountText.gameObject.transform.GetChild(0).gameObject.transform.GetComponent<>().color = Color.cyan;

                _playerData.bulletAmount--;
                bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = _playerData.bulletAmount.ToString();
                _playerData.isFiring = true;

            }

            //Crosshair
            crosshairImage.GetComponent<CanvasGroup>().alpha = 1;

            //SetFalseBullet
            StartCoroutine(Delay(2f));
        }
        else
        {
            _playerData.isFiring = false;
        }
    }
    public void Sword(PlayerData _playerData)
    {
        if (_playerData.isPlayable)
        {
            if (_playerController.sword && _playerData.isSwordTime)
            {
                //PlayerData
                _playerData.isSwording = true;

                //Crosshair
                crosshairImage.GetComponent<CanvasGroup>().alpha = 1;

                //SetFalseBullet
                StartCoroutine(Delay(2f));
            }
            else
            {
                _playerData.isSwording = false;
            }
        }
        else
        {
            _playerData.isFiring = false;
        }
    }
    IEnumerator DelaySwordBullet()
    {
        yield return new WaitForSeconds(1f);
        _playerData.isSwording = true;
    }
    void Rotation(PlayerData _playerData)
    {
        if (SceneController.rotateTouchOrMousePos == true)
        {
            //Mouse Rotation Controller
            _touchX = Input.GetAxis("Mouse X") * _playerData.rotateSpeed * Time.timeScale;
            _touchY = Input.GetAxis("Mouse Y") * _playerData.rotateSpeed * Time.timeScale;
        }
        else
        {

            //Touch Rotation Controller
            SensivityXSetting(1, _playerController, _playerData);
            _touchY = _playerController.lookRotation.y * _playerData.sensivityY * Time.deltaTime * 40;
        }
        //Rotating With Camera On X Axis
        GetInstance.GetComponent<Transform>().Rotate(0f, _touchX, 0f);

        //Rotating Just Camera On Y Axis
        _currentCameraTransform.transform.Rotate(-_touchY * Time.timeScale / 10, 0f, 0f);


        //Debug.Log(_playerController.lookRotation.x);
        CheckCameraEulerX(_playerData);

        //Debug.Log(_currentCamera.transform.eulerAngles.x);
        ChooseCamera();
    }
    void SensivityXSetting(int touchXValue,  PlayerController _playerController, PlayerData _playerData)
    {//ControllerSmoothForXAxis
        if ((_playerController.lookRotation.x >= -0.2f && _playerController.lookRotation.x < 0f) || (_playerController.lookRotation.x <= 0.2f && _playerController.lookRotation.x > 0f))
        {
            _touchX = (_playerController.lookRotation.x * 2f) / 8f * _playerData.sensivityX * Time.timeScale * touchXValue;
        }
        else if ((_playerController.lookRotation.x >= -0.4f && _playerController.lookRotation.x < -0.2f) || (_playerController.lookRotation.x <= 0.4f && _playerController.lookRotation.x > 0.2f))
        {
            _touchX = (_playerController.lookRotation.x * 2f) / 7f * _playerData.sensivityX * Time.timeScale * touchXValue;
        }
        else if ((_playerController.lookRotation.x >= -0.6f && _playerController.lookRotation.x < -0.4f) || (_playerController.lookRotation.x <= 0.6f && _playerController.lookRotation.x > 0.4f))
        {
            _touchX = (_playerController.lookRotation.x * 2f) / 6f * _playerData.sensivityX * Time.timeScale * touchXValue;
        }
        else if ((_playerController.lookRotation.x >= -0.8f && _playerController.lookRotation.x < -0.6f) || (_playerController.lookRotation.x <= 0.8f && _playerController.lookRotation.x > 0.6f))
        {
            _touchX = (_playerController.lookRotation.x * 2f) / 5f * _playerData.sensivityX * Time.timeScale * touchXValue;
        }
        else
        {
            _touchX = (_playerController.lookRotation.x * 2f) / 4f * _playerData.sensivityX * Time.timeScale * touchXValue;
        }
    }

    void CheckCameraEulerX(PlayerData _playerData)
    {
        if (_currentCameraTransform.transform.eulerAngles.x > 74 && _currentCameraTransform.transform.eulerAngles.x <= 80)
        {
            //PlayerData
            _playerData.isLookingUp = false;

            //CinemachineVirtualCamera
            _currentCameraTransform.transform.eulerAngles = new Vector3(0f, _currentCameraTransform.transform.eulerAngles.y, _currentCameraTransform.transform.eulerAngles.z);
        }
        else if (_currentCameraTransform.transform.eulerAngles.x > 355)
        {
            //PlayerData
            _playerData.isLookingUp = false;

            //CinemachineVirtualCamera
            _currentCameraTransform.transform.eulerAngles = new Vector3(0f, _currentCameraTransform.transform.eulerAngles.y, _currentCameraTransform.transform.eulerAngles.z);
        }
        else if (_currentCameraTransform.transform.eulerAngles.x < 0)
        {
            //PlayerData
            _playerData.isLookingUp = true;

            //CinemachineVirtualCamera
            _currentCameraTransform.transform.eulerAngles = new Vector3(0f, _currentCameraTransform.transform.eulerAngles.y, _currentCameraTransform.transform.eulerAngles.z);
        }
        else if (_currentCameraTransform.transform.eulerAngles.x > 270 && _currentCameraTransform.transform.eulerAngles.x <= 360)
        {
            //PlayerData
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
    void TouchEnemy(Collision collision, PlayerData _playerData)
    {
        if (_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value == 0)
        {
            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
            //DeathSFX(_playerData);

            //EnemyAnimation--Collision
            if (collision.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()))
            {
                collision.gameObject.GetComponent<EnemyManager>().enemyData.isWalking = false;
                collision.gameObject.GetComponent<EnemyManager>().enemyData.enemySpeed = 0;
            }
            if (collision.gameObject.CompareTag(SceneController.Tags.CloneDobby.ToString()))
            {
                collision.gameObject.GetComponent<CloneSpawner>().cloneData.isCloneDancing = true;
                collision.gameObject.GetComponent<CloneSpawner>().cloneData.isCloneWalking = false;
            }

            _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

            //PlayerData
            _playerData.isDestroyed = true;
            _playerData.isDying = true;
            _playerData.isIdling = false;
            _playerData.isPlayable = false;
            _playerData.objects[3].transform.localScale = Vector3.zero;
            
            StartCoroutine(DelayDestroy(7f));
        }
        else
        {
            if (collision.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()) && collision.gameObject.GetComponent<EnemyManager>()._healthBar == null)
            {
                //Hit
                collision.gameObject.GetComponent<EnemyManager>().enemyData.isTouchable = false;
            }
            if (collision.gameObject.GetComponent<EnemyManager>().enemyData.isTouchable)
            {
                //ParticleEffect
                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);

                //SoundEffect
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetEnemyHit);
                //GetHitSFX(_playerData);

                //PlayerData
                DecreaseHealth(5);
                //_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value -= 5;

                //_topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;
            }
        }
    }

    
    //Triggers
    void TriggerBullet(Collider other, PlayerData _playerData)
    {
        
        if (_playerData.objects[3] != null)
        {
            if (_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value == 0 && !_playerData.isWinning)
            {
                //Particle Effect
                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Burn, _particleTransform.transform);

                //Sound Effect
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
                //DeathSFX(_playerData);


                _playerData.isDestroyed = true;
                
                //EnemyAnimation
                if (other.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()))
                {
                    other.gameObject.GetComponent<EnemyManager>().enemyData.isWalking = false;
                    other.gameObject.GetComponent<EnemyManager>().enemyData.enemySpeed = 0;
                }
                if (other.gameObject.CompareTag(SceneController.Tags.CloneDobby.ToString()))
                {
                    other.gameObject.GetComponent<CloneSpawner>().cloneData.isCloneDancing = true;
                    other.gameObject.GetComponent<CloneSpawner>().cloneData.isCloneWalking = false;
                }

                _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

                //PlayerData
                _playerData.isDying = true;
                _playerData.isIdling = false;
                _playerData.isPlayable = false;

                _playerData.objects[3].transform.localScale = Vector3.zero;
                StartCoroutine(DelayDestroy(3f));
            }
            else if(!_playerData.isWinning)
            {
                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);
                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.TouchBurning, _particleTransform.transform);

                //SoundEffect
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetBulletHit);
                //GetHitSFX(_playerData);

                //PlayerData
                DecreaseHealth(2);
                //_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value -= 5;
                //_topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;
            }
        }
        StartCoroutine(LookAtTouchEnemyBullet(other));
    }
    
    void PickUpCoin(SceneController.Tags value, Collider other, PlayerData _playerData)
    {
        if (value == SceneController.Tags.Coin)
        {
            //Data
            _playerData.playerSpeed = 0.5f;
            _playerData.isPicking = true;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
            //PickUpCoinSFX(_playerData);


            //Trigger
            other.gameObject.SetActive(false);

            //Score
            ScoreController.GetInstance.SetScore(23);
            //CreateSlaveObject();
            ScoreTextGrowing(0, 255, 0);
        }
        else if (value == SceneController.Tags.RotateCoin)
        {
            //PlayerData
            _playerData.isPickRotateCoin = true;
            _playerData.playerSpeed = 0.5f;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
            //PickUpCoinSFX(_playerData);


            //Trigger CoinObject
            other.gameObject.SetActive(false);

            //SettingScore
            ScoreController.GetInstance.SetScore(23);
            //CreateSlaveObject();
            ScoreTextGrowing(0, 255, 0);
        }
        else if (value == SceneController.Tags.CheeseCoin)
        {
            //PlayerData
            _playerData.isPickRotateCoin = true;
            _playerData.playerSpeed = 0.5f;

            //_cheeseObject.SetActive(true);
            _cheeseObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            StartCoroutine(DelayDestroyCoinObject(_cheeseObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
            //PickUpCoinSFX(_playerData);


            //Trigger CoinObject
            other.gameObject.SetActive(false);

            //SettingScore
            ScoreController.GetInstance.SetScore(23);
            //CreateSlaveObject();
            ScoreTextGrowing(0, 255, 0);
        }
        else if (value == SceneController.Tags.HealthCoin)
        {
            IncreaseHealth(50);
        }
        else if (value == SceneController.Tags.MushroomCoin)
        {
            //PlayerData
            _playerData.isPickRotateCoin = true;
            _playerData.playerSpeed = 0.5f;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Poison);
            //PickUpCoinSFX(_playerData);

            //Trigger CoinObject
            other.gameObject.SetActive(false);

            //GettingDamageScore
            GettingPoisonDamage(100, 7f, 10);//Score
        }
        else if (value == SceneController.Tags.BulletCoin)
        {
            //PlayerData
            _playerData.isPickRotateCoin = true;
            _playerData.playerSpeed = 0.5f;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            //PickUpBulletCoinSFX(_playerData);

            //Trigger CoinObject
            if (_playerData.bulletAmount  != _playerData.bulletPack)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
                other.gameObject.SetActive(false);
                bulletAmountCanvas.transform.GetChild(0).gameObject.transform.localScale = Vector3.one;
            }
            else
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin);
            }

            //SettingScore
            _playerData.bulletAmount = _playerData.bulletPack;
            bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = _playerData.bulletAmount.ToString();

            //ScoreTextGrowing(0, 255, 0);
        }
    }
    void DecreaseScore(int scoreDamageValue)
    {

        ScoreTextGrowing(255, 0 , 0);

        if (ScoreController._scoreAmount > scoreDamageValue)
        {
            ScoreController.GetInstance.SetScore(-scoreDamageValue);
        }
        else if (ScoreController._scoreAmount < scoreDamageValue && ScoreController._scoreAmount > 0)
        {
            ScoreController.GetInstance.SetScore(-ScoreController._scoreAmount);
        }
        else if (ScoreController._scoreAmount <= 0)
        {
            ScoreController._scoreAmount = 0;
            ScoreController.GetInstance._scoreText.text = ScoreController._scoreAmount.ToString();
        }
    }
    void IncreaseScore(int scoreDamageValue)
    {

        ScoreTextGrowing(0, 255, 0);

        if (ScoreController._scoreAmount > scoreDamageValue)
        {
            ScoreController.GetInstance.SetScore(-scoreDamageValue);
        }
        else if (ScoreController._scoreAmount < scoreDamageValue && ScoreController._scoreAmount > 0)
        {
            ScoreController.GetInstance.SetScore(-ScoreController._scoreAmount);
        }
        else if (ScoreController._scoreAmount <= 0)
        {
            ScoreController._scoreAmount = 0;
            ScoreController.GetInstance._scoreText.text = ScoreController._scoreAmount.ToString();
        }
    }
    void ScoreTextGrowing(int r, int g, int b)
    {
        ScoreController.GetInstance._scoreText.transform.localScale = new Vector3(2f, 2f, 2f);
        ScoreController.GetInstance._scoreText.color = new Color(r,g,b);

        StartCoroutine(DelaySizeBack());
    }

    void IncreaseHealth(int damageHealthValue)
    {
        if (_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value <= 50)
        {
            _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value += damageHealthValue;

            _healthBarObject.transform.localScale = new Vector3(1f,
                                                                0.3f,
                                                                0.3f);
            _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

            StartCoroutine(DelaySizeBack());
        }        
    }
    void DecreaseHealth(int damageHealthValue)
    {
        _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value -= damageHealthValue;
        _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

        _healthBarObject.transform.localScale = new Vector3(1f,
                                                            0.3f,
                                                            0.3f);

        StartCoroutine(DelaySizeBack());
    }
    void GettingPoisonDamage(int scoreDamageValue, float delayDestroying, int damageHealthValue)
    {
        DecreaseScore(scoreDamageValue);
        if (_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value > 0)
        {
            DecreaseHealth(damageHealthValue);
        }
        else
        {
            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
            //DeathSFX(_playerData);
            _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

            //PlayerData
            _playerData.isDestroyed = true;
            _playerData.isDying = true;
            _playerData.isIdling = false;
            _playerData.isPlayable = false;
            _playerData.objects[3].transform.localScale = Vector3.zero;

            StartCoroutine(DelayDestroy(delayDestroying));
        }
    }
    IEnumerator DelaySizeBack()
    {
        yield return new WaitForSeconds(0.5f);
        ScoreController.GetInstance._scoreText.transform.localScale = Vector3.one;
        _healthBarObject.transform.localScale = new Vector3(1, 0.1f, 0.1f);
        ScoreController.GetInstance._scoreText.color = Color.white;
    }

    void DestroyByWater(PlayerData _playerData)
    {
        //PlayerData
        _playerData.isDestroyed = true;
        _playerData.isDying = true;
        _playerData.isIdling = false;
        _playerData.isPlayable = false;

        //SoundEffect
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.JumpToSea);
        //JumpToSeaSFX(_playerData);

        //DestroyingWithDelay
        StartCoroutine(DelayDestroy(3f));
    }
    void DestroyByLava(PlayerData _playerData)
    {
        //PlayerData
        _playerData.isDestroyed = true;
        _playerData.isDying = true;
        _playerData.isIdling = false;
        _playerData.isPlayable = false;

        //ParticleEffect
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Burn, _particleTransform.transform);

        //DestroyingWithDelay
        StartCoroutine(DelayDestroy(3f));
    }

    public void CreateSlaveObject()
    {
        //if (slaves.transform.childCount < 4 && slaves.transform.childCount >= 0)
        //{
            
        //    slaveObject = Instantiate(_playerData.slaveObjects[PlayerData.slaveCounter],
        //                                             PlayerManager.GetInstance.gameObject.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).position,
        //                                             Quaternion.identity,
        //                                             slaves);
        //    PlayerData.slaveCounter++;
        //}
        //else
        //{
        //    PlayerData.slaveCounter = 0;
        //    Destroy(slaveObject);
        //}
        
    }

    void TriggerLadder(bool isTouch, bool isTouchExit, PlayerData _playerData)
    {
        GetInstance.GetComponent<Rigidbody>().isKinematic = isTouch;
        if (PlayerManager.GetInstance._zValue > 0 && !isTouchExit)
        {
            //PlayerData
            _playerData.isClimbing = isTouch;
            _playerData.isBackClimbing = !isTouch;
        }
        else if (PlayerManager.GetInstance._zValue < 0 && !isTouchExit)
        {
            //PlayerData
            _playerData.isBackClimbing = isTouch;
            _playerData.isClimbing = !isTouch;
        }
        else if (isTouchExit && PlayerManager.GetInstance._zValue != 0)
        {
            //PlayerData
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

    void CreateCharacterObject()
    {
        characterObject = Instantiate(_characterObject, gameObject.transform);

        GameObject current;
        if (_playerData.currentCharacterName == PlayerData.CharacterNames.Dobby)
        {
            current = _playerData.dobby;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Glassy)
        {
            current = _playerData.glassy;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Guard)
        {
            current = _playerData.guard;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Spartacus)
        {
            current = _playerData.spartacus;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Lusth)
        {
            current = _playerData.lusth;
        }
        else
        {
            current = _playerData.dobby;
        }
        Instantiate(current, characterObject.transform);
    }
    public void FindHandObjectTransforms()
    {
        //GameObjects
        _coinObject = GameObject.Find("Coin");
        _cheeseObject = GameObject.Find("Cheese");
        _coinObject.transform.localScale = Vector3.zero;
        _cheeseObject.transform.localScale = Vector3.zero;

        SetWeaponTransform();
        SetSwordTransform();        
    }
    public void GetFingerTransform()
    {
        if (_characterObject != null)
        {
            if (_playerData.currentCharacterName == PlayerData.CharacterNames.Dobby)
            {
                _pinkyDobby = GameObject.Find("mixamorig:RightHandRing4");
            }
            else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Glassy)
            {
                _pinkyGlassy = GameObject.Find("mixamorig:RightHandPinky4");
            }
            else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Spartacus)
            {
                _pinkySpartacus = GameObject.Find("mixamorig:RightHandRing4");
            }
            else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Lusth)
            {
                _pinkyGuard = GameObject.Find("mixamorig:RightHandIndex4");
            }
            else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Guard)
            {
                _pinkyLusth = GameObject.Find("mixamorig:RightHandRing4");
            }
            else
            {
                _pinkyDobby = GameObject.Find("mixamorig:RightHandRing4");
            }
        }
    }
    public void SetWeaponTransform()//Getting finger transform parameter
    {
        if (_bulletData.currentWeaponName == BulletData.ak47)
        {
            _gunTransform = GameObject.Find("Ak47Transform");
        }
        else if (_bulletData.currentWeaponName == BulletData.rifle)
        {
            _gunTransform = GameObject.Find("RifleTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.bulldog)
        {
            _gunTransform = GameObject.Find("BulldogTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.cowgun)
        {
            _gunTransform = GameObject.Find("CowgunTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.crystalgun)
        {
            _gunTransform = GameObject.Find("CrystalgunTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.demongun)
        {
            _gunTransform = GameObject.Find("DemongunTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.icegun)
        {
            _gunTransform = GameObject.Find("IcegunTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.negev)
        {
            _gunTransform = GameObject.Find("NegevTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.axegun)
        {
            _gunTransform = GameObject.Find("AxegunTransform");
        }
    }
    public void SetSwordTransform()
    {
        if (_bulletData.currentSwordName == BulletData.lowSword)
        {
            _swordTransform = GameObject.Find("LowSwordTransform");
        }
        else if (_bulletData.currentSwordName == BulletData.warriorSword)
        {
            _swordTransform = GameObject.Find("WarriorSwordTransform");
        }
        else if (_bulletData.currentSwordName == BulletData.hummer)
        {
            _swordTransform = GameObject.Find("HummerTransform");
        }
        else if (_bulletData.currentSwordName == BulletData.orcSword)
        {
            _swordTransform = GameObject.Find("OrcSwordTransform");
        }
        else if (_bulletData.currentSwordName == BulletData.axeSword)
        {
            _swordTransform = GameObject.Find("AxeSwordTransform");
        }
        else if (_bulletData.currentSwordName == BulletData.axeKnight)
        {
            _swordTransform = GameObject.Find("AxeKnightTransform");
        }
        else if (_bulletData.currentSwordName == BulletData.barbarianSword)
        {
            _swordTransform = GameObject.Find("BarbarianSwordTransform");
        }
        else if (_bulletData.currentSwordName == BulletData.demonSword)
        {
            _swordTransform = GameObject.Find("DemonSwordTransform");
        }
        else if (_bulletData.currentSwordName == BulletData.magicSword)
        {
            _swordTransform = GameObject.Find("MagicSwordTransform");
        }
        else if (_bulletData.currentSwordName == BulletData.longHummer)
        {
            _swordTransform = GameObject.Find("LongHummerTransform");
        }
        else if (_bulletData.currentSwordName == BulletData.club)
        {
            _swordTransform = GameObject.Find("ClubTransform");
        }
    }
    void CreateVictoryAnimation(PlayerData _playerData)
    {//InstantiatingDancerObject
        EnemyBulletManager.isFirable = false;
        GameObject jolleenObject = Instantiate(_playerData.jolleenObject, _jolleenTransform.transform);
        jolleenObject.transform.position = _jolleenTransform.transform.position;
        Destroy(jolleenObject, _playerData.danceTime);
    }
    public Transform PlayerRandomSpawn(PlayerData _playerData)
    {//Random Spawn Control Function
        int value = UnityEngine.Random.Range(0, 8);
        gameObject.transform.position = _playerData.spawns.GetChild(2).position;
        return _playerData.spawns.GetChild(value);
    }
    public void CreateStartPlayerStaff(PlayerData _playerData)
    { //Create Player Objects On Start
        Instantiate(_playerData.objects[1],
                    _bulletsTransform.transform.position,
                    Quaternion.identity,
                    _bulletsTransform.transform);//BulletsPrefab
        Instantiate(_playerData.objects[2], 
                    _cameraWasherTransform.transform.position, 
                    Quaternion.identity, 
                    _cameraWasherTransform.transform);//CameraWasherPrefab
        _healthBarObject = Instantiate(_playerData.objects[3],
                        healthBarTransform.transform.position,
                        Quaternion.identity,
                        gameObject.transform);//HealthBarPrefab

        Instantiate(_playerData.objects[4], gameObject.transform.position,
                    Quaternion.identity,
                    gameObject.transform);//MagnetPrefab

        Instantiate(_playerData.objects[5],
                    playerIconTransform.transform.position,
                    Quaternion.identity,
                    playerIconTransform.transform);//PlayerIconPrefab

        Instantiate(_playerData.objects[6], gameObject.transform);//PlayerSFXPrefab

        bulletAmountCanvas = Instantiate(_playerData.objects[7], gameObject.transform);//BulletAmountCanvas

        //CreateSlaveObject();



        playerIconTransform.transform.rotation = gameObject.transform.rotation;
    }
    void DataStatesOnInitial(PlayerData _playerData)
    {//PlayerData
        if (_playerData != null)
        {
            _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
            _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;
            _playerData.isCompleteFirstMap = false;
            _playerData.isCompleteSecondMap = false;
            _playerData.isCompleteThirdMap = false;
            //PlayerData.slaveCounter = 0;
            _bulletData.isRifle = false;
            _playerData.bulletAmount = _playerData.bulletPack;
            bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = _playerData.bulletAmount.ToString();
            _playerData.objects[5].GetComponent<MeshRenderer>().enabled = true;
            _playerData.objects[3].transform.localScale = new Vector3(1f, 0.1f, 0.1f);
            _playerData.isLockedWalking = false;
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
            _playerData.isDying = false;
            _playerData.isFiring = false;
            _playerData.isWalking = false;
            _playerData.isClimbing = false;
            _playerData.isBackWalking = false;
            _playerData.isGround = true;
        }
    }
    IEnumerator LookAtTouchEnemyBullet(Collider other)
    {
        yield return new WaitForSeconds(0.3f);
        _warmArrow.transform.localScale = Vector3.one;
        _warmArrow.transform.LookAt(other.gameObject.transform);
    }
    IEnumerator DelayWarmArrowDirection()
    {
        yield return new WaitForSeconds(1f);
        _warmArrow.transform.localScale = Vector3.zero;
    }
    IEnumerator Delay(float value)
    {
        yield return new WaitForSeconds(value);

        //CrosshairImage
        crosshairImage.GetComponent<CanvasGroup>().alpha = 0;
    }
    IEnumerator DelayLevelUp(float delayWait, float delayDestroy, PlayerData _playerData, Collider other)
    {
        _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
        _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

        if (other.CompareTag(SceneController.Tags.FirstFinishArea.ToString()))
        {
            _playerData.isCompleteFirstMap = true;
        }
        else if (other.CompareTag(SceneController.Tags.SecondFinishArea.ToString()))
        {
            _playerData.isCompleteSecondMap = true;
        }
        else if (other.CompareTag(SceneController.Tags.ThirdFinishArea.ToString()))
        {
            _playerData.isCompleteThirdMap = true;
        }
        //PlayerData
        //_playerData.isLockedWalking = false;
        _playerData.objects[3].transform.localScale = new Vector3(1f, _playerData.objects[3].transform.localScale.y, _playerData.objects[3].transform.localScale.z);
        //DestroyImmediate(_playerData.healthBarObject, true);
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.LevelUp);
        //LevelUpSFX(_playerData);
        //_playerData.isTouchFinish = true;

        yield return new WaitForSeconds(delayWait);
        //PlayerData
        //_playerData.isPlayable = false;
        //_playerData.isWinning = true;

        //JolleenAnimation
        //CreateVictoryAnimation(_playerData);

        yield return new WaitForSeconds(delayDestroy);
        //Destroy(gameObject);
        //SceneController.GetInstance.LevelUp();
    }
    IEnumerator DelayDestroy(float delayDying)
    {
        //ParticleEffect
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Death, _particleTransform.transform);

        yield return new WaitForSeconds(delayDying);
        Destroy(gameObject);
        SceneController.GetInstance.LoadEndScene();
    }
    IEnumerator DelayDestroyCoinObject(GameObject coinObject)
    {
        yield return new WaitForSeconds(0.5f);
        coinObject.transform.localScale = Vector3.zero;
    }
}