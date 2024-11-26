using Unity.Cinemachine;
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PlayerManager : AbstractPlayer<PlayerManager>
{
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
    public struct PlayerComponents
    {
        public Rigidbody playerRigidbody;
        public Slider healthBarSlider;
        public Animator characterAnimator;
        public PlayerController _playerController;
        public Transform playerTransform;
        public ArrowRotationController _arrowRotationController;
    }
    public PlayerComponents playerComponents = new PlayerComponents();


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
    public EnemyBulletData _enemyBulletData;
    public LevelData _levelData;
    //public BulletData enemyBulletData;

    [Header("Current Spawn Transforms")]
    public Transform _particleTransform;
    public Transform _currentCameraTransform;

    [SerializeField] public Transform _jolleenTransform;
    [SerializeField] public Transform playerIconTransform;
    [SerializeField] public Transform healthBarTransform;
    [SerializeField] public Transform _bulletsSpawnTransform;
    [SerializeField] public Transform _cameraWasherTransform;

    [HideInInspector]
    public Transform bulletCoinTransform;


    [Header("CinemachineVirtualCamera")]
    public CinemachineCamera _currentCamera;
    public GameObject cameraSpawner;

    [Header("Crosshair")]
    private CanvasGroup crosshairImage;  


    public ObjectPool _objectPool;
    public EnemyObjectPool _enemyObjectPool;
    public EnvironmentObjectPool _environmentObjectPool;

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
    private GameObject _topCanvasHealthBarObject;
    public Slider _topCanvasHealthBarSlider;

    public static float randomEnemyXPos;
    public static float randomEnemyZPos;


    private TextMeshProUGUI messageText;

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

        Interfaces();

        PlayerComponentsOnStart();

        InitStates();

        SpawnPlayerObject();
    }

    //Init
    private void InitStates()
    {
        if (GameObject.Find("ObjectPool"))
        {
            _objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
        }
        
        if (GameObject.Find("EnemyObjectPool"))
        {
            _enemyObjectPool = GameObject.Find("EnemyObjectPool").GetComponent<EnemyObjectPool>();
        }
        if (GameObject.Find("EnvironmentObjectPool"))
        {
            _environmentObjectPool = GameObject.Find("EnvironmentObjectPool").GetComponent<EnvironmentObjectPool>();
        }
        

        inputMovement = new InputMovement();

        if (GameObject.Find("CameraSpawner"))
        {
            cameraSpawner = GameObject.Find("CameraSpawner");
        }        

        if (GameObject.Find("MessageText").GetComponent<TextMeshProUGUI>())
        {
            messageText = GameObject.Find("MessageText").GetComponent<TextMeshProUGUI>();
        }
        //Audio
        if (GetComponent<AudioSource>())
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (_levelData)
        {
            _levelData.currentEnemyDetectionDistance = _levelData.levelStates[LevelData.currentLevelId].enemyDetectionDistance;
        }

        if (_playerData)
        {
            if (GameObject.Find("DamageHealthText"))
            {
                _playerData.damageHealthText = GameObject.Find("DamageHealthText").GetComponent<TextMeshProUGUI>();
            }

            _playerData.decreaseCounter = 0;

            _playerData.bulletPackAmount = 2;

            if (bulletAmountCanvas)
            {
                if (bulletAmountCanvas.transform.childCount >= 2)
                {
                    if (bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>())
                    {
                        bulletAmountText = bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>();
                    }
                    if (bulletAmountCanvas.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>())
                    {
                        bulletPackAmountText = bulletAmountCanvas.transform.GetChild(1).transform.GetComponent<TextMeshProUGUI>();
                    }
                }                
            }

            if (_topCanvasHealthBarObject)
            {
                _topCanvasHealthBarSlider = _topCanvasHealthBarObject.GetComponent<Slider>();
            }
        }
    }

    
    void PlayerComponentsOnStart()
    {
        if (GetComponent<Transform>())
        {
            playerComponents.playerTransform = GetComponent<Transform>();
        }

        if (FindObjectOfType<ArrowRotationController>())
        {
            playerComponents._arrowRotationController = FindObjectOfType<ArrowRotationController>();
        }

        if (gameObject.GetComponent<Rigidbody>())
        {
            playerComponents.playerRigidbody = GetComponent<Rigidbody>();

            playerComponents.playerRigidbody.isKinematic = false;
        }
        if (FindObjectOfType<PlayerController>())
        {
            playerComponents._playerController = FindObjectOfType<PlayerController>();
        }

        if (transform.childCount >= 2)
        {
            if (transform.GetChild(1).childCount >= 1)
            {
                if (transform.GetChild(1).GetChild(0).gameObject != null)
                {
                    if (transform.GetChild(1).GetChild(0).gameObject.GetComponent<Animator>())
                    {
                        playerComponents.characterAnimator = transform.GetChild(1).GetChild(0).gameObject.GetComponent<Animator>();
                    }
                }
            }
        }
    }

    void Interfaces()
    {
        playerInterfaces = new PlayerInterfaces();
        playerInterfaces.iPlayerShoot = GetComponent<IPlayerShoot>();
        playerInterfaces.iPlayerCamera = GetComponent<IPlayerCamera>();
        playerInterfaces.iPlayerInitial = GetComponent<IPlayerInitial>();
        playerInterfaces.iPlayerTrigger = GetComponent<IPlayerTrigger>();
        playerInterfaces.iPlayerTouch = GetComponent<IPlayerTouch>();
        playerInterfaces.iPlayerScore = GetComponent<IPlayerScore>();
        playerInterfaces.iPlayerHealth = GetComponent<IPlayerHealth>();
        playerInterfaces.iPlayerMovement = GetComponent<IPlayerMovement>();
        playerInterfaces.iPlayerRotation = GetComponent<IPlayerRotation>();

        if (_bulletData)
        {
            if (playerInterfaces.iPlayerTrigger != null)
            {
                playerInterfaces.iPlayerTrigger.CheckAllWeaponsLocked(_bulletData);
            }
        }

        if (playerInterfaces.iPlayerInitial != null)
        {
            if (_playerData)
            {
                playerInterfaces.iPlayerInitial.CreateCharacterObject(_playerData, ref characterObject);
            }

            playerInterfaces.iPlayerInitial.GetHandObjectsTransform(ref _coinObject, ref _cheeseObject);
            if (_bulletData)
            {
                //playerInterfaces.iPlayerInitial.GetWeaponTransform(_bulletData, ref _gunTransform);
                //playerInterfaces.iPlayerInitial.GetSwordTransform(_bulletData, ref _swordTransform);
            }
            if (_playerData)
            {
                playerInterfaces.iPlayerInitial.CreateStartPlayerStaff(_playerData,
                                                  ref playerIconTransform,
                                                  ref _bulletsSpawnTransform,
                                                  ref _cameraWasherTransform,
                                                  healthBarTransform,
                                                  ref _healthBarObject,
                                                  ref bulletAmountCanvas);
                if (_healthBarObject)
                {
                    if (_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>())
                    {
                        playerComponents.healthBarSlider = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
                    }
                }
            }
            if (_levelData && _playerData && _bulletData)
            {
                playerInterfaces.iPlayerInitial.DataStatesOnInitial(_levelData, _playerData, _bulletData,
                                 ref _healthBarObject,
                                 ref _topCanvasHealthBarObject,
                                 ref bulletAmountCanvas);
            }
        }
    }
    private void SpawnPlayerObject()
    {
        if (_levelData)
        {
            if (_levelData.playerSpawns.GetChild(LevelData.currentLevelId))
            {
                transform.position =
                    _levelData.playerSpawns.GetChild(LevelData.currentLevelId).transform.position;
            }            
        }        
    }

    void FixedUpdate()
    {
        // If the player is not in sword animation, allow firing
        if (_playerData)
        {
            if (playerInterfaces.iPlayerShoot != null)
            {
                if (!_playerData.isSwordAnimate && _playerData)
                {
                    playerInterfaces.iPlayerShoot.Fire(_playerData);
                }
            }            
        }


        // Trigger sword action if both Z and X values are zero
        if (playerInterfaces.iPlayerShoot != null)
        {
            if (_playerData)
            {
                if (GetZValue() == 0 && GetXValue() == 0)
                {
                    if (playerInterfaces.iPlayerShoot != null)
                    {
                        playerInterfaces.iPlayerShoot.Sword(_playerData);
                    }                    
                }
            }
        }


        // Common conditions to reduce redundancy
        if (_playerData && bulletAmountCanvas && playerComponents._playerController)
        {
            // Handle crosshair and firing related actions
            if (_playerData.isPlayable && !_playerData.isWinning && playerComponents._playerController.fire)
            {
                // Show crosshair with delay
                if (playerInterfaces.iPlayerShoot != null)
                {
                    if (GameObject.Find("CrosshairImage"))
                    {
                        if (GameObject.Find("CrosshairImage").GetComponent<CanvasGroup>())
                        {
                            crosshairImage = GameObject.Find("CrosshairImage").GetComponent<CanvasGroup>();
                            if (crosshairImage)
                            {
                                StartCoroutine(playerInterfaces.iPlayerShoot.DelayShowingCrosshairAlpha(crosshairImage, 2f));
                            }
                        }
                    }
                }

                // Update bullet pack and amount text size
                if (playerInterfaces.iPlayerTrigger != null)
                {
                    playerInterfaces.iPlayerTrigger.SetBulletPackAndAmountTextSize(_playerData, ref bulletAmountCanvas);
                }
            }
            else
            {
                // Delayed fire walk disactivity if not actively firing
                if (playerInterfaces.iPlayerShoot != null)
                {
                    SetFireFalse();
                }
            }
        }

        // Update bullet amount and pack amount text
        if (_playerData)
        {
            if (bulletAmountText)
            {
                bulletAmountText.text = _playerData.bulletAmount.ToString();
            }
            if (bulletPackAmountText)
            {
                bulletPackAmountText.text = "x" + _playerData.bulletPackAmount.ToString();
            }
        }
        
       
    }

    void Update()
    {
        if (playerInterfaces.iPlayerCamera != null)
        {
            playerInterfaces.iPlayerCamera.ChangeCamera();
        }
        if (playerInterfaces.iPlayerTrigger != null)
        {
            if (_damageArrow)
            {
                playerInterfaces.iPlayerTrigger.DamageArrowDirection(ref _damageArrow);
            }           
        }
        if (_playerData)
        {
            Movement(_playerData);//PlayerStatement
            Rotation(_playerData);
        }
        
        DontFallDown();
        IncreaseHealthWhenEnemyKilledAtUpdate(10);

        HandleDeathScenario(_playerData,
                                          ref _healthBarObject,
                                          ref _topCanvasHealthBarObject,
                                          ref _particleTransform,
                                          ref playerComponents.healthBarSlider,
                                          ref _topCanvasHealthBarSlider,
                                          ref _playerData.damageHealthText);
    }
    

    void IncreaseHealthWhenEnemyKilledAtUpdate(int increasedAmount)
    {
        if (_playerData)
        {
            if (playerInterfaces.iPlayerHealth != null)
            {
                if (_playerData.getCurrentEnemyDead)
                {
                    if (playerComponents.healthBarSlider && _topCanvasHealthBarSlider && _healthBarObject)
                    {
                        playerInterfaces.iPlayerHealth.IncreaseHealth(increasedAmount, ref _healthBarObject,
                                                                      ref playerComponents.healthBarSlider,
                                                                      ref _topCanvasHealthBarSlider);
                        _playerData.getCurrentEnemyDead = false;
                    }
                    
                }
            }
            
        }
        
    }
    
    void DontFallDown()
    {
        if (_playerData)
        {
            if (playerComponents.playerRigidbody)
            {
                if (transform.position.y <= 0.9301061f && !_playerData.isGround)
                {
                    transform.position = new Vector3(transform.position.x,
                                                                 0.93010632f,
                                                                 transform.position.z);
                }
                else if (transform.position.y > 0.9301061f && _playerData.isGround)
                {

                    playerComponents.playerRigidbody.isKinematic = false;
                }
            }            
        }        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameObject == null || _playerData.objects[3] == null) return;

        // Define a set of ground-related tags to simplify the comparison
        var groundTags = new HashSet<string>
    {
        SceneController.Tags.Ground.ToString(),
        SceneController.Tags.Bridge.ToString(),
        SceneController.Tags.FanceWooden.ToString(),
        SceneController.Tags.Magma.ToString()
    };

        // Check if collided object is ground-related
        if (groundTags.Contains(collision.collider.tag))
        {
            _playerData.isGround = true;
            _playerData.jumpCount = 0;
        }
        else
        {
            _playerData.isGround = false;
        }

        // Handle collision with enemies
        if (collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()))
        {
            HandleEnemyCollision(collision);
        }

        // Handle collision with coins
        if (collision.collider.CompareTag(SceneController.Tags.Coin.ToString()))
        {
            HandleCoinCollision(collision);
        }
    }

    private void HandleEnemyCollision(Collision collision)
    {
        var enemyManager = collision.gameObject.GetComponent<EnemyManager>();

        if (enemyManager == null) return;

        if (playerComponents.healthBarSlider.value == 0)
        {
            playerInterfaces.iPlayerTouch.TouchEnemy(_playerData, ref playerComponents.healthBarSlider,
                                            ref _topCanvasHealthBarSlider);
            DelayPlayerDestroy();
        }
        else
        {
            enemyManager.enemyData.enemyStats[enemyManager.GetEnemyIndex()].isTouchable[enemyManager.enemyChildID] = enemyManager._healthBar != null;

            if (enemyManager.enemyData.enemyStats[enemyManager.GetEnemyIndex()].isTouchable[enemyManager.enemyChildID])
            {
                CreateTouchParticleEffect();
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetEnemyHit);
            }
        }
    }

    private void HandleCoinCollision(Collision collision)
    {
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);

        collision.collider.gameObject.SetActive(false);

        ScoreController.GetInstance.SetScore(_levelData.currentStaticCoinValue * 2);
        playerInterfaces.iPlayerScore.ScoreTextGrowing(0, 255, 0);
    }

    private void CreateTouchParticleEffect()
    {
        GameObject particleObject = _objectPool.GetComponent<ObjectPool>().GetPooledObject(_playerData.playerTouchParticleObjectPoolCount);

        if (particleObject != null)
        {
            particleObject.transform.position = _particleTransform.transform.position;
            StartCoroutine(DelaySetActiveFalseParticle(particleObject, 1f));
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
        if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()))
        {
            _playerData.isGround = false;
        }
    }


    void TriggerFinishControl(Collider other)
    {
        if (other.gameObject.name != "FinishPlane") return;

        // Handle when level can be skipped
        if (LevelData.levelCanBeSkipped)
        {
            //GetLevelTag(other);

            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.LevelUp);

            _levelData.levelStates[LevelData.currentLevelId].isCompleteMap = true;
            LevelData.isLevelUp = true;
            

            // Reset health bar sliders
            playerComponents.healthBarSlider.value = 100;
            _topCanvasHealthBarSlider.value = playerComponents.healthBarSlider.value;

            // Update score and initiate level up
            ScoreController.GetInstance.SetScoreWithLevelUp();
            playerInterfaces.iPlayerTrigger.DelayLevelUp();
        }
        else
        {
            // Show requirement message based on the current language
            string requirementMessage = PlayerData.Languages.Turkish == _playerData.currentLanguage
                ? "Bölümü Geçmen İçin Bölüm Görevlerini Bitirmen Gerekiyor!!!"
                : "You Need To Finish Current Level's Mission(s)!!!";

            StartCoroutine(ShowRequirements(requirementMessage, 3f));
        }
    }


    public IEnumerator ShowRequirements(string requirementMessage, float delayValue)
    {
        if (PlayerManager.GetInstance.gameObject)
        {
            if (messageText)
            {
                messageText.text = requirementMessage;

                yield return new WaitForSeconds(delayValue);

                messageText.text = "";
            }
        } 
    }
    void GetLevelTag(Collider other)
    {
        for (int i = 0; i < _levelData.levels.Length; i++)
        {
            if (_levelData.levels[i].finishAreaName == other.tag)
            {
                LevelData.currentLevelId = i + 1; // Assuming the level IDs start from 1
                return; // Exit once the match is found
            }
        }
    }

    void TriggerCoinControl(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Coin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.Coin.ToString(), other, _playerData,
                                        ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                                        ref _environmentObjectPool);//GetScore
            playerInterfaces.iPlayerScore.ScoreTextGrowing(0, 255, 0);
            playerInterfaces.iPlayerHealth.IncreaseHealth(5, ref _healthBarObject, ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, other);
        }
        if (other.CompareTag(SceneController.Tags.CheeseCoin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.CheeseCoin.ToString(), other, _playerData,
                                         ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                                         ref _environmentObjectPool);//GetScore
            playerInterfaces.iPlayerScore.ScoreTextGrowing(0, 255, 0);
            playerInterfaces.iPlayerHealth.IncreaseHealth(5, ref _healthBarObject, ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, other);
        }
        if (other.CompareTag(SceneController.Tags.RotateCoin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.RotateCoin.ToString(), other, _playerData,
                                         ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                                         ref _environmentObjectPool);//GetScore
            playerInterfaces.iPlayerScore.ScoreTextGrowing(0, 255, 0);
            playerInterfaces.iPlayerHealth.IncreaseHealth(5, ref _healthBarObject, ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, other);

        }
        if (other.CompareTag(SceneController.Tags.MushroomCoin.ToString()))
        {
            playerInterfaces.iPlayerScore.DecreaseScore(10);

            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.MushroomCoin.ToString(), other, _playerData, ref _coinObject,
                                          ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                                          ref _environmentObjectPool);
            if (playerComponents.healthBarSlider.value > 0)
            {
                playerInterfaces.iPlayerHealth.DecreaseHealth(ref _playerData, 30, ref _healthBarObject,
                    ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, ref _playerData.damageHealthText);

                playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.BulletCoin.ToString(), other, _playerData, ref _coinObject,
                                          ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                                          ref _environmentObjectPool);//FreshBulletAmount
            }
            else
            {
                playerInterfaces.iPlayerTrigger.GettingPoisonDamage(_playerData, ref _topCanvasHealthBarSlider, ref playerComponents.healthBarSlider);//Score
                DelayPlayerDestroy();
            }
        }
        if (other.CompareTag(SceneController.Tags.BulletCoin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.BulletCoin.ToString(), other, _playerData,
                                      ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas,
                                      ref bulletAmountText, ref bulletPackAmountText,
                                      ref _environmentObjectPool);//FreshBulletAmount
        }
        if (other.CompareTag(SceneController.Tags.HealthCoin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.HealthCoin.ToString(), other, _playerData,
                                      ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas,
                                      ref bulletAmountText, ref bulletPackAmountText,
                                      ref _environmentObjectPool);
            playerInterfaces.iPlayerHealth.IncreaseHealth(50, ref _healthBarObject, ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, other);
        }
        if (other.CompareTag(SceneController.Tags.LevelUpKey.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.LevelUpKey.ToString(), other, _playerData,
                                      ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas,
                                      ref bulletAmountText, ref bulletPackAmountText,
                                      ref _environmentObjectPool);
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
                                          ref playerComponents.healthBarSlider,
                                          ref _topCanvasHealthBarSlider,
                                          ref _playerData.damageHealthText);

            StartCoroutine(playerInterfaces.iPlayerTrigger.DamageArrowIsLookAtEnemy(other, _damageArrow));

            GameObject particleObject = null;

            if (particleObject == null)
            {
                particleObject = _objectPool.GetComponent<ObjectPool>().GetPooledObject(_playerData.playerTouchParticleObjectPoolCount);
                particleObject.transform.position = _particleTransform.transform.position;
                StartCoroutine(DelaySetActiveFalseParticle(particleObject, .2f));
            }
        }

        TriggerFinishControl(other);

        TriggerCoinControl(other);

        TriggerWeapon(other);

        TriggerSword(other);
    }

    void TriggerWeapon(Collider other)
    {
        string otherTag = other.tag.ToString();
        if (otherTag == _bulletData.currentWeaponName)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Poison);
            StartCoroutine(DelayMessageText(_playerData, PlayerData.alreadyHaveThisWeaponMessageTr, PlayerData.alreadyHaveThisWeaponMessage));
        }
        else if (IsWeaponInStruct(otherTag))
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, otherTag, other, _playerData, ref _coinObject,
                                                       ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                                                       ref _environmentObjectPool);

            PlayerData.currentBulletExplosionIsChanged = true;
        }
        playerInterfaces.iPlayerTrigger.CheckWeaponCollect(other, _bulletData);
    }

    // Helper function to check if the tag matches any weapon name in the struct
    bool IsWeaponInStruct(string tag)
    {
        for (int i = 1; i <= 9; i++)
        {
            if (tag == _bulletData.weaponStruct[i].weaponName)
            {
                return true;
            }
        }
        return false;
    }

    private void TriggerSword(Collider other)
    {
        if (other.tag.ToString() == _bulletData.currentSwordName)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Poison);
        }
        else if (other.tag.ToString() == BulletData.lowSword)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
        }
    }

    
    #region //Move and Rotation
    private void Movement(PlayerData _playerData)
    {
        if (playerComponents._playerController)
        {
            if (_currentCameraTransform.transform)
            {
                if (_playerData.isPlayable && !_playerData.isWinning)
                {
                    //Getting left stick values
                    inputMovement._xValue = playerComponents._playerController.movement.x;
                    inputMovement._zValue = playerComponents._playerController.movement.y;

                    //Moves
                    if (playerInterfaces.iPlayerMovement != null && playerInterfaces.iPlayerShoot != null)
                    {
                        Moves(playerInterfaces.iPlayerMovement, playerInterfaces.iPlayerShoot);
                    }
                }
                else if (_playerData.isWinning)
                {
                    //VirtualCameraEulerAngle for Salsa Dance
                    _currentCameraTransform.transform.eulerAngles = new Vector3(_currentCameraTransform.transform.eulerAngles.x,
                                                                                45f,
                                                                                _currentCameraTransform.transform.eulerAngles.z);
                }
                else
                {
                    //PlayerData
                    PlayerData.isFire = false;
                }
            }            
        }        
    }
    private void Moves(IPlayerMovement iPlayerMovement, IPlayerShoot iPlayerShoot)
    {
        //Moves
        if (_playerData)
        {
            if (!_playerData.isSwordAnimate && _particleTransform)
            {
                if (playerComponents.playerTransform && playerComponents.characterAnimator && playerComponents.playerRigidbody)
                {
                    iPlayerMovement.Walk(_playerData, ref playerComponents.playerTransform, ref playerComponents.characterAnimator);
                    iPlayerMovement.Run(_playerData, _particleTransform.transform, 0.1f, playerComponents.playerRigidbody, _objectPool, _playerData);
                    iPlayerMovement.Jump(_playerData, ref playerComponents.playerRigidbody);
                }                
            }
        }            
    }

    private void Rotation(PlayerData _playerData)
    {
        if (playerInterfaces.iPlayerRotation != null && playerInterfaces.iPlayerCamera != null)
        {
            if (_currentCameraTransform && playerComponents._playerController)
            {
                if (SceneController.rotateTouchOrMousePos == true)
                {
                    //Mouse Rotation Controller
                    playerInterfaces.iPlayerRotation.GetMousePosition(_playerData, ref inputMovement._touchX, ref inputMovement._touchY);
                }
                else
                {
                    //Touch Rotation Controller
                    playerInterfaces.iPlayerRotation.SensivityXSettings(3f, playerComponents._playerController, _playerData, ref inputMovement._touchX);

                    inputMovement._touchY = playerComponents._playerController.lookRotation.y * _playerData.sensivityY;
                }

                playerInterfaces.iPlayerRotation.Rotate(ref inputMovement._touchX, ref inputMovement._touchX, ref playerComponents.playerTransform);

                //Rotating Just Camera On X Axis with TouchY
                _currentCameraTransform.transform.Rotate(-inputMovement._touchY * Time.deltaTime * 10, 0f, 0f);


                playerInterfaces.iPlayerCamera.CheckCameraEulerX(_playerData, _currentCameraTransform);
            }            
        }     
    }
    #endregion

    public void DelayPlayerDestroy()
    {
        if (_objectPool && _playerData)
        {
            if (_particleTransform)
            {
                //ParticleEffect
                GameObject particleObject = null;

                if (particleObject == null)
                {
                    particleObject = _objectPool.GetComponent<ObjectPool>().GetPooledObject(_playerData.deathParticleObjectPoolCount);
                    particleObject.transform.position = _particleTransform.transform.position;

                    StartCoroutine(DelaySetActiveFalseParticle(particleObject, 5f));
                }
            }
        }        
    }
    
}