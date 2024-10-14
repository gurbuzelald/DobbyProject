using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System;


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
            /*if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                GameObject objectOfGame = new GameObject();
                objectOfGame.name = typeof(T).Name;
                _instance = objectOfGame.AddComponent<T>();
            }*/
            return _instance;
        }
    }
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;
            //DontDestroyOnLoad(gameObject);
        }
    }

    #region //Initial
    public void GetHandObjectsTransform(ref GameObject _coinObject, ref GameObject _cheeseObject)
    {
        //GameObjects
        if (GameObject.Find("Coin"))
        {
            _coinObject = GameObject.Find("Coin");
            _coinObject.transform.localScale = Vector3.zero;
        }
        if (GameObject.Find("Cheese"))
        {
            _cheeseObject = GameObject.Find("Cheese");
            _cheeseObject.transform.localScale = Vector3.zero;
        }
    }
    public virtual void GetWeaponTransform(BulletData _bulletData, ref GameObject _gunTransform)//Getting finger transform parameter
    {
        if (_bulletData.currentWeaponName == BulletData.shotGun && GameObject.Find("ShotGunTransform"))
        {
            _gunTransform = GameObject.Find("ShotGunTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.machine && GameObject.Find("MachineTransform"))
        {
            _gunTransform = GameObject.Find("MachineTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.bulldog && GameObject.Find("BulldogTransform"))
        {
            _gunTransform = GameObject.Find("BulldogTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.cow && GameObject.Find("CowTransform"))
        {
            _gunTransform = GameObject.Find("CowTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.crystal && GameObject.Find("CrystalTransform"))
        {
            _gunTransform = GameObject.Find("CrystalTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.demon && GameObject.Find("DemonTransform"))
        {
            _gunTransform = GameObject.Find("DemonTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.ice && GameObject.Find("IceTransform"))
        {
            _gunTransform = GameObject.Find("IceTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.electro && GameObject.Find("ElectroTransform"))
        {
            _gunTransform = GameObject.Find("ElectroTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.axe && GameObject.Find("AxeTransform"))
        {
            _gunTransform = GameObject.Find("AxeTransform");
        }
        else if (_bulletData.currentWeaponName == BulletData.pistol && GameObject.Find("PistolTransform"))
        {
            _gunTransform = GameObject.Find("PistolTransform");
        }
    }
    public virtual void GetSwordTransform(BulletData _bulletData, ref GameObject _swordTransform)
    {
        if (_bulletData.currentSwordName == BulletData.lowSword && GameObject.Find("LowSwordTransform"))
        {
            _swordTransform = GameObject.Find("LowSwordTransform");
        }
    }
    public void CreateCharacterObject(PlayerData _playerData, ref GameObject characterObject)
    {
        if (_playerData.characterObject)
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
    }


    public virtual void CreateStartPlayerStaff(PlayerData _playerData, ref Transform playerIconTransform, ref Transform _bulletsTransform,
                                               ref Transform _cameraWasherTransform, Transform healthBarTransform,
                                               ref GameObject _healthBarObject, ref GameObject bulletAmountCanvas)
    { //Create Player Objects On Start
        if (_playerData)
        {
            if (_playerData.objects[1] && _bulletsTransform)
            {
                Instantiate(_playerData.objects[1],
                   _bulletsTransform.transform.position,
                    Quaternion.identity,
                    _bulletsTransform.transform);//BulletsPrefab
            }
            else
            {
                Debug.Log("There is no BulletsPrefab");
            }
            if (_playerData.objects[2] && _cameraWasherTransform)
            {
                Instantiate(_playerData.objects[2],
                        _cameraWasherTransform.transform.position,
                        Quaternion.identity,
                        _cameraWasherTransform.transform);//CameraWasherPrefab
            }
            else
            {
                Debug.Log("There is no CameraWasherPrefab");
            }

            if (_playerData.objects[3] && healthBarTransform && PlayerManager.GetInstance.gameObject)
            {
                _healthBarObject = Instantiate(_playerData.objects[3],
                            healthBarTransform.transform.position,
                            Quaternion.identity,
                            PlayerManager.GetInstance.gameObject.transform);//HealthBarPrefab
            }
            else
            {
                Debug.Log("There is no HealthBarPrefab");
            }
            if (_playerData.objects[4] && playerIconTransform && PlayerManager.GetInstance.gameObject)
            {
                Instantiate(_playerData.objects[4],
                        playerIconTransform.transform.position,
                        Quaternion.identity,
                        playerIconTransform.transform);//PlayerIconPrefab
                playerIconTransform.rotation = PlayerManager.GetInstance.gameObject.transform.rotation;
            }
            else
            {
                Debug.Log("There is no PlayerIconPrefab");
            }
            if (_playerData.objects[5] && PlayerManager.GetInstance.gameObject)
            {
                Instantiate(_playerData.objects[5], PlayerManager.GetInstance.gameObject.transform);//PlayerSFXPrefab
            }
            else
            {
                Debug.Log("There is no PlayerSFXPrefab");
            }

            if (_playerData.objects[6] && PlayerManager.GetInstance.gameObject)
            {
                bulletAmountCanvas = Instantiate(_playerData.objects[6], PlayerManager.GetInstance.gameObject.transform);//BulletAmountCanvas
            }
            else
            {
                Debug.Log("There is no BulletAmountCanvas");
            }
        }
    }

    public void DataStatesOnInitial(LevelData levelData, PlayerData _playerData, BulletData _bulletData, ref GameObject _healthBarObject,
                             ref GameObject _topCanvasHealthBarObject, ref GameObject bulletAmountCanvas)
    {//PlayerData
        if (_playerData && _bulletData && levelData)
        {
            if (GameObject.Find("MessageText"))
            {
                _playerData.currentMessageObject = GameObject.Find("MessageText");
            }
            
            if (_playerData.currentMessageObject)
            {
                _playerData.currentMessageText = _playerData.currentMessageObject.GetComponent<TextMeshProUGUI>();
            }

            if (_healthBarObject)
            {
                if (_healthBarObject.transform.childCount >= 1)
                {
                    if (_healthBarObject.transform.GetChild(0).childCount >= 1)
                    {
                        if (_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>())
                        {
                            _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value = 100;

                            _topCanvasHealthBarObject = GameObject.Find("HealthSlider");
                            if (_topCanvasHealthBarObject)
                            {
                                if (_topCanvasHealthBarObject.GetComponent<Slider>())
                                {
                                    _topCanvasHealthBarObject.GetComponent<Slider>().value = _healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>().value;
                                }
                                else
                                {
                                    Debug.Log("_topCanvasHealthBarObject.GetComponent<Slider>()");
                                }
                            }
                            else
                            {
                                Debug.Log("_topCanvasHealthBarObject");
                            }
                        }
                        else
                        {
                            Debug.Log("_healthBarObject.transform.GetChild(0).GetChild(0).GetComponent<Slider>()");
                        }
                    }
                    else
                    {
                        Debug.Log("_healthBarObject.transform.GetChild(0).childCount");
                    }
                }
                else
                {
                    Debug.Log("_healthBarObject.transform.childCount");
                }
            }
            else
            {
                Debug.Log("_healthBarObject");
            }

            if (levelData.isCompleteMaps.Length >= 1)
            {
                for (int i = 0; i < levelData.isCompleteMaps.Length; i++)
                {
                    levelData.isCompleteMaps[i] = false;
                }
            }
            

            if (bulletAmountCanvas)
            {
                if (bulletAmountCanvas.transform.childCount >= 1)
                {
                    if (bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>())
                    {
                        bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = _playerData.bulletAmount.ToString();
                    }
                    else
                    {
                        Debug.Log("bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>()");
                    }
                }
                else
                {
                    Debug.Log("bulletAmountCanvas.transform.childCount >= 1");
                }
            }
            else
            {
                Debug.Log("bulletAmountCanvas");
            }

            if (_playerData.objects[4])
            {
                _playerData.objects[4].GetComponent<MeshRenderer>().enabled = true;
            }
            else
            {
                Debug.Log("_playerData.objects[4]");
            }

            if (_playerData.objects[3])
            {
                _playerData.objects[3].transform.localScale = new Vector3(1f, 0.1f, 0.1f);
            }
            else
            {
                Debug.Log("_playerData.objects[3]");
            }

            _playerData.bulletAmount = _bulletData.currentBulletPack;
            _playerData.isFireWalkAnimation = false;
            _playerData.isFire = false;
            levelData.isLevelUp = false;
            LevelData.levelCanBeSkipped = false;
            _playerData.clickShiftCount = 0;
            _playerData.isDestroyed = false;
            _playerData.jumpCount = 0;
            _playerData.isLose = false;
            _playerData.isTouchFinish = false;
            _playerData.isPicking = false;
            _playerData.isPickRotateCoin = false;
            _playerData.isLookingUp = false;
            _playerData.isWinning = false;
            _playerData.isRunning = false;
            _playerData.isPlayable = true;
            CharacterSpeeds(_playerData);
            CharacterJumpForce(_playerData);
            _playerData.isDying = false;
            _playerData.isFireWalkAnimation = false;
            _playerData.isWalking = false;
            _playerData.isBackWalking = false;
            _playerData.isGround = true;
            _playerData.isSwordAnimate = false;
        }
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


    #region //Shoot
    public virtual void Fire(PlayerData _playerData)
    {
        if (_playerData.isPlayable && PlayerManager.GetInstance.playerComponents._playerController.fire && !_playerData.isWinning)
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
                if (!_playerData.isWalking && !_playerData.isSideWalking && !_playerData.isBackWalking && !_playerData.isSwordAnimate)
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
                if (_playerData.bulletAmount <= PlayerManager.GetInstance._bulletData.currentBulletPack / 2f &&
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
                    PlayerManager.GetInstance.playerComponents._playerController.fire = false;
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
        if (_playerData)
        {
            if (_playerData.isPlayable)
            {
                if (PlayerManager.GetInstance.playerComponents._playerController)
                {
                    if (PlayerManager.GetInstance.playerComponents._playerController.sword && !_playerData.isSwordAnimate)
                    {
                        //PlayerData
                        _playerData.isSwordAnimate = true;
                        _playerData.isSword = true;
                    }
                    else
                    {
                        _playerData.isSword = false;
                    }
                }
            }
        }
    }
    
    public virtual IEnumerator DelayShowingCrosshairAlpha(CanvasGroup crosshairImage, float delay)
    {
        if (crosshairImage)
        {
            crosshairImage.alpha = 1;

            yield return new WaitForSeconds(delay);

            crosshairImage.alpha = 0;
        }
    }

    public virtual IEnumerator delayFireWalkDisactivity(PlayerData _playerData, float delay)
    {
        if (_playerData)
        {
            yield return new WaitForSeconds(delay);
            _playerData.isFire = false;
        }
    }

    #endregion

    #region //Camera


    public virtual void ChangeCamera()
    {
        if (PlayerManager.GetInstance.playerComponents._playerController)
        {
            var playerController = PlayerManager.GetInstance.playerComponents._playerController;
            var cameraSpawner = PlayerManager.GetInstance.cameraSpawner;

            if (playerController && cameraSpawner)
            {
                if (PlayerManager.GetInstance.gameObject)
                {
                    if (PlayerManager.GetInstance.GetZValue() == 0 && PlayerManager.GetInstance.GetXValue() == 0)
                    {
                        ConvertToFarCamera(cameraSpawner);
                    }
                    else
                    {
                        ConvertToCloseCamera(cameraSpawner);
                    }
                }
            }
        }
    }

    public virtual void ConvertToCloseCamera(GameObject cameraSpawner)
    {
        SwitchCamera(cameraSpawner, 0, 1);
    }

    public virtual void ConvertToFarCamera(GameObject cameraSpawner)
    {
        SwitchCamera(cameraSpawner, 1, 0);
    }

    private void SwitchCamera(GameObject cameraSpawner, int activateIndex, int deactivateIndex)
    {
        var activateCamera = cameraSpawner.transform.GetChild(activateIndex).gameObject;
        var deactivateCamera = cameraSpawner.transform.GetChild(deactivateIndex).gameObject;

        activateCamera.transform.SetPositionAndRotation(deactivateCamera.transform.position, deactivateCamera.transform.rotation);

        deactivateCamera.SetActive(false);
        activateCamera.SetActive(true);

        var currentCamera = activateCamera.GetComponent<CinemachineVirtualCamera>();
        PlayerManager.GetInstance._currentCamera = currentCamera;

        currentCamera.m_Follow = transform;
        currentCamera.m_LookAt = transform;
    }

    public virtual void CheckCameraEulerX(PlayerData _playerData, Transform _currentCameraTransform)
    {
        if (_currentCameraTransform)
        {
            Vector3 eulerAngles = _currentCameraTransform.eulerAngles;
            float cameraXAngle = eulerAngles.x;

            if ((cameraXAngle > 74 && cameraXAngle <= 80) || (cameraXAngle > 355 || cameraXAngle < 0))
            {
                _playerData.isLookingUp = cameraXAngle < 0;
                _currentCameraTransform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
            }
            else
            {
                _playerData.isLookingUp = cameraXAngle > 270 && cameraXAngle <= 360;
            }
        }
    }


    #endregion

    #region //Trigger

    public virtual void TriggerBullet(Collider other, PlayerData _playerData, 
                                  ref GameObject _healthBarObject, 
                                  ref GameObject _topCanvasHealthBarObject, 
                                  ref Transform _particleTransform, 
                                  ref Slider healthBarSlider,
                                  ref Slider topCanvasHealthBarSlider,
                                  ref TextMeshProUGUI damageHealthText)
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
                particleObject =
                    PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(_playerData.playerBurningTouchParticleObjectPoolCount);
                particleObject.transform.position = _particleTransform.transform.position;

                StartCoroutine(PlayerManager.GetInstance.DelaySetActiveFalseParticle(particleObject, 2f));
            }
            

            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);

            // Mark player as destroyed and handle enemy-related effects
            _playerData.isDestroyed = true;

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
            StartCoroutine(PlayerManager.GetInstance.DelayPlayerDestroy(3f));
            return; // Early exit since the player is dead
        }

        // Handle non-death hit
        if (!_playerData.isWinning && healthValue != 0)
        {
            
            //Debug.Log("in");
            GameObject particleObject = null;
            GameObject particleObject1 = null;

            if (particleObject == null)
            {
                particleObject =
                    PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(_playerData.playerBurningTouchParticleObjectPoolCount);
                particleObject.transform.position = _particleTransform.transform.position;

                StartCoroutine(PlayerManager.GetInstance.DelaySetActiveFalseParticle(particleObject, 2f));                
            }

            if (particleObject1 == null)
            {
                particleObject1 =
                    PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(_playerData.playerTouchParticleObjectPoolCount);
                particleObject1.transform.position = _particleTransform.transform.position;

                StartCoroutine(PlayerManager.GetInstance.DelaySetActiveFalseParticle(particleObject, .2f));
            }
            //Debug.Log(other.gameObject.name);

            //other.gameObject.transform.parent.GetComponent<EnemyManager>().CheckEnemyBulletDamage(ref other.gameObject.transform.parent.GetComponent<EnemyManager>().bulletData);

            DecreaseHealth(ref _playerData, PlayerManager.GetInstance._bulletData.currentEnemyBulletDamage,
                            ref _healthBarObject, ref healthBarSlider, ref topCanvasHealthBarSlider, ref damageHealthText);
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
                if (PlayerManager.GetInstance.playerComponents.healthBarSlider.value < 75)
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
            GameObject particleObject = objectPool.GetComponent<ObjectPool>().GetPooledObject(_playerData.destroyBulletCoinParticleObjectPoolCount);
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
            particleObject = objectPool.GetComponent<ObjectPool>().GetPooledObject(PlayerManager.GetInstance._playerData.destroyCoinParticleObjectPoolCount);
            particleObject.transform.position = other.gameObject.transform.position;
            StartCoroutine(DelaySetActiveFalseParticle(particleObject, 1f));
        }
        else if (ParticleController.ParticleNames.DestroyHealthCoin == particle)
        {
            particleObject1 = objectPool.GetComponent<ObjectPool>().GetPooledObject(PlayerManager.GetInstance._playerData.destroyHealthCoinObjectPoolCount);
            particleObject1.transform.position = other.gameObject.transform.position;
            StartCoroutine(DelaySetActiveFalseParticle(particleObject1, 1f));
        }
        else if (ParticleController.ParticleNames.DestroyMushroomCoin == particle)
        {
            particleObject2 = objectPool.GetComponent<ObjectPool>().GetPooledObject(PlayerManager.GetInstance._playerData.destroyMushroomCoinObjectPoolCount);
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
        if (bulletData)
        {
            if (bulletData.shotGunLock == BulletData.locked && bulletData.machineLock == BulletData.locked &&
            bulletData.axeLock == BulletData.locked && bulletData.bulldogLock == BulletData.locked &&
            bulletData.cowLock == BulletData.locked && bulletData.crystalLock == BulletData.locked &&
            bulletData.demonLock == BulletData.locked && bulletData.iceLock == BulletData.locked &&
            bulletData.electroLock == BulletData.locked && bulletData.pistolLock == BulletData.locked)
            {
                bulletData.currentWeaponName = BulletData.pistol;
            }
        }        
    }

    public virtual void CheckWeaponCollect(Collider other, BulletData _bulletData)
    {
        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.machine,
            BulletData.machine,
            ref _bulletData.isMachine,
            ref _bulletData.machineLock,
            _bulletData.machineBulletAmount,
            9);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.shotGun,
            BulletData.shotGun,
            ref _bulletData.isShotGun,
            ref _bulletData.shotGunLock,
            _bulletData.shotGunBulletAmount,
            8);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.axe,
            BulletData.axe,
            ref _bulletData.isAxe,
            ref _bulletData.axeLock,
            _bulletData.axeBulletAmount,
            1);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.bulldog,
            BulletData.bulldog,
            ref _bulletData.isBulldog,
            ref _bulletData.bulldogLock,
            _bulletData.bulldogBulletAmount,
            2);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.cow,
            BulletData.cow,
            ref _bulletData.isCow,
            ref _bulletData.cowLock,
            _bulletData.cowBulletAmount,
            3);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.crystal,
            BulletData.crystal,
            ref _bulletData.isCrystal,
            ref _bulletData.crystalLock,
            _bulletData.crystalBulletAmount,
            4);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.demon,
            BulletData.demon,
            ref _bulletData.isDemon,
            ref _bulletData.demonLock,
            _bulletData.demonBulletAmount,
            5);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.ice,
            BulletData.ice,
            ref _bulletData.isIce,
            ref _bulletData.iceLock,
            _bulletData.iceBulletAmount,
            6);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.electro,
            BulletData.electro,
            ref _bulletData.isElectro,
            ref _bulletData.electroLock,
            _bulletData.electroBulletAmount,
            7);

        HandleWeaponCollect(other, _bulletData,
            SceneController.Tags.pistol,
            BulletData.pistol,
            ref _bulletData.isPistol,
            ref _bulletData.pistolLock,
            _bulletData.pistolBulletAmount,
            0);
    }

    // Helper method for handling weapon collection
    private void HandleWeaponCollect(Collider other, BulletData _bulletData, SceneController.Tags tag,
        string weaponName, ref bool weaponStatus, ref string weaponLock, int bulletAmount, int _currentWeaponID)
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
                BulletData.currentWeaponID = _currentWeaponID;
                IncreaseUsageLimit(_bulletData, tag);

                StartCoroutine(DelayMessageText(PlayerManager.GetInstance._playerData, tagString, tagString));
            }
            else if (_bulletData.currentWeaponName == weaponName)
            {
                other.gameObject.transform.GetChild(0).GetChild(0).transform.localScale = Vector3.one;
                StartCoroutine(PlayerManager.GetInstance.DelayTransformOneGiftBoxWarnText(other));
            }
        }
    }

    void IncreaseUsageLimit(BulletData _bulletData, SceneController.Tags tag)
    {
        Dictionary<SceneController.Tags, (Action unlock, Action<int> setUsageLimit, string usageCountKey)> bulletMap = new Dictionary<SceneController.Tags, (Action, Action<int>, string)>
    {
        { SceneController.Tags.shotGun,    (() => _bulletData.shotGunLock =
        _bulletData.unLocked, value => _bulletData.shotGunUsageLimit = value, "ShotGunUsageCount") },

        { SceneController.Tags.machine,    (() => _bulletData.machineLock =
        _bulletData.unLocked, value => _bulletData.machineUsageLimit = value, "MachineUsageCount") },

        { SceneController.Tags.cow,     (() => _bulletData.cowLock =
        _bulletData.unLocked, value => _bulletData.cowUsageLimit = value, "CowUsageCount") },

        { SceneController.Tags.axe,     (() => _bulletData.axeLock =
        _bulletData.unLocked, value => _bulletData.axeUsageLimit = value, "AxeUsageCount") },

        { SceneController.Tags.crystal, (() => _bulletData.crystalLock =
        _bulletData.unLocked, value => _bulletData.crystalUsageLimit = value, "CrystalUsageCount") },

        { SceneController.Tags.demon,   (() => _bulletData.demonLock =
        _bulletData.unLocked, value => _bulletData.demonUsageLimit = value, "DemonUsageCount") },

        { SceneController.Tags.pistol,  (() => _bulletData.pistolLock =
        _bulletData.unLocked, value => _bulletData.pistolUsageLimit = value, "PistolUsageCount") },

        { SceneController.Tags.ice,     (() => _bulletData.iceLock =
        _bulletData.unLocked, value => _bulletData.iceUsageLimit = value, "IceUsageCount") },

        { SceneController.Tags.electro, (() => _bulletData.electroLock =
        _bulletData.unLocked, value => _bulletData.electroUsageLimit = value, "ElectroUsageCount") },

        { SceneController.Tags.bulldog, (() => _bulletData.bulldogLock =
        _bulletData.unLocked, value => _bulletData.bulldogUsageLimit = value, "BulldogUsageCount") }
    };

        if (bulletMap.ContainsKey(tag))
        {
            var actions = bulletMap[tag];
            actions.unlock();
            actions.setUsageLimit(1);
            PlayerPrefs.SetInt(actions.usageCountKey, 1);
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
            //collision.gameObject.GetComponent<EnemyManager>().enemyData.isWalking = false;
        }
        

        _topCanvasHealthBarSlider.value = _healthBarSlider.value;

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
    public virtual void DecreaseHealth(ref PlayerData playerData, int damageHealthValue, ref GameObject _healthBarObject, ref Slider _healthBarSlider,
        ref Slider _topCanvasHealthBarSlider, ref TextMeshProUGUI damageHealthText)
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
        if (PlayerController.run && !_playerData.isJumping && !_playerData.isBackWalking)
        {
            _playerData.isRunning = true;
            _playerData.clickShiftCount++;
            StartCoroutine(DelayFalseRunning(_playerData, runTimeAmount));
        }

        if (_playerData.clickShiftCount > 1)
        {
            _playerData.isRunning = false;
        }
        if (_playerData.isRunning && !_playerData.isJumping && !_playerData.isBackWalking)
        {
            if (PlayerManager.GetInstance.GetZValue() > 0f)
            {
                objectRigidbody.AddForce(transform.forward * Time.deltaTime * 15000);
            }
            if (PlayerManager.GetInstance.GetZValue() < 0f)
            {
                objectRigidbody.AddForce(-transform.forward * Time.deltaTime * 15000);
            }
            if (PlayerManager.GetInstance.GetXValue() > 0f)
            {
                objectRigidbody.AddForce(transform.right * Time.deltaTime * 15000);
            }
            if (PlayerManager.GetInstance.GetXValue() < 0f)
            {
                objectRigidbody.AddForce(-transform.right * Time.deltaTime * 15000);
            }
            if(PlayerManager.GetInstance.GetZValue() == 0f && PlayerManager.GetInstance.GetXValue() == 0f)
            {
                objectRigidbody.AddForce(transform.forward * Time.deltaTime * 15000);
            }            
        }

    }

    public virtual void Walk(PlayerData _playerData, ref Transform playerTransform, ref Animator characterAnimator)
    {
        float zValue = PlayerManager.GetInstance.GetZValue();
        float xValue = PlayerManager.GetInstance.GetXValue();

        if (Mathf.Abs(xValue)*2 >= zValue)
        {
            _playerData.isSideWalking = true;
            _playerData.isWalking = false;            
        }
        else
        {
            _playerData.isWalking = true;
            _playerData.isSideWalking = false;
        }
        if (Mathf.Abs(xValue) > 0 && Mathf.Abs(zValue) < .4f)
        {
            playerTransform.Translate((_playerData.playerSpeed / 3) * Time.deltaTime * Mathf.Sign(xValue), 0f, 0f);
        }
        if (zValue > 0 && Mathf.Abs(xValue) < .4f)
        {
            playerTransform.Translate(0f, 0f, _playerData.playerSpeed * zValue * Time.deltaTime);
        }
        if (Mathf.Abs(zValue) > .4f && Mathf.Abs(xValue) > .4f)
        {
            playerTransform.Translate(0f, 0f, _playerData.playerSpeed * zValue * Time.deltaTime);
            playerTransform.Translate((_playerData.playerSpeed / 3) * Time.deltaTime * Mathf.Sign(xValue), 0f, 0f);
        }


        // Geri Yürüme Durumu
        if (zValue < 0f)
        {
            playerTransform.Translate(0f, 0f, (-_playerData.playerSpeed * 2 / 3) * Time.deltaTime);
            _playerData.isBackWalking = true;
            _playerData.isWalking = false;
            _playerData.isSideWalking = false;
        }
        else
        {
            _playerData.isBackWalking = false;
        }
        // Durma Durumu
        if (zValue == 0f && xValue == 0f)
        {
            _playerData.isBackWalking = false;
            _playerData.isWalking = false;
            _playerData.isSideWalking = false;
        }
    }

    public virtual void Jump(PlayerData _playerData, ref Rigidbody playerRigidbody)
    {
        if (PlayerManager.GetInstance.playerComponents._playerController)
        {
            if (PlayerManager.GetInstance.playerComponents._playerController.jump && _playerData.jumpCount == 0 && _playerData.isGround)
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
    }

    void JumpDirectionZ(PlayerData _playerData, ref Rigidbody playerRigidbody)
    {
        if (PlayerManager.GetInstance.GetZValue() < 0)
        {
            playerRigidbody.AddForce(transform.forward * -1 * _playerData.currentJumpForce / 3, ForceMode.Impulse);
        }
        else if (PlayerManager.GetInstance.GetZValue() > 0)
        {
            playerRigidbody.AddForce(transform.forward * _playerData.currentJumpForce / 3, ForceMode.Impulse);
        }

    }
    void JumpDirectionX(PlayerData _playerData, ref Rigidbody playerRigidbody)
    {
        if (PlayerManager.GetInstance.GetXValue() < 0 && _playerData.isSideWalking)
        {
            playerRigidbody.AddForce(transform.right * -1 * _playerData.currentJumpForce / 3, ForceMode.Impulse);

        }
        else if (PlayerManager.GetInstance.GetXValue() > 0 && _playerData.isSideWalking)
        {
            playerRigidbody.AddForce(transform.right * _playerData.currentJumpForce / 3, ForceMode.Impulse);
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
        if (Input.GetAxis("Mouse X")> 0)
        {
            _touchX = _playerData.rotateSpeed * Time.deltaTime;
        }
        else if(Input.GetAxis("Mouse X") < 0)
        {
            _touchX = -_playerData.rotateSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            _touchY = _playerData.rotateSpeed * Time.deltaTime * 5f;
        }
        else if (Input.GetAxis("Mouse Y") < 0)
        {
            _touchY = -_playerData.rotateSpeed * Time.deltaTime * 5f;
        }
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