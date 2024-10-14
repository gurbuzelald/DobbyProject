using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


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

    [HideInInspector]
    public Transform bulletCoinTransform;


    [Header("CinemachineVirtualCamera")]
    public CinemachineVirtualCamera _currentCamera;
    public GameObject cameraSpawner;

    [Header("Crosshair")]
    private CanvasGroup crosshairImage;  


    public ObjectPool _objectPool;
    public EnemyObjectPool _enemyObjectPool;

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
            _levelData.currentEnemyDetectionDistance = _levelData.enemyDetectionDistances[LevelData.currentLevelCount];
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
        if (_playerData)
        {
            if (_playerData.playerSpawns.GetChild(LevelData.currentLevelCount))
            {
                transform.position =
                    _playerData.playerSpawns.GetChild(LevelData.currentLevelCount).transform.position;
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
                    if (GameObject.Find("CrosshairImage").GetComponent<CanvasGroup>())
                    {
                        crosshairImage = GameObject.Find("CrosshairImage").GetComponent<CanvasGroup>();
                        if (crosshairImage)
                        {
                            StartCoroutine(playerInterfaces.iPlayerShoot.DelayShowingCrosshairAlpha(crosshairImage, 2f));
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
                    StartCoroutine(playerInterfaces.iPlayerShoot.delayFireWalkDisactivity(_playerData, 0f));
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
                if (playerComponents.healthBarSlider.value == 0)
                {
                    playerInterfaces.iPlayerTouch.TouchEnemy(collision, _playerData, ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, ref _particleTransform);

                    StartCoroutine(DelayPlayerDestroy(3f));
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
                        //ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);

                        GameObject particleObject = null;

                        if (particleObject == null)
                        {
                            particleObject =
                                _objectPool.GetComponent<ObjectPool>().GetPooledObject(_playerData.playerTouchParticleObjectPoolCount);
                            particleObject.transform.position = _particleTransform.transform.position;

                            StartCoroutine(DelaySetActiveFalseParticle(particleObject, 1f));
                        }

                        //SoundEffect
                        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetEnemyHit);
                        //GetHitSFX(_playerData);                        
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
        if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()))
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

            playerComponents.healthBarSlider.value = 100;
            _topCanvasHealthBarSlider.value = playerComponents.healthBarSlider.value;

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
            playerInterfaces.iPlayerHealth.IncreaseHealth(5, ref _healthBarObject, ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, other);
        }
        if (other.CompareTag(SceneController.Tags.CheeseCoin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.CheeseCoin, other, _playerData,
                                         ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                                         ref _objectPool);//GetScore
            playerInterfaces.iPlayerScore.ScoreTextGrowing(0, 255, 0);
            playerInterfaces.iPlayerHealth.IncreaseHealth(5, ref _healthBarObject, ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, other);
        }
        if (other.CompareTag(SceneController.Tags.RotateCoin.ToString()))
        {
            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.RotateCoin, other, _playerData,
                                         ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                                         ref _objectPool);//GetScore
            playerInterfaces.iPlayerScore.ScoreTextGrowing(0, 255, 0);
            playerInterfaces.iPlayerHealth.IncreaseHealth(5, ref _healthBarObject, ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, other);

        }
        if (other.CompareTag(SceneController.Tags.MushroomCoin.ToString()))
        {
            playerInterfaces.iPlayerScore.DecreaseScore(10);

            playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.MushroomCoin, other, _playerData, ref _coinObject,
                                          ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                                          ref _objectPool);
            if (playerComponents.healthBarSlider.value > 0)
            {
                playerInterfaces.iPlayerHealth.DecreaseHealth(ref _playerData, 30, ref _healthBarObject,
                    ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, ref _playerData.damageHealthText);

                playerInterfaces.iPlayerTrigger.PickUpCoin(_levelData, SceneController.Tags.BulletCoin, other, _playerData, ref _coinObject,
                                          ref _cheeseObject, ref bulletAmountCanvas, ref bulletAmountText, ref bulletPackAmountText,
                                          ref _objectPool);//FreshBulletAmount
            }
            else
            {
                playerInterfaces.iPlayerTrigger.GettingPoisonDamage(_playerData, ref _topCanvasHealthBarSlider, ref playerComponents.healthBarSlider);//Score
                StartCoroutine(DelayPlayerDestroy(3f));
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
            playerInterfaces.iPlayerHealth.IncreaseHealth(50, ref _healthBarObject, ref playerComponents.healthBarSlider, ref _topCanvasHealthBarSlider, other);
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

        if (other.CompareTag(SceneController.Tags.EnemyTriggerBox.ToString()))
        {
            SetTrueEnemy(other);

            Destroy(other.gameObject);
        }
        if (other.CompareTag(SceneController.Tags.BossTriggerBox.ToString()))
        {
            SetTrueBoss(other);
            for (int i = 0; i < EnemySpawner.bossEnemyBoxes.Length; i++)
            {
                Destroy(EnemySpawner.bossEnemyBoxes[i]);
            }
        }
        if (other.CompareTag(SceneController.Tags.ChestTriggerBox.ToString()))
        {
            SetTrueChestMonster(other);

            Destroy(other.gameObject);
        }

        if (other.CompareTag(SceneController.Tags.ChestTrigger2Box.ToString()))
        {
            SetTrueChestMonster2(other);

            Destroy(other.gameObject);
        }

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




        if (other.tag.ToString() == _bulletData.currentWeaponName)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Poison);
            
            StartCoroutine(DelayMessageText(_playerData, PlayerData.alreadyHaveThisWeaponMessageTr, PlayerData.alreadyHaveThisWeaponMessage));
        }
        else if (other.tag.ToString() == BulletData.shotGun || other.tag.ToString() == BulletData.machine ||
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


    public void SetTrueEnemy(Collider other)
    {
        if (_enemyObjectPool)
        {
            for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                GameObject currentEnemyObjects = _enemyObjectPool.GetPooledObject(_playerData.enemyPrefabObjectPoolCount);

                currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyDataNumber = i;
                currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyBulletDataNumber = i;
                currentEnemyObjects.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
                currentEnemyObjects.transform.position = new Vector3(other.gameObject.transform.GetChild(i).position.x,
                                                                     1f,
                                                                     other.gameObject.transform.GetChild(i).position.z);
            }
        }

    }
    public void SetTrueBoss(Collider other)
    {
        if (_enemyObjectPool)
        {
            for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                GameObject currentEnemyObjects = _enemyObjectPool.GetPooledObject(_playerData.bossEnemyPrefabObjectPoolCount);

                currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyDataNumber = i;
                currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyBulletDataNumber = i;
                currentEnemyObjects.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
                currentEnemyObjects.transform.position = new Vector3(other.gameObject.transform.GetChild(i).position.x,
                                                                     1f,
                                                                     other.gameObject.transform.GetChild(i).position.z);
                currentEnemyObjects.transform.localScale = new Vector3(currentEnemyObjects.transform.localScale.x,
                                                                       currentEnemyObjects.transform.localScale.y,
                                                                       currentEnemyObjects.transform.localScale.z);
            }
        }

    }

    public void SetTrueChestMonster(Collider other)
    {
        if (_enemyObjectPool)
        {
            for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                GameObject currentEnemyObjects = _enemyObjectPool.GetPooledObject(_playerData.chestMonsterEnemyPrefabObjectPoolCount);

                currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyDataNumber = i;
                currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyBulletDataNumber = i;
                currentEnemyObjects.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
                currentEnemyObjects.transform.position = new Vector3(other.gameObject.transform.GetChild(i).position.x,
                                                                     1f,
                                                                     other.gameObject.transform.GetChild(i).position.z);
                currentEnemyObjects.transform.localScale = new Vector3(currentEnemyObjects.transform.localScale.x,
                                                                       currentEnemyObjects.transform.localScale.y,
                                                                       currentEnemyObjects.transform.localScale.z);
            }            
        }
    }

    public void SetTrueChestMonster2(Collider other)
    {
        if (_enemyObjectPool)
        {
            for (int i = 0; i < other.gameObject.transform.childCount; i++)
            {
                GameObject currentEnemyObjects = _enemyObjectPool.GetPooledObject(_playerData.chestMonster2EnemyPrefabObjectPoolCount);

                currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyDataNumber = i;
                currentEnemyObjects.gameObject.transform.GetComponent<EnemyManager>().enemyBulletDataNumber = i;
                currentEnemyObjects.gameObject.transform.GetChild(2).GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
                currentEnemyObjects.transform.position = new Vector3(other.gameObject.transform.GetChild(i).position.x,
                                                                     1f,
                                                                     other.gameObject.transform.GetChild(i).position.z);
                currentEnemyObjects.transform.localScale = new Vector3(currentEnemyObjects.transform.localScale.x,
                                                                       currentEnemyObjects.transform.localScale.y,
                                                                       currentEnemyObjects.transform.localScale.z);
            }
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
                                                                                0f,
                                                                                _currentCameraTransform.transform.eulerAngles.z);
                }
                else
                {
                    //PlayerData
                    _playerData.isFire = false;
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
                    iPlayerMovement.Run(_playerData, _particleTransform.transform, 0.1f, playerComponents.playerRigidbody);
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

    public IEnumerator DelayPlayerDestroy(float delayDying)
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

                    StartCoroutine(DelaySetActiveFalseParticle(particleObject, 2f));
                }

                yield return new WaitForSeconds(delayDying);

                Destroy(gameObject);
                //SceneController.DestroySingletonObjects();
                SceneController.LoadEndScene();
            }
        }        
    }
    
}