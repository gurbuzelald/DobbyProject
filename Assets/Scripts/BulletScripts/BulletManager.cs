using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using System;

public class BulletManager : AbstractBullet<BulletManager>
{
    [Header("Bullet Transform")]
    [SerializeField] Transform _bulletSpawnTransform;

    [Header("Data")]
    public BulletData bulletData;
    public PlayerData _playerData;

    [Header("Initial Transform of This")]
    private Transform _initTransform;

    public GameObject _currentWeaponObject;
    public GameObject _currentSwordObject;
    public GameObject pinky;

    public static bool isCreatedWeaponBullet;

    public ObjectPool _objectPool;

    void Start()
    {
        SetWeaponTransform();

        isCreatedWeaponBullet = false;

        CreateWeaponObject();

        CreateSwordObject();

        bulletData.bulletDelayCounter = 0;
        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;


        if (bulletData)
        {
            CheckWeaponUsageLimitAtStart();
        }

        _objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
    }

    void CheckWeaponUsageLimitAtStart()
    {
        if (bulletData.axeUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.axeLock = BulletData.locked;
        }
        if (bulletData.bulldogUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.bulldogLock = BulletData.locked;
        }
        if (bulletData.cowUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.cowLock = BulletData.locked;
        }
        if (bulletData.crystalUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.crystalLock = BulletData.locked;
        }
        if (bulletData.demonUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.demonLock = BulletData.locked;
        }
        if (bulletData.iceUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.iceLock = BulletData.locked;
        }
        if (bulletData.electroUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.electroLock = BulletData.locked;
        }
        if (bulletData.shotGunUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.shotGunLock = BulletData.locked;
        }
        if (bulletData.machineUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.machineLock = BulletData.locked;
        }
    }
    public void CreateSwordObject()
    {
        if (PlayerManager.GetInstance._bulletData)
        {
            PlayerManager.GetInstance.GetSwordTransform(PlayerManager.GetInstance._bulletData, ref PlayerManager.GetInstance._swordTransform);
        }
        
        if (bulletData)
        {
            if (BulletData.lowSword == bulletData.currentSwordName)
            {
                if (_bulletSpawnTransform)
                {
                    if (PlayerManager.GetInstance)
                    {
                        if (PlayerManager.GetInstance._swordTransform)
                        {
                            if (bulletData.lowSwordObject)
                            {
                                _currentSwordObject = Instantiate(bulletData.lowSwordObject,
                                               _bulletSpawnTransform.position,
                                               Quaternion.identity,
                                               PlayerManager.GetInstance._swordTransform.transform);
                            }
                        }
                    }   
                }
            }
        }
        
        if (_currentSwordObject)
        {
            _currentSwordObject.SetActive(true);
            _currentSwordObject.transform.position = PlayerManager.GetInstance._swordTransform.transform.position;

            _currentSwordObject.transform.rotation = PlayerManager.GetInstance._swordTransform.transform.rotation;
        }
    }
    public void CreateWeaponObject()
    {
        if (PlayerManager.GetInstance._bulletData)
        {
            PlayerManager.GetInstance.GetWeaponTransform(PlayerManager.GetInstance._bulletData, ref PlayerManager.GetInstance._gunTransform);
        }
        

        if (bulletData && _bulletSpawnTransform && PlayerManager.GetInstance._gunTransform)
        {
            if (bulletData.currentWeaponName == BulletData.shotGun)
            {
                _currentWeaponObject = Instantiate(bulletData.shotGunObject,
                                                   _bulletSpawnTransform.position,
                                                   Quaternion.identity,
                                                   PlayerManager.GetInstance._gunTransform.transform);

                bulletData.currentShootFrequency = bulletData.shotGunShootFrequency;

                bulletData.currentBulletPack = bulletData.shotGunBulletAmount;
            }
            else if (bulletData.currentWeaponName == BulletData.machine)
            {
                _currentWeaponObject = Instantiate(bulletData.machineObject,
                                        _bulletSpawnTransform.position,
                                        Quaternion.identity,
                                        PlayerManager.GetInstance._gunTransform.transform);

                bulletData.currentShootFrequency = bulletData.machineShootFrequency;

                bulletData.currentBulletPack = bulletData.machineBulletAmount;
            }
            else if (bulletData.currentWeaponName == BulletData.bulldog)
            {
                _currentWeaponObject = Instantiate(bulletData.bullDogObject,
                                        _bulletSpawnTransform.position,
                                        Quaternion.identity,
                                        PlayerManager.GetInstance._gunTransform.transform);

                bulletData.currentShootFrequency = bulletData.bulldogShootFrequency;

                bulletData.currentBulletPack = bulletData.bulldogBulletAmount;
            }
            else if (bulletData.currentWeaponName == BulletData.cow)
            {
                _currentWeaponObject = Instantiate(bulletData.cowObject,
                                        _bulletSpawnTransform.position,
                                        Quaternion.identity,
                                        PlayerManager.GetInstance._gunTransform.transform);

                bulletData.currentShootFrequency = bulletData.cowShootFrequency;

                bulletData.currentBulletPack = bulletData.cowBulletAmount;

            }
            else if (bulletData.currentWeaponName == BulletData.crystal)
            {
                _currentWeaponObject = Instantiate(bulletData.crsytalObject,
                                        _bulletSpawnTransform.position,
                                        Quaternion.identity,
                                        PlayerManager.GetInstance._gunTransform.transform);

                bulletData.currentShootFrequency = bulletData.crystalShootFrequency;

                bulletData.currentBulletPack = bulletData.crystalBulletAmount;
            }
            else if (bulletData.currentWeaponName == BulletData.demon)
            {
                _currentWeaponObject = Instantiate(bulletData.demonObject,
                                        _bulletSpawnTransform.position,
                                        Quaternion.identity,
                                        PlayerManager.GetInstance._gunTransform.transform);

                bulletData.currentShootFrequency = bulletData.demonShootFrequency;

                bulletData.currentBulletPack = bulletData.demonBulletAmount;
            }
            else if (bulletData.currentWeaponName == BulletData.ice)
            {
                _currentWeaponObject = Instantiate(bulletData.iceObject,
                                        _bulletSpawnTransform.position,
                                        Quaternion.identity,
                                        PlayerManager.GetInstance._gunTransform.transform);

                bulletData.currentShootFrequency = bulletData.iceShootFrequency;

                bulletData.currentBulletPack = bulletData.iceBulletAmount;
            }
            else if (bulletData.currentWeaponName == BulletData.electro)
            {
                _currentWeaponObject = Instantiate(bulletData.electroObject,
                                        _bulletSpawnTransform.position,
                                        Quaternion.identity,
                                        PlayerManager.GetInstance._gunTransform.transform);

                bulletData.currentShootFrequency = bulletData.electroShootFrequency;

                bulletData.currentBulletPack = bulletData.electroBulletAmount;
            }
            else if (bulletData.currentWeaponName == BulletData.axe)
            {
                _currentWeaponObject = Instantiate(bulletData.axeObject,
                                        _bulletSpawnTransform.position,
                                        Quaternion.identity,
                                        PlayerManager.GetInstance._gunTransform.transform);

                bulletData.currentShootFrequency = bulletData.axeShootFrequency;

                bulletData.currentBulletPack = bulletData.axeBulletAmount;
            }
            else if (bulletData.currentWeaponName == BulletData.pistol)
            {
                _currentWeaponObject = Instantiate(bulletData.pistolObject,
                                        _bulletSpawnTransform.position,
                                        Quaternion.identity,
                                        PlayerManager.GetInstance._gunTransform.transform);

                bulletData.currentShootFrequency = bulletData.pistolShootFrequency;

                bulletData.currentBulletPack = bulletData.pistolBulletAmount;
            }
            else
            {
                Debug.Log("Check current weapon name");
            }

            if (_currentWeaponObject)
            {
                _currentWeaponObject.SetActive(true);

                if (PlayerManager.GetInstance._gunTransform)
                {
                    _currentWeaponObject.transform.position = PlayerManager.GetInstance._gunTransform.transform.position;
                    _currentWeaponObject.transform.rotation = PlayerManager.GetInstance._gunTransform.transform.rotation;
                }
            }
        }
    }

