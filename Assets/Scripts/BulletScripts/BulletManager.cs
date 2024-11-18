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

        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;

        _objectPool = GameObject.Find("ObjectPool").GetComponent<ObjectPool>();
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


    public void SetWeaponTransform()
    {
        if (PlayerManager.GetInstance._gunTransform)
        {
            for (int i = 0; i < bulletData.weaponStruct.Length; i++)
            {
                var weaponName = bulletData.weaponStruct[i].weaponName;
                if (bulletData.currentWeaponName == weaponName)
                {
                    var weaponTransform = GameObject.Find($"{weaponName}Transform");
                    if (weaponTransform)
                    {
                        PlayerManager.GetInstance._gunTransform = weaponTransform;
                    }
                    break; // Exit the loop once the matching weapon is found
                }
            }
        }
    }

    public void SetSwordTransform(GameObject pinky)//Getting finger transform parameter
    {
        if (bulletData.currentSwordName == BulletData.lowSword)
        {
            PlayerManager.GetInstance._gunTransform = GameObject.Find("lowSwordTransform");
        }
    }
    public void ChangeWeaponObject()
    {
        if (_playerData && bulletData)
        {
            if (_playerData.isWinning && _currentWeaponObject)
            {
                Destroy(_currentWeaponObject);
            }
            for (int i = 0; i < bulletData.weaponStruct.Length; i++)
            {
                HandleWeaponChange(bulletData.weaponStruct[i].weaponName, ref bulletData.weaponStruct[i].isWeapon, bulletData.weaponStruct[i].id, bulletData.weaponStruct[i].shootFrequency);
            }
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

            PlayerPrefs.SetInt("CurrentWeaponID", BulletData.currentWeaponID);

            PlayerManager.GetInstance._objectPool.SetPlayerBulletsAndExplosionsAtUpdate();

            CreateWeaponObject();
            PlayerData.currentBulletExplosionIsChanged = true;

            isWeaponActive = false;
        }
    }
    public void ChangeSwordObject()
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

        ChangeWeaponObject();
        ChangeSwordObject();

        BulletRotation(PlayerManager.GetInstance._currentCamera,
                       _bulletSpawnTransform);

        WeaponFire();

        //SetCurrentWeaponID();
       // SetCurrentSwordID();
    }

    public void SetCurrentWeaponID()
    {
        if (bulletData)
        {
            // Loop through weaponStruct and match the currentWeaponName
            for (int i = 0; i < bulletData.weaponStruct.Length; i++)
            {
                if (bulletData.currentWeaponName == bulletData.weaponStruct[i].weaponName)
                {
                    BulletData.currentWeaponID = bulletData.weaponStruct[i].id;

                    PlayerPrefs.SetInt("CurrentWeaponID", BulletData.currentWeaponID);

                    bulletData.currentWeaponName = bulletData.weaponStruct[BulletData.currentWeaponID].weaponName;

                    break; // Exit loop once the matching weapon is found
                }
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
                    CreatePlayerBullet(_bulletSpawnTransform, bulletData.weaponStruct[BulletData.currentSwordID].swordSpeed, objectPoolCount, _objectPool, 0f, delayValue);
                }
            }
        }
    }

    public void WeaponFire()
    {
        if (_playerData && bulletData)
        {
            if (_playerData.isFire && !_playerData.isSwordAnimate && _playerData.isFireTime)
            {
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
            for (int i = 0; i < bulletData.weaponStruct.Length; i++)
            {
                if (BulletData.currentWeaponID == bulletData.weaponStruct[i].id)
                {
                    bulletData.currentWeaponName = bulletData.weaponStruct[BulletData.currentWeaponID].weaponName;
                    PlayerSoundEffect.GetInstance.ShootSoundEffectStatement(bulletData.weaponStruct[i].weaponName);
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
            CreatePlayerBullet(_bulletSpawnTransform, bulletData.weaponStruct[BulletData.currentWeaponID].bulletSpeed, objectPoolCount, _objectPool, 0f, 1);
            isCreatedWeaponBullet = true;
        }
    }
}
