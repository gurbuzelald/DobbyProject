using Cinemachine;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : AbstractSingleton<PlayerManager>
{
    [HideInInspector]
    public PlayerController _playerController;
    [HideInInspector]
    public ArrowRotationController _arrowRotationController;
    [HideInInspector]
    public Transform bulletCoinTransform;

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

    [Header("Current Spawn Transforms")]
    public Transform _particleTransform;
    public Transform _currentCameraTransform;  

    [SerializeField] Transform _jolleenTransform;
    [SerializeField] Transform playerIconTransform;
    [SerializeField] Transform healthBarTransform;
    [SerializeField] Transform _bulletsTransform;    
    [SerializeField] Transform _cameraWasherTransform;

    public Transform[] _slaveTransforms;
    public Transform slaves;
    //private GameObject slaveObject;

    [Header("CinemachineVirtualCamera")]
    public CinemachineVirtualCamera _currentCamera;
    public GameObject cameraSpawner;

    [Header("Crosshair")]
    public CanvasGroup crosshairImage;

    [Header("Input Movement")]
    public float _xValue;
    public float _zValue;
    private float _touchX;
    private float _touchY;        


    public ObjectPool _objectPool;

    [SerializeField] GameObject _damageArrow;


    [Header("Character Object")]
    
    public GameObject _currentCharacterObject;
    private GameObject characterObject;

    [Header("Show Bullet Amoun")]
    private GameObject bulletAmountCanvas;
    private GameObject _healthBarObject;
    [SerializeField] GameObject _topCanvasHealthBarObject;

    void Start()
    {
        //Scripts
        _playerController = FindObjectOfType<PlayerController>();
        _arrowRotationController = FindObjectOfType<ArrowRotationController>();

        CreateCharacterObject();

        GetHandObjectsTransform();

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
        Fire(_playerData);
        
    }
    void Update()
    {
        ChangeCamera();

        DamageArrowDirection();

        Movement(_playerData);//PlayerStatement
    }

    #region //Start
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
            _playerData.isLevelUp = false;

            _playerData.isClickable = true;
            _playerData.normalSpeed = true;
            _playerData.extraSpeed = true;

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
            CharacterSpeeds();
            CharacterJumpForce();
            _initPlayerSpeed = _playerData.playerSpeed;
            _playerData.isDying = false;
            _playerData.isFireNonWalk = false;
            _playerData.isWalking = false;
            _playerData.isClimbing = false;
            _playerData.isBackWalking = false;
            _playerData.isGround = true;
        }
    }

    void CreateCharacterObject()
    {
        characterObject = Instantiate(_playerData.characterObject, gameObject.transform);

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
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Eve)
        {
            current = _playerData.eve;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Michelle)
        {
            current = _playerData.michelle;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Boss)
        {
            current = _playerData.boss;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Aj)
        {
            current = _playerData.aj;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Mremireh)
        {
            current = _playerData.mremireh;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Ty)
        {
            current = _playerData.ty;
        }
        else
        {
            current = _playerData.dobby;
        }
        Instantiate(current, characterObject.transform);
    }

    public Transform PlayerRandomSpawn(PlayerData _playerData)
    {//Random Spawn Control Function
        int value = UnityEngine.Random.Range(0, 8);
        gameObject.transform.position = _playerData.spawns.GetChild(2).position;
        return _playerData.spawns.GetChild(value);
    }


    #endregion

    #region //Get Hand's Staffs On Start
    public void GetHandObjectsTransform()
    {
        //GameObjects
        _coinObject = GameObject.Find("Coin");
        _cheeseObject = GameObject.Find("Cheese");
        _coinObject.transform.localScale = Vector3.zero;
        _cheeseObject.transform.localScale = Vector3.zero;

        GetWeaponTransform();
        GetSwordTransform();
    }
    public void GetWeaponTransform()//Getting finger transform parameter
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
    public void GetSwordTransform()
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

    #endregion

    #region //Touch
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
    private void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag(SceneController.Tags.Ground.ToString()) || collision.collider.CompareTag(SceneController.Tags.Bridge.ToString()))
        {
            _playerData.isGround = true;
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
            _playerData.isGround = false;
        }
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
    #endregion

    #region //Trigger
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
        if (other.tag.ToString() == _bulletData.currentWeaponName)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Poison);
        }
        else if (other.tag.ToString() == BulletData.ak47 || other.tag.ToString() == BulletData.rifle ||
            other.tag.ToString() == BulletData.bulldog || other.tag.ToString() == BulletData.cowgun ||
            other.tag.ToString() == BulletData.crystalgun || other.tag.ToString() == BulletData.demongun ||
            other.tag.ToString() == BulletData.icegun || other.tag.ToString() == BulletData.negev ||
            other.tag.ToString() == BulletData.axegun)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
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


        if (other.CompareTag(SceneController.Tags.Lava.ToString()))
        {
            DestroyByLava(_playerData);//DeathByLava
        }
        if (other.CompareTag(SceneController.Tags.Water.ToString()))
        {
            DestroyByWater(_playerData);//DeathByLadder
        }
        CheckWeaponCollect(other);

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Ladder.ToString()))
        {
            TriggerLadder(false, true, _playerData);//ExitLadder
        }
    }

    public void CheckWeaponCollect(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Rifle.ToString()) && _bulletData.currentWeaponName != BulletData.rifle)
        {
            Destroy(other.gameObject);
            _bulletData.isRifle = true;
        }
        else if (other.CompareTag(SceneController.Tags.Rifle.ToString()) && _bulletData.currentWeaponName == BulletData.rifle)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Ak47.ToString()) && _bulletData.currentWeaponName != BulletData.ak47)
        {
            Destroy(other.gameObject);
            _bulletData.isAk47 = true;
        }
        else if (other.CompareTag(SceneController.Tags.Ak47.ToString()) && _bulletData.currentWeaponName == BulletData.ak47)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Axegun.ToString()) && _bulletData.currentWeaponName != BulletData.axegun)
        {
            Destroy(other.gameObject);
            _bulletData.isAxegun = true;
        }
        else if (other.CompareTag(SceneController.Tags.Axegun.ToString()) && _bulletData.currentWeaponName == BulletData.axegun)
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
        else if (other.CompareTag(SceneController.Tags.Cowgun.ToString()) && _bulletData.currentWeaponName == BulletData.cowgun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Crystalgun.ToString()) && _bulletData.currentWeaponName != BulletData.crystalgun)
        {
            Destroy(other.gameObject);
            _bulletData.isCrystalgun = true;
        }
        else if (other.CompareTag(SceneController.Tags.Crystalgun.ToString()) && _bulletData.currentWeaponName == BulletData.crystalgun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Demongun.ToString()) && _bulletData.currentWeaponName != BulletData.demongun)
        {
            Destroy(other.gameObject);
            _bulletData.isDemongun = true;
        }
        else if (other.CompareTag(SceneController.Tags.Demongun.ToString()) && _bulletData.currentWeaponName != BulletData.demongun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Icegun.ToString()) && _bulletData.currentWeaponName != BulletData.icegun)
        {
            Destroy(other.gameObject);
            _bulletData.isIcegun = true;
        }
        else if (other.CompareTag(SceneController.Tags.Icegun.ToString()) && _bulletData.currentWeaponName == BulletData.icegun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Negev.ToString()) && _bulletData.currentWeaponName != BulletData.negev)
        {
            Destroy(other.gameObject);
            _bulletData.isNegev = true;
        }
        else if (other.CompareTag(SceneController.Tags.Negev.ToString()) && _bulletData.currentWeaponName == BulletData.negev)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(DelayTransformOneGiftBoxWarmText(other));
        }
    }

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
            else if (!_playerData.isWinning)
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
        StartCoroutine(DamageArrowIsLookAtEnemy(other));
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
            //_playerData.isPickRotateCoin = true;

            _playerData.isPicking = true;
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
            _playerData.isPicking = true;
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
            _playerData.isPicking = true;
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
            _playerData.isPicking = true;
            _playerData.playerSpeed = 0.5f;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            //PickUpBulletCoinSFX(_playerData);

            //Trigger CoinObject
            if (_playerData.bulletAmount != _playerData.bulletPack)
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

    void BulletPackGrow()
    {
        if (_playerData.bulletAmount <= _playerData.bulletPack / 2f)
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = Vector3.one;
        }
    }

    void DamageArrowDirection()
    {
        if (_damageArrow != null)
        {
            if (_damageArrow.transform.localScale == Vector3.one)
            {
                StartCoroutine(DelayDamageArrowDirection());
            }
        }
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
    void CreateVictoryAnimation(PlayerData _playerData)
    {//InstantiatingDancerObject
        //EnemyBulletManager.isFirable = false;
        GameObject jolleenObject = Instantiate(_playerData.jolleenObject, _jolleenTransform.transform);
        jolleenObject.transform.position = _jolleenTransform.transform.position;
        Destroy(jolleenObject, _playerData.danceTime);
    }

    IEnumerator DelayLevelUp(float delayWait, float delayDestroy, PlayerData _playerData, Collider other)
    {
        _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
        _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

        if (other.CompareTag(SceneController.Tags.FirstFinishArea.ToString()))
        {
            _playerData.isLevelUp = true;
            _playerData.isCompleteFirstMap = true;
            _playerData.isSecondMapTarget = true;
        }
        else if (other.CompareTag(SceneController.Tags.SecondFinishArea.ToString()))
        {
            _playerData.isLevelUp = true;
            _playerData.isCompleteSecondMap = true;
            _playerData.isThirdMapTarget = true;
        }
        else if (other.CompareTag(SceneController.Tags.ThirdFinishArea.ToString()))
        {
            _playerData.isLevelUp = true;
            _playerData.isCompleteThirdMap = true;
            _playerData.isFourthMapTarget = true;
        }
        //PlayerData
        //_playerData.isLockedWalking = false;
        //_playerData.objects[3].transform.localScale = new Vector3(1f, _playerData.objects[3].transform.localScale.y, _playerData.objects[3].transform.localScale.z);
        //DestroyImmediate(_playerData.healthBarObject, true);
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.LevelUp);
        //LevelUpSFX(_playerData);
        //_playerData.isTouchFinish = true;

        yield return new WaitForSeconds(delayWait);
        //_playerData.isLevelUp = false;
        //PlayerData
        //_playerData.isPlayable = false;
        //_playerData.isWinning = true;

        //JolleenAnimation
        //CreateVictoryAnimation(_playerData);

        yield return new WaitForSeconds(delayDestroy);
        //Destroy(gameObject);
        //SceneController.GetInstance.LevelUp();
    }

    IEnumerator DamageArrowIsLookAtEnemy(Collider other)
    {
        yield return new WaitForSeconds(0.3f);
        _damageArrow.transform.localScale = Vector3.one;
        _damageArrow.transform.LookAt(other.gameObject.transform);
    }

    IEnumerator DelayDamageArrowDirection()
    {
        yield return new WaitForSeconds(1f);
        _damageArrow.transform.localScale = Vector3.zero;
    }

    IEnumerator DelayDestroyCoinObject(GameObject coinObject)
    {
        yield return new WaitForSeconds(0.5f);
        coinObject.transform.localScale = Vector3.zero;
    }

    IEnumerator DelayTransformOneGiftBoxWarmText(Collider other)
    {
        yield return new WaitForSeconds(1f);
        other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.zero;
    }


    #endregion

    #region //Camera
    void ChangeCamera()
    {
        if (_zValue == 0 && _xValue == 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y == 0)
        {
            ConvertToFarCamera(cameraSpawner);
        }
        else if (_zValue != 0 && _xValue == 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(cameraSpawner);
        }
        else if (_zValue == 0 && _xValue != 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(cameraSpawner);
        }
        else if (_zValue != 0 && _xValue != 0 && _playerController.lookRotation.x == 0 && _playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(cameraSpawner);
        }
        else
        {
            //Do Nothing
        }
    }
    void ConvertToCloseCamera(GameObject cameraSpawner)
    {
        cameraSpawner.transform.GetChild(0).gameObject.transform.position = cameraSpawner.transform.GetChild(1).gameObject.transform.position;
        cameraSpawner.transform.GetChild(0).gameObject.transform.rotation = cameraSpawner.transform.GetChild(1).gameObject.transform.rotation;

        cameraSpawner.transform.GetChild(1).gameObject.SetActive(false);
        cameraSpawner.transform.GetChild(0).gameObject.SetActive(true);
        _currentCamera = cameraSpawner.transform.GetChild(0).gameObject.GetComponent<CinemachineVirtualCamera>();
        _currentCamera.m_Follow = gameObject.transform;
        _currentCamera.m_LookAt = gameObject.transform;
    }
    void ConvertToFarCamera(GameObject cameraSpawner)
    {
        cameraSpawner.transform.GetChild(1).gameObject.transform.position = cameraSpawner.transform.GetChild(0).gameObject.transform.position;
        cameraSpawner.transform.GetChild(1).gameObject.transform.rotation = cameraSpawner.transform.GetChild(0).gameObject.transform.rotation;

        cameraSpawner.transform.GetChild(0).gameObject.SetActive(false);
        cameraSpawner.transform.GetChild(1).gameObject.SetActive(true);

        _currentCamera = cameraSpawner.transform.GetChild(1).gameObject.GetComponent<CinemachineVirtualCamera>();

        _currentCamera.m_Follow = gameObject.transform;
        _currentCamera.m_LookAt = gameObject.transform;
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
    #endregion

    #region //Move and Rotation
    void Movement(PlayerData _playerData)
    {
        if (_playerData && gameObject)
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
                _playerData.isFireNonWalk = false;
            }
        }
    }
    void SkateBoard(PlayerData _playerData)
    {//StyleWalking
        if (PlayerController.skateBoard && !_playerData.isJumping && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isRunning && !_playerData.isBackWalking)
        {
            //PlayerData
            if (_playerData.clickTabCount < 1)
            {
                _playerData.clickTabCount++;
                _playerData.isSkateBoarding = true;
            }
            else
            {
                _playerData.isSkateBoarding = false;
                _playerData.skateboardParticle.Stop();
            }
        }
        if (_playerData.isSkateBoarding && !_playerData.isJumping && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isRunning && !_playerData.isBackWalking)
        {
            //ParticleEffect
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Skateboard, _particleTransform.transform);

            //_skateboardParticle.Play();
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _playerData.playerSpeed * Time.deltaTime);
        }
    }

    void Run(PlayerData _playerData)
    {//FasterWalking
        if (_playerData.isClickable)
        {
            if (PlayerController.run && !_playerData.isJumping && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding && !_playerData.isBackWalking)
            {
                _playerData.isRunning = true;
                _playerData.clickShiftCount++;
                _playerData.isClickable = false;
                StartCoroutine(DelayFalseRunning(0.1f));
            }
        }

        if (_playerData.clickShiftCount > 1)
        {
            _playerData.isRunning = false;
        }
        if (_playerData.isRunning && !_playerData.isJumping && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding && !_playerData.isBackWalking)
        {
            //ParticleEffect
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Skateboard, _particleTransform.transform);

            //_skateboardParticle.Play();
            GetInstance.GetComponent<Transform>().Translate(0f, 0f, _playerData.playerSpeed * Time.deltaTime * 13f);
        }

    }

    void Walk(PlayerData _playerData)
    {//ForwardAndBackWalking
        if (!_playerData.isLockedWalking)
        {
            if ((_zValue > 0.01f && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding))
            {
                //PlayerData
                _playerData.isWalking = true;
                if (GetInstance.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Animator>().GetLayerWeight(16) == 1)
                {//When fireWalk Animation is active, player speed will lower then original speed
                    GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue * _playerData.playerSpeed * Time.deltaTime * 3f);
                }
                else
                {
                    GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue * _playerData.playerSpeed * Time.deltaTime * 10f);
                }
                _playerData.isBackWalking = false;
            }
            else if (_zValue < -0.01 && !_playerData.isClimbing && !_playerData.isBackClimbing)
            {
                //PlayerData
                GetInstance.GetComponent<Transform>().Translate(0f, 0f, _zValue * _playerData.playerSpeed * Time.deltaTime * 3f);
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
        SpeedSettings(_playerData);
    }
    void SideWalk(PlayerData _playerData)
    {//LeftAndRightWalking
        if ((!_playerData.isClimbing && !_playerData.isBackClimbing) && (_xValue < -0.02f || _xValue > 0.02f))
        {
            GetInstance.GetComponent<Transform>().Translate(_xValue * _playerData.playerSpeed * Time.deltaTime * 5f, 0f, 0f);
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
    void Jump(PlayerData _playerData)
    {
        if (_playerController.jump && _playerData.jumpCount == 0 && _playerData.isGround)
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
            SensivityXSettings(1, _playerController, _playerData);
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
    IEnumerator DelayFalseRunning(float delay)
    {
        yield return new WaitForSeconds(delay);
        _playerData.isRunning = false;

        yield return new WaitForSeconds(3f);
        _playerData.isClickable = true;

    }

    #endregion

    #region //Settings

    void SpeedSettings(PlayerData _playerData)
    {
        if (!_playerData.isLockedWalking)
        {
            if ((_xValue > 0 && _zValue > 0) || (_xValue < 0 && _zValue > 0) || (_xValue < 0 && _zValue < 0) || (_xValue > 0 && _zValue < 0) || _zValue < 0)
            {
                //PlayerData
                if (_playerData.extraSpeed)
                {
                    _playerData.playerSpeed = _initPlayerSpeed * 5f;
                }
                if (_playerData.normalSpeed)
                {
                    _playerData.playerSpeed = _initPlayerSpeed;
                }
            }
            else if (_playerData.isSkateBoarding && _zValue > 0)
            {
                //PlayerData
                _playerData.playerSpeed = _initPlayerSpeed * 1.6f;

            }
            else if (_playerData.isRunning)
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

    void SensivityXSettings(int touchXValue, PlayerController _playerController, PlayerData _playerData)
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

    void CharacterJumpForce()
    {
        if (_playerData.currentCharacterName == PlayerData.CharacterNames.Dobby)
        {
            _playerData.jumpForce = 3f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Michelle)
        {
            _playerData.jumpForce = 4.5f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Glassy)
        {
            _playerData.jumpForce = 4.5f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Aj)
        {
            _playerData.jumpForce = 4f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Mremireh)
        {
            _playerData.jumpForce = 5f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Lusth)
        {
            _playerData.jumpForce = 4.5f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Spartacus)
        {
            _playerData.jumpForce = 4f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Boss)
        {
            _playerData.jumpForce = 3;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Ty)
        {
            _playerData.jumpForce = 3f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Guard)
        {
            _playerData.jumpForce = 3f;
        }
        else
        {
            _playerData.jumpForce = 3f;
        }
    }
    void CharacterSpeeds()
    {
        if (_playerData.currentCharacterName == PlayerData.CharacterNames.Dobby)
        {
            _playerData.playerSpeed = 3.5f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Michelle)
        {
            _playerData.playerSpeed = 3.2f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Glassy)
        {
            _playerData.playerSpeed = 3f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Aj)
        {
            _playerData.playerSpeed = 3f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Mremireh)
        {
            _playerData.playerSpeed = 1f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Lusth)
        {
            _playerData.playerSpeed = 2.5f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Spartacus)
        {
            _playerData.playerSpeed = 1.5f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Boss)
        {
            _playerData.playerSpeed = 2f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Ty)
        {
            _playerData.playerSpeed = 2f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Guard)
        {
            _playerData.playerSpeed = 2f;
        }
        else
        {
            _playerData.playerSpeed = 2f;
        }
    }
    #endregion

    #region //Shoot
    public void Fire(PlayerData _playerData)
    {
        if (_playerData.isPlayable && _playerController.fire && !_playerData.isWinning)
        {
            //PlayerData
            if (_playerData.bulletAmount <= 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);

                _playerData.isFireNonWalk = false;

                _playerData.isFireWalk = false;
            }
            else if (_playerData.bulletAmount <= _playerData.bulletPack / 2f && !_playerData.isWalking)
            {
                _playerData.bulletAmount--;

                _playerData.isFireNonWalk = true;

            }
            else if (_playerData.bulletAmount > _playerData.bulletPack / 2f && !_playerData.isWalking)
            {
                _playerData.bulletAmount--;

                _playerData.isFireNonWalk = true;

            }
            else if (_playerData.bulletAmount <= _playerData.bulletPack / 2f && _playerData.isWalking)
            {
                _playerData.bulletAmount--;

                _playerData.isFireWalk = true;

            }
            else if (_playerData.bulletAmount > _playerData.bulletPack / 2f && _playerData.isWalking)
            {
                _playerData.bulletAmount--;

                _playerData.isFireWalk = true;
            }

            bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = _playerData.bulletAmount.ToString();

            //SetFalseBullet
            StartCoroutine(DelayShowingCrosshairAlpha(2f));
            BulletPackGrow();
        }
        else
        {
            _playerData.isFireNonWalk = false;
            StartCoroutine(delayFireWalkDisactivity(4f));
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

                //SetFalseBullet
                StartCoroutine(DelayShowingCrosshairAlpha(2f));
            }
            else
            {
                _playerData.isSwording = false;
            }
        }
        else
        {
            _playerData.isFireNonWalk = false;
        }
    }

    IEnumerator DelayShowingCrosshairAlpha(float value)
    {
        crosshairImage.GetComponent<CanvasGroup>().alpha = 1;

        yield return new WaitForSeconds(value);

        crosshairImage.GetComponent<CanvasGroup>().alpha = 0;
    }

    IEnumerator delayFireWalkDisactivity(float delay)
    {
        yield return new WaitForSeconds(delay);
        _playerData.isFireWalk = false;
    }

    IEnumerator DelaySwordBullet()
    {
        yield return new WaitForSeconds(1f);
        _playerData.isSwording = true;
    }

    #endregion

    #region //Score
    void DecreaseScore(int scoreDamageValue)
    {

        ScoreTextGrowing(255, 0, 0);

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
        ScoreController.GetInstance._scoreText.color = new Color(r, g, b);

        StartCoroutine(DelayScoreSizeBack());
    }

    IEnumerator DelayScoreSizeBack()
    {
        yield return new WaitForSeconds(0.5f);
        ScoreController.GetInstance._scoreText.transform.localScale = Vector3.one;
        ScoreController.GetInstance._scoreText.color = Color.white;
    }


    #endregion

    #region //Health
    void IncreaseHealth(int damageHealthValue)
    {
        if (_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value <= 50)
        {
            _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value += damageHealthValue;

            _healthBarObject.transform.localScale = new Vector3(1f,
                                                                0.3f,
                                                                0.3f);
            _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

            StartCoroutine(DelayHealthSizeBack());
        }
    }
    void DecreaseHealth(int damageHealthValue)
    {
        _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value -= damageHealthValue;
        _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

        _healthBarObject.transform.localScale = new Vector3(1f,  0.3f,  0.3f);

        StartCoroutine(DelayHealthSizeBack());
    }

    IEnumerator DelayHealthSizeBack()
    {
        yield return new WaitForSeconds(0.5f);
        _healthBarObject.transform.localScale = new Vector3(1, 0.1f, 0.1f);
    }
    #endregion

    #region //Destroy
    IEnumerator DelayDestroy(float delayDying)
    {
        //ParticleEffect
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Death, _particleTransform.transform);

        yield return new WaitForSeconds(delayDying);

        Destroy(gameObject);

        SceneController.GetInstance.LoadEndScene();
    }

    #endregion
}