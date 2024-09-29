using Cinemachine;
using System;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayerManager : AbstractPlayer<PlayerManager>
{
    [HideInInspector]
    public PlayerController _playerController;
    [HideInInspector]
    public ArrowRotationController _arrowRotationController;

    struct PlayerInterfaces
    {
        public IPlayerShoot iPlayerShoot;
        public IPlayerCamera iPlayerCamera;
        public IPlayerInitial iPlayerInitial;
        public IPlayerTrigger iPlayerTrigger;
        public IPlayerTouch iPlayerTouch;
        public IPlayerScore iPlayerScore;
        public IPlayerHealth iPlayerHealth;
        public IPlayerMovement iPlayerMovement;
        public IPlayerRotation iPlayerRotation;
    }
    PlayerInterfaces playerInterfaces;
    struct InputMovement
    {
        public float _xValue;
        public float _zValue;
        public float _touchX;
        public float _touchY;
    }
    private InputMovement inputMovement;
    public struct PlayerObjects
    {
        public Rigidbody playerRigidbody;
        public Slider healthBarSlider;
        public Animator characterAnimator;
    }
    public PlayerObjects playerObjects = new PlayerObjects();


    [HideInInspector]
    public float _initPlayerSpeed;

    [HideInInspector]
    public GameObject _gunTransform;
    [HideInInspector]
    public GameObject _swordTransform;
    [HideInInspector]
    public GameObject _coinObject;
    [HideInInspector]
    public GameObject _cheeseObject;


    [Header("Sound")]
    [HideInInspector] public AudioSource audioSource;

    [Header("Data")]
    public PlayerData _playerData;
    public EnemyData _enemyData;
    public BulletData _bulletData;
    public LevelData _levelData;
    public BulletData enemyBulletData;

    [Header("Current Spawn Transforms")]
    public Transform _particleTransform;
    public Transform _currentCameraTransform;

    [SerializeField] public Transform _jolleenTransform;
    [SerializeField] public Transform playerIconTransform;
    [SerializeField] public Transform healthBarTransform;
    [SerializeField] public Transform _bulletsSpawnTransform;
    [SerializeField] public Transform _cameraWasherTransform;
    private Transform playerTransform;

    [HideInInspector]
    public Transform bulletCoinTransform;


    [Header("CinemachineVirtualCamera")]
    public CinemachineVirtualCamera _currentCamera;
    public GameObject cameraSpawner;

    [Header("Crosshair")]
    public CanvasGroup crosshairImage;  


    public ObjectPool _objectPool;

    [SerializeField] GameObject _damageArrow;

    [HideInInspector]
    public GameObject _currentCharacterObject;
    private GameObject characterObject;

    [Header("Show Bullet Amount")]
    [HideInInspector]
    public GameObject bulletAmountCanvas;
    public TextMeshProUGUI  bulletAmountText;
    public TextMeshProUGUI bulletPackAmountText;
    [HideInInspector]
    public GameObject _healthBarObject;
    public GameObject _topCanvasHealthBarObject;
    public Slider _topCanvasHealthBarSlider;

    float timer = 0;
    public static float randomEnemyXPos;
    public static float randomEnemyZPos;


    private TextMeshProUGUI messageText;


    private PlayerManager playerManager;

    private Collider characterCollider;

    public float GetZValue()
    {
        return inputMovement._zValue;
    }
    public float GetXValue()
    {
        return inputMovement._xValue;
    }
    void Start()
    {
        characterCollider = gameObject.transform.GetComponent<Collider>();

        RandomEnemySpawnDistance(10);
        inputMovement = new InputMovement();
        playerInterfaces = new PlayerInterfaces();

        playerManager = gameObject.GetComponent<PlayerManager>(); 
        GetInstance.gameObject.GetComponent<Rigidbody>().isKinematic = false ;

        if (GameObject.Find("MessageText").GetComponent<TextMeshProUGUI>())
        {
            messageText = GameObject.Find("MessageText").GetComponent<TextMeshProUGUI>();
        }


        _playerData.decreaseCounter = 0;
        InitStates();
        //Scripts
        _playerController = FindObjectOfType<PlayerController>();
        _arrowRotationController = FindObjectOfType<ArrowRotationController>();
        //Audio
        audioSource = GetComponent<AudioSource>();

        //Particle
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Birth, _particleTransform.transform);

        SpawnPlayerObject();

        playerInterfaces.iPlayerTrigger.CheckAllWeaponsLocked(_bulletData);
    }


    private void SpawnPlayerObject()
    {
        transform.position =
            _playerData.playerSpawns.GetChild(LevelData.currentLevelCount).transform.position;
    }
    void FixedUpdate()
    {
        // If the player is not in sword animation, allow firing
        if (!_playerData.isSwordAnimate)
        {
            playerInterfaces.iPlayerShoot.Fire(_playerData);
        }

        // Trigger sword action if both Z and X values are zero
        if (GetZValue() == 0 && GetXValue() == 0)
        {
            playerInterfaces.iPlayerShoot.Sword(_playerData);
        }

        // Common conditions to reduce redundancy
        bool canPlayActions = _playerData.isPlayable && !_playerData.isWinning;
        bool fireActive = GetInstance._playerController.fire;

        // Handle crosshair and firing related actions
        if (canPlayActions && fireActive)
        {
            // Show crosshair with delay
            StartCoroutine(playerInterfaces.iPlayerShoot.DelayShowingCrosshairAlpha(crosshairImage, 2f));

            // Update bullet pack and amount text size
            playerInterfaces.iPlayerTrigger.SetBulletPackAndAmountTextSize(_playerData, ref bulletAmountCanvas);
        }
        else
        {
            // Delayed fire walk disactivity if not actively firing
            StartCoroutine(playerInterfaces.iPlayerShoot.delayFireWalkDisactivity(_playerData, 0f));
        }

        // Update bullet amount and pack amount text
        bulletAmountText.text = _playerData.bulletAmount.ToString();
        bulletPackAmountText.text = "x" + _playerData.bulletPackAmount.ToString();
    }

    void Update()
    {
        playerInterfaces.iPlayerCamera.ChangeCamera(_playerData, ref playerManager);

        playerInterfaces.iPlayerTrigger.DamageArrowDirection(ref _damageArrow);

        Movement(_playerData);//PlayerStatement
        Rotation(_playerData);
        DontFallDown();
        IncreaseHealthWhenEnemyKilledAtUpdate(10);
    }

    void IncreaseHealthWhenEnemyKilledAtUpdate(int increasedAmount)
    {
        if (_playerData.getCurrentEnemyDead)
        {
            playerInterfaces.iPlayerHealth.IncreaseHealth(increasedAmount, ref _healthBarObject, ref playerObjects.healthBarSlider, ref _topCanvasHealthBarSlider);
            _playerData.getCurrentEnemyDead = false;
        }
    }
    public void RandomEnemySpawnDistance(float enemySpawnableDistance)
    {
        timer += Time.deltaTime;
        if (timer>=5)
        {
            randomEnemyXPos = Random.Range(gameObject.transform.position.x - enemySpawnableDistance,
                                   gameObject.transform.position.x + enemySpawnableDistance);
            randomEnemyZPos = Random.Range(gameObject.transform.position.z - enemySpawnableDistance,
                                       gameObject.transform.position.z + enemySpawnableDistance);
            Debug.Log("X:" + randomEnemyXPos);
            Debug.Log("Y:" + randomEnemyZPos);
            timer = 0;
        }        
    }

    
    void DontFallDown()
    {        
        if (GetInstance.transform.position.y <= 0.9301061f && !_playerData.isGround)
        {
            GetInstance.transform.position = new Vector3(GetInstance.transform.position.x,
                                                         0.93010632f,
                                                         GetInstance.transform.position.z);
           // playerRigidbody.isKinematic = true;
        }
        else if (GetInstance.transform.position.y > 0.9301061f && _playerData.isGround)
        {

            playerObjects.playerRigidbody.isKinematic = false;
        }
    }

    void OnCollisionEnter(Collision collision)
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
            if (collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()))
            {
                if (playerObjects.healthBarSlider.value == 0)
                {
                    playerInterfaces.iPlayerTouch.TouchEnemy(collision, _playerData, ref playerObjects.healthBarSlider, ref _topCanvasHealthBarSlider, ref _particleTransform);

                    StartCoroutine(DelayDestroy(7f));
                }
                else
                {
                    if (collision.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()) && collision.gameObject.GetComponent<EnemyManager>()._healthBar == null)
                    {
                        //Hit
                        collision.gameObject.GetComponent<EnemyManager>().enemyData.isTouchable = false;
                    }
                    else if(collision.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()) && collision.gameObject.GetComponent<EnemyManager>()._healthBar)
                    {
                        collision.gameObject.GetComponent<EnemyManager>().enemyData.isTouchable = true;
                    }

                    if (collision.gameObject.GetComponent<EnemyManager>().enemyData.isTouchable)
                    {
                        //Touch ParticleEffect
                        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);

                        //SoundEffect
                        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetEnemyHit);
                        //GetHitSFX(_playerData);

                        //PlayerData
                        CheckEnemyCollisionDamage(collision, ref _playerData);
                        playerInterfaces.iPlayerHealth.DecreaseHealth(ref _playerData,
                            collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage,
                            ref _healthBarObject, ref playerObjects.healthBarSlider,
                            ref _topCanvasHealthBarSlider, ref _playerData.damageHealthText);
                    }
                }
            }
            if (collision.collider.CompareTag(SceneController.Tags.Coin.ToString()))
            {//For Big Coins
                //SoundEffect
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
                //PickUpCoinSFX(_playerData);

                //HitCoinBigObject
                collision.collider.gameObject.SetActive(false);

                //SettingScore
                ScoreController.GetInstance.SetScore(_levelData.currentStaticCoinValue * 2);
                playerInterfaces.iPlayerScore.ScoreTextGrowing(0, 255, 0);
                //CreateSlaveObject();
            }
        }
    }
    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneController.Tags.Bridge.ToString()))
        {
            _playerData.isGround = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag(SceneController.Tags.Magma.ToString()))
        {
            Destroy(collision.collider.gameObject);
        }
        if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneController.Tags.Bridge.ToString()))
        {
            _playerData.isGround = false;
        }
    }

    
    void TriggerFinishControl(Collider other)
    {
        if (other.gameObject.name == "FinishPlane" && LevelData.levelCanBeSkipped)
        {
            GetLevelTag(other);

            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.LevelUp);
            
            _levelData.isCompleteMaps[LevelData.currentLevelCount] = true;

            _levelData.isLevelUp = true;

            playerObjects.healthBarSlider.value = 100;
            _topCanvasHealthBarSlider.value = playerObjects.healthBarSlider.value;

            ScoreController.GetInstance.SetScoreWithLevelUp();

            StartCoroutine(playerInterfaces.iPlayerTrigger.DelayLevelUp(_levelData, 2f));
        }
        else if (other.gameObject.name == "FinishPlane")
        {
            if (PlayerData.Languages.Turkish == _playerData.currentLanguage)
            {
                LevelUpController.requirementMessage = "Bölümü Geçmen İçin Bölüm Görevlerini Bitirmen Gerekiyor!!!";
            }
            else
            {
                LevelUpController.requirementMessage = "You Need To Finish Current Level's Mission(s)!!!";
            }
            StartCoroutine(ShowRequirements(LevelUpController.requirementMessage, 3f));
        }
    }

    public IEnumerator ShowRequirements(string requirementMessage, float delayValue)
    {
        if (messageText)
        {
            messageText.text = requirementMessage;

            yield return new WaitForSeconds(delayValue);

            messageText.text = "";
        }        
    }
    void GetLevelTag(Collider other)
    {
        switch (other.tag)
        {
            case (LevelData.FirstFinishArea):
                LevelData.currentLevelCount = 0;
                break;
            case (LevelData.SecondFinishArea):
                LevelData.currentLevelCount = 1;
                break;
            case (LevelData.ThirdFinishArea):
                LevelData.currentLevelCount = 2;
                break;
            case (LevelData.FourthFinishArea):
                LevelData.currentLevelCount = 3;
                break;
            case (LevelData.FifthFinishArea):
                LevelData.currentLevelCount = 4;
                break;
            case (LevelData.SixthFinishArea):
                LevelData.currentLevelCount = 5;
                break;
            case (LevelData.SeventhFinishArea):
                LevelData.currentLevelCount = 6;
                break;
            case (LevelData.EighthFinishArea):
                LevelData.currentLevelCount = 7;
                break;
            case (LevelData.NinethFinishArea):
                LevelData.currentLevelCount = 8;
                break;
            case (LevelData.TenthFinishArea):
                LevelData.currentLevelCount = 9;
                break;
            default:
                LevelData.currentLevelCount = 0;
                break;
        }
    }
    void TriggerCoinControl(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Coin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.Coin, other, _playerData,
                    ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                    ref _objectPool);//GetScore
            playerInterfaces.iPlayerScore.ScoreTextGrowing(0, 255, 0);
            playerInterfaces.iPlayerHealth.IncreaseHealth(5, ref _healthBarObject, ref playerObjects.healthBarSlider, ref _topCanvasHealthBarSlider, other);
        }
        if (other.CompareTag(SceneController.Tags.CheeseCoin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.CheeseCoin, other, _playerData,
                ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                    ref _objectPool);//GetScore
            playerInterfaces.iPlayerScore.ScoreTextGrowing(0, 255, 0);
            playerInterfaces.iPlayerHealth.IncreaseHealth(5, ref _healthBarObject, ref playerObjects.healthBarSlider, ref _topCanvasHealthBarSlider, other);
        }
        if (other.CompareTag(SceneController.Tags.RotateCoin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.RotateCoin, other, _playerData,
                ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                    ref _objectPool);//GetScore
            playerInterfaces.iPlayerScore.ScoreTextGrowing(0, 255, 0);
            playerInterfaces.iPlayerHealth.IncreaseHealth(5, ref _healthBarObject, ref playerObjects.healthBarSlider, ref _topCanvasHealthBarSlider, other);

        }
        if (other.CompareTag(SceneController.Tags.MushroomCoin.ToString()))
        {
            playerInterfaces.iPlayerScore.DecreaseScore(10);

            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.MushroomCoin, other, _playerData, ref _coinObject,
                                      ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                    ref _objectPool);
            if (playerObjects.healthBarSlider.value > 0)
            {
                playerInterfaces.iPlayerHealth.DecreaseHealth(ref _playerData, 30, ref _healthBarObject, ref playerObjects.healthBarSlider, ref _topCanvasHealthBarSlider, ref _playerData.damageHealthText);

                playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.BulletCoin, other, _playerData, ref _coinObject,
                                          ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                    ref _objectPool);//FreshBulletAmount
            }
            else
            {
                playerInterfaces.iPlayerTrigger.GettingPoisonDamage(_playerData, ref _topCanvasHealthBarSlider, ref playerObjects.healthBarSlider);//Score
                StartCoroutine(DelayDestroy(7f));
            }
        }
        if (other.CompareTag(SceneController.Tags.BulletCoin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.BulletCoin, other, _playerData,
                                      ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas,
                                      ref bulletAmountText, ref bulletPackAmountText,
                    ref _objectPool);//FreshBulletAmount
        }
        if (other.CompareTag(SceneController.Tags.HealthCoin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.HealthCoin, other, _playerData,
                                      ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas,
                                      ref bulletAmountText, ref bulletPackAmountText,
                    ref _objectPool);
            playerInterfaces.iPlayerHealth.IncreaseHealth(50, ref _healthBarObject, ref playerObjects.healthBarSlider, ref _topCanvasHealthBarSlider, other);
        }
        if (other.CompareTag(SceneController.Tags.LevelUpKey.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.LevelUpKey, other, _playerData,
                                      ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas,
                                      ref bulletAmountText, ref bulletPackAmountText,
                    ref _objectPool);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.EnemyBullet.ToString()))
        {
            playerInterfaces.iPlayerTrigger.TriggerBullet(other, _playerData, 
                                          ref _healthBarObject, 
                                          ref _topCanvasHealthBarObject, 
                                          ref _particleTransform, 
                                          ref playerObjects.healthBarSlider,
                                          ref _topCanvasHealthBarSlider);

            StartCoroutine(playerInterfaces.iPlayerTrigger.DamageArrowIsLookAtEnemy(other, _damageArrow));

            playerInterfaces.iPlayerHealth.DecreaseHealth(ref _playerData,
                enemyBulletData.currentEnemyBulletDamage,
                ref _healthBarObject, ref playerObjects.healthBarSlider, ref _topCanvasHealthBarSlider, ref _playerData.damageHealthText);

            //Touch ParticleEffect
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);
        }

        TriggerFinishControl(other);

        TriggerCoinControl(other);



        if (other.tag.ToString() == _bulletData.currentWeaponName)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Poison);
            
            StartCoroutine(DelayMessageText(_playerData, PlayerData.alreadyHaveThisWeaponMessageTr, PlayerData.alreadyHaveThisWeaponMessage));
        }
        else if (other.tag.ToString() == BulletData.ak47 || other.tag.ToString() == BulletData.m4a4 ||
            other.tag.ToString() == BulletData.bulldog || other.tag.ToString() == BulletData.cow ||
            other.tag.ToString() == BulletData.crystal || other.tag.ToString() == BulletData.demon ||
            other.tag.ToString() == BulletData.ice || other.tag.ToString() == BulletData.electro ||
            other.tag.ToString() == BulletData.axe)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.BulletCoin, other, _playerData, ref _coinObject, 
                                      ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                    ref _objectPool);//FreshBulletAmount

            PlayerData.currentBulletExplosionIsChanged = true;
        }

        if (other.tag.ToString() == _bulletData.currentSwordName)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Poison);
        }
        else if (other.tag.ToString() == BulletData.lowSword || other.tag.ToString() == BulletData.warriorSword ||
            other.tag.ToString() == BulletData.hummer || other.tag.ToString() == BulletData.orcSword ||
            other.tag.ToString() == BulletData.axeSword || other.tag.ToString() == BulletData.axeKnight ||
            other.tag.ToString() == BulletData.barbarianSword || other.tag.ToString() == BulletData.demonSword ||
            other.tag.ToString() == BulletData.magicSword || other.tag.ToString() == BulletData.longHummer
            || other.tag.ToString() == BulletData.club)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
        }
        playerInterfaces.iPlayerTrigger.CheckWeaponCollect(other, _bulletData);
    }



    #region //Move and Rotation
    private void Movement(PlayerData _playerData)
    {
        if (_playerData.isPlayable && !_playerData.isWinning)
        {
            //Getting left stick values
            inputMovement._xValue = _playerController.movement.x * Time.deltaTime * 2f;
            inputMovement._zValue = _playerController.movement.y * Time.deltaTime * 2f;

            //Moves
            Moves(playerInterfaces.iPlayerMovement, playerInterfaces.iPlayerShoot);
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
            _playerData.isFire = false;
        }
    }
    private void Moves(IPlayerMovement iPlayerMovement, IPlayerShoot iPlayerShoot)
    {
        //Moves

        if (!_playerData.isSwordAnimate)
        {
            iPlayerMovement.Walk(_playerData, ref playerTransform, ref playerObjects.characterAnimator);
            iPlayerMovement.SideWalk(_playerData, ref playerTransform);
            iPlayerMovement.SpeedSettings(_playerData, _initPlayerSpeed);
            iPlayerMovement.Climb(_playerData, ref playerTransform);
            iPlayerMovement.SkateBoard(_playerData, _particleTransform.transform, ref playerTransform);
            iPlayerMovement.Run(_playerData, _particleTransform.transform, 0f, playerObjects.playerRigidbody);
            iPlayerMovement.Jump(_playerData, ref playerObjects.playerRigidbody);
        }        
    }

    private void Rotation(PlayerData _playerData)
    {
        if (SceneController.rotateTouchOrMousePos == true)
        {
            //Mouse Rotation Controller
            playerInterfaces.iPlayerRotation.GetMousePosition(_playerData, ref inputMovement._touchX, ref inputMovement._touchY);
        }
        else
        {
            //Touch Rotation Controller
            playerInterfaces.iPlayerRotation.SensivityXSettings(3f, _playerController, _playerData, ref inputMovement._touchX);

            inputMovement._touchY = _playerController.lookRotation.y * _playerData.sensivityY;
        }

        playerInterfaces.iPlayerRotation.Rotate(ref inputMovement._touchX, ref inputMovement._touchX, ref playerTransform);


        //Rotating Just Camera On X Axis with TouchY
        _currentCameraTransform.transform.Rotate(-inputMovement._touchY * Time.deltaTime * 10, 0f, 0f);


        //Debug.Log(_playerController.lookRotation.x);
        playerInterfaces.iPlayerCamera.CheckCameraEulerX(_playerData, _currentCameraTransform);
    }

    #endregion

    public IEnumerator DelayDestroy(float delayDying)
    {
        //ParticleEffect
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Death, _particleTransform.transform);

        yield return new WaitForSeconds(delayDying);

        Destroy(gameObject);

        SceneController.LoadEndScene();
    }
    //Init
    private void InitStates()
    {
        _levelData.currentEnemyDetectionDistance = _levelData.enemyDetectionDistances[LevelData.currentLevelCount];

        _playerData.damageHealthText = GameObject.Find("DamageHealthText").GetComponent<TextMeshProUGUI>();
        playerTransform = GetInstance.GetComponent<Transform>();

        playerInterfaces.iPlayerShoot = GetComponent<IPlayerShoot>();
        playerInterfaces.iPlayerCamera = GetComponent<IPlayerCamera>();
        playerInterfaces.iPlayerInitial = GetComponent<IPlayerInitial>();
        playerInterfaces.iPlayerTrigger = GetComponent<IPlayerTrigger>();
        playerInterfaces.iPlayerTouch = GetComponent<IPlayerTouch>();
        playerInterfaces.iPlayerScore = GetComponent<IPlayerScore>();
        playerInterfaces.iPlayerHealth = GetComponent<IPlayerHealth>();
        playerInterfaces.iPlayerMovement = GetComponent<IPlayerMovement>();
        playerInterfaces.iPlayerRotation = GetComponent<IPlayerRotation>();

        if (_playerData)
        {
            _playerData.bulletPackAmount = 2;

            _playerData.isTouchableSkate = true;
            playerObjects.playerRigidbody = GetComponent<Rigidbody>();

            playerInterfaces.iPlayerInitial.CreateCharacterObject(_playerData, ref characterObject);



            playerInterfaces.iPlayerInitial.GetHandObjectsTransform(ref _coinObject, ref _cheeseObject);
            playerInterfaces.iPlayerInitial.GetWeaponTransform(_bulletData, ref _gunTransform);
            playerInterfaces.iPlayerInitial.GetSwordTransform(_bulletData, ref _swordTransform);
            playerInterfaces.iPlayerInitial.CreateStartPlayerStaff(_playerData, 
                                                   ref playerIconTransform, 
                                                   ref _bulletsSpawnTransform,
                                                   ref _cameraWasherTransform, healthBarTransform,
                                                   ref _healthBarObject, 
                                                   ref bulletAmountCanvas);



            playerInterfaces.iPlayerInitial.DataStatesOnInitial(_levelData, _playerData, _bulletData, 
                                 ref _healthBarObject,
                                 ref _topCanvasHealthBarObject, 
                                 ref bulletAmountCanvas,
                                 ref _initPlayerSpeed);
            playerObjects.healthBarSlider = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>();

            bulletAmountText = bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();
            bulletPackAmountText = bulletAmountCanvas.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>();
            _topCanvasHealthBarSlider = _topCanvasHealthBarObject.GetComponent<Slider>();
            playerObjects.characterAnimator = GetInstance.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Animator>();
        }

    }
}