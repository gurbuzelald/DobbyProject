using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.Cinemachine;
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
    public virtual void GetWeaponTransform(BulletData _bulletData, ref GameObject _gunTransform)
    {
        for (int i = 0; i < _bulletData.weaponStruct.Length; i++)
        {
            var weaponName = _bulletData.weaponStruct[i].weaponName;
            if (_bulletData.currentWeaponName == weaponName)
            {
                var weaponTransform = GameObject.Find($"{weaponName}Transform");
                if (weaponTransform)
                {
                    _gunTransform = weaponTransform;
                    return; // Exit early once the matching transform is found
                }
            }
        }
    }

    public virtual void GetSwordTransform(BulletData _bulletData, ref GameObject _swordTransform)
    {
        if (_bulletData.currentSwordName == BulletData.lowSword && GameObject.Find("lowSwordTransform"))
        {
            _swordTransform = GameObject.Find("lowSwordTransform");
        }
    }
    public void CreateCharacterObject(PlayerData _playerData, ref GameObject characterObject)
    {
        if (_playerData.characterObject)
        {
            characterObject = Instantiate(_playerData.characterObject, transform);

            GameObject current = null;

            // Find the character matching the currentCharacterID
            foreach (var character in _playerData.characterStruct)
            {
                if (character.id == PlayerData.currentCharacterID)
                {
                    current = character.characterObject;
                    break;
                }
            }

            // Fallback to the first character if no match is found
            if (current == null && _playerData.characterStruct.Length > 0)
            {
                current = _playerData.characterStruct[0].characterObject;
            }

            if (current != null)
            {
                Instantiate(current, characterObject.transform);
            }
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

            if (levelData.levelStates.Length >= 1)
            {
                for (int i = 0; i < levelData.levelStates.Length; i++)
                {
                    levelData.levelStates[i].isCompleteMap = false;
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

            _playerData.bulletAmount = _bulletData.currentBulletPackAmount;
            _playerData.isFireWalkAnimation = false;
            PlayerData.isFire = false;
            LevelData.isLevelUp = false;
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
            PlayerData.isRunning = false;
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
        int characterIndex = PlayerData.currentCharacterID;

        if (characterIndex >= 0 && characterIndex < _playerData.characterStruct.Length)
        {
            PlayerData.currentJumpForce = _playerData.characterStruct[characterIndex].jumpForce;  // Assuming jumpForce is the correct property.
        }
        else
        {
            PlayerData.currentJumpForce = _playerData.characterStruct[0].jumpForce;  // Default to first character's jump force.
        }
    }

    void CharacterSpeeds(PlayerData _playerData)
    {
        int characterIndex = PlayerData.currentCharacterID;

        if (characterIndex >= 0 && characterIndex < _playerData.characterStruct.Length)
        {
            PlayerData.currentCharacterSpeed = _playerData.characterStruct[characterIndex].speed; 
        }
        else
        {
            PlayerData.currentCharacterSpeed = _playerData.characterStruct[0].speed;
        }
    }

    public virtual int CharacterDurability(ref PlayerData _playerData)
    {
        int characterIndex = PlayerData.currentCharacterID;

        if (characterIndex >= 0 && characterIndex < _playerData.characterStruct.Length)
        {
            PlayerData.currentCharacterDurability = _playerData.characterStruct[characterIndex].durability;
        }
        else
        {
            PlayerData.currentCharacterDurability = _playerData.characterStruct[0].durability;
        }
        return PlayerData.currentCharacterDurability;
    }

    #endregion


    #region //Shoot
    public virtual void Fire(PlayerData _playerData)
    {
        if (_playerData.isPlayable && PlayerManager.GetInstance.playerComponents._playerController.fire &&
            !_playerData.isWinning && !_playerData.isDying)
        {
            //PlayerData
            if (_playerData.bulletAmount <= 0 && _playerData.bulletPackAmount <= 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);

                _playerData.isFireWalkAnimation = false;

                PlayerData.isFire = false;
            }
            else if (_playerData.bulletAmount <= 0 && _playerData.bulletPackAmount >= 0)
            {
                _playerData.bulletAmount = PlayerManager.GetInstance._bulletData.currentBulletPackAmount;

                _playerData.bulletPackAmount--;

                PlayerData.isFire = true;
            }
            else if(_playerData.bulletPackAmount >= 0)
            {
                if (_playerData.isSideWalking && !_playerData.isWalking || _playerData.isBackWalking)
                {
                    PlayerData.isFire = true;
                    _playerData.isFireAnimation = false;
                    _playerData.isFireWalkAnimation = false;
                }
                if (!_playerData.isWalking && !_playerData.isSideWalking && !_playerData.isBackWalking && !_playerData.isSwordAnimate)
                {
                    PlayerData.isFire = true;
                    _playerData.isFireAnimation = true;
                    _playerData.isFireWalkAnimation = false;
                }
                if (_playerData.isWalking && !_playerData.isSideWalking && !_playerData.isBackWalking)
                {
                    PlayerData.isFire = true;
                    _playerData.isFireAnimation = false;
                    _playerData.isFireWalkAnimation = true;
                }
                if (_playerData.bulletAmount <= PlayerManager.GetInstance._bulletData.currentBulletPackAmount / 2f &&
                    _playerData.bulletAmount > 0 && _playerData.isWalking)
                {
                    PlayerData.isFire = true;
                }
                else if (_playerData.bulletAmount > PlayerManager.GetInstance._bulletData.currentBulletPackAmount / 2f && _playerData.isWalking)
                {
                    PlayerData.isFire = true;
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
            PlayerData.isFire = false;
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

    public virtual void SetFireFalse()
    {
        PlayerData.isFire = false;
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
                    /*if (PlayerManager.GetInstance.GetZValue() == 0 && PlayerManager.GetInstance.GetXValue() == 0)
                    {
                        ConvertToFarCamera(cameraSpawner);
                    }
                    else
                    {
                        ConvertToCloseCamera(cameraSpawner);
                    }*/
                    ConvertToCloseCamera(cameraSpawner);
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
        //var deactivateCamera = cameraSpawner.transform.GetChild(deactivateIndex).gameObject;

        activateCamera.transform.SetPositionAndRotation(activateCamera.transform.position, activateCamera.transform.rotation);

        //deactivateCamera.SetActive(false);
        activateCamera.SetActive(true);

        var currentCamera = activateCamera.GetComponent<CinemachineCamera>();

        if (currentCamera)
        {
            PlayerManager.GetInstance._currentCamera = currentCamera;

            currentCamera.Follow = transform;
            currentCamera.LookAt = transform;
        }        
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


    public virtual void HandleDeathScenario(PlayerData _playerData,
                                  ref GameObject _healthBarObject,
                                  ref GameObject _topCanvasHealthBarObject,
                                  ref Transform _particleTransform,
                                  ref Slider healthBarSlider,
                                  ref Slider topCanvasHealthBarSlider,
                                  ref TextMeshProUGUI damageHealthText)
    {
        // Handle death scenario
        if (healthBarSlider.value == 0 && !_playerData.isWinning && _playerData.isGround)
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
            topCanvasHealthBarSlider.value = healthBarSlider.value;
            _playerData.isDying = true;
            _playerData.isIdling = false;
            _playerData.isPlayable = false;

            // Hide the player object
            _playerData.objects[3].transform.localScale = Vector3.zero;

            // Trigger delayed destruction
            PlayerManager.GetInstance.DelayPlayerDestroy();

            healthBarSlider.value += 1;

            return; // Early exit since the player is dead
        }
    }

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

        // Handle non-death hit
        if (!_playerData.isWinning && healthValue > 0)
        {
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

            if (other.gameObject.transform.parent.name == "bossEnemyTransform")
            {
                DecreaseHealth(ref _playerData, PlayerManager.GetInstance._enemyBulletData.currentEnemyBulletDamage*2,
                            ref _healthBarObject, ref healthBarSlider, ref topCanvasHealthBarSlider, ref damageHealthText);
            }
            else
            {
                DecreaseHealth(ref _playerData, PlayerManager.GetInstance._enemyBulletData.currentEnemyBulletDamage,
                            ref _healthBarObject, ref healthBarSlider, ref topCanvasHealthBarSlider, ref damageHealthText);
            }
        }
    }

    public virtual void PickUpCoin(LevelData levelData,
                               string tag, Collider other,
                               PlayerData _playerData,
                               ref GameObject _coinObject,
                               ref GameObject _cheeseObject,
                               ref GameObject bulletAmountCanvas,
                               ref TextMeshProUGUI bulletAmountText,
                               ref TextMeshProUGUI bulletPackAmountText,
                               ref EnvironmentObjectPool environmentObjectPool)
    {
        _playerData.isPicking = true; // Set player state once at the start



        // If-else for different tag types
        if (tag == SceneController.Tags.Coin.ToString())
        {
            HandleCoinPickup(_coinObject, ParticleController.ParticleNames.DestroyCoin, PlayerSoundEffect.SoundEffectTypes.PickUpCoin,
                             other, environmentObjectPool);
            ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue);
        }
        else if (tag == SceneController.Tags.RotateCoin.ToString())
        {
            HandleCoinPickup(_coinObject, ParticleController.ParticleNames.DestroyRotateCoin, PlayerSoundEffect.SoundEffectTypes.PickUpCoin,
                             other, environmentObjectPool);
            ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue);
        }
        else if (tag == SceneController.Tags.CheeseCoin.ToString())
        {
            _cheeseObject.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
            HandleCoinPickup(_cheeseObject, ParticleController.ParticleNames.DestroyRotateCoin, PlayerSoundEffect.SoundEffectTypes.PickUpCoin,
                             other, environmentObjectPool);
            ScoreController.GetInstance.SetScore(levelData.currentStaticCoinValue);
        }
        else if (tag == SceneController.Tags.MushroomCoin.ToString())
        {
            HandleCoinPickup(_coinObject, ParticleController.ParticleNames.DestroyMushroomCoin, PlayerSoundEffect.SoundEffectTypes.Poison,
                             other, environmentObjectPool);
            StartCoroutine(DelayMessageText(_playerData, PlayerData.poisonMessageTr, PlayerData.poisonMessage));
        }
        else if (tag == SceneController.Tags.BulletCoin.ToString())
        {
            HandleBulletCoinPickup(_coinObject, other, bulletAmountCanvas, _playerData, bulletAmountText, bulletPackAmountText, environmentObjectPool);
        }
        else if (tag == SceneController.Tags.HealthCoin.ToString())
        {
            if (PlayerManager.GetInstance.playerComponents.healthBarSlider.value < 75)
            {
                HandleCoinPickup(_coinObject, ParticleController.ParticleNames.DestroyHealthCoin,
                                 PlayerSoundEffect.SoundEffectTypes.IncreasingHealth, other, environmentObjectPool);
                StartCoroutine(DelayMessageText(_playerData, PlayerData.pickHealthObjectMessageTr, PlayerData.pickHealthObjectMessage));
            }
        }
        else if (tag == SceneController.Tags.LevelUpKey.ToString())
        {
            StartCoroutine(DelayMessageText(_playerData, PlayerData.pickedKeyMessageTr, PlayerData.pickedKeyMessage));
            LevelData.currentOwnedLevelUpKeys++;

            HandleCoinPickup(_coinObject, ParticleController.ParticleNames.DestroyKeyCoin,
                             PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin, other, environmentObjectPool);
        }
        if (other.gameObject.transform.parent.parent.name == "GiftBoxTransform")
        {
            HandleBulletCoinPickup(_coinObject, other, bulletAmountCanvas, _playerData, bulletAmountText, bulletPackAmountText, environmentObjectPool);
        }

    }

    void HandleBulletCoinPickup(GameObject _coinObject, Collider other, GameObject bulletAmountCanvas,
        PlayerData _playerData, TextMeshProUGUI bulletAmountText, TextMeshProUGUI bulletPackAmountText, EnvironmentObjectPool environmentObjectPool)
    {
        _coinObject.transform.localScale = Vector3.one;

        if ((_playerData.bulletPackAmount == 2 && _playerData.bulletAmount != PlayerManager.GetInstance._bulletData.currentBulletPackAmount) ||
            (_playerData.bulletPackAmount == 0 && _playerData.bulletAmount == 0) ||
             _playerData.bulletPackAmount < 2 ||
             (_playerData.bulletPackAmount == 2 && _playerData.bulletAmount != PlayerManager.GetInstance._bulletData.currentBulletPackAmount))
        {
            CreateBulletParticleEffect(environmentObjectPool, other, _playerData);            
        }

        if (_playerData.bulletPackAmount == 0 && _playerData.bulletAmount == 0)
        {
            CreateBulletParticleEffect(environmentObjectPool, other, _playerData);

            other.gameObject.SetActive(false);
            _playerData.bulletAmount = PlayerManager.GetInstance._bulletData.currentBulletPackAmount;
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            StartCoroutine(DelayMessageText(_playerData, PlayerData.pickBulletObjectMessageTr, PlayerData.pickBulletObjectMessage));
        }
        else if (_playerData.bulletPackAmount < 2)
        {
            CreateBulletParticleEffect(environmentObjectPool, other, _playerData);

            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            ++_playerData.bulletPackAmount;
            StartCoroutine(DelayMessageText(_playerData, PlayerData.pickBulletObjectMessageTr, PlayerData.pickBulletObjectMessage));
            other.gameObject.SetActive(false);
            bulletAmountCanvas.transform.GetChild(0).gameObject.transform.localScale = Vector3.one;
            bulletAmountCanvas.transform.GetChild(1).gameObject.transform.localScale = Vector3.one;
        }
        else if (_playerData.bulletPackAmount == 2 && _playerData.bulletAmount != PlayerManager.GetInstance._bulletData.currentBulletPackAmount)
        {
            CreateBulletParticleEffect(environmentObjectPool, other, _playerData);

            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            other.gameObject.SetActive(false);
            _playerData.bulletAmount = PlayerManager.GetInstance._bulletData.currentBulletPackAmount;
            StartCoroutine(DelayMessageText(_playerData, PlayerData.pickBulletObjectMessageTr, PlayerData.pickBulletObjectMessage));
        }
        else
        {
            StartCoroutine(DelayMessageText(_playerData, PlayerData.alreadyHaveThisMessageTr, PlayerData.alreadyHaveThisMessage));
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin);
        }
    }

    void CreateBulletParticleEffect(EnvironmentObjectPool environmentObjectPool, Collider other, PlayerData _playerData)
    {
        if (other.gameObject.transform.parent.parent.name == "GiftBoxTransform")
        {
            GameObject particleObject = environmentObjectPool.GetPooledObject(_playerData.destroyWeaponCollectParticleObjectPoolCount);
            particleObject.transform.position = other.gameObject.transform.position;

            StartCoroutine(DelaySetActiveFalseParticle(particleObject, 1f));
        }
        else
        {
            GameObject particleObject = environmentObjectPool.GetPooledObject(_playerData.destroyBulletCoinParticleObjectPoolCount);
            particleObject.transform.position = other.gameObject.transform.position;

            StartCoroutine(DelaySetActiveFalseParticle(particleObject, 1f));
        }
        
    }


    void HandleCoinPickup(GameObject coinObj, ParticleController.ParticleNames particle,
        PlayerSoundEffect.SoundEffectTypes sound, Collider other, EnvironmentObjectPool environmentObjectPool)
    {
        if (coinObj != null)
        {
            coinObj.transform.localScale = Vector3.one;
            StartCoroutine(PlayerManager.GetInstance.DelayDestroyCoinObject(coinObj));
        }

        GameObject particleObject = null;
        GameObject particleObject1 = null;
        GameObject particleObject2 = null;

        if (ParticleController.ParticleNames.DestroyCoin == particle)
        {
            particleObject = environmentObjectPool.GetPooledObject(PlayerManager.GetInstance._playerData.destroyCoinParticleObjectPoolCount);
            particleObject.transform.position = other.gameObject.transform.position;
            StartCoroutine(DelaySetActiveFalseParticle(particleObject, 1f));
        }
        else if (ParticleController.ParticleNames.DestroyRotateCoin == particle)
        {
            particleObject = environmentObjectPool.GetPooledObject(PlayerManager.GetInstance._playerData.destroyGroupCoinParticleObjectPoolCount);
            particleObject.transform.position = other.gameObject.transform.position;
            StartCoroutine(DelaySetActiveFalseParticle(particleObject, 1f));
        }
        else if (ParticleController.ParticleNames.DestroyHealthCoin == particle)
        {
            particleObject1 = environmentObjectPool.GetPooledObject(PlayerManager.GetInstance._playerData.destroyHealthCoinObjectPoolCount);
            particleObject1.transform.position = other.gameObject.transform.position;
            StartCoroutine(DelaySetActiveFalseParticle(particleObject1, 1f));
        }
        else if (ParticleController.ParticleNames.DestroyMushroomCoin == particle)
        {
            particleObject2 = environmentObjectPool.GetPooledObject(PlayerManager.GetInstance._playerData.destroyMushroomCoinObjectPoolCount);
            particleObject2.transform.position = other.gameObject.transform.position;
            StartCoroutine(DelaySetActiveFalseParticle(particleObject2, 1f));
        }
        else if (ParticleController.ParticleNames.DestroyKeyCoin == particle)
        {
            particleObject2 = environmentObjectPool.GetPooledObject(PlayerManager.GetInstance._playerData.destroyKeyParticleObjectPoolCount);
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
            if (bulletData.weaponStruct[8].lockState == BulletData.locked && bulletData.weaponStruct[9].lockState == BulletData.locked &&
            bulletData.weaponStruct[1].lockState == BulletData.locked && bulletData.weaponStruct[2].lockState == BulletData.locked &&
            bulletData.weaponStruct[3].lockState == BulletData.locked && bulletData.weaponStruct[4].lockState == BulletData.locked &&
            bulletData.weaponStruct[5].lockState == BulletData.locked && bulletData.weaponStruct[6].lockState == BulletData.locked &&
            bulletData.weaponStruct[7].lockState == BulletData.locked && bulletData.weaponStruct[0].lockState == BulletData.locked)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[0].weaponName;
                PlayerPrefs.SetInt("CurrentWeaponID", 0);
            }
        }        
    }

    public virtual void CheckWeaponCollect(Collider other, BulletData _bulletData)
    {
        for (int i = 0; i < _bulletData.weaponStruct.Length; i++)
        {
            HandleWeaponCollect(other, _bulletData,
            _bulletData.weaponStruct[i].weaponName,
            _bulletData.weaponStruct[i].weaponName,
            ref _bulletData.weaponStruct[i].isWeapon,
            ref _bulletData.weaponStruct[i].lockState,
            _bulletData.weaponStruct[i].bulletPackAmount,
            _bulletData.weaponStruct[i].id);
        }
        
    }

    // Helper method for handling weapon collection
    private void HandleWeaponCollect(Collider other, BulletData _bulletData, string tag,
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

                _bulletData.currentBulletPackAmount = bulletAmount;

                PlayerManager.GetInstance._playerData.bulletAmount = bulletAmount;

                BulletData.currentWeaponID = _currentWeaponID;

                PlayerPrefs.SetInt("CurrentWeaponID", BulletData.currentWeaponID);

                _bulletData.currentWeaponName = _bulletData.weaponStruct[BulletData.currentWeaponID].weaponName;

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

    void IncreaseUsageLimit(BulletData _bulletData, string tag)
    {
        // Define the bullet map only if it’s not already defined, reducing memory allocation.
        var bulletMap = new Dictionary<string, Action>
    {
        { _bulletData.weaponStruct[0].weaponName,    () => SetWeaponLimit(_bulletData, 0) },
        { _bulletData.weaponStruct[1].weaponName,    () => SetWeaponLimit(_bulletData, 1) },
        { _bulletData.weaponStruct[2].weaponName,        () => SetWeaponLimit(_bulletData, 2) },
        { _bulletData.weaponStruct[3].weaponName,        () => SetWeaponLimit(_bulletData, 3) },
        { _bulletData.weaponStruct[4].weaponName,    () => SetWeaponLimit(_bulletData, 4) },
        { _bulletData.weaponStruct[5].weaponName,      () => SetWeaponLimit(_bulletData, 5) },
        { _bulletData.weaponStruct[6].weaponName,     () => SetWeaponLimit(_bulletData, 6) },
        { _bulletData.weaponStruct[7].weaponName,        () => SetWeaponLimit(_bulletData, 7) },
        { _bulletData.weaponStruct[8].weaponName,    () => SetWeaponLimit(_bulletData, 8) },
        { _bulletData.weaponStruct[9].weaponName,    () => SetWeaponLimit(_bulletData, 9) }
    };

        if (bulletMap.TryGetValue(tag, out var action))
        {
            action();
        }
    }

    // Helper function to handle setting lock state, usage limit, and PlayerPrefs.
    void SetWeaponLimit(BulletData _bulletData, int index)
    {
        _bulletData.weaponStruct[index].lockState = _bulletData.unLocked;
        _bulletData.weaponStruct[index].usageLimit = 1;
        PlayerPrefs.SetInt($"{_bulletData.weaponStruct[index].weaponName}UsageCount", 1);
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
        if (_playerData.bulletAmount <= PlayerManager.GetInstance._bulletData.currentBulletPackAmount / 2f * 3)
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
            bulletAmountCanvas.transform.GetChild(1).transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
        }
        else if (_playerData.bulletAmount <= PlayerManager.GetInstance._bulletData.currentBulletPackAmount / 2f)
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            bulletAmountCanvas.transform.GetChild(1).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (_playerData.bulletAmount <= PlayerManager.GetInstance._bulletData.currentBulletPackAmount / 3f)
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
        if (_playerData.isGround)
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
    }
    public virtual void DelayLevelUp()
    {
        Invoke("InvokeLevelUp", 2);
    }

    void InvokeLevelUp()
    {
        LevelData.isLevelUp = false;
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

    public virtual void TouchEnemy(PlayerData _playerData, 
                                    ref Slider _healthBarSlider, 
                                    ref Slider _topCanvasHealthBarSlider)
    {
        if (_playerData.isGround)
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

        Invoke(nameof(DelayScoreSizeBack), .5f);
    }

    public virtual void DelayScoreSizeBack()
    {
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
    
    public virtual void Run(PlayerData _playerData, Transform _particleTransform, float runTimeAmount, Rigidbody objectRigidbody,
        ObjectPool playerObjectPool, PlayerData playerData)
    {//FasterWalking
        if (PlayerController.run && !_playerData.isJumping && !_playerData.isBackWalking)
        {
            PlayerData.isRunning = true;
            _playerData.clickShiftCount++;
            Invoke("DelayFalseRunning", runTimeAmount);

            CreateRunParticle(playerObjectPool, playerData);
        }

        if (_playerData.clickShiftCount > 1)
        {
            PlayerData.isRunning = false;
        }
        if (PlayerData.isRunning && !_playerData.isJumping && !_playerData.isBackWalking)
        {
            if (PlayerManager.GetInstance.GetZValue() > 0f)
            {
                objectRigidbody.AddForce(transform.forward * Time.deltaTime * 15000);
            }
            else if (PlayerManager.GetInstance.GetZValue() < 0f)
            {
                objectRigidbody.AddForce(-transform.forward * Time.deltaTime * 15000);
            }
            else if (PlayerManager.GetInstance.GetXValue() > 0f)
            {
                objectRigidbody.AddForce(transform.right * Time.deltaTime * 15000);
            }
            else if (PlayerManager.GetInstance.GetXValue() < 0f)
            {
                objectRigidbody.AddForce(-transform.right * Time.deltaTime * 15000);
            }
            else if(PlayerManager.GetInstance.GetZValue() == 0f && PlayerManager.GetInstance.GetXValue() == 0f)
            {
                objectRigidbody.AddForce(transform.forward * Time.deltaTime * 15000);
            }            
        }

    }

    void CreateRunParticle(ObjectPool playerObjectPool, PlayerData playerData)
    {
        GameObject particleObject = playerObjectPool.GetPooledObject(playerData.playerRunParticleOjectPoolID);
        particleObject.transform.position = new Vector3(PlayerManager.GetInstance.transform.position.x,
                                            PlayerManager.GetInstance.transform.position.y + .3f,
                                            PlayerManager.GetInstance.transform.position.z);

        StartCoroutine(DelaySetActiveFalseParticle(particleObject, 1f));
    }

    public virtual void Walk(PlayerData _playerData, ref Transform playerTransform, ref Animator characterAnimator)
    {
        float zValue = PlayerManager.GetInstance.GetZValue();
        float xValue = PlayerManager.GetInstance.GetXValue();

        if (Mathf.Abs(xValue) >= .4f && Mathf.Abs(zValue) >= .4f)
        {
            _playerData.isSideWalking = true;
            _playerData.isWalking = true;
        }
        else if (Mathf.Abs(xValue) * (2.5f) > zValue)
        {
            _playerData.isSideWalking = true;
            _playerData.isWalking = false;
        }
        else if (Mathf.Abs(xValue) * (2.5f) < zValue)
        {
            _playerData.isWalking = true;
            _playerData.isSideWalking = false;
        }

        if (_playerData.isSideWalking && _playerData.isWalking)
        {

            Vector3 normal = new Vector3((PlayerData.currentCharacterSpeed / 3) * Time.deltaTime * Mathf.Sign(xValue),
                                       0f,
                                       PlayerData.currentCharacterSpeed * zValue * Time.deltaTime);
            playerTransform.Translate(normal.normalized*Time.deltaTime);
            
        }
        else if (_playerData.isSideWalking || (Mathf.Abs(xValue) >= .5f && Mathf.Abs(zValue) >= .5f))
        {
            playerTransform.Translate((PlayerData.currentCharacterSpeed / 3) * Time.deltaTime * Mathf.Sign(xValue), 0f, 0f);
        }
        else if (_playerData.isWalking)
        {
            playerTransform.Translate(0f, 0f, PlayerData.currentCharacterSpeed * zValue * Time.deltaTime);
        }


        // Geri Yürüme Durumu
        if (zValue < 0f)
        {
            _playerData.isBackWalking = true;
            _playerData.isWalking = false;
            _playerData.isSideWalking = false;
        }
        else
        {
            _playerData.isBackWalking = false;
        }

        if (_playerData.isBackWalking)
        {
            playerTransform.Translate(0f, 0f, (-PlayerData.currentCharacterSpeed * .4f) * Time.deltaTime);
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
            if (PlayerManager.GetInstance.playerComponents._playerController.jump && _playerData.jumpCount == 0 && _playerData.isGround &&
                !_playerData.isDying && _playerData.isPlayable)
            {

                //SoundEffect
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);

                //PlayerData
                _playerData.isJumping = true;

                //AddForceForJump
                playerRigidbody.AddForce(transform.up * PlayerData.currentJumpForce, ForceMode.Impulse);

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
            playerRigidbody.AddForce(transform.forward * -1 * PlayerData.currentJumpForce / 3, ForceMode.Impulse);
        }
        else if (PlayerManager.GetInstance.GetZValue() > 0)
        {
            playerRigidbody.AddForce(transform.forward * PlayerData.currentJumpForce / 3, ForceMode.Impulse);
        }

    }
    void JumpDirectionX(PlayerData _playerData, ref Rigidbody playerRigidbody)
    {
        if (PlayerManager.GetInstance.GetXValue() < 0 && _playerData.isSideWalking)
        {
            playerRigidbody.AddForce(transform.right * -1 * PlayerData.currentJumpForce / 3, ForceMode.Impulse);

        }
        else if (PlayerManager.GetInstance.GetXValue() > 0 && _playerData.isSideWalking)
        {
            playerRigidbody.AddForce(transform.right * PlayerData.currentJumpForce / 3, ForceMode.Impulse);
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
    void DelayFalseRunning()
    {
        PlayerData.isRunning = false;
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