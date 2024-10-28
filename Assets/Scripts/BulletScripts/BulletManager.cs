using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Cinemachine;
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
        if (bulletData.weaponStruct[1].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.weaponStruct[1].lockState = BulletData.locked;
        }
        if (bulletData.weaponStruct[2].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.weaponStruct[2].lockState = BulletData.locked;
        }
        if (bulletData.weaponStruct[3].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.weaponStruct[3].lockState = BulletData.locked;
        }
        if (bulletData.weaponStruct[4].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.weaponStruct[4].lockState = BulletData.locked;
        }
        if (bulletData.weaponStruct[5].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.weaponStruct[5].lockState = BulletData.locked;
        }
        if (bulletData.weaponStruct[6].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.weaponStruct[6].lockState = BulletData.locked;
        }
        if (bulletData.weaponStruct[7].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.weaponStruct[7].lockState = BulletData.locked;
        }
        if (bulletData.weaponStruct[8].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.weaponStruct[8].lockState = BulletData.locked;
        }
        if (bulletData.weaponStruct[9].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;

            bulletData.weaponStruct[9].lockState = BulletData.locked;
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
            _currentSwordObject.SetActive(false);
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
            // Find the weapon in the weaponStruct by matching the current weapon name
            for (int i = 0; i < bulletData.weaponStruct.Length; i++)
            {
                if (bulletData.currentWeaponName == bulletData.weaponStruct[i].weaponName)
                {
                    // Instantiate the weapon object and update its properties
                    _currentWeaponObject = Instantiate(
                        bulletData.weaponStruct[i].weaponObject,
                        _bulletSpawnTransform.position,
                        Quaternion.identity,
                        PlayerManager.GetInstance._gunTransform.transform
                    );

                    bulletData.currentShootFrequency = bulletData.weaponStruct[i].shootFrequency;
                    bulletData.currentBulletPackAmount = bulletData.weaponStruct[i].bulletPackAmount;

                    break; // Exit loop once the matching weapon is found
                }
            }

            if (_currentWeaponObject)
            {
                _currentWeaponObject.SetActive(true);

                if (PlayerManager.GetInstance._gunTransform)
                {
                    // Position and rotate the weapon to match the gun's transform
                    _currentWeaponObject.transform.position = PlayerManager.GetInstance._gunTransform.transform.position;
                    _currentWeaponObject.transform.rotation = PlayerManager.GetInstance._gunTransform.transform.rotation;
                }
            }
            else
            {
                Debug.Log("Check current weapon name");
            }
        }
    }


    public void SetWeaponTransform()//Getting finger transform parameter
    {
        if (PlayerManager.GetInstance._gunTransform)
        {
            if (bulletData.currentWeaponName == bulletData.weaponStruct[8].weaponName)
            {
                if (GameObject.Find("ShotGunTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("ShotGunTransform");
                }
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[9].weaponName)
            {
                if (GameObject.Find("MachineTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("MachineTransform");
                }
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[2].weaponName)
            {
                if (GameObject.Find("BulldogTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("BulldogTransform");
                }
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[3].weaponName)
            {
                if (GameObject.Find("CowTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("CowTransform");
                }
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[4].weaponName)
            {
                if (GameObject.Find("CrystalTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("CrystalTransform");
                }
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[5].weaponName)
            {
                if (GameObject.Find("DemonTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("DemonTransform");
                }
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[6].weaponName)
            {
                if (GameObject.Find("IceTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("IceTransform");
                }
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[7].weaponName)
            {
                if (GameObject.Find("ElectroTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("ElectroTransform");
                }
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[1].weaponName)
            {
                if (GameObject.Find("AxeTransform"))
                {
                    PlayerManager.GetInstance._gunTransform = GameObject.Find("AxeTransform");
                }
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[0].weaponName)
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

            HandleWeaponChange(bulletData.weaponStruct[9].weaponName, ref bulletData.weaponStruct[9].isWeapon, bulletData.weaponStruct[9].id, bulletData.weaponStruct[9].shootFrequency);
            HandleWeaponChange(bulletData.weaponStruct[8].weaponName, ref bulletData.weaponStruct[8].isWeapon, bulletData.weaponStruct[8].id, bulletData.weaponStruct[8].shootFrequency);
            HandleWeaponChange(bulletData.weaponStruct[1].weaponName, ref bulletData.weaponStruct[1].isWeapon, bulletData.weaponStruct[1].id, bulletData.weaponStruct[1].shootFrequency);
            HandleWeaponChange(bulletData.weaponStruct[7].weaponName, ref bulletData.weaponStruct[7].isWeapon, bulletData.weaponStruct[7].id, bulletData.weaponStruct[7].shootFrequency);
            HandleWeaponChange(bulletData.weaponStruct[4].weaponName, ref bulletData.weaponStruct[4].isWeapon, bulletData.weaponStruct[4].id, bulletData.weaponStruct[4].shootFrequency);
            HandleWeaponChange(bulletData.weaponStruct[5].weaponName, ref bulletData.weaponStruct[5].isWeapon, bulletData.weaponStruct[5].id, bulletData.weaponStruct[5].shootFrequency);
            HandleWeaponChange(bulletData.weaponStruct[6].weaponName, ref bulletData.weaponStruct[6].isWeapon, bulletData.weaponStruct[6].id, bulletData.weaponStruct[6].shootFrequency);
            HandleWeaponChange(bulletData.weaponStruct[2].weaponName, ref bulletData.weaponStruct[2].isWeapon, bulletData.weaponStruct[2].id, bulletData.weaponStruct[2].shootFrequency);
            HandleWeaponChange(bulletData.weaponStruct[3].weaponName, ref bulletData.weaponStruct[3].isWeapon, bulletData.weaponStruct[3].id, bulletData.weaponStruct[3].shootFrequency);
            HandleWeaponChange(bulletData.weaponStruct[0].weaponName, ref bulletData.weaponStruct[0].isWeapon, bulletData.weaponStruct[0].id, bulletData.weaponStruct[0].shootFrequency);
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
            if (bulletData.currentWeaponName == bulletData.weaponStruct[0].weaponName)
            {
                BulletData.currentWeaponID = bulletData.weaponStruct[0].id;
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[1].weaponName)
            {
                BulletData.currentWeaponID = bulletData.weaponStruct[1].id;
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[2].weaponName)
            {
                BulletData.currentWeaponID = bulletData.weaponStruct[2].id;
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[3].weaponName)
            {
                BulletData.currentWeaponID = bulletData.weaponStruct[3].id;
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[4].weaponName)
            {
                BulletData.currentWeaponID = bulletData.weaponStruct[4].id;
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[5].weaponName)
            {
                BulletData.currentWeaponID = bulletData.weaponStruct[5].id;
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[6].weaponName)
            {
                BulletData.currentWeaponID = bulletData.weaponStruct[6].id;
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[7].weaponName)
            {
                BulletData.currentWeaponID = bulletData.weaponStruct[7].id;
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[8].weaponName)
            {
                BulletData.currentWeaponID = bulletData.weaponStruct[8].id;
            }
            else if (bulletData.currentWeaponName == bulletData.weaponStruct[9].weaponName)
            {
                BulletData.currentWeaponID = bulletData.weaponStruct[9].id;
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
                    _bulletSpawnTransform.position = new Vector3(PlayerManager.GetInstance._gunTransform.transform.position.x,
                                                      PlayerManager.GetInstance._gunTransform.transform.position.y + .03f,
                                                      PlayerManager.GetInstance._gunTransform.transform.position.z + .01f);
                    CreatePlayerBullet(_bulletSpawnTransform, bulletData.swordSpeed, objectPoolCount, _objectPool, 0f, delayValue);
                }
            }
        }
    }

    public void WeaponFire()
    {
        if (_playerData && bulletData)
        {
            if (_playerData.isFire && !_playerData.isSwordAnimate && bulletData.bulletDelayCounter == 0 && _playerData.isFireTime)
            {
                bulletData.bulletDelayCounter++;

                _playerData.isFireTime = false;

                StartCoroutine(Delay(bulletData.currentShootFrequency, _playerData.playerWeaponBulletObjectPoolCount));
            }
        }
    }

    public void WeaponSoundTypeState()
    {
        // Check if bulletData exists
        if (bulletData)
        {
            // Loop through the weaponStruct array to find a matching weapon
            foreach (var weapon in bulletData.weaponStruct)
            {
                if (bulletData.currentWeaponName == weapon.weaponName)
                {
                    PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(weapon.weaponName);
                    return; // Exit once a match is found to avoid unnecessary iterations
                }
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
        }
    }
    IEnumerator Delay(float delayValue, int objectPoolCount)
    {
        // Return early if objectPoolCount doesn't match player's weapon bullet object pool count
        if (objectPoolCount != _playerData.playerWeaponBulletObjectPoolCount) yield break;

        // Activate the current weapon object and deactivate the sword object if applicable
        _currentWeaponObject?.SetActive(true);
        _currentSwordObject?.SetActive(false);

        // Wait for the specified delay
        yield return new WaitForSeconds(delayValue);

        // Handle bullet availability and sound effect
        if (_playerData.bulletAmount <= 0)
        {
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
            yield break;
        }

        // Call WeaponSoundTypeState and proceed with bullet creation
        WeaponSoundTypeState();

        if (_bulletSpawnTransform && _objectPool)
        {
            _bulletSpawnTransform.position = new Vector3(PlayerManager.GetInstance._gunTransform.transform.position.x,
                                                      PlayerManager.GetInstance._gunTransform.transform.position.y + .03f,
                                                      PlayerManager.GetInstance._gunTransform.transform.position.z + .01f);
            CreatePlayerBullet(_bulletSpawnTransform, bulletData.bulletSpeed, objectPoolCount, _objectPool, 0f, 1);
            isCreatedWeaponBullet = true;
        }

        // Reset bullet delay counter
        bulletData.bulletDelayCounter = 0;
    }

}
