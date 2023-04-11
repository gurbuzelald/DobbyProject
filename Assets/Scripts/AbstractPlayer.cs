using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using System.Collections;


//This abstract class has abstraction singleton and interface functions
public abstract class AbstractPlayer<T> : MonoBehaviour, IPlayerShoot, IPlayerCamera, IPlayerInitial,
                                                            IPlayerTrigger, IPlayerScore, IPlayerHealth,
                                                            IPlayerTouch, IPlayerMovement, IPlayerRotation where T : MonoBehaviour
{
    private static T _instance;

    public static T GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                GameObject objectOfGame = new GameObject();
                objectOfGame.name = typeof(T).Name;
                _instance = objectOfGame.AddComponent<T>();
            }
            return _instance;
        }

    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;

            DontDestroyOnLoad(gameObject);
        }
    }

    #region //Initial
    public void GetHandObjectsTransform(ref GameObject _coinObject, ref GameObject _cheeseObject)
    {
        //GameObjects
        _coinObject = GameObject.Find("Coin");
        _cheeseObject = GameObject.Find("Cheese");
        _coinObject.transform.localScale = Vector3.zero;
        _cheeseObject.transform.localScale = Vector3.zero;        
    }
    public virtual void GetWeaponTransform(BulletData _bulletData, ref GameObject _gunTransform)//Getting finger transform parameter
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
    public virtual void GetSwordTransform(BulletData _bulletData, ref GameObject _swordTransform)
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
    public void CreateCharacterObject(PlayerData _playerData, ref GameObject characterObject)
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


    public virtual void CreateStartPlayerStaff(PlayerData _playerData, ref Transform playerIconTransform, ref Transform _bulletsTransform, 
                                               ref Transform _cameraWasherTransform, Transform healthBarTransform, 
                                               ref GameObject _healthBarObject, ref GameObject bulletAmountCanvas)
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
                        PlayerManager.GetInstance.gameObject.transform);//HealthBarPrefab

        Instantiate(_playerData.objects[4], PlayerManager.GetInstance.gameObject.transform.position,
                    Quaternion.identity,
                    PlayerManager.GetInstance.gameObject.transform);//MagnetPrefab

        Instantiate(_playerData.objects[5],
                    playerIconTransform.transform.position,
                    Quaternion.identity,
                    playerIconTransform.transform);//PlayerIconPrefab
        playerIconTransform.rotation = PlayerManager.GetInstance.gameObject.transform.rotation;

        Instantiate(_playerData.objects[6], PlayerManager.GetInstance.gameObject.transform);//PlayerSFXPrefab

        bulletAmountCanvas = Instantiate(_playerData.objects[7], PlayerManager.GetInstance.gameObject.transform);//BulletAmountCanvas

        //CreateSlaveObject();
    }

    public void DataStatesOnInitial(PlayerData _playerData, BulletData _bulletData, ref GameObject _healthBarObject,
                             ref GameObject _topCanvasHealthBarObject, ref GameObject bulletAmountCanvas,
                             ref float _initPlayerSpeed)
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
            CharacterSpeeds(_playerData);
            CharacterJumpForce(_playerData);
            _initPlayerSpeed = _playerData.playerSpeed;
            _playerData.isDying = false;
            _playerData.isFireNonWalk = false;
            _playerData.isWalking = false;
            _playerData.isClimbing = false;
            _playerData.isBackWalking = false;
            _playerData.isGround = true;
        }
    }


    public Transform PlayerRandomSpawn(PlayerData _playerData)
    {//Random Spawn Control Function
        int value = UnityEngine.Random.Range(0, 8);
        PlayerManager.GetInstance.gameObject.transform.position = _playerData.spawns.GetChild(2).position;
        return _playerData.spawns.GetChild(value);
    }
    void CharacterJumpForce(PlayerData _playerData)
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
    void CharacterSpeeds(PlayerData _playerData)
    {
        if (_playerData.currentCharacterName == PlayerData.CharacterNames.Dobby)
        {
            _playerData.playerSpeed = 2.5f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Michelle)
        {
            _playerData.playerSpeed = 2.5f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Glassy)
        {
            _playerData.playerSpeed = 2.4f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Aj)
        {
            _playerData.playerSpeed = 2f;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Mremireh)
        {
            _playerData.playerSpeed = 1.2f;
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
    public virtual void Fire(PlayerData _playerData)
    {
        if (_playerData.isPlayable && PlayerManager.GetInstance._playerController.fire && !_playerData.isWinning)
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
                _playerData.isFireNonWalk = true;
            }
            else if (_playerData.bulletAmount > _playerData.bulletPack / 2f && !_playerData.isWalking)
            {
                _playerData.isFireNonWalk = true;
            }
            else if (_playerData.bulletAmount <= _playerData.bulletPack / 2f && _playerData.isWalking)
            {
                _playerData.isFireWalk = true;
            }
            else if (_playerData.bulletAmount > _playerData.bulletPack / 2f && _playerData.isWalking)
            {
                _playerData.isFireWalk = true;
            }
            if (_playerData.bulletAmount > 0 && BulletManager.isCreatedWeaponBullet)
            {
                _playerData.bulletAmount--;
                PlayerManager.GetInstance._playerController.fire = false;
                BulletManager.isCreatedWeaponBullet = false;
            }
        }
        else
        {
            _playerData.isFireNonWalk = false;            
        }
    }
    IEnumerator DelayDisactivateFire()
    {
        yield return new WaitForSeconds(0.01f);
        PlayerManager.GetInstance._playerController.fire = false;
    }
    public virtual void Sword(PlayerData _playerData)
    {
        if (_playerData.isPlayable)
        {
            if (PlayerManager.GetInstance._playerController.sword && _playerData.isSwordTime)
            {
                //PlayerData
                _playerData.isSwording = true;                
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

    public virtual IEnumerator DelayShowingCrosshairAlpha(CanvasGroup crosshairImage, float delay)
    {
        crosshairImage.GetComponent<CanvasGroup>().alpha = 1;

        yield return new WaitForSeconds(delay);

        crosshairImage.GetComponent<CanvasGroup>().alpha = 0;
    }

    public virtual IEnumerator delayFireWalkDisactivity(PlayerData _playerData, float delay)
    {
        yield return new WaitForSeconds(delay);
        _playerData.isFireWalk = false;
    }

    #endregion

    #region //Camera


    public virtual void ChangeCamera()
    {
        if (PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue == 0 
            && PlayerManager.GetInstance._playerController.lookRotation.x == 0 
            && PlayerManager.GetInstance._playerController.lookRotation.y == 0)
        {
            ConvertToFarCamera(PlayerManager.GetInstance.cameraSpawner);
        }
        else if (PlayerManager.GetInstance._zValue != 0 && PlayerManager.GetInstance._xValue == 0 
            && PlayerManager.GetInstance._playerController.lookRotation.x == 0 && PlayerManager.GetInstance._playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(PlayerManager.GetInstance.cameraSpawner);
        }
        else if (PlayerManager.GetInstance._zValue == 0 && PlayerManager.GetInstance._xValue != 0 
            && PlayerManager.GetInstance._playerController.lookRotation.x == 0 && PlayerManager.GetInstance._playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(PlayerManager.GetInstance.cameraSpawner);
        }
        else if (PlayerManager.GetInstance._zValue != 0 && PlayerManager.GetInstance._xValue != 0 
            && PlayerManager.GetInstance._playerController.lookRotation.x == 0 && PlayerManager.GetInstance._playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(PlayerManager.GetInstance.cameraSpawner);
        }
    }
    public virtual void ConvertToCloseCamera(GameObject cameraSpawner)
    {
        cameraSpawner.transform.GetChild(0).gameObject.transform.position = cameraSpawner.transform.GetChild(1).gameObject.transform.position;
        cameraSpawner.transform.GetChild(0).gameObject.transform.rotation = cameraSpawner.transform.GetChild(1).gameObject.transform.rotation;

        cameraSpawner.transform.GetChild(1).gameObject.SetActive(false);
        cameraSpawner.transform.GetChild(0).gameObject.SetActive(true);
        PlayerManager.GetInstance._currentCamera = cameraSpawner.transform.GetChild(0).gameObject.GetComponent<CinemachineVirtualCamera>();
        PlayerManager.GetInstance._currentCamera.m_Follow = gameObject.transform;
        PlayerManager.GetInstance._currentCamera.m_LookAt = gameObject.transform;
    }
    public virtual void ConvertToFarCamera(GameObject cameraSpawner)
    {
        cameraSpawner.transform.GetChild(1).gameObject.transform.position = cameraSpawner.transform.GetChild(0).gameObject.transform.position;
        cameraSpawner.transform.GetChild(1).gameObject.transform.rotation = cameraSpawner.transform.GetChild(0).gameObject.transform.rotation;

        cameraSpawner.transform.GetChild(0).gameObject.SetActive(false);
        cameraSpawner.transform.GetChild(1).gameObject.SetActive(true);

        PlayerManager.GetInstance._currentCamera = cameraSpawner.transform.GetChild(1).gameObject.GetComponent<CinemachineVirtualCamera>();

        PlayerManager.GetInstance._currentCamera.m_Follow = gameObject.transform;
        PlayerManager.GetInstance._currentCamera.m_LookAt = gameObject.transform;
    }

    public virtual void CheckCameraEulerX(PlayerData _playerData, Transform _currentCameraTransform)
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

    
    #endregion

    #region //Trigger


    public virtual void TriggerLadder(bool isTouch, bool isTouchExit, PlayerData _playerData)
    {
        PlayerManager.GetInstance.GetComponent<Rigidbody>().isKinematic = isTouch;
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


    public virtual void TriggerBullet(Collider other, PlayerData _playerData, ref GameObject _healthBarObject, ref GameObject _topCanvasHealthBarObject, ref Transform _particleTransform)
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
                StartCoroutine(PlayerManager.GetInstance.DelayDestroy(3f));
            }
            else if (!_playerData.isWinning)
            {
                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);
                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.TouchBurning, _particleTransform.transform);

                //SoundEffect
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetBulletHit);
                //GetHitSFX(_playerData);

                //PlayerData
                //_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value -= 5;
                //_topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;
            }
        }
    }

    public virtual void PickUpCoin(SceneController.Tags value, Collider other, PlayerData _playerData, ref GameObject _coinObject, ref GameObject _cheeseObject, ref GameObject bulletAmountCanvas)
    {
        if (value == SceneController.Tags.Coin)
        {
            //Data
            _playerData.playerSpeed = 0.5f;
            _playerData.isPicking = true;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
            //PickUpCoinSFX(_playerData);


            //Trigger
            other.gameObject.SetActive(false);

            //Score
            ScoreController.GetInstance.SetScore(23);
            //CreateSlaveObject();
        }
        else if (value == SceneController.Tags.RotateCoin)
        {
            //PlayerData
            //_playerData.isPickRotateCoin = true;

            _playerData.isPicking = true;
            _playerData.playerSpeed = 0.5f;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
            //PickUpCoinSFX(_playerData);


            //Trigger CoinObject
            other.gameObject.SetActive(false);

            //SettingScore
            ScoreController.GetInstance.SetScore(23);
            //CreateSlaveObject();
        }
        else if (value == SceneController.Tags.CheeseCoin)
        {
            //PlayerData
            _playerData.isPicking = true;
            _playerData.playerSpeed = 0.5f;

            //_cheeseObject.SetActive(true);
            _cheeseObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(_cheeseObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
            //PickUpCoinSFX(_playerData);


            //Trigger CoinObject
            other.gameObject.SetActive(false);

            //SettingScore
            ScoreController.GetInstance.SetScore(23);
            //CreateSlaveObject();
        }
        else if (value == SceneController.Tags.MushroomCoin)
        {
            //PlayerData
            _playerData.isPicking = true;
            _playerData.playerSpeed = 0.5f;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Poison);
            //PickUpCoinSFX(_playerData);

            //Trigger CoinObject
            other.gameObject.SetActive(false);
        }
        else if (value == SceneController.Tags.BulletCoin)
        {
            //PlayerData
            _playerData.isPicking = true;
            _playerData.playerSpeed /= 2f;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(_coinObject));

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

    public virtual void CheckWeaponCollect(Collider other, BulletData _bulletData)
    {
        if (other.CompareTag(SceneController.Tags.Rifle.ToString()) && _bulletData.currentWeaponName != BulletData.rifle)
        {
            Destroy(other.gameObject);
            _bulletData.isRifle = true;
        }
        else if (other.CompareTag(SceneController.Tags.Rifle.ToString()) && _bulletData.currentWeaponName == BulletData.rifle)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Ak47.ToString()) && _bulletData.currentWeaponName != BulletData.ak47)
        {
            Destroy(other.gameObject);
            _bulletData.isAk47 = true;
        }
        else if (other.CompareTag(SceneController.Tags.Ak47.ToString()) && _bulletData.currentWeaponName == BulletData.ak47)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Axegun.ToString()) && _bulletData.currentWeaponName != BulletData.axegun)
        {
            Destroy(other.gameObject);
            _bulletData.isAxegun = true;
        }
        else if (other.CompareTag(SceneController.Tags.Axegun.ToString()) && _bulletData.currentWeaponName == BulletData.axegun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Bulldog.ToString()) && _bulletData.currentWeaponName != BulletData.bulldog)
        {
            Destroy(other.gameObject);
            _bulletData.isBulldog = true;
        }
        else if (other.CompareTag(SceneController.Tags.Bulldog.ToString()) && _bulletData.currentWeaponName == BulletData.bulldog)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Cowgun.ToString()) && _bulletData.currentWeaponName != BulletData.cowgun)
        {
            Destroy(other.gameObject);
            _bulletData.isCowgun = true;
        }
        else if (other.CompareTag(SceneController.Tags.Cowgun.ToString()) && _bulletData.currentWeaponName == BulletData.cowgun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Crystalgun.ToString()) && _bulletData.currentWeaponName != BulletData.crystalgun)
        {
            Destroy(other.gameObject);
            _bulletData.isCrystalgun = true;
        }
        else if (other.CompareTag(SceneController.Tags.Crystalgun.ToString()) && _bulletData.currentWeaponName == BulletData.crystalgun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Demongun.ToString()) && _bulletData.currentWeaponName != BulletData.demongun)
        {
            Destroy(other.gameObject);
            _bulletData.isDemongun = true;
        }
        else if (other.CompareTag(SceneController.Tags.Demongun.ToString()) && _bulletData.currentWeaponName != BulletData.demongun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Icegun.ToString()) && _bulletData.currentWeaponName != BulletData.icegun)
        {
            Destroy(other.gameObject);
            _bulletData.isIcegun = true;
        }
        else if (other.CompareTag(SceneController.Tags.Icegun.ToString()) && _bulletData.currentWeaponName == BulletData.icegun)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.Negev.ToString()) && _bulletData.currentWeaponName != BulletData.negev)
        {
            Destroy(other.gameObject);
            _bulletData.isNegev = true;
        }
        else if (other.CompareTag(SceneController.Tags.Negev.ToString()) && _bulletData.currentWeaponName == BulletData.negev)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }
    }
    public virtual void DamageArrowDirection(ref GameObject _damageArrow)
    {
        if (_damageArrow != null && _damageArrow.transform.localScale == Vector3.one)
        {
            StartCoroutine(PlayerManager.GetInstance.DelayDamageArrowDirection(_damageArrow));
        }
    }

    public virtual void BulletPackGrow(PlayerData _playerData, ref GameObject bulletAmountCanvas)
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


    public virtual void DestroyByWater(PlayerData _playerData)
    {
        //PlayerData
        _playerData.isDestroyed = true;
        _playerData.isDying = true;
        _playerData.isIdling = false;
        _playerData.isPlayable = false;

        //SoundEffect
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.JumpToSea);
        //JumpToSeaSFX(_playerData);

    }

    public virtual void DestroyByLava(PlayerData _playerData, ref Transform _particleTransform)
    {
        //PlayerData
        _playerData.isDestroyed = true;
        _playerData.isDying = true;
        _playerData.isIdling = false;
        _playerData.isPlayable = false;

        //ParticleEffect
        ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Burn, _particleTransform.transform);

    }

    public virtual void GettingPoisonDamage(PlayerData _playerData, ref GameObject _topCanvasHealthBarObject, ref GameObject _healthBarObject)
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

    }


    public virtual IEnumerator DelayLevelUp(float delayWait, float delayDestroy, PlayerData _playerData, Collider other)
    {

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

    public virtual IEnumerator DamageArrowIsLookAtEnemy(Collider other, GameObject _damageArrow)
    {
        yield return new WaitForSeconds(0.3f);
        _damageArrow.transform.localScale = Vector3.one;
        _damageArrow.transform.LookAt(other.gameObject.transform);
    }

    public virtual IEnumerator DelayDamageArrowDirection(GameObject _damageArrow)
    {
        yield return new WaitForSeconds(1f);
        _damageArrow.transform.localScale = Vector3.zero;
    }

    public virtual IEnumerator DelayDestroyCoinObject(GameObject coinObject)
    {
        yield return new WaitForSeconds(0.5f);
        coinObject.transform.localScale = Vector3.zero;
    }

    public virtual IEnumerator DelayTransformOneGiftBoxWarmText(Collider other)
    {
        yield return new WaitForSeconds(1f);
        other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.zero;
    }

    public virtual void CreateVictoryAnimation(PlayerData _playerData, ref Transform _jolleenTransform)
    {//InstantiatingDancerObject
        //EnemyBulletManager.isFirable = false;
        GameObject jolleenObject = Instantiate(_playerData.jolleenObject, _jolleenTransform.transform);
        jolleenObject.transform.position = _jolleenTransform.transform.position;
        Destroy(jolleenObject, _playerData.danceTime);
    }


    #endregion

    #region //Touch

    public virtual void TouchEnemy(Collision collision, PlayerData _playerData, ref GameObject _healthBarObject, ref GameObject _topCanvasHealthBarObject, ref Transform _particleTransform)
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

    }

    #endregion

    #region //Score
    public virtual void DecreaseScore(int scoreDamageValue)
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
    public virtual void IncreaseScore(int scoreDamageValue)
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
    public virtual void ScoreTextGrowing(int r, int g, int b)
    {
        ScoreController.GetInstance._scoreText.transform.localScale = new Vector3(2f, 2f, 2f);
        ScoreController.GetInstance._scoreText.color = new Color(r, g, b);

        StartCoroutine(DelayScoreSizeBack());
    }

    public virtual IEnumerator DelayScoreSizeBack()
    {
        yield return new WaitForSeconds(0.5f);
        ScoreController.GetInstance._scoreText.transform.localScale = Vector3.one;
        ScoreController.GetInstance._scoreText.color = Color.white;
    }
    #endregion

    #region //Health
    public virtual void IncreaseHealth(int damageHealthValue, ref GameObject _healthBarObject, ref GameObject _topCanvasHealthBarObject)
    {
        if (_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value < 100)
        {
            _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value += damageHealthValue;

            _healthBarObject.transform.localScale = new Vector3(1f,
                                                                0.3f,
                                                                0.3f);
            _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

            StartCoroutine(DelayHealthSizeBack(_healthBarObject));
        }
    }
    public virtual void DecreaseHealth(int damageHealthValue, ref GameObject _healthBarObject, ref GameObject _topCanvasHealthBarObject)
    {
        _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value -= damageHealthValue;
        _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;

        _healthBarObject.transform.localScale = new Vector3(1f, 0.3f, 0.3f);

        StartCoroutine(DelayHealthSizeBack(_healthBarObject));
    }

    public virtual IEnumerator DelayHealthSizeBack(GameObject _healthBarObject)
    {
        yield return new WaitForSeconds(0.5f);
        _healthBarObject.transform.localScale = new Vector3(1, 0.1f, 0.1f);
    }
    #endregion

    #region //Move
    public virtual void SkateBoard(PlayerData _playerData, Transform _particleTransform)
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
    public virtual void Run(PlayerData _playerData, Transform _particleTransform, float runTimeAmount)
    {//FasterWalking
        if (_playerData.isClickable && PlayerController.run && !_playerData.isJumping && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding && !_playerData.isBackWalking)
        {
            _playerData.isRunning = true;
            _playerData.clickShiftCount++;
            _playerData.isClickable = false;
            StartCoroutine(DelayFalseRunning(_playerData, runTimeAmount));
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
    
    public virtual void Walk(PlayerData _playerData)
    {//ForwardAndBackWalking
        if (!_playerData.isLockedWalking)
        {
            if ((PlayerManager.GetInstance._zValue > 0.01f && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding))
            {
                //PlayerData
                _playerData.isWalking = true;
                if (PlayerManager.GetInstance.transform.GetChild(1).GetChild(0).gameObject.GetComponent<Animator>().GetLayerWeight(16) == 1)
                {//When fireWalk Animation is active, player speed will lower then original speed
                    PlayerManager.GetInstance.GetComponent<Transform>().Translate(0f, 0f, PlayerManager.GetInstance._zValue * _playerData.playerSpeed * Time.deltaTime * 3f);
                }
                else
                {
                    PlayerManager.GetInstance.GetComponent<Transform>().Translate(0f, 0f, PlayerManager.GetInstance._zValue * _playerData.playerSpeed * Time.deltaTime * 10f);
                }
                _playerData.isBackWalking = false;
            }
            else if (PlayerManager.GetInstance._zValue < -0.01 && !_playerData.isClimbing && !_playerData.isBackClimbing)
            {
                //PlayerData
                GetInstance.GetComponent<Transform>().Translate(0f, 0f, PlayerManager.GetInstance._zValue * _playerData.playerSpeed * Time.deltaTime * 3f);
                _playerData.isBackWalking = true;
                _playerData.isWalking = false;
            }
            else if (PlayerManager.GetInstance._zValue == 0)
            {
                //PlayerData
                _playerData.isBackWalking = false;
                _playerData.isWalking = false;
            }
        }
        else
        {
            PlayerManager.GetInstance.GetComponent<Transform>().Translate(0f, 0f, _playerData.playerSpeed * Time.deltaTime / 4f);
        }

    }
    public virtual void Climb(PlayerData _playerData)
    {//WhenEnterToTheLadderGoToClimb
        if (PlayerManager.GetInstance._zValue > 0 && _playerData.isClimbing && !_playerData.isBackClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, PlayerManager.GetInstance._zValue, 0f);
        }
        else if (PlayerManager.GetInstance._zValue < 0 && !_playerData.isClimbing && _playerData.isBackClimbing)
        {
            GetInstance.GetComponent<Transform>().Translate(0f, PlayerManager.GetInstance._zValue, 0f);
        }
    }

    public virtual void Jump(PlayerData _playerData)
    {
        if (PlayerManager.GetInstance._playerController.jump && _playerData.jumpCount == 0 && _playerData.isGround)
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


    public virtual void SideWalk(PlayerData _playerData)
    {//LeftAndRightWalking
        if ((!_playerData.isClimbing && !_playerData.isBackClimbing) && (PlayerManager.GetInstance._xValue < -0.02f || PlayerManager.GetInstance._xValue > 0.02f))
        {
            GetInstance.GetComponent<Transform>().Translate(PlayerManager.GetInstance._xValue * _playerData.playerSpeed * Time.deltaTime * 5f, 0f, 0f);
        }
    }

    public virtual void SpeedSettings(PlayerData _playerData, float _initPlayerSpeed)
    {
        if (!_playerData.isLockedWalking)
        {
            if ((PlayerManager.GetInstance._xValue > 0 && PlayerManager.GetInstance._zValue > 0) || 
                (PlayerManager.GetInstance._xValue < 0 && PlayerManager.GetInstance._zValue > 0) || 
                (PlayerManager.GetInstance._xValue < 0 && PlayerManager.GetInstance._zValue < 0) || 
                (PlayerManager.GetInstance._xValue > 0 && PlayerManager.GetInstance._zValue < 0) || 
                PlayerManager.GetInstance._zValue < 0)
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
            else if (_playerData.isSkateBoarding && PlayerManager.GetInstance._zValue > 0)
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

    IEnumerator DelayFalseRunning(PlayerData _playerData, float delay)
    {
        yield return new WaitForSeconds(delay);
        _playerData.isRunning = false;

        yield return new WaitForSeconds(3f);
        _playerData.isClickable = true;

    }
    #endregion

    #region //Rotation

    public virtual void Rotate(ref float _touchX, ref float _touchY)
    {
        //Rotating With Camera On X Axis
        PlayerManager.GetInstance.GetComponent<Transform>().Rotate(0f, _touchX, 0f);
    }

    public virtual void GetMousePosition(PlayerData _playerData, ref float _touchX, ref float _touchY)
    {
        _touchX = Input.GetAxis("Mouse X") * _playerData.rotateSpeed * Time.timeScale;
        _touchY = Input.GetAxis("Mouse Y") * _playerData.rotateSpeed * Time.timeScale * 5f;
    }


    public virtual void SensivityXSettings(int touchXValue, PlayerController _playerController, PlayerData _playerData, ref float _touchX)
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


    #endregion


}