    public void SetWeaponTransform()//Getting finger transform parameter
    {
        if (PlayerManager.GetInstance._gunTransform)
        {
            if (bulletData.currentWeaponName == BulletData.shotGun)
            {
                if (GameObject.Find("ShotGunTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("ShotGunTransform");
                }
            }
            else if (bulletData.currentWeaponName == BulletData.machine)
            {
                if (GameObject.Find("MachineTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("MachineTransform");
                }
            }
            else if (bulletData.currentWeaponName == BulletData.bulldog)
            {
                if (GameObject.Find("BulldogTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("BulldogTransform");
                }
            }
            else if (bulletData.currentWeaponName == BulletData.cow)
            {
                if (GameObject.Find("CowTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("CowTransform");
                }
            }
            else if (bulletData.currentWeaponName == BulletData.crystal)
            {
                if (GameObject.Find("CrystalTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("CrystalTransform");
                }
            }
            else if (bulletData.currentWeaponName == BulletData.demon)
            {
                if (GameObject.Find("DemonTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("DemonTransform");
                }
            }
            else if (bulletData.currentWeaponName == BulletData.ice)
            {
                if (GameObject.Find("IceTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("IceTransform");
                }
            }
            else if (bulletData.currentWeaponName == BulletData.electro)
            {
                if (GameObject.Find("ElectroTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("ElectroTransform");
                }
            }
            else if (bulletData.currentWeaponName == BulletData.axe)
            {
                if (GameObject.Find("AxeTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("AxeTransform");
                }
            }
            else if (bulletData.currentWeaponName == BulletData.pistol)
            {
                if (GameObject.Find("PistolTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("PistolTransform");
                }
            }
        }
    }
    public void SetSwordTransform(GameObject pinky)//Getting finger transform parameter
    {
        if (bulletData.currentWeaponName == BulletData.lowSword)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("LowSwordTransform");
        }
    }
    public void DestroyWeaponObject()
    {
        if (_playerData && bulletData)
        {
            if (_playerData.isWinning && _currentWeaponObject)
            {
                Destroy(_currentWeaponObject);
            }

            HandleWeaponChange(BulletData.machine, ref bulletData.isMachine, 9, bulletData.machineShootFrequency);
            HandleWeaponChange(BulletData.shotGun, ref bulletData.isShotGun, 8, bulletData.shotGunShootFrequency);
            HandleWeaponChange(BulletData.axe, ref bulletData.isAxe, 1, bulletData.axeShootFrequency);
            HandleWeaponChange(BulletData.electro, ref bulletData.isElectro, 7, bulletData.electroShootFrequency);
            HandleWeaponChange(BulletData.crystal, ref bulletData.isCrystal, 4, bulletData.crystalShootFrequency);
            HandleWeaponChange(BulletData.demon, ref bulletData.isDemon, 5, bulletData.demonShootFrequency);
            HandleWeaponChange(BulletData.ice, ref bulletData.isIce, 6, bulletData.iceShootFrequency);
            HandleWeaponChange(BulletData.bulldog, ref bulletData.isBulldog, 2, bulletData.bulldogShootFrequency);
            HandleWeaponChange(BulletData.cow, ref bulletData.isCow, 3, bulletData.cowShootFrequency);
            HandleWeaponChange(BulletData.pistol, ref bulletData.isPistol, 0, bulletData.pistolShootFrequency);
        }
    }

    private void HandleWeaponChange(string weaponName, ref bool isWeaponActive, int weaponID, float shootFrequency)
    {
        if (isWeaponActive && bulletData.currentWeaponName != weaponName)
        {
            if (_currentWeaponObject)
            {
                Destroy(_currentWeaponObject);
            }
           
            bulletData.currentWeaponName = weaponName;
            bulletData.currentShootFrequency = shootFrequency;

            BulletData.currentWeaponID = weaponID;
            PlayerManager.GetInstance._objectPool.SetPlayerBulletsAndExplosionsAtUpdate();

            CreateWeaponObject();
            PlayerData.currentBulletExplosionIsChanged = true;

            isWeaponActive = false;
        }
    }
    public void DestroySwordObject()
    {
        if (_playerData && bulletData)
        {
            if (_playerData.isWinning && _currentSwordObject)
            {
                Destroy(_currentSwordObject);
            }
            HandleSwordChange(BulletData.lowSword, ref bulletData.isLowSword);
        }
    }

    private void HandleSwordChange(string swordName, ref bool isSwordActive)
    {
        string[] incompatibleSwords = {BulletData.lowSword };

        if (isSwordActive && Array.Exists(incompatibleSwords, name => bulletData.currentSwordName == name))
        {
            if (_currentSwordObject && bulletData)
            {
                Destroy(_currentSwordObject);
                bulletData.currentSwordName = swordName;
                CreateSwordObject();
                isSwordActive = false;
            }
        }
    }
    void FixedUpdate()
    {//Bullet Sound Opening With Fix Because Of This Method

        DestroyWeaponObject();
        DestroySwordObject();

        BulletRotation(PlayerManager.GetInstance._currentCamera,
                       _bulletSpawnTransform);

        WeaponFire();

        SetCurrentWeaponID();
        SetCurrentSwordID();
    }

    public void SetCurrentWeaponID()
    {
        if (bulletData)
        {
            if (bulletData.currentWeaponName == BulletData.pistol)
            {
                BulletData.currentWeaponID = 0;
            }
            else if (bulletData.currentWeaponName == BulletData.axe)
            {
                BulletData.currentWeaponID = 1;
            }
            else if (bulletData.currentWeaponName == BulletData.bulldog)
            {
                BulletData.currentWeaponID = 2;
            }
            else if (bulletData.currentWeaponName == BulletData.cow)
            {
                BulletData.currentWeaponID = 3;
            }
            else if (bulletData.currentWeaponName == BulletData.crystal)
            {
                BulletData.currentWeaponID = 4;
            }
            else if (bulletData.currentWeaponName == BulletData.demon)
            {
                BulletData.currentWeaponID = 5;
            }
            else if (bulletData.currentWeaponName == BulletData.ice)
            {
                BulletData.currentWeaponID = 6;
            }
            else if (bulletData.currentWeaponName == BulletData.electro)
            {
                BulletData.currentWeaponID = 7;
            }
            else if (bulletData.currentWeaponName == BulletData.shotGun)
            {
                BulletData.currentWeaponID = 8;
            }
            else if (bulletData.currentWeaponName == BulletData.machine)
            {
                BulletData.currentWeaponID = 9;
            }
        }
    }


    public void SetCurrentSwordID()
    {
        if (bulletData)
        {
            if (bulletData.currentSwordName == BulletData.lowSword)
            {
                BulletData.currentSwordID = 0;
            }
            else if (bulletData.currentSwordName == BulletData.warriorSword)
            {
                BulletData.currentWeaponID = 1;
            }
            else if (bulletData.currentSwordName == BulletData.hummer)
            {
                BulletData.currentWeaponID = 2;
            }
            else if (bulletData.currentSwordName == BulletData.orcSword)
            {
                BulletData.currentWeaponID = 3;
            }
            else if (bulletData.currentSwordName == BulletData.axeSword)
            {
                BulletData.currentWeaponID = 4;
            }
            else if (bulletData.currentSwordName == BulletData.axeKnight)
            {
                BulletData.currentWeaponID = 5;
            }
            else if (bulletData.currentSwordName == BulletData.barbarianSword)
            {
                BulletData.currentWeaponID = 6;
            }
            else if (bulletData.currentSwordName == BulletData.demonSword)
            {
                BulletData.currentWeaponID = 7;
            }
            else if (bulletData.currentSwordName == BulletData.magicSword)
            {
                BulletData.currentWeaponID = 8;
            }
            else if (bulletData.currentSwordName == BulletData.longHummer)
            {
                BulletData.currentWeaponID = 9;
            }
            else if (bulletData.currentSwordName == BulletData.club)
            {
                BulletData.currentWeaponID = 10;
            }
        }
    }

    public void SwordFire(float delayValue, int objectPoolCount)
    {
        if (_playerData)
        {
            if (objectPoolCount == _playerData.playerSwordBulletObjectPoolCount)
            {//SwordBullet
                if (_currentWeaponObject)
                {
                    _currentWeaponObject.SetActive(false);
                }
                if (_currentSwordObject)
                {
                    _currentSwordObject.SetActive(true);
                }


                SwordSoundTypeState();

                if (_bulletSpawnTransform && _objectPool)
                {
                    CreatePlayerBullet(_bulletSpawnTransform, bulletData.swordSpeed, objectPoolCount, _objectPool, 0f, 1f);
                }

                /* _bulletSpawnTransform.position = new Vector3(_bulletSpawnTransform.transform.position.x,
                                                              _bulletSpawnTransform.transform.position.y,
                                                              _bulletSpawnTransform.transform.position.z);*/
            }
        }
    }

    public void WeaponFire()
    {
        if (_playerData && bulletData)
        {
            if ((_playerData.isFire || _playerData.isFire) && !_playerData.isSwordAnimate && bulletData.bulletDelayCounter == 0 && _playerData.isFireTime)
            {
                bulletData.bulletDelayCounter++;

                StartCoroutine(Delay(bulletData.weaponBulletDelay, _playerData.playerWeaponBulletObjectPoolCount));
            }
        }
    }

    public void WeaponSoundTypeState()
    {//PlayerManager.GetInstance.SwordSFX(_playerData);
        if (bulletData)
        {
            if (bulletData.currentWeaponName == BulletData.shotGun)
            {
                PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.ShotGun);
            }
            else if (bulletData.currentWeaponName == BulletData.machine)
            {
                PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Machine);
            }
            else if (bulletData.currentWeaponName == BulletData.bulldog)
            {
                PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Bulldog);
            }
            else if (bulletData.currentWeaponName == BulletData.cow)
            {
                PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Cow);
            }
            else if (bulletData.currentWeaponName == BulletData.crystal)
            {
                PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Crystal);
            }
            else if (bulletData.currentWeaponName == BulletData.demon)
            {
                PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Demon);
            }
            else if (bulletData.currentWeaponName == BulletData.ice)
            {
                PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Ice);
            }
            else if (bulletData.currentWeaponName == BulletData.electro)
            {
                PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Electro);
            }
            else if (bulletData.currentWeaponName == BulletData.axe)
            {
                PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Axe);
            }
            else if (bulletData.currentWeaponName == BulletData.pistol)
            {
                PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(PlayerSoundEffect.ShootSoundEffectTypes.Pistol);
            }
        }
    }

    public void SwordSoundTypeState()
    {
        if (bulletData)
        {
            if (bulletData.currentSwordName == BulletData.lowSword)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.LowSword);
            }
            else if (bulletData.currentSwordName == BulletData.warriorSword)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.WarriorSword);
            }
            else if (bulletData.currentSwordName == BulletData.hummer)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.Hummer);
            }
            else if (bulletData.currentSwordName == BulletData.orcSword)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.OrcSword);
            }
            else if (bulletData.currentSwordName == BulletData.axeSword)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.AxeSword);
            }
            else if (bulletData.currentSwordName == BulletData.axeKnight)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.AxeKnight);
            }
            else if (bulletData.currentSwordName == BulletData.barbarianSword)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.BarbarianSword);
            }
            else if (bulletData.currentSwordName == BulletData.demonSword)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.DemonSword);
            }
            else if (bulletData.currentSwordName == BulletData.magicSword)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.MagicSword);
            }
            else if (bulletData.currentSwordName == BulletData.longHummer)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.LongHummer);
            }
            else if (bulletData.currentSwordName == BulletData.club)
            {
                PlayerSoundEffect.GetInstance.SwordSoundEffectStatement(PlayerSoundEffect.SwordSoundEffectTypes.Club);
            }
        }
    }
    IEnumerator Delay(float delayValue, int objectPoolCount)
    {        
        
        if (objectPoolCount == _playerData.playerWeaponBulletObjectPoolCount)
        {//WeaponBullet
            if (_currentWeaponObject)
            {
                _currentWeaponObject.SetActive(true);
            }

            if (_currentSwordObject)
            {
                _currentSwordObject.SetActive(false);
            }
            
            yield return new WaitForSeconds(delayValue);
            if (_playerData.bulletAmount <= 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
            }
            else
            {
                WeaponSoundTypeState();

                if (_bulletSpawnTransform && _objectPool)
                {
                    CreatePlayerBullet(_bulletSpawnTransform, bulletData.bulletSpeed, objectPoolCount, _objectPool, 0f, 1f);

                    isCreatedWeaponBullet = true;
                }
            }
            //PlayerManager.GetInstance._currentCamera.transform.position.x
           /* _bulletSpawnTransform.position = new Vector3(_bulletSpawnTransform.transform.position.x, 
                                                         _bulletSpawnTransform.transform.position.y, 
                                                         _bulletSpawnTransform.transform.position.z);*/
            bulletData.bulletDelayCounter = 0;
        }
        
    }
}
