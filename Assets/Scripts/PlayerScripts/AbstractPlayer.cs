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
            if (BulletData.currentWeaponName == weaponName)
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
                PlayerData.currentMessageObject = GameObject.Find("MessageText");
            }
            
            if (PlayerData.currentMessageObject)
            {
                PlayerData.currentMessageText = PlayerData.currentMessageObject.GetComponent<TextMeshProUGUI>();
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
                        bulletAmountCanvas.transform.GetChild(0).transform.GetComponent<TextMeshProUGUI>().text = PlayerData.bulletAmount.ToString();
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
            if (BulletData.currentBulletPackAmount == 0)
            {
                BulletData.currentBulletPackAmount = 21;
            }

            PlayerData.bulletAmount = BulletData.currentBulletPackAmount;

            PlayerData.isFireWalkAnimation = false;
            PlayerData.isFire = false;
            LevelData.isLevelUp = false;
            LevelData.levelCanBeSkipped = false;
            PlayerData.clickShiftCount = 0;
            PlayerData.isDestroyed = false;
            PlayerData.jumpCount = 0;
            PlayerData.isLose = false;
            PlayerData.isTouchFinish = false;
            PlayerData.isPicking = false;
            PlayerData.isPickRotateCoin = false;
            PlayerData.isLookingUp = false;
            PlayerData.isWinning = false;
            PlayerData.isRunning = false;
            PlayerData.isPlayable = true;
            CharacterSpeeds(_playerData);
            CharacterJumpForce(_playerData);
            PlayerData.isDying = false;
            PlayerData.isFireWalkAnimation = false;
            PlayerData.isWalking = false;
            PlayerData.isBackWalking = false;
            PlayerData.isGround = true;
            PlayerData.isSwordAnimate = false;
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
        if (PlayerData.isPlayable && PlayerController.GetFire() &&
            !PlayerData.isWinning && !PlayerData.isDying)
        {
            //PlayerData
            if (PlayerData.bulletAmount <= 0 && PlayerData.bulletPackAmount <= 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);

                PlayerData.isFireWalkAnimation = false;

                PlayerData.isFire = false;
            }
            else if (PlayerData.bulletAmount <= 0 && PlayerData.bulletPackAmount >= 0)
            {
                PlayerData.bulletAmount = BulletData.currentBulletPackAmount;

                PlayerData.bulletPackAmount--;

                PlayerData.isFire = true;
            }
            else if(PlayerData.bulletPackAmount >= 0)
            {
                if (PlayerData.isSideWalking && !PlayerData.isWalking || PlayerData.isBackWalking)
                {
                    PlayerData.isFire = true;
                    PlayerData.isFireAnimation = false;
                    PlayerData.isFireWalkAnimation = false;
                }
                if (!PlayerData.isWalking && !PlayerData.isSideWalking && !PlayerData.isBackWalking && !PlayerData.isSwordAnimate)
                {
                    PlayerData.isFire = true;
                    PlayerData.isFireAnimation = true;
                    PlayerData.isFireWalkAnimation = false;
                }
                if (PlayerData.isWalking && !PlayerData.isSideWalking && !PlayerData.isBackWalking)
                {
                    PlayerData.isFire = true;
                    PlayerData.isFireAnimation = false;
                    PlayerData.isFireWalkAnimation = true;
                }
                if (PlayerData.bulletAmount <= BulletData.currentBulletPackAmount / 2f &&
                    PlayerData.bulletAmount > 0 && PlayerData.isWalking)
                {
                    PlayerData.isFire = true;
                }
                else if (PlayerData.bulletAmount > BulletData.currentBulletPackAmount / 2f && PlayerData.isWalking)
                {
                    PlayerData.isFire = true;
                }
                if (PlayerData.bulletAmount > 0 && BulletManager.isCreatedWeaponBullet)
                {
                    --PlayerData.bulletAmount;
                    PlayerController.SetFire(false);
                    BulletManager.isCreatedWeaponBullet = false;
                }
            }
        }
        else
        {
            PlayerData.isFire = false;
            PlayerData.isFireAnimation = false;
            PlayerData.isFireWalkAnimation = false;
        }
    }
    public virtual void Sword(PlayerData _playerData)
    {
        if (_playerData)
        {
            if (PlayerData.isPlayable)
            {
                if (PlayerController.GetSword() && !PlayerData.isSwordAnimate)
                {
                    //PlayerData
                    PlayerData.isSwordAnimate = true;
                    PlayerData.isSword = true;
                }
                else
                {
                    PlayerData.isSword = false;
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
        var cameraSpawner = PlayerManager.GetInstance.cameraSpawner;

        if (cameraSpawner)
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
                PlayerData.isLookingUp = cameraXAngle < 0;
                _currentCameraTransform.eulerAngles = new Vector3(0f, eulerAngles.y, eulerAngles.z);
            }
            else
            {
                PlayerData.isLookingUp = cameraXAngle > 270 && cameraXAngle <= 360;
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
        if (healthBarSlider.value == 0 && !PlayerData.isWinning && PlayerData.isGround)
        {

            GameObject particleObject = null;

            if (particleObject == null)
            {
                particleObject =
                    PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(_playerData.playerBurningTouchParticleObjectPoolCount);
                particleObject.transform.position = _particleTransform.transform.position;

                StartCoroutine(PlayerManager.GetInstance.DelaySetActiveFalseParticle(particleObject, 1));
            }


            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);

            // Mark player as destroyed and handle enemy-related effects
            PlayerData.isDestroyed = true;

            // Sync top canvas health bar and set player states
            topCanvasHealthBarSlider.value = healthBarSlider.value;
            PlayerData.isDying = true;
            PlayerData.isIdling = false;
            PlayerData.isPlayable = false;

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
        if (!PlayerData.isWinning && healthValue > 0)
        {
            GameObject particleObject = null;
            GameObject particleObject1 = null;

            if (particleObject == null)
            {
                particleObject =
                    PlayerManager.GetInstance._objectPool.GetComponent<ObjectPool>().GetPooledObject(_playerData.playerBurningTouchParticleObjectPoolCount);
                particleObject.transform.position = _particleTransform.transform.position;

                StartCoroutine(PlayerManager.GetInstance.DelaySetActiveFalseParticle(particleObject, 1));                
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
        PlayerData.isPicking = true; // Set player state once at the start



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

        if ((PlayerData.bulletPackAmount == 2 && PlayerData.bulletAmount != BulletData.currentBulletPackAmount) ||
            (PlayerData.bulletPackAmount == 0 && PlayerData.bulletAmount == 0) ||
             PlayerData.bulletPackAmount < 2 ||
             (PlayerData.bulletPackAmount == 2 && PlayerData.bulletAmount != BulletData.currentBulletPackAmount))
        {
            CreateBulletParticleEffect(environmentObjectPool, other, _playerData);            
        }

        if (PlayerData.bulletPackAmount == 0 && PlayerData.bulletAmount == 0)
        {
            CreateBulletParticleEffect(environmentObjectPool, other, _playerData);

            other.gameObject.SetActive(false);
            PlayerData.bulletAmount = BulletData.currentBulletPackAmount;
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            StartCoroutine(DelayMessageText(_playerData, PlayerData.pickBulletObjectMessageTr, PlayerData.pickBulletObjectMessage));
        }
        else if (PlayerData.bulletPackAmount < 2)
        {
            CreateBulletParticleEffect(environmentObjectPool, other, _playerData);

            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            ++PlayerData.bulletPackAmount;
            StartCoroutine(DelayMessageText(_playerData, PlayerData.pickBulletObjectMessageTr, PlayerData.pickBulletObjectMessage));
            other.gameObject.SetActive(false);
            bulletAmountCanvas.transform.GetChild(0).gameObject.transform.localScale = Vector3.one;
            bulletAmountCanvas.transform.GetChild(1).gameObject.transform.localScale = Vector3.one;
        }
        else if (PlayerData.bulletPackAmount == 2 && PlayerData.bulletAmount != BulletData.currentBulletPackAmount)
        {
            CreateBulletParticleEffect(environmentObjectPool, other, _playerData);

            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin);
            other.gameObject.SetActive(false);
            PlayerData.bulletAmount = BulletData.currentBulletPackAmount;
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
                BulletData.currentWeaponName = bulletData.weaponStruct[0].weaponName;
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
            if (BulletData.currentWeaponName != weaponName)
            {
                Destroy(other.gameObject);

                weaponStatus = true;

                ObjectPool.creatablePlayerBullet = true;

                weaponLock = BulletData.unLocked;

                PlayerData.currentBulletExplosionIsChanged = true;

                BulletData.currentBulletPackAmount = bulletAmount;

                PlayerData.bulletAmount = bulletAmount;

                BulletData.currentWeaponID = _currentWeaponID;

                PlayerPrefs.SetInt("CurrentWeaponID", BulletData.currentWeaponID);

                BulletData.currentWeaponName = _bulletData.weaponStruct[BulletData.currentWeaponID].weaponName;

                IncreaseUsageLimit(_bulletData, tag);

                StartCoroutine(DelayMessageText(PlayerManager.GetInstance._playerData, tagString, tagString));
            }
            else if (BulletData.currentWeaponName == weaponName)
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
        _bulletData.weaponStruct[index].lockState = BulletData.unLocked;
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
        if (PlayerData.bulletAmount <= BulletData.currentBulletPackAmount / 2f * 3)
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
            bulletAmountCanvas.transform.GetChild(1).transform.localScale = new Vector3(1.75f, 1.75f, 1.75f);
        }
        else if (PlayerData.bulletAmount <= BulletData.currentBulletPackAmount / 2f)
        {
            bulletAmountCanvas.transform.GetChild(0).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
            bulletAmountCanvas.transform.GetChild(1).transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (PlayerData.bulletAmount <= BulletData.currentBulletPackAmount / 3f)
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
        if (PlayerData.isGround)
        {
            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);
            _topCanvasHealthBarSlider.value = _healthBarSlider.value;

            //PlayerData
            PlayerData.isDestroyed = true;
            PlayerData.isDying = true;
            PlayerData.isIdling = false;
            PlayerData.isPlayable = false;
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
        if (PlayerData.isGround)
        {
            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Death);


            _topCanvasHealthBarSlider.value = _healthBarSlider.value;

            //PlayerData
            PlayerData.isDestroyed = true;
            PlayerData.isDying = true;
            PlayerData.isIdling = false;
            PlayerData.isPlayable = false;
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
        if (PlayerController.GetRun() && !PlayerData.isJumping && !PlayerData.isBackWalking)
        {
            PlayerData.isRunning = true;
            PlayerData.clickShiftCount++;
            Invoke("DelayFalseRunning", runTimeAmount);

            CreateRunParticle(playerObjectPool, playerData);
        }

        if (PlayerData.clickShiftCount > 1)
        {
            PlayerData.isRunning = false;
        }
        if (PlayerData.isRunning && !PlayerData.isJumping && !PlayerData.isBackWalking)
        {
            if (PlayerManager.GetXAndZValue().z > 0f)
            {
                objectRigidbody.AddForce(transform.forward * Time.deltaTime * 15000);
            }
            else if (PlayerManager.GetXAndZValue().z < 0f)
            {
                objectRigidbody.AddForce(-transform.forward * Time.deltaTime * 15000);
            }
            else if (PlayerManager.GetXAndZValue().x > 0f)
            {
                objectRigidbody.AddForce(transform.right * Time.deltaTime * 15000);
            }
            else if (PlayerManager.GetXAndZValue().x < 0f)
            {
                objectRigidbody.AddForce(-transform.right * Time.deltaTime * 15000);
            }
            else if(PlayerManager.GetXAndZValue().z == 0f && PlayerManager.GetXAndZValue().x == 0f)
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
        float zValue = PlayerManager.GetXAndZValue().z;
        float xValue = PlayerManager.GetXAndZValue().x;

        if (Mathf.Abs(xValue) >= .4f && Mathf.Abs(zValue) >= .4f)
        {
            PlayerData.isSideWalking = true;
            PlayerData.isWalking = true;
        }
        else if (Mathf.Abs(xValue) * (2.5f) > zValue)
        {
            PlayerData.isSideWalking = true;
            PlayerData.isWalking = false;
        }
        else if (Mathf.Abs(xValue) * (2.5f) < zValue)
        {
            PlayerData.isWalking = true;
            PlayerData.isSideWalking = false;
        }

        if (PlayerData.isSideWalking && PlayerData.isWalking)
        {

            Vector3 normal = new Vector3((PlayerData.currentCharacterSpeed / 3) * Time.deltaTime * Mathf.Sign(xValue),
                                       0f,
                                       PlayerData.currentCharacterSpeed * zValue * Time.deltaTime);
            playerTransform.Translate(normal.normalized*Time.deltaTime);
            
        }
        else if (PlayerData.isSideWalking || (Mathf.Abs(xValue) >= .5f && Mathf.Abs(zValue) >= .5f))
        {
            playerTransform.Translate((PlayerData.currentCharacterSpeed / 3) * Time.deltaTime * Mathf.Sign(xValue), 0f, 0f);
        }
        else if (PlayerData.isWalking)
        {
            playerTransform.Translate(0f, 0f, PlayerData.currentCharacterSpeed * zValue * Time.deltaTime);
        }


        // Geri Yürüme Durumu
        if (zValue < 0f)
        {
            PlayerData.isBackWalking = true;
            PlayerData.isWalking = false;
            PlayerData.isSideWalking = false;
        }
        else
        {
            PlayerData.isBackWalking = false;
        }

        if (PlayerData.isBackWalking)
        {
            playerTransform.Translate(0f, 0f, (-PlayerData.currentCharacterSpeed * .4f) * Time.deltaTime);
        }
        // Durma Durumu
        if (zValue == 0f && xValue == 0f)
        {
            PlayerData.isBackWalking = false;
            PlayerData.isWalking = false;
            PlayerData.isSideWalking = false;
        }
    }

    public virtual void Jump(PlayerData _playerData, ref Rigidbody playerRigidbody)
    {
        if (PlayerController.GetJump() && PlayerData.jumpCount == 0 && PlayerData.isGround &&
                !PlayerData.isDying && PlayerData.isPlayable)
        {

            //SoundEffect
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Jump);

            //PlayerData
            PlayerData.isJumping = true;

            //AddForceForJump
            playerRigidbody.AddForce(transform.up * PlayerData.currentJumpForce, ForceMode.Impulse);

            JumpDirectionZ(_playerData, ref playerRigidbody);
            JumpDirectionX(_playerData, ref playerRigidbody);
            PlayerData.jumpCount++;
        }
        else
        {
            //PlayerData
            PlayerData.isJumping = false;
        }
    }

    void JumpDirectionZ(PlayerData _playerData, ref Rigidbody playerRigidbody)
    {
        if (PlayerManager.GetXAndZValue().z < 0)
        {
            playerRigidbody.AddForce(transform.forward * -1 * PlayerData.currentJumpForce / 3, ForceMode.Impulse);
        }
        else if (PlayerManager.GetXAndZValue().z > 0)
        {
            playerRigidbody.AddForce(transform.forward * PlayerData.currentJumpForce / 3, ForceMode.Impulse);
        }

    }
    void JumpDirectionX(PlayerData _playerData, ref Rigidbody playerRigidbody)
    {
        if (PlayerManager.GetXAndZValue().x < 0 && PlayerData.isSideWalking)
        {
            playerRigidbody.AddForce(transform.right * -1 * PlayerData.currentJumpForce / 3, ForceMode.Impulse);

        }
        else if (PlayerManager.GetXAndZValue().x > 0 && PlayerData.isSideWalking)
        {
            playerRigidbody.AddForce(transform.right * PlayerData.currentJumpForce / 3, ForceMode.Impulse);
        }

    }
    public IEnumerator DelayMessageText(PlayerData _playerData, string turkishMessage, string englishMessage)
    {
        string message = PlayerData.currentLanguage == PlayerData.Languages.Turkish ? turkishMessage : englishMessage;
        PlayerData.currentMessageText.text = message;
        if (PlayerData.currentMessageText.text != PlayerData.emptyMessage)
        {
            yield return new WaitForSeconds(2f);
            PlayerData.currentMessageText.text = PlayerData.emptyMessage;
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
            _touchX = PlayerData.rotateSpeed * Time.deltaTime;
        }
        else if(Input.GetAxis("Mouse X") < 0)
        {
            _touchX = -PlayerData.rotateSpeed * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse Y") > 0)
        {
            _touchY = PlayerData.rotateSpeed * Time.deltaTime * 5f;
        }
        else if (Input.GetAxis("Mouse Y") < 0)
        {
            _touchY = -PlayerData.rotateSpeed * Time.deltaTime * 5f;
        }
    }


    public virtual void SensivityXSettings(float touchXValue, PlayerData _playerData, ref float _touchX)
    {//ControllerSmoothForXAxis
        if ((PlayerController.GetLookRotation().x >= -0.2f && PlayerController.GetLookRotation().x < 0f) ||
            (PlayerController.GetLookRotation().x <= 0.2f && PlayerController.GetLookRotation().x > 0f))
        {
            _touchX = (PlayerController.GetLookRotation().x * 2f) / 8f * PlayerData.sensivityX * touchXValue;
        }
        else if ((PlayerController.GetLookRotation().x >= -0.4f && PlayerController.GetLookRotation().x < -0.2f) ||
            (PlayerController.GetLookRotation().x <= 0.4f && PlayerController.GetLookRotation().x > 0.2f))
        {
            _touchX = (PlayerController.GetLookRotation().x * 2f) / 7f * PlayerData.sensivityX * touchXValue;
        }
        else if ((PlayerController.GetLookRotation().x >= -0.6f && PlayerController.GetLookRotation().x < -0.4f) ||
            (PlayerController.GetLookRotation().x <= 0.6f && PlayerController.GetLookRotation().x > 0.4f))
        {
            _touchX = (PlayerController.GetLookRotation().x * 2f) / 6f * PlayerData.sensivityX * touchXValue;
        }
        else if ((PlayerController.GetLookRotation().x >= -0.8f && PlayerController.GetLookRotation().x < -0.6f) ||
            (PlayerController.GetLookRotation().x <= 0.8f && PlayerController.GetLookRotation().x > 0.6f))
        {
            _touchX = (PlayerController.GetLookRotation().x * 2f) / 5f * PlayerData.sensivityX * touchXValue;
        }
        else
        {
            _touchX = (PlayerController.GetLookRotation().x * 2f) / 4f * PlayerData.sensivityX * touchXValue;
        }
    }
    #endregion


}