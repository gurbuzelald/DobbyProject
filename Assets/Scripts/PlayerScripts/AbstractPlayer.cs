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
        else if (_bulletData.currentWeaponName == BulletData.electro)
        {
            _gunTransform = GameObject.Find("ElectroTransform");
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
            _playerData.isFireWalkAnimation = false;
            _playerData.isFire = false;
            levelData.isLevelUp = false;
            LevelData.levelCanBeSkipped = false;

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

            _playerData.bulletAmount = _bulletData.currentBulletPack;

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
            _playerData.isFireWalkAnimation = false;
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
            _playerData.playerSpeed = _playerData.dobbySpeed;
        }
    }

    #endregion

    #region //Update Functions
    
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

                _playerData.isFireWalkAnimation = false;

                _playerData.isFire = false;
            }
            else if (_playerData.bulletAmount <= 0 && _playerData.bulletPackAmount >= 0)
            {
                _playerData.bulletAmount = PlayerManager.GetInstance._bulletData.currentBulletPack;

                _playerData.bulletPackAmount--;
            }
            else if(_playerData.bulletPackAmount >= 0)
            {
                if (_playerData.isSideWalking && !_playerData.isWalking || _playerData.isBackWalking)
                {
                    _playerData.isFire = true;
                    _playerData.isFireAnimation = false;
                    _playerData.isFireWalkAnimation = false;
                }
                if (!_playerData.isWalking && !_playerData.isSideWalking && !_playerData.isBackWalking && !_playerData.isSwording)
                {
                    _playerData.isFire = true;
                    _playerData.isFireAnimation = true;
                    _playerData.isFireWalkAnimation = false;
                }
                if (_playerData.isWalking && !_playerData.isSideWalking && !_playerData.isBackWalking)
                {
                    _playerData.isFire = true;
                    _playerData.isFireAnimation = false;
                    _playerData.isFireWalkAnimation = true;
                }
                else if (_playerData.bulletAmount <= PlayerManager.GetInstance._bulletData.currentBulletPack / 2f &&
                    _playerData.bulletAmount > 0 && _playerData.isWalking)
                {
                    _playerData.isFire = true;
                }
                else if (_playerData.bulletAmount > PlayerManager.GetInstance._bulletData.currentBulletPack / 2f && _playerData.isWalking)
                {
                    _playerData.isFire = true;
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
            _playerData.isFire = false;
            _playerData.isFireAnimation = false;
            _playerData.isFireWalkAnimation = false;
        }
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
            _playerData.isFireWalkAnimation = false;
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
        _playerData.isFire = false;
    }

    #endregion

    #region //Camera


    public virtual void ChangeCamera(PlayerData playerData, ref PlayerManager playerManager)
    {
        // Cache values to reduce repeated calls and improve readability
        float zValue = playerManager.GetZValue();
        float xValue = playerManager.GetXValue();
        var lookRotation = playerManager._playerController.lookRotation;
        bool isLookingForward = (lookRotation.x == 0 && lookRotation.y == 0);
        bool isMoving = (zValue != 0 || xValue != 0);
        bool isSkateboarding = playerData.isSkateBoarding;

        // Check for far or close camera conversion based on player movement and look rotation
        if (zValue == 0 && xValue == 0 && isLookingForward)
        {
            ConvertToFarCamera(playerManager.cameraSpawner);
        }
        else if (isMoving || isSkateboarding && isLookingForward)
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
        // Cache frequently accessed values
        Vector3 eulerAngles = _currentCameraTransform.transform.eulerAngles;
        float cameraXAngle = eulerAngles.x;
        float cameraYAngle = eulerAngles.y;
        float cameraZAngle = eulerAngles.z;

        // Adjust player state and camera based on X angle
        if (cameraXAngle > 74 && cameraXAngle <= 80 || cameraXAngle > 355 || cameraXAngle < 0)
        {
            _playerData.isLookingUp = cameraXAngle < 0; // Set isLookingUp based on angle < 0

            // Reset the X rotation to 0
            _currentCameraTransform.transform.eulerAngles = new Vector3(0f, cameraYAngle, cameraZAngle);
        }
        else if (cameraXAngle > 270 && cameraXAngle <= 360)
        {
            _playerData.isLookingUp = true;
        }
        else
        {
            _playerData.isLookingUp = false;
        }
    }


    #endregion

    #region //Trigger

   public virtual void TriggerBullet(Collider other, PlayerData _playerData, 
                                  ref GameObject _healthBarObject, 
                                  ref GameObject _topCanvasHealthBarObject, 
                                  ref Transform _particleTransform, 
                                  ref Slider healthBarSlider,
                                  ref Slider topCanvasHealthBarSlider)
    {
        var playerObject = _playerData.objects[3];

        // Exit if no player object
        if (playerObject == null) return;

        // Cache health value
        float healthValue = healthBarSlider.value;        

        // Handle death scenario
        if (healthValue == 0 && !_playerData.isWinning)
        {
            GameObject particleObject = null;

            if (particleObject == null)
            {
                particleObject = PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(13);
                particleObject.transform.position = _particleTransform.transform.position;

                StartCoroutine(PlayerManager.GetInstance.DelaySetActiveFalseParticle(particleObject, 3f));
            }
            

            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);

        // Mark player as destroyed and handle enemy-related effects
        _playerData.isDestroyed = true;

        if (other.gameObject.CompareTag(SceneController.Tags.Enemy.ToString()))
        {
            var enemyManager = other.gameObject.GetComponent<EnemyManager>();
            enemyManager.enemyData.isWalking = false;
            enemyManager.enemyData.enemySpeed = 0;
        }

        // Sync top canvas health bar and set player states
        topCanvasHealthBarSlider.value = healthValue;
        _playerData.isDying = true;
        _playerData.isIdling = false;
        _playerData.isPlayable = false;

        // Hide the player object
        playerObject.transform.localScale = Vector3.zero;

        // Play death sound again
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);

        // Trigger delayed destruction
        StartCoroutine(PlayerManager.GetInstance.DelayDestroy(3f));
        return; // Early exit since the player is dead
    }

        // Handle non-death hit
        if (!_playerData.isWinning)
        {
            
            //Debug.Log("in");
            GameObject particleObject = null;
            GameObject particleObject1 = null;

            if (particleObject == null)
            {
                particleObject = PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(13);
                particleObject.transform.position = _particleTransform.transform.position;

                StartCoroutine(PlayerManager.GetInstance.DelaySetActiveFalseParticle(particleObject, 2f));                
            }

            if (particleObject == null)
            {
                particleObject1 = PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(14);
                particleObject1.transform.position = _particleTransform.transform.position;

                StartCoroutine(PlayerManager.GetInstance.DelaySetActiveFalseParticle(particleObject, 2f));
            }
            

            // Activate bullet hit on player
            _playerData.enemyBulletHitActivate = true;

        // You can uncomment if sound effect is needed
        // PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.GiveBulletHit);
    }
}

    public virtual void PickUpCoin(LevelData levelData,
                               SceneController.Tags value, Collider other,
                               PlayerData _playerData,
                               ref GameObject _coinObject,
                               ref GameObject _cheeseObject,
                               ref GameObject bulletAmountCanvas,
                               ref TextMeshProUGUI bulletAmountText,
                               ref TextMeshProUGUI bulletPackAmountText,
                               ref ObjectPool objectPool)
    {
        _playerData.isPicking = true; // Set player state once at the start

        

        // Switch-case for different tag types
        switch (value)
        {
            case SceneController.Tags.Coin:
                HandleCoinPickup(_coinObject, ParticleController.ParticleNames.DestroyRotateCoin, PlayerSoundEffect.SoundEffectTypes.PickUpCoin,
                    other, objectPool);
                ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue);
                break;

            case SceneController.Tags.RotateCoin:
                HandleCoinPickup(_coinObject, ParticleController.ParticleNames.DestroyRotateCoin, PlayerSoundEffect.SoundEffectTypes.PickUpCoin,
                    other, objectPool);
                ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue);
                break;

            case SceneController.Tags.CheeseCoin:
                _cheeseObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
                HandleCoinPickup(_cheeseObject, ParticleController.ParticleNames.DestroyRotateCoin, PlayerSoundEffect.SoundEffectTypes.PickUpCoin,
                    other, objectPool);
                ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue);
                break;

            case SceneController.Tags.MushroomCoin:
                HandleCoinPickup(_coinObject, ParticleController.ParticleNames.DestroyMushroomCoin, PlayerSoundEffect.SoundEffectTypes.Poison,
                    other, objectPool);
                StartCoroutine(DelayMessageText(_playerData, PlayerData.poisonMessageTr, PlayerData.poisonMessage));
                break;

            case SceneController.Tags.BulletCoin:
                HandleBulletCoinPickup(_coinObject, other, bulletAmountCanvas, _playerData, bulletAmountText, bulletPackAmountText, objectPool);
                break;

            case SceneController.Tags.HealthCoin:
                if (PlayerManager.GetInstance.playerObjects.healthBarSlider.value < 75)
                {
                    HandleCoinPickup(_coinObject, ParticleController.ParticleNames.DestroyHealthCoin,
                                     PlayerSoundEffect.SoundEffectTypes.IncreasingHealth, other, objectPool);
                    StartCoroutine(DelayMessageText(_playerData, PlayerData.pickHealthObjectMessageTr, PlayerData.pickHealthObjectMessage));
                }
                break;

            case SceneController.Tags.LevelUpKey:
                StartCoroutine(DelayMessageText(_playerData, PlayerData.pickedKeyMessageTr, PlayerData.pickedKeyMessage));
                LevelData.currentOwnedLevelUpKeys++;
                HandleCoinPickup(_coinObject, ParticleController.ParticleNames.DestroyBulletCoin,
                                 PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin, other, objectPool);
                break;
        }
    }

    void HandleBulletCoinPickup(GameObject _coinObject, Collider other, GameObject bulletAmountCanvas,
        PlayerData _playerData, TextMeshProUGUI bulletAmountText, TextMeshProUGUI bulletPackAmountText, ObjectPool objectPool)
    {
        _coinObject.transform.localScale = Vector3.one;

        if ((_playerData.bulletPackAmount == 2 && _playerData.bulletAmount != PlayerManager.GetInstance._bulletData.currentBulletPack) ||
            (_playerData.bulletPackAmount == 0 && _playerData.bulletAmount == 0) ||
             _playerData.bulletPackAmount < 2 ||
             (_playerData.bulletPackAmount == 2 && _playerData.bulletAmount != PlayerManager.GetInstance._bulletData.currentBulletPack))
        {
            GameObject particleObject = objectPool.GetComponent<ObjectPool>().GetPooledObject(4);
            particleObject.transform.position = other.gameObject.transform.position;

            StartCoroutine(DelaySetActiveFalseParticle(particleObject, 1f));
        }

        if (_playerData.bulletPackAmount == 0 && _playerData.bulletAmount == 0)
        {
            other.gameObject.SetActive(false);
            _playerData.bulletAmount = PlayerManager.GetInstance._bulletData.currentBulletPack;
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            StartCoroutine(DelayMessageText(_playerData, PlayerData.pickBulletObjectMessageTr, PlayerData.pickBulletObjectMessage));
        }
        else if (_playerData.bulletPackAmount < 2)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            _playerData.bulletPackAmount += 1;
            StartCoroutine(DelayMessageText(_playerData, PlayerData.pickBulletObjectMessageTr, PlayerData.pickBulletObjectMessage));
            other.gameObject.SetActive(false);
            bulletAmountCanvas.transform.GetChild(0).gameObject.transform.localScale = Vector3.one;
            bulletAmountCanvas.transform.GetChild(1).gameObject.transform.localScale = Vector3.one;
        }
        else if (_playerData.bulletPackAmount == 2 && _playerData.bulletAmount != PlayerManager.GetInstance._bulletData.currentBulletPack)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            other.gameObject.SetActive(false);
            _playerData.bulletAmount = PlayerManager.GetInstance._bulletData.currentBulletPack;
            StartCoroutine(DelayMessageText(_playerData, PlayerData.pickBulletObjectMessageTr, PlayerData.pickBulletObjectMessage));
        }
        else
        {
            StartCoroutine(DelayMessageText(_playerData, PlayerData.alreadyHaveThisMessageTr, PlayerData.alreadyHaveThisMessage));
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin);
        }
    }

    // Helper method to handle particle, sound, and coin destruction
    void HandleCoinPickup(GameObject coinObj, ParticleController.ParticleNames particle,
        PlayerSoundEffect.SoundEffectTypes sound, Collider other, ObjectPool objectPool)
    {
        if (coinObj != null)
        {
            coinObj.transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(coinObj));
        }

        GameObject particleObject = null;
        GameObject particleObject1 = null;
        GameObject particleObject2 = null;

        if (ParticleController.ParticleNames.DestroyRotateCoin == particle)
        {
            particleObject = objectPool.GetComponent<ObjectPool>().GetPooledObject(3);
            particleObject.transform.position = other.gameObject.transform.position;
            StartCoroutine(DelaySetActiveFalseParticle(particleObject, 1f));
        }
        else if (ParticleController.ParticleNames.DestroyHealthCoin == particle)
        {
            particleObject1 = objectPool.GetComponent<ObjectPool>().GetPooledObject(6);
            particleObject1.transform.position = other.gameObject.transform.position;
            StartCoroutine(DelaySetActiveFalseParticle(particleObject1, 1f));
        }
        else if (ParticleController.ParticleNames.DestroyMushroomCoin == particle)
        {
            particleObject2 = objectPool.GetComponent<ObjectPool>().GetPooledObject(7);
            particleObject2.transform.position = other.gameObject.transform.position;
            StartCoroutine(DelaySetActiveFalseParticle(particleObject2, 1f));
        }

        
        PlayerSoundEffect.GetInstance.SoundEffectStatement(sound);
        Destroy(other.gameObject);
    }
    public IEnumerator DelaySetActiveFalseParticle(GameObject particleObject, float delayValue)
    {
        yield return new WaitForSeconds(delayValue);
        particleObject.SetActive(false);
    }
    public void CheckAllWeaponsLocked(BulletData bulletData)
    {
        if (bulletData.ak47Lock == BulletData.locked && bulletData.m4a4Lock == BulletData.locked && 
            bulletData.axeLock == BulletData.locked && bulletData.bulldogLock == BulletData.locked &&
            bulletData.cowLock == BulletData.locked && bulletData.crystalLock == BulletData.locked &&
            bulletData.demonLock == BulletData.locked && bulletData.iceLock == BulletData.locked &&
            bulletData.electroLock == BulletData.locked && bulletData.pistolLock == BulletData.locked)
        {
            bulletData.currentWeaponName = BulletData.pistol;
        }
    }

    public virtual void CheckWeaponCollect(Collider other, BulletData _bulletData)
    {
        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.m4a4,
            BulletData.m4a4,
            ref _bulletData.isM4a4,
            ref _bulletData.m4a4Lock,
            _bulletData.m4A4BulletAmount);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.ak47,
            BulletData.ak47,
            ref _bulletData.isAk47,
            ref _bulletData.ak47Lock,
            _bulletData.ak47BulletAmount);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.axe,
            BulletData.axe,
            ref _bulletData.isAxe,
            ref _bulletData.axeLock,
            _bulletData.axeBulletAmount);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.bulldog,
            BulletData.bulldog,
            ref _bulletData.isBulldog,
            ref _bulletData.bulldogLock,
            _bulletData.bulldogBulletAmount);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.cow,
            BulletData.cow,
            ref _bulletData.isCow,
            ref _bulletData.cowLock,
            _bulletData.cowBulletAmount);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.crystal,
            BulletData.crystal,
            ref _bulletData.isCrystal,
            ref _bulletData.crystalLock,
            _bulletData.crystalBulletAmount);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.demon,
            BulletData.demon,
            ref _bulletData.isDemon,
            ref _bulletData.demonLock,
            _bulletData.demonBulletAmount);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.ice,
            BulletData.ice,
            ref _bulletData.isIce,
            ref _bulletData.iceLock,
            _bulletData.iceBulletAmount);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.electro,
            BulletData.electro,
            ref _bulletData.isElectro,
            ref _bulletData.electroLock,
            _bulletData.electroBulletAmount);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.pistol,
            BulletData.pistol,
            ref _bulletData.isPistol,
            ref _bulletData.pistolLock,
            _bulletData.pistolBulletAmount);
    }

    // Helper method for handling weapon collection
    private void HandleWeaponCollect(Collider other, BulletData _bulletData, SceneController.Tags tag,
        string weaponName, ref bool weaponStatus, ref string weaponLock, int bulletAmount)
    {
        string tagString = tag.ToString();

        if (other.CompareTag(tagString))
        {
            if (_bulletData.currentWeaponName != weaponName)
            {
                Destroy(other.gameObject);
                weaponStatus = true;
                ObjectPool.creatablePlayerBullet = true;
                weaponLock = _bulletData.unLocked;
                PlayerData.currentBulletExplosionIsChanged = true;
                _bulletData.currentBulletPack = bulletAmount;
                PlayerManager.GetInstance._playerData.bulletAmount = bulletAmount;

                StartCoroutine(DelayMessageText(PlayerManager.GetInstance._playerData, tagString, tagString));
            }
            else if (_bulletData.currentWeaponName == weaponName)
            {
                other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
                StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarnText(other));
            }
        }
    }
    public virtual void DamageArrowDirection(ref GameObject _damageArrow)
    {
        if (_damageArrow != null && _damageArrow.transform.localScale == Vector3.one)
        {
            StartCoroutine(PlayerManager.GetInstance.DelayDamageArrowDirection(_damageArrow));
        }
    }

    public virtual void SetBulletPackAndAmountTextSize(PlayerData _playerData, ref GameObject bulletAmountCanvas)
    {
        if (_playerData.bulletAmount <= PlayerManager.GetInstance._bulletData.currentBulletPack / 2f * 3)
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
            bulletAmountCanvas.transform.GetChild(1).transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
        }
        else if (_playerData.bulletAmount <= PlayerManager.GetInstance._bulletData.currentBulletPack / 2f)
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            bulletAmountCanvas.transform.GetChild(1).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (_playerData.bulletAmount <= PlayerManager.GetInstance._bulletData.currentBulletPack / 3f)
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
            bulletAmountCanvas.transform.GetChild(1).transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }
        else
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = Vector3.one;
            bulletAmountCanvas.transform.GetChild(1).transform.localScale = Vector3.one;
        }
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
        LevelData.levelCanBeSkipped = false;
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

    public virtual IEnumerator DelayTransformOneGiftBoxWarnText(Collider other)
    {
        other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
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

        collision.gameObject.transform.GetComponent<EnemyManager>().enemyData.currentEnemyName = collision.gameObject.name;


        switch (collision.gameObject.transform.GetComponent<EnemyManager>().enemyData.currentEnemyName)
        {
            case PlayerData.clown:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                    collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.clownEnemyCollisionDamage;
                break;
            case PlayerData.monster:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                    collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.monsterEnemyCollisionDamage;
                break;
            case PlayerData.prisoner:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                    collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.prisonerEnemyCollisionDamage;
                break;
            case PlayerData.pedroso:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                    collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.pedrosoEnemyCollisionDamage;
                break;
            case PlayerData.cop:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                   collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.copEnemyCollisionDamage;
                break;
            case PlayerData.ortiz:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                    collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.ortizEnemyCollisionDamage;
                break;
            case PlayerData.skeleton:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                    collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.skeletonEnemyCollisionDamage;
                break;
            case PlayerData.uriel:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                    collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.urielEnemyCollisionDamage;
                break;
            case PlayerData.goblin:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                    collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.goblinEnemyCollisionDamage;
                break;
            case PlayerData.laygo:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                    collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.laygoEnemyCollisionDamage;
                break;
            default:
                collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.currentEnemyCollisionDamage =
                    collision.gameObject.transform.GetComponent<EnemyManager>().bulletData.clownEnemyCollisionDamage;
                break;
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
            ScoreController.GetInstance._scoreText.text = ScoreController._scoreAmount.ToString();
        }
        else if (ScoreController._scoreAmount < scoreDamageValue && ScoreController._scoreAmount > 0)
        {
            ScoreController.GetInstance.SetScore(-ScoreController._scoreAmount);
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
    public virtual void IncreaseHealth(int damageHealthValue, ref GameObject _healthBarObject,
        ref Slider _healthBarSlider, ref Slider _topCanvasHealthBarSlider,
        Collider other = null)
    {
        if (_healthBarSlider.value < 75)
        {
            _healthBarSlider.value += damageHealthValue;

            _healthBarObject.transform.localScale = new Vector3(1f,
                                                                0.3f,
                                                                0.3f);
            _topCanvasHealthBarSlider.value = _healthBarSlider.value;

            StartCoroutine(DelayHealthSizeBack(_healthBarObject));

            if (other != null)
            {
                Destroy(other.gameObject, 1f);
            }
        }
    }
    public virtual void DecreaseHealth(ref PlayerData playerData, int damageHealthValue, ref GameObject _healthBarObject, ref Slider _healthBarSlider, ref Slider _topCanvasHealthBarSlider,
                                       ref TextMeshProUGUI damageHealthText)
    {
        _healthBarSlider.value -= (-CharacterDurability(ref playerData)) + damageHealthValue;
        _topCanvasHealthBarSlider.value = _healthBarSlider.value;

        damageHealthText.enabled = true;

        damageHealthText.text = "-" + (damageHealthValue - CharacterDurability(ref playerData)).ToString();


        _healthBarObject.transform.localScale = new Vector3(1f, 0.3f, 0.3f);

        StartCoroutine(DelayHealthSizeBack(_healthBarObject));
        StartCoroutine(DelayDamageHealthTextEnableFalse(damageHealthText));
    }
    public virtual int CharacterDurability(ref PlayerData playerData)
    {
        if (PlayerData.CharacterNames.Glassy == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.glassyDurability;
        }
        else if (PlayerData.CharacterNames.Dobby == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.dobbyDurability;
        }
        else if (PlayerData.CharacterNames.Joleen == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.joleenDurability;
        }
        else if (PlayerData.CharacterNames.Lusth == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.lusthDurability;
        }
        else if (PlayerData.CharacterNames.Guard == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.guardDurability;
        }
        else if (PlayerData.CharacterNames.Eve == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.eveDurability;
        }
        else if (PlayerData.CharacterNames.Michelle == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.michelleDurability;
        }
        else if (PlayerData.CharacterNames.Boss == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.bossDurability;
        }
        else if (PlayerData.CharacterNames.Aj == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.ajDurability;
        }
        else if (PlayerData.CharacterNames.Mremireh == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.mremirehDurability;
        }
        else if (PlayerData.CharacterNames.Ty == playerData.currentCharacterName)
        {
            PlayerData.currentCharacterDurability = playerData.tyDurability;
        }
        return PlayerData.currentCharacterDurability;
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
        if (_playerData.isRunning && !_playerData.isJumping && !_playerData.isClimbing && !_playerData.isBackClimbing && !_playerData.isBackWalking)
        {
            objectRigidbody.AddForce(transform.forward*_playerData.playerSpeed * Time.deltaTime * 1000f);
        }

    }

    public virtual void Walk(PlayerData _playerData, ref Transform playerTransform, ref Animator characterAnimator)
    {//ForwardAndBackWalking
        if (!_playerData.isLockedWalking)
        {
            if ((PlayerManager.GetInstance.GetZValue() >= 0.01 && !_playerData.isClimbing && !_playerData.isBackClimbing))
            {
                //PlayerData
                _playerData.isWalking = true;

                if (characterAnimator.GetLayerWeight(16) == 1)
                {//When fireWalk Animation is active, player speed will lower then original speed
                    playerTransform.Translate(0f, 0f, PlayerManager.GetInstance.GetZValue() * _playerData.playerSpeed * Time.deltaTime);
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
                playerTransform.Translate(0f, 0f, PlayerManager.GetInstance.GetZValue() * (_playerData.playerSpeed * 2 / 3)* Time.deltaTime);
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
            playerTransform.Translate(0f, 0f, _playerData.playerSpeed / 2 * Time.deltaTime);
        }
        else
        {
            _playerData.isWalking = false;
        }

    }
    public virtual void SideWalk(PlayerData _playerData, ref Transform playerTransform)
    {//LeftAndRightWalking

        if (Mathf.Abs(PlayerManager.GetInstance.GetXValue()) < Mathf.Abs(PlayerManager.GetInstance.GetZValue()) || (PlayerManager.GetInstance.GetZValue() > 0.1f &&
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

            playerTransform.Translate(PlayerManager.GetInstance.GetXValue() * (_playerData.playerSpeed / 3 )* Time.deltaTime, 0f, 0f);
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

            JumpDirectionZ(_playerData, ref playerRigidbody);
            JumpDirectionX(_playerData, ref playerRigidbody);
            _playerData.jumpCount++;
        }
        else
        {
            //PlayerData
            _playerData.isJumping = false;
        }

    }

    void JumpDirectionZ(PlayerData _playerData, ref Rigidbody playerRigidbody)
    {
        if (PlayerManager.GetInstance.GetZValue() <= 0.01)
        {
            playerRigidbody.AddForce(transform.forward * -1 * _playerData.currentJumpForce / 3, ForceMode.Impulse);
        }
        else
        {
            playerRigidbody.AddForce(transform.forward * _playerData.currentJumpForce / 3, ForceMode.Impulse);
        }

    }
    void JumpDirectionX(PlayerData _playerData, ref Rigidbody playerRigidbody)
    {
        if (PlayerManager.GetInstance.GetXValue() <= 0.01 && _playerData.isSideWalking)
        {
            playerRigidbody.AddForce(transform.right * -1 * _playerData.currentJumpForce / 3, ForceMode.Impulse);

        }
        else if (PlayerManager.GetInstance.GetXValue() >= 0.01 && _playerData.isSideWalking)
        {
            playerRigidbody.AddForce(transform.right * _playerData.currentJumpForce / 3, ForceMode.Impulse);
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
                    _playerData.playerSpeed = _initPlayerSpeed;
                }
                if (_playerData.normalSpeed)
                {
                    _playerData.playerSpeed = _initPlayerSpeed;
                }
            }
            else if (_playerData.isRunning)
            {
                //PlayerData
                //_playerData.playerSpeed = _initPlayerSpeed * 1.3f;
            }
            else
            {
                //PlayerData
                _playerData.skateboardParticle.Stop();
                _playerData.playerSpeed = _initPlayerSpeed;
            }
        }
    }
    public IEnumerator DelayMessageText(PlayerData _playerData, string turkishMessage, string englishMessage)
    {
        string message = _playerData.currentLanguage == PlayerData.Languages.Turkish ? turkishMessage : englishMessage;
        _playerData.currentMessageText.text = message;
        if (_playerData.currentMessageText.text != PlayerData.emptyMessage)
        {
            yield return new WaitForSeconds(2f);
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


    public virtual void SensivityXSettings(float touchXValue, PlayerController _playerController, PlayerData _playerData, ref float _touchX)
    {//ControllerSmoothForXAxis
        if ((_playerController.lookRotation.x >= -0.2f && _playerController.lookRotation.x < 0f) || (_playerController.lookRotation.x <= 0.2f && _playerController.lookRotation.x > 0f))
        {
            _touchX = (_playerController.lookRotation.x * 2f) / 8f * _playerData.sensivityX * touchXValue;
        }
        else if ((_playerController.lookRotation.x >= -0.4f && _playerController.lookRotation.x < -0.2f) || (_playerController.lookRotation.x <= 0.4f && _playerController.lookRotation.x > 0.2f))
        {
            _touchX = (_playerController.lookRotation.x * 2f) / 7f * _playerData.sensivityX * touchXValue;
        }
        else if ((_playerController.lookRotation.x >= -0.6f && _playerController.lookRotation.x < -0.4f) || (_playerController.lookRotation.x <= 0.6f && _playerController.lookRotation.x > 0.4f))
        {
            _touchX = (_playerController.lookRotation.x * 2f) / 6f * _playerData.sensivityX * touchXValue;
        }
        else if ((_playerController.lookRotation.x >= -0.8f && _playerController.lookRotation.x < -0.6f) || (_playerController.lookRotation.x <= 0.8f && _playerController.lookRotation.x > 0.6f))
        {
            _touchX = (_playerController.lookRotation.x * 2f) / 5f * _playerData.sensivityX * touchXValue;
        }
        else
        {
            _touchX = (_playerController.lookRotation.x * 2f) / 4f * _playerData.sensivityX * touchXValue;
        }
    }
    #endregion


}