using Cinemachine;
using System.Collections;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : AbstractPlayer<PlayerManager>
{
    [HideInInspector]
    public PlayerController _playerController;
    [HideInInspector]
    public ArrowRotationController _arrowRotationController;


    [Header("Interfaces")]
    private IPlayerShoot iPlayerShoot;
    private IPlayerCamera iPlayerCamera;
    private IPlayerInitial iPlayerInitial;
    private IPlayerTrigger iPlayerTrigger;
    private IPlayerTouch iPlayerTouch;
    private IPlayerScore iPlayerScore;
    private IPlayerHealth iPlayerHealth;
    private IPlayerMovement iPlayerMovement;
    private IPlayerRotation iPlayerRotation;


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
    public CanvasGroup crosshairImage;

    [Header("Input Movement")]
    public float _xValue;
    public float _zValue;
    private float _touchX;
    private float _touchY;


    public ObjectPool _objectPool;

    [SerializeField] GameObject _damageArrow;


    [HideInInspector]
    public GameObject _currentCharacterObject;
    private GameObject characterObject;

    [Header("Show Bullet Amount")]
    [HideInInspector]
    public GameObject bulletAmountCanvas;
    [HideInInspector]
    public GameObject _healthBarObject;
    [SerializeField] GameObject _topCanvasHealthBarObject;

    void Start()
    {
        InitStates();
        //Scripts
        _playerController = FindObjectOfType<PlayerController>();
        _arrowRotationController = FindObjectOfType<ArrowRotationController>();
        //Audio
        audioSource = GetComponent<AudioSource>();

        //Particle
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Birth, _particleTransform.transform);
    }



    void FixedUpdate()
    {
        iPlayerShoot.Fire(_playerData);
        if (_playerData.isPlayable && PlayerManager.GetInstance._playerController.fire && !_playerData.isWinning)
        {
            //SetFalseBullet
            StartCoroutine(iPlayerShoot.DelayShowingCrosshairAlpha(crosshairImage, 2f));
        }
        else
        {
            StartCoroutine(iPlayerShoot.delayFireWalkDisactivity(_playerData, 4f));
        }
        if (_playerData.isPlayable && _playerController.fire && !_playerData.isWinning)
        {
            iPlayerTrigger.BulletPackGrow(_playerData, ref bulletAmountCanvas);
        }
        bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = _playerData.bulletAmount.ToString();

    }
    void Update()
    {
        iPlayerCamera.ChangeCamera();

        iPlayerTrigger.DamageArrowDirection(ref _damageArrow);

        Movement(_playerData);//PlayerStatement
        Rotation(_playerData);
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
            if (collision.collider.CompareTag(SceneController.Tags.Enemy.ToString()) || collision.collider.CompareTag(SceneController.Tags.CloneDobby.ToString()))
            {
                if (_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value == 0)
                {
                    iPlayerTouch.TouchEnemy(collision, _playerData, ref _healthBarObject, ref _topCanvasHealthBarObject, ref _particleTransform);

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
                        //Touch ParticleEffect
                        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);

                        //SoundEffect
                        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetEnemyHit);
                        //GetHitSFX(_playerData);

                        //PlayerData
                        iPlayerHealth.DecreaseHealth(5, ref _healthBarObject, ref _topCanvasHealthBarObject);
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
                ScoreController.GetInstance.SetScore(2);
                iPlayerScore.ScoreTextGrowing(0, 255, 0);
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



    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.EnemyBullet.ToString()))
        {
            iPlayerTrigger.TriggerBullet(other, _playerData, ref _healthBarObject, ref _topCanvasHealthBarObject, ref _particleTransform);

            StartCoroutine(iPlayerTrigger.DamageArrowIsLookAtEnemy(other, _damageArrow));

            iPlayerHealth.DecreaseHealth(2, ref _healthBarObject, ref _topCanvasHealthBarObject);

            //Touch ParticleEffect
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);
        }
        if (other.CompareTag(SceneController.Tags.Ladder.ToString()))
        {
            iPlayerTrigger.TriggerLadder(true, false, _playerData);
        }

        if (other.CompareTag(SceneController.Tags.FirstFinishArea.ToString()))
        {

            _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
            _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

            StartCoroutine(iPlayerTrigger.DelayLevelUp(2f, _playerData.danceTime, _playerData, other));//LevelUpWithCoroutine
        }
        else if (other.CompareTag(SceneController.Tags.SecondFinishArea.ToString()))
        {

            _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
            _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

            StartCoroutine(iPlayerTrigger.DelayLevelUp(2f, _playerData.danceTime, _playerData, other));//LevelUpWithCoroutine
        }
        else if (other.CompareTag(SceneController.Tags.ThirdFinishArea.ToString()))
        {
            _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
            _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

            StartCoroutine(iPlayerTrigger.DelayLevelUp(2f, _playerData.danceTime, _playerData, other));//LevelUpWithCoroutine
        }
        if (other.CompareTag(SceneController.Tags.Coin.ToString()))
        {
            iPlayerTrigger.PickUpCoin(SceneController.Tags.Coin, other, _playerData, ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas);//GetScore
            iPlayerScore.ScoreTextGrowing(0, 255, 0);
        }
        if (other.CompareTag(SceneController.Tags.CheeseCoin.ToString()))
        {
            iPlayerTrigger.PickUpCoin(SceneController.Tags.CheeseCoin, other, _playerData, ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas);//GetScore
            iPlayerScore.ScoreTextGrowing(0, 255, 0);
        }
        if (other.CompareTag(SceneController.Tags.RotateCoin.ToString()))
        {
            iPlayerTrigger.PickUpCoin(SceneController.Tags.RotateCoin, other, _playerData, ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas);//GetScore
            iPlayerScore.ScoreTextGrowing(0, 255, 0);
        }
        if (other.CompareTag(SceneController.Tags.MushroomCoin.ToString()))
        {
            iPlayerScore.DecreaseScore(10);

            iPlayerTrigger.PickUpCoin(SceneController.Tags.MushroomCoin, other, _playerData, ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas);
            if (_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value > 0)
            {
                iPlayerHealth.DecreaseHealth(10, ref _healthBarObject, ref _topCanvasHealthBarObject);
            }
            else
            {
                iPlayerTrigger.GettingPoisonDamage(_playerData, ref _topCanvasHealthBarObject, ref _healthBarObject);//Score
                StartCoroutine(DelayDestroy(7f));
            }
        }
        if (other.CompareTag(SceneController.Tags.BulletCoin.ToString()))
        {
            iPlayerTrigger.PickUpCoin(SceneController.Tags.BulletCoin, other, _playerData, ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas);//FreshBulletAmount
        }
        if (other.CompareTag(SceneController.Tags.HealthCoin.ToString()))
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.IncreasingHealth);

            iPlayerHealth.IncreaseHealth(50, ref _healthBarObject, ref _topCanvasHealthBarObject, other);
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
            iPlayerTrigger.PickUpCoin(SceneController.Tags.BulletCoin, other, _playerData, ref _coinObject, ref _cheeseObject, ref bulletAmountCanvas);//FreshBulletAmount
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
            iPlayerTrigger.DestroyByLava(_playerData, ref _particleTransform);//DeathByLava

            //DestroyingWithDelay
            StartCoroutine(DelayDestroy(3f));
        }
        if (other.CompareTag(SceneController.Tags.Water.ToString()))
        {
            iPlayerTrigger.DestroyByWater(_playerData);//DeathByLadder

            //DestroyingWithDelay
            StartCoroutine(DelayDestroy(3f));
        }
        iPlayerTrigger.CheckWeaponCollect(other, _bulletData);

    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(SceneController.Tags.Ladder.ToString()))
        {
            iPlayerTrigger.TriggerLadder(false, true, _playerData);//ExitLadder
        }
    }




    #region //Move and Rotation
    private void Movement(PlayerData _playerData)
    {
        if (_playerData.isPlayable && !_playerData.isWinning)
        {
            //Getting left stick values
            _xValue = _playerController.movement.x * Time.deltaTime * 2f;
            _zValue = _playerController.movement.y * Time.deltaTime * 2f;

            //Moves
            Moves(iPlayerMovement, iPlayerShoot);
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
    private void Moves(IPlayerMovement iPlayerMovement, IPlayerShoot iPlayerShoot)
    {
        //Moves
        iPlayerMovement.Walk(_playerData);
        iPlayerMovement.SideWalk(_playerData);
        iPlayerMovement.SpeedSettings(_playerData, _initPlayerSpeed);
        iPlayerMovement.Climb(_playerData);
        iPlayerMovement.SkateBoard(_playerData, _particleTransform.transform);
        iPlayerMovement.Run(_playerData, _particleTransform.transform, 0.05f);
        iPlayerMovement.Jump(_playerData);

        iPlayerShoot.Sword(_playerData);
        //SetFalseBullet
        StartCoroutine(iPlayerShoot.DelayShowingCrosshairAlpha(crosshairImage, 2f));
    }

    private void Rotation(PlayerData _playerData)
    {
        if (SceneController.rotateTouchOrMousePos == true)
        {
            //Mouse Rotation Controller
            iPlayerRotation.GetMousePosition(_playerData, ref _touchX, ref _touchY);
        }
        else
        {

            //Touch Rotation Controller
            iPlayerRotation.SensivityXSettings(1, _playerController, _playerData, ref _touchX);
            _touchY = _playerController.lookRotation.y * _playerData.sensivityY * Time.deltaTime * 40;

        }

        iPlayerRotation.Rotate(ref _touchX, ref _touchX);


        //Rotating Just Camera On X Axis with TouchY
        _currentCameraTransform.transform.Rotate(-_touchY * Time.timeScale / 10, 0f, 0f);


        //Debug.Log(_playerController.lookRotation.x);
        iPlayerCamera.CheckCameraEulerX(_playerData, _currentCameraTransform);
    }

    #endregion

    public IEnumerator DelayDestroy(float delayDying)
    {
        //ParticleEffect
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Death, _particleTransform.transform);

        yield return new WaitForSeconds(delayDying);

        Destroy(gameObject);

        SceneController.GetInstance.LoadEndScene();
    }
    //Init
    private void InitStates()
    {
        if (_playerData.currentMapName == PlayerData.MapNames.FirstMap)
        {
            PlayerManager.GetInstance.gameObject.transform.position = _playerData.playerSpawns.GetChild(0).transform.position;
        }
        else if (_playerData.currentMapName == PlayerData.MapNames.SecondMap)
        {
            PlayerManager.GetInstance.gameObject.transform.position = _playerData.playerSpawns.GetChild(1).transform.position;
        }
        else if (_playerData.currentMapName == PlayerData.MapNames.ThirdMap)
        {
            PlayerManager.GetInstance.gameObject.transform.position = _playerData.playerSpawns.GetChild(2).transform.position;
        }
        else if (_playerData.currentMapName == PlayerData.MapNames.FourthMap)
        {
            PlayerManager.GetInstance.gameObject.transform.position = _playerData.playerSpawns.GetChild(3).transform.position;
        }

        iPlayerShoot = GetComponent<IPlayerShoot>();
        iPlayerCamera = GetComponent<IPlayerCamera>();
        iPlayerInitial = GetComponent<IPlayerInitial>();
        iPlayerTrigger = GetComponent<IPlayerTrigger>();
        iPlayerTouch = GetComponent<IPlayerTouch>();
        iPlayerScore = GetComponent<IPlayerScore>();
        iPlayerHealth = GetComponent<IPlayerHealth>();
        iPlayerMovement = GetComponent<IPlayerMovement>();
        iPlayerRotation = GetComponent<IPlayerRotation>();

        if (_playerData)
        {
            iPlayerTrigger.TriggerLadder(false, true, _playerData);
            //
            //iPlayerInitial.PlayerRandomSpawn(_playerData);


            iPlayerInitial.CreateCharacterObject(_playerData, ref characterObject);



            iPlayerInitial.GetHandObjectsTransform(ref _coinObject, ref _cheeseObject);
            iPlayerInitial.GetWeaponTransform(_bulletData, ref _gunTransform);
            iPlayerInitial.GetSwordTransform(_bulletData, ref _swordTransform);
            iPlayerInitial.CreateStartPlayerStaff(_playerData, ref playerIconTransform, ref _bulletsSpawnTransform,
                                                   ref _cameraWasherTransform, healthBarTransform,
                                                   ref _healthBarObject, ref bulletAmountCanvas);



            iPlayerInitial.DataStatesOnInitial(_playerData, _bulletData, ref _healthBarObject,
                                 ref _topCanvasHealthBarObject, ref bulletAmountCanvas,
                                 ref _initPlayerSpeed);
        }

    }
}