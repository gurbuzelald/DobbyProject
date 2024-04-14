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
        else if (_bulletData.currentWeaponName == BulletData.m4a4)
        {
            _gunTransform = GameObject.Find("M4a4Transform");
        }
        else if (_bulletData.currentWeaponName == BulletData.bulldog)
        {
            _gunTransform = GameObject.Find("BulldogTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.cow)
        {
            _gunTransform = GameObject.Find("CowTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.crystal)
        {
            _gunTransform = GameObject.Find("CrystalTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.demon)
        {
            _gunTransform = GameObject.Find("DemonTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.ice)
        {
            _gunTransform = GameObject.Find("IceTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.negev)
        {
            _gunTransform = GameObject.Find("NegevTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.axe)
        {
            _gunTransform = GameObject.Find("AxeTransform");
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
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Joleen)
        {
            current = _playerData.joleen;
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

        //Instantiate(_playerData.objects[4],
        //            new Vector3(PlayerManager.GetInstance.gameObject.transform.position.x,
        //                        1,
        //                        PlayerManager.GetInstance.gameObject.transform.position.z),
        //            Quaternion.identity,
        //            PlayerManager.GetInstance.gameObject.transform);//MagnetPrefab

        Instantiate(_playerData.objects[4],
                    playerIconTransform.transform.position,
                    Quaternion.identity,
                    playerIconTransform.transform);//PlayerIconPrefab
        playerIconTransform.rotation = PlayerManager.GetInstance.gameObject.transform.rotation;

        Instantiate(_playerData.objects[5], PlayerManager.GetInstance.gameObject.transform);//PlayerSFXPrefab

        bulletAmountCanvas = Instantiate(_playerData.objects[6], PlayerManager.GetInstance.gameObject.transform);//BulletAmountCanvas

        //CreateSlaveObject();
    }

    public void DataStatesOnInitial(LevelData levelData, PlayerData _playerData, BulletData _bulletData, ref GameObject _healthBarObject,
                             ref GameObject _topCanvasHealthBarObject, ref GameObject bulletAmountCanvas,
                             ref float _initPlayerSpeed)
    {//PlayerData
        if (_playerData != null)
        {
            _playerData.currentMessageObject = GameObject.Find("MessageText");
            if (_playerData.currentMessageObject)
            {
                _playerData.currentMessageText = _playerData.currentMessageObject.GetComponent<TextMeshProUGUI>();
            }
            _playerData.isFireNonWalk = false;
            _playerData.isFireWalk = false;
            levelData.isLevelUp = false;

            _playerData.isClickable = true;
            _playerData.normalSpeed = true;
            _playerData.extraSpeed = true;

            _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;
            _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;
            for (int i = 0; i < levelData.isCompleteMaps.Length; i++)
            {
                levelData.isCompleteMaps[i] = false;
            }
            //PlayerData.slaveCounter = 0;
            _bulletData.isM4a4 = false;
            _playerData.bulletAmount = _playerData.bulletPack;
            bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = _playerData.bulletAmount.ToString();
            _playerData.objects[4].GetComponent<MeshRenderer>().enabled = true;
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
            _playerData.isSwordAnimate = false;
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
            _playerData.currentJumpForce = _playerData.dobbyJumpForce;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Michelle)
        {
            _playerData.currentJumpForce = _playerData.michelleJumpForce;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Glassy)
        {
            _playerData.currentJumpForce = _playerData.glassyJumpForce;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Aj)
        {
            _playerData.currentJumpForce = _playerData.ajJumpForce;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Mremireh)
        {
            _playerData.currentJumpForce = _playerData.mremirehJumpForce;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Lusth)
        {
            _playerData.currentJumpForce = _playerData.lusthJumpForce;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Joleen)
        {
            _playerData.currentJumpForce = _playerData.joleenJumpForce;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Boss)
        {
            _playerData.currentJumpForce = _playerData.bossJumpForce;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Ty)
        {
            _playerData.currentJumpForce = _playerData.tyJumpForce;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Guard)
        {
            _playerData.currentJumpForce = _playerData.guardJumpForce;
        }
        else
        {
            _playerData.currentJumpForce = _playerData.dobbyJumpForce;
        }
    }
    void CharacterSpeeds(PlayerData _playerData)
    {
        if (_playerData.currentCharacterName == PlayerData.CharacterNames.Dobby)
        {
            _playerData.playerSpeed = _playerData.dobbySpeed;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Michelle)
        {
            _playerData.playerSpeed = _playerData.michelleSpeed;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Glassy)
        {
            _playerData.playerSpeed = _playerData.glassySpeed;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Aj)
        {
            _playerData.playerSpeed = _playerData.ajSpeed;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Mremireh)
        {
            _playerData.playerSpeed = _playerData.mremirehSpeed;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Lusth)
        {
            _playerData.playerSpeed = _playerData.lusthSpeed;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Joleen)
        {
            _playerData.playerSpeed = _playerData.joleenSpeed;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Boss)
        {
            _playerData.playerSpeed = _playerData.bossSpeed;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Ty)
        {
            _playerData.playerSpeed = _playerData.tySpeed;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Guard)
        {
            _playerData.playerSpeed = _playerData.guardSpeed;
        }
        else if (_playerData.currentCharacterName == PlayerData.CharacterNames.Eve)
        {
            _playerData.playerSpeed = _playerData.eveSpeed;
        }
        else
        {
            _playerData.playerSpeed = 2f;
        }
    }

    #endregion

    #region //Update Functions
    public virtual void GetAttackFromEnemy(ref PlayerData _playerData, ref Slider _topCanvasHealthBarSlider, ref Slider healthBarSlider, ref GameObject _healthBarObject, ref Transform _particleTransform)
    {
        if (_playerData.isDecreaseHealth && _playerData.decreaseCounter == 0 && healthBarSlider.value > 0)
        {
            CheckEnemyAttackDamage(ref _playerData);

            DecreaseHealth(ref _playerData, _playerData.currentEnemyAttackDamage, ref _healthBarObject, ref healthBarSlider, ref _topCanvasHealthBarSlider, ref _playerData.damageHealthText);

            //Touch ParticleEffect
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Touch, _particleTransform.transform);

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GetEnemyHit);


            _playerData.isDecreaseHealth = false;

            _playerData.decreaseCounter++;
            StartCoroutine(DelayDecreaseCounterZero(_playerData));
        }
        else if (healthBarSlider.value <= 0)
        {
            _playerData.isPlayable = false;
            _playerData.isDying = true;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroy(7f));
        }
    }
    public virtual void CheckEnemyAttackDamage(ref PlayerData _playerData)
    {
        if (_playerData.currentEnemyName == PlayerData.clown)
        {
            _playerData.currentEnemyAttackDamage = _playerData.clownEnemyAttackDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.monster)
        {
            _playerData.currentEnemyAttackDamage = _playerData.monsterEnemyAttackDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.prisoner)
        {
            _playerData.currentEnemyAttackDamage = _playerData.prisonerEnemyAttackDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.pedroso)
        {
            _playerData.currentEnemyAttackDamage = _playerData.pedrosoEnemyAttackDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.morak)
        {
            _playerData.currentEnemyAttackDamage = _playerData.morakEnemyAttackDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.ortiz)
        {
            _playerData.currentEnemyAttackDamage = _playerData.ortizEnemyAttackDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.skeleton)
        {
            _playerData.currentEnemyAttackDamage = _playerData.skeletonEnemyAttackDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.uriel)
        {
            _playerData.currentEnemyAttackDamage = _playerData.urielEnemyAttackDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.goblin)
        {
            _playerData.currentEnemyAttackDamage = _playerData.goblinEnemyAttackDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.cop)
        {
            _playerData.currentEnemyAttackDamage = _playerData.copEnemyAttackDamage;
        }
    }
    IEnumerator DelayDecreaseCounterZero(PlayerData _playerData)
    {
        yield return new WaitForSeconds(1f);
        _playerData.decreaseCounter = 0;
    }
    #endregion

    #region //Shoot
    public virtual void Fire(PlayerData _playerData)
    {
        if (_playerData.isPlayable && PlayerManager.GetInstance._playerController.fire && !_playerData.isWinning)
        {
            //PlayerData
            if (_playerData.bulletAmount <= 0 && _playerData.bulletPackAmount <= 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);

                _playerData.isFireNonWalk = false;

                _playerData.isFireWalk = false;
            }
            else if (_playerData.bulletAmount <= 0 && _playerData.bulletPackAmount >= 0)
            {
                _playerData.bulletAmount = _playerData.bulletPack;

                _playerData.bulletPackAmount--;
            }
            else if(_playerData.bulletPackAmount >= 0)
            {
                if (_playerData.bulletAmount <= _playerData.bulletPack / 2f && !_playerData.isWalking && !_playerData.isSideWalking)
                {
                    _playerData.isFireNonWalk = true;
                }
                else if (_playerData.bulletAmount > _playerData.bulletPack / 2f && !_playerData.isWalking && !_playerData.isSideWalking)
                {
                    _playerData.isFireNonWalk = true;
                }
                else if (!_playerData.isWalking && _playerData.isSideWalking)
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
                    --_playerData.bulletAmount;
                    PlayerManager.GetInstance._playerController.fire = false;
                    BulletManager.isCreatedWeaponBullet = false;
                }
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
                _playerData.isSwordAnimate = true;

                StartCoroutine(DelayPlayableTrue(_playerData));
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
    IEnumerator DelayPlayableTrue(PlayerData _playerData)
    {
        yield return new WaitForSeconds(2f);
        _playerData.isSwordAnimate = false;
    }
    
    public virtual IEnumerator DelayShowingCrosshairAlpha(CanvasGroup crosshairImage, float delay)
    {
        crosshairImage.alpha = 1;

        yield return new WaitForSeconds(delay);

        crosshairImage.alpha = 0;
    }

    public virtual IEnumerator delayFireWalkDisactivity(PlayerData _playerData, float delay)
    {
        yield return new WaitForSeconds(delay);
        _playerData.isFireWalk = false;
    }

    #endregion

    #region //Camera


    public virtual void ChangeCamera(PlayerData playerData, ref PlayerManager playerManager)
    {
        if (playerManager.GetZValue() == 0 && playerManager.GetXValue() == 0
            && playerManager._playerController.lookRotation.x == 0
            && playerManager._playerController.lookRotation.y == 0)
        {
            ConvertToFarCamera(playerManager.cameraSpawner);
        }
        else if (playerManager.GetZValue() != 0 || playerManager.GetXValue() != 0 || playerData.isSkateBoarding
            && playerManager._playerController.lookRotation.x == 0 && playerManager._playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(playerManager.cameraSpawner);
        }
        else if (playerManager.GetZValue() == 0 && playerManager.GetXValue() != 0
            && playerManager._playerController.lookRotation.x == 0 && playerManager._playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(playerManager.cameraSpawner);
        }
        else if (playerManager.GetZValue() != 0 && playerManager.GetXValue() != 0
            && playerManager._playerController.lookRotation.x == 0 && playerManager._playerController.lookRotation.y == 0)
        {
            ConvertToCloseCamera(playerManager.cameraSpawner);
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


    public virtual void TriggerLadder(bool isTouch, bool isTouchExit, PlayerData _playerData, ref Rigidbody objectRigidbody)
    {
        objectRigidbody.isKinematic = isTouch;
        if (PlayerManager.GetInstance.GetZValue() > 0 && !isTouchExit)
        {
            //PlayerData
            _playerData.isClimbing = isTouch;
            _playerData.isBackClimbing = !isTouch;
        }
        else if (PlayerManager.GetInstance.GetZValue() < 0 && !isTouchExit)
        {
            //PlayerData
            _playerData.isBackClimbing = isTouch;
            _playerData.isClimbing = !isTouch;
        }
        else if (isTouchExit && PlayerManager.GetInstance.GetZValue() != 0)
        {
            //PlayerData
            _playerData.isBackClimbing = isTouch;
            _playerData.isClimbing = isTouch;

            if (PlayerManager.GetInstance.GetZValue() < 0)
            {
                _playerData.isBackWalking = !isTouch;
            }
            else if (PlayerManager.GetInstance.GetZValue() > 0)
            {
                _playerData.isWalking = !isTouch;
            }
        }
    }


    public virtual void TriggerBullet(Collider other, PlayerData _playerData, 
                                        ref GameObject _healthBarObject, 
                                        ref GameObject _topCanvasHealthBarObject, 
                                        ref Transform _particleTransform, 
                                        ref Slider healthBarSlider,
                                        ref Slider topCanvasHealthBarSlider)
    {

        if (_playerData.objects[3] != null)
        {
            if (healthBarSlider.value == 0 && !_playerData.isWinning)
            {
                //Particle Effect
                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Burn, _particleTransform.transform);

                //Sound Effect
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);


                _playerData.isDestroyed = true;

                //EnemyAnimation
                if (other.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()))
                {
                    other.gameObject.GetComponent<EnemyManager>().enemyData.isWalking = false;
                    other.gameObject.GetComponent<EnemyManager>().enemyData.enemySpeed = 0;
                }

                topCanvasHealthBarSlider.value = healthBarSlider.value;

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
            }
        }
    }

    public virtual void PickUpCoin(LevelData levelData, 
                                    SceneController.Tags value, Collider other, 
                                    PlayerData _playerData, 
                                    ref GameObject _coinObject, 
                                    ref GameObject _cheeseObject, 
                                    ref GameObject bulletAmountCanvas,
                                    ref TextMeshProUGUI bulletAmountText,
                                    ref TextMeshProUGUI bulletPackAmountText)
    {
        if (value == SceneController.Tags.Coin)
        {
            //Data
            _playerData.isPicking = true;
            

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
            //PickUpCoinSFX(_playerData);


            //Trigger
            Destroy(other.gameObject);

            //Score
            ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue);
        }
        else if (value == SceneController.Tags.RotateCoin)
        {
            //PlayerData

            _playerData.isPicking = true;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);


            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.DestroyRotateCoin, other.gameObject.transform);

            //Trigger CoinObject
            other.gameObject.SetActive(false);

            //SettingScore
            ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue);
        }
        else if (value == SceneController.Tags.CheeseCoin)
        {
            //PlayerData
            _playerData.isPicking = true;

            //_cheeseObject.SetActive(true);
            _cheeseObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(_cheeseObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpCoin);
            //PickUpCoinSFX(_playerData);

            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.DestroyRotateCoin, other.gameObject.transform);

            //Trigger CoinObject
            other.gameObject.SetActive(false);

            //SettingScore
            ScoreController.GetInstance.SetScore(2);
        }
        else if (value == SceneController.Tags.MushroomCoin)
        {
            //PlayerData
            _playerData.isPicking = true;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(_coinObject));

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Poison);

            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.DestroyMushroomCoin, other.gameObject.transform);

            //Trigger CoinObject
            other.gameObject.SetActive(false);
        }
        else if (value == SceneController.Tags.BulletCoin)
        {
            //PlayerData
            _playerData.isPicking = true;

            //_coinObject.SetActive(true);
            _coinObject.transform.localScale = Vector3.one;
            
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(_coinObject));

            //Trigger CoinObject
            if (_playerData.bulletPackAmount == 0 && _playerData.bulletAmount == 0)
            {
                other.gameObject.SetActive(false);

                _playerData.bulletAmount = _playerData.bulletPack;
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            }
            else if (_playerData.bulletPackAmount < 2)
            {
                _playerData.bulletPackAmount += 1;

                StartCoroutine(DelayMessageText(_playerData, PlayerData.pickBulletObjectMessage));

                ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.DestroyBulletCoin, other.gameObject.transform);

                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
                other.gameObject.SetActive(false);
                bulletAmountCanvas.transform.GetChild(0).gameObject.transform.localScale = Vector3.one;
                bulletAmountCanvas.transform.GetChild(1).gameObject.transform.localScale = Vector3.one;
            }
            else if (_playerData.bulletPackAmount == 2)
            {
                if (_playerData.bulletAmount != _playerData.bulletPack)
                {
                    other.gameObject.SetActive(false);

                    _playerData.bulletAmount = _playerData.bulletPack;
                    PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);

                }
                else
                {
                    PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin);
                }

                StartCoroutine(DelayMessageText(_playerData, PlayerData.pickBulletObjectMessage));

                //bulletAmountCanvas.transform.GetChild(0).gameObject.transform.localScale = Vector3.one;
                //bulletAmountCanvas.transform.GetChild(1).gameObject.transform.localScale = Vector3.one;

            }
            else
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin);
            }           

        }
        else if (value == SceneController.Tags.HealthCoin)
        {
            StartCoroutine(DelayMessageText(_playerData, PlayerData.pickHealthObjectMessage));

            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.IncreasingHealth);
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.DestroyHealthCoin, other.gameObject.transform);
        }
    }
    public void CheckAllWeaponsLocked(BulletData bulletData)
    {
        if (bulletData.ak47Lock == BulletData.locked && bulletData.m4a4Lock == BulletData.locked && 
            bulletData.axeLock == BulletData.locked && bulletData.bulldogLock == BulletData.locked &&
            bulletData.cowLock == BulletData.locked && bulletData.crystalLock == BulletData.locked &&
            bulletData.demonLock == BulletData.locked && bulletData.iceLock == BulletData.locked &&
            bulletData.negevLock == BulletData.locked && bulletData.pistolLock == BulletData.locked)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }
    }

    public virtual void CheckWeaponCollect(Collider other, BulletData _bulletData)
    {
        if (other.CompareTag(SceneController.Tags.m4a4.ToString()) && _bulletData.currentWeaponName != BulletData.m4a4)
        {
            Destroy(other.gameObject);
            _bulletData.isM4a4 = true;
            _bulletData.m4a4Lock = _bulletData.unLocked;
        }
        else if (other.CompareTag(SceneController.Tags.m4a4.ToString()) && _bulletData.currentWeaponName == BulletData.m4a4)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.ak47.ToString()) && _bulletData.currentWeaponName != BulletData.ak47)
        {
            Destroy(other.gameObject);
            _bulletData.isAk47 = true;
            _bulletData.ak47Lock = _bulletData.unLocked;

        }
        else if (other.CompareTag(SceneController.Tags.ak47.ToString()) && _bulletData.currentWeaponName == BulletData.ak47)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.axe.ToString()) && _bulletData.currentWeaponName != BulletData.axe)
        {
            Destroy(other.gameObject);
            _bulletData.isAxe = true;
            _bulletData.axeLock = _bulletData.unLocked;
        }
        else if (other.CompareTag(SceneController.Tags.axe.ToString()) && _bulletData.currentWeaponName == BulletData.axe)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.bulldog.ToString()) && _bulletData.currentWeaponName != BulletData.bulldog)
        {
            Destroy(other.gameObject);
            _bulletData.isBulldog = true;
            _bulletData.bulldogLock = _bulletData.unLocked;
        }
        else if (other.CompareTag(SceneController.Tags.bulldog.ToString()) && _bulletData.currentWeaponName == BulletData.bulldog)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.cow.ToString()) && _bulletData.currentWeaponName != BulletData.cow)
        {
            Destroy(other.gameObject);
            _bulletData.isCow = true;
            _bulletData.cowLock = _bulletData.unLocked;

        }
        else if (other.CompareTag(SceneController.Tags.cow.ToString()) && _bulletData.currentWeaponName == BulletData.cow)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.crystal.ToString()) && _bulletData.currentWeaponName != BulletData.crystal)
        {
            Destroy(other.gameObject);
            _bulletData.isCrystal = true;
            _bulletData.crystalLock = _bulletData.unLocked;

        }
        else if (other.CompareTag(SceneController.Tags.crystal.ToString()) && _bulletData.currentWeaponName == BulletData.crystal)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.demon.ToString()) && _bulletData.currentWeaponName != BulletData.demon)
        {
            Destroy(other.gameObject);
            _bulletData.isDemon = true;
            _bulletData.demonLock = _bulletData.unLocked;

        }
        else if (other.CompareTag(SceneController.Tags.demon.ToString()) && _bulletData.currentWeaponName != BulletData.demon)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.ice.ToString()) && _bulletData.currentWeaponName != BulletData.ice)
        {
            Destroy(other.gameObject);
            _bulletData.isIce = true;
            _bulletData.iceLock = _bulletData.unLocked;

        }
        else if (other.CompareTag(SceneController.Tags.ice.ToString()) && _bulletData.currentWeaponName == BulletData.ice)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.ice.ToString()) && _bulletData.currentWeaponName != BulletData.negev)
        {
            Destroy(other.gameObject);
            _bulletData.isNegev = true;
            _bulletData.negevLock = _bulletData.unLocked;

        }
        else if (other.CompareTag(SceneController.Tags.ice.ToString()) && _bulletData.currentWeaponName == BulletData.negev)
        {
            other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarmText(other));
        }

        if (other.CompareTag(SceneController.Tags.pistol.ToString()) && _bulletData.currentWeaponName != BulletData.pistol)
        {
            Destroy(other.gameObject);
            _bulletData.isPistol = true;
            _bulletData.pistolLock = _bulletData.unLocked;

        }
        else if (other.CompareTag(SceneController.Tags.pistol.ToString()) && _bulletData.currentWeaponName == BulletData.pistol)
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
            bulletAmountCanvas.transform.GetChild(1).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = Vector3.one;
            bulletAmountCanvas.transform.GetChild(1).transform.localScale = Vector3.one;
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

    public virtual void GettingPoisonDamage(PlayerData _playerData, ref Slider _topCanvasHealthBarSlider, ref Slider _healthBarSlider)
    {
        //SoundEffect
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
        _topCanvasHealthBarSlider.value = _healthBarSlider.value;

        //PlayerData
        _playerData.isDestroyed = true;
        _playerData.isDying = true;
        _playerData.isIdling = false;
        _playerData.isPlayable = false;
        _playerData.objects[3].transform.localScale = Vector3.zero;
    }
    public virtual IEnumerator DelayLevelUp(LevelData levelData, float delayWait)
    {
        yield return new WaitForSeconds(delayWait);

        levelData.isLevelUp = false;
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
        GameObject jolleenObject = Instantiate(_playerData.jolleenObject, _jolleenTransform.transform);
        jolleenObject.transform.position = _jolleenTransform.transform.position;
        Destroy(jolleenObject, _playerData.danceTime);
    }


    #endregion

    #region //Touch

    public virtual void TouchEnemy(Collision collision, 
                                    PlayerData _playerData, 
                                    ref Slider _healthBarSlider, 
                                    ref Slider _topCanvasHealthBarSlider, 
                                    ref Transform _particleTransform)
    {
        //SoundEffect
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
        //DeathSFX(_playerData);

        //EnemyAnimation--Collision
        if (collision.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()))
        {
            collision.gameObject.GetComponent<EnemyManager>().enemyData.isWalking = false;
        }

        _topCanvasHealthBarSlider.value = _healthBarSlider.value;

        //PlayerData
        _playerData.isDestroyed = true;
        _playerData.isDying = true;
        _playerData.isIdling = false;
        _playerData.isPlayable = false;
        _playerData.objects[3].transform.localScale = Vector3.zero;

    }

    public virtual void CheckEnemyCollisionDamage(Collision collision, ref PlayerData _playerData)
    {

        _playerData.currentEnemyName = collision.gameObject.name;

        if (_playerData.currentEnemyName == PlayerData.clown)
        {
            _playerData.currentEnemyCollisionDamage = _playerData.clownEnemyCollisionDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.monster)
        {
            _playerData.currentEnemyCollisionDamage = _playerData.monsterEnemyCollisionDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.prisoner)
        {
            _playerData.currentEnemyCollisionDamage = _playerData.prisonerEnemyCollisionDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.pedroso)
        {
            _playerData.currentEnemyCollisionDamage = _playerData.pedrosoEnemyCollisionDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.morak)
        {
            _playerData.currentEnemyCollisionDamage = _playerData.morakEnemyCollisionDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.ortiz)
        {
            _playerData.currentEnemyCollisionDamage = _playerData.ortizEnemyCollisionDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.skeleton)
        {
            _playerData.currentEnemyCollisionDamage = _playerData.skeletonEnemyCollisionDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.uriel)
        {
            _playerData.currentEnemyCollisionDamage = _playerData.urielEnemyCollisionDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.goblin)
        {
            _playerData.currentEnemyCollisionDamage = _playerData.goblinEnemyCollisionDamage;
        }
        else if (_playerData.currentEnemyName == PlayerData.cop)
        {
            _playerData.currentEnemyCollisionDamage = _playerData.copEnemyCollisionDamage;
        }
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
            ScoreController.GetInstance.SetScore(scoreDamageValue);
        }
        else if (ScoreController._scoreAmount < scoreDamageValue && ScoreController._scoreAmount > 0)
        {
            ScoreController.GetInstance.SetScore(ScoreController._scoreAmount);
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
    public virtual void IncreaseHealth(int damageHealthValue, ref GameObject _healthBarObject, ref Slider _healthBarSlider, ref Slider _topCanvasHealthBarSlider, Collider other)
    {
        if (_healthBarSlider.value < 75)
        {
            _healthBarSlider.value += damageHealthValue;

            _healthBarObject.transform.localScale = new Vector3(1f,
                                                                0.3f,
                                                                0.3f);
            _topCanvasHealthBarSlider.value = _healthBarSlider.value;

            StartCoroutine(DelayHealthSizeBack(_healthBarObject));

            Destroy(other.gameObject, 1f);
        }
    }
    public virtual void DecreaseHealth(ref PlayerData playerData, int damageHealthValue, ref GameObject _healthBarObject, ref Slider _healthBarSlider, ref Slider _topCanvasHealthBarSlider,
                                       ref TextMeshProUGUI damageHealthText)
    {
        _healthBarSlider.value -= CharacterDurability(damageHealthValue, ref playerData);
        _topCanvasHealthBarSlider.value -= _healthBarSlider.value;

        damageHealthText.enabled = true;

        damageHealthText.text = "-" + damageHealthValue.ToString();


        _healthBarObject.transform.localScale = new Vector3(1f, 0.3f, 0.3f);

        StartCoroutine(DelayHealthSizeBack(_healthBarObject));
        StartCoroutine(DelayDamageHealthTextEnableFalse(damageHealthText));
    }
    public virtual int CharacterDurability(int damageHealthValue, ref PlayerData playerData)
    {
        if (PlayerData.CharacterNames.Glassy == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.glassyDurability;
        }
        else if (PlayerData.CharacterNames.Dobby == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.dobbyDurability;
        }
        else if (PlayerData.CharacterNames.Joleen == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.joleenDurability;
        }
        else if (PlayerData.CharacterNames.Lusth == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.lusthDurability;
        }
        else if (PlayerData.CharacterNames.Guard == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.guardDurability;
        }
        else if (PlayerData.CharacterNames.Eve == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.eveDurability;
        }
        else if (PlayerData.CharacterNames.Michelle == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.michelleDurability;
        }
        else if (PlayerData.CharacterNames.Boss == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.bossDurability;
        }
        else if (PlayerData.CharacterNames.Aj == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.ajDurability;
        }
        else if (PlayerData.CharacterNames.Mremireh == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.mremirehDurability;
        }
        else if (PlayerData.CharacterNames.Ty == playerData.currentCharacterName)
        {
            damageHealthValue -= playerData.tyDurability;
        }
        return damageHealthValue;
    }

    public virtual IEnumerator DelayHealthSizeBack(GameObject _healthBarObject)
    {
        yield return new WaitForSeconds(0.5f);
        _healthBarObject.transform.localScale = new Vector3(1, 0.1f, 0.1f);
    }
    public virtual IEnumerator DelayDamageHealthTextEnableFalse(TextMeshProUGUI damageHealthText)
    {
        yield return new WaitForSeconds(0.5f);
        damageHealthText.enabled = false;
    }
    #endregion

    #region //Move
    public virtual void SkateBoard(PlayerData _playerData, Transform _particleTransform, ref Transform playerTransform)
    {//StyleWalking
        if (PlayerController.skateBoard && !_playerData.isJumping 
            && !_playerData.isClimbing && !_playerData.isBackClimbing 
            && !_playerData.isRunning && !_playerData.isBackWalking && _playerData.isTouchableSkate)
        {
            //PlayerData
            if (_playerData.clickTabCount < 1)
            {
                _playerData.clickTabCount++;
                _playerData.isSkateBoarding = true;

                _playerData.isTouchableSkate = false;

                StartCoroutine(DelaySkateBoardTouching(_playerData, 0.1f));

            }
            else
            {
                _playerData.isSkateBoarding = false;
                _playerData.skateboardParticle.Stop();

                _playerData.isTouchableSkate = false;

                StartCoroutine(DelaySkateBoardTouching(_playerData, 0.1f));
            }
        }
        if (_playerData.isSkateBoarding && !_playerData.isJumping && 
            !_playerData.isClimbing && !_playerData.isBackClimbing && 
            !_playerData.isRunning && !_playerData.isBackWalking)
        {
            //ParticleEffect
            ParticleController.GetInstance.CreateParticle(ParticleController.ParticleNames.Skateboard, _particleTransform.transform);

            //_skateboardParticle.Play();
            playerTransform.Translate(0f, 0f, _playerData.skateBoardSpeed * Time.deltaTime);            
        }
        
    }
    IEnumerator DelaySkateBoardTouching(PlayerData _playerData, float delay)
    {
        yield return new WaitForSeconds(delay);

        _playerData.isTouchableSkate = true;

    }
    public virtual void Run(PlayerData _playerData, Transform _particleTransform, float runTimeAmount, Rigidbody objectRigidbody)
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

            objectRigidbody.AddForce(transform.forward*_playerData.playerSpeed * Time.deltaTime * 1000f);
        }

    }

    public virtual void Walk(PlayerData _playerData, ref Transform playerTransform, ref Animator characterAnimator)
    {//ForwardAndBackWalking
        if (!_playerData.isLockedWalking)
        {
            if ((PlayerManager.GetInstance.GetZValue() >= 0.01 && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isSkateBoarding))
            {
                //PlayerData
                _playerData.isWalking = true;

                if (characterAnimator.GetLayerWeight(16) == 1)
                {//When fireWalk Animation is active, player speed will lower then original speed
                    playerTransform.Translate(0f, 0f, PlayerManager.GetInstance.GetZValue() * _playerData.fireWalkSpeed * Time.deltaTime);
                }
                else
                {
                    playerTransform.Translate(0f, 0f, PlayerManager.GetInstance.GetZValue() * _playerData.playerSpeed * Time.deltaTime);
                }
                _playerData.isBackWalking = false;
            }
            if (PlayerManager.GetInstance.GetZValue() < -0.01 && !_playerData.isClimbing && !_playerData.isBackClimbing)
            {
                //PlayerData
                playerTransform.Translate(0f, 0f, PlayerManager.GetInstance.GetZValue() * _playerData.backWalkingSpeed * Time.deltaTime);
                _playerData.isBackWalking = true;
                _playerData.isWalking = false;
                _playerData.isBackClimbing = false;
                _playerData.isClimbing = false;
                _playerData.isSideWalking = false;
            }
            if (PlayerManager.GetInstance.GetZValue() == 0)
            {
                //PlayerData
                _playerData.isBackWalking = false;
                _playerData.isWalking = false;
            }
        }
        else if(_playerData.isLockedWalking)
        {
            playerTransform.Translate(0f, 0f, _playerData.lockedSpeed * Time.deltaTime);
        }
        else
        {
            _playerData.isWalking = false;
        }

    }
    public virtual void SideWalk(PlayerData _playerData, ref Transform playerTransform)
    {//LeftAndRightWalking

        if (Mathf.Abs(PlayerManager.GetInstance.GetXValue()) <= Mathf.Abs(PlayerManager.GetInstance.GetZValue()) || (PlayerManager.GetInstance.GetZValue() > 0.1f &&
            PlayerManager.GetInstance.GetXValue() > 0.1f))
        {
            _playerData.isWalking = true;
            _playerData.isSideWalking = false;
        }
        if ((!_playerData.isClimbing && !_playerData.isBackClimbing) && 
            (PlayerManager.GetInstance.GetXValue() < -0.001f || PlayerManager.GetInstance.GetXValue() > 0.001f) &&
            Mathf.Abs(PlayerManager.GetInstance.GetXValue()) > 2 * Mathf.Abs(PlayerManager.GetInstance.GetZValue()) &&
            PlayerManager.GetInstance.GetZValue() < 0.2f)
        {
            _playerData.isSideWalking = true;

            playerTransform.Translate(PlayerManager.GetInstance.GetXValue() * _playerData.slideWalkSpeed * Time.deltaTime, 0f, 0f);
        }
        if (PlayerManager.GetInstance.GetXValue() == 0f)
        {
            _playerData.isSideWalking = false;
        }
    }
    public virtual void Climb(PlayerData _playerData, ref Transform playerTransform)
    {//WhenEnterToTheLadderGoToClimb
        if (PlayerManager.GetInstance.GetZValue() > 0 && _playerData.isClimbing && !_playerData.isBackClimbing)
        {
            playerTransform.Translate(0f, PlayerManager.GetInstance.GetZValue() * _playerData.climbSpeed, 0f);
        }
        else if (PlayerManager.GetInstance.GetZValue() < 0 && !_playerData.isClimbing && _playerData.isBackClimbing)
        {
            playerTransform.Translate(0f, PlayerManager.GetInstance.GetZValue(), 0f);
        }
    }

    public virtual void Jump(PlayerData _playerData, ref Rigidbody playerRigidbody)
    {
        if (PlayerManager.GetInstance._playerController.jump && _playerData.jumpCount == 0 && _playerData.isGround)
        {

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);            

            //PlayerData
            _playerData.isJumping = true;

            //AddForceForJump
            playerRigidbody.AddForce(transform.up * _playerData.currentJumpForce, ForceMode.Impulse);
            _playerData.jumpCount++;
        }
        else
        {
            //PlayerData
            _playerData.isJumping = false;
        }

    }

    public virtual void SpeedSettings(PlayerData _playerData, float _initPlayerSpeed)
    {
        if (!_playerData.isLockedWalking)
        {
            if ((PlayerManager.GetInstance.GetXValue() > 0 && PlayerManager.GetInstance.GetZValue() > 0) ||
                (PlayerManager.GetInstance.GetXValue() < 0 && PlayerManager.GetInstance.GetZValue() > 0) ||
                (PlayerManager.GetInstance.GetXValue() < 0 && PlayerManager.GetInstance.GetZValue() < 0) ||
                (PlayerManager.GetInstance.GetXValue() > 0 && PlayerManager.GetInstance.GetZValue() < 0) ||
                PlayerManager.GetInstance.GetZValue() < 0)
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
    public IEnumerator DelayMessageText(PlayerData _playerData, string messageValue)
    {
        _playerData.currentMessageText.text = messageValue;
        if (_playerData.currentMessageText.text != PlayerData.emptyMessage)
        {
            yield return new WaitForSeconds(0.5f);
            _playerData.currentMessageText.text = PlayerData.emptyMessage;
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

    public virtual void Rotate(ref float _touchX, ref float _touchY, ref Transform playerTransform)
    {
        //Rotating With Camera On X Axis
        playerTransform.Rotate(0f, _touchX, 0f);
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