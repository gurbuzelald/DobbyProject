using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletManager : AbstractBullet<BulletManager>
{
    [Header("Bullet Transform")]
    [SerializeField] Transform _bulletSpawnTransform;

    [Header("Data")]
    public BulletData bulletData;
    public PlayerData _playerData;

    [Header("Initial Transform of This")]
    private Transform _initTransform;

    private GameObject _pistolObject;
    private GameObject _swordObject;

    void Start()
    {
        CreatePistolObject();

        CreateSwordObject();

        bulletData.bulletDelayCounter = 0;
        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;
    }
    void CreateSwordObject()
    {
        if (BulletData.SwordNames.lowSword == bulletData.currentSwordName)
        {
            _swordObject = Instantiate(bulletData._lowSword,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);

            _swordObject.SetActive(false);

            _swordObject.transform.position = PlayerManager.GetInstance._swordTransform.position;

            _swordObject.transform.rotation = PlayerManager.GetInstance._swordTransform.rotation;
        }
        else if (BulletData.SwordNames.warriorSword == bulletData.currentSwordName)
        {
            _swordObject = Instantiate(bulletData._warriorSwordObject,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);

            _swordObject.SetActive(false);

            _swordObject.transform.position = PlayerManager.GetInstance._swordTransform.position;

            //_swordObject.transform.rotation = PlayerManager.GetInstance._swordTransform.rotation;
        }
        else if (BulletData.SwordNames.hummer == bulletData.currentSwordName)
        {
            _swordObject = Instantiate(bulletData._hummer,
                                   _bulletSpawnTransform.position,
                                   Quaternion.identity,
                                   PlayerManager.GetInstance._swordTransform);

            _swordObject.SetActive(false);

            _swordObject.transform.position = PlayerManager.GetInstance._swordTransform.position;

            //_swordObject.transform.rotation = PlayerManager.GetInstance._swordTransform.rotation;
        }
    }
    void CreatePistolObject()
    {
        _pistolObject = Instantiate(bulletData._pistolObject,
                                    _bulletSpawnTransform.position,
                                    Quaternion.identity,
                                    PlayerManager.GetInstance._gunTransform);

        _pistolObject.SetActive(false);

        _pistolObject.transform.position = PlayerManager.GetInstance._gunTransform.position;

        _pistolObject.transform.rotation = PlayerManager.GetInstance._gunTransform.rotation;
    }
    void FixedUpdate()
    {//Bullet Sound Opening With Fix Because Of This Method


        BulletRotation(_playerData.isLookingUp, 
                       PlayerManager.GetInstance._currentCamera.transform.GetComponent<CinemachineVirtualCamera>(), 
                       _bulletSpawnTransform);

        if (_playerData.isFiring && !_playerData.isSwording && bulletData.bulletDelayCounter == 0)
        {
            bulletData.bulletDelayCounter++;            
            StartCoroutine(Delay(bulletData.bulletDelay, 0));
        }
        if (_playerData.isSwording && !_playerData.isFiring && bulletData.bulletDelayCounter == 0 && _playerData.isSwordTime)
        {
            bulletData.bulletDelayCounter++;
            StartCoroutine(Delay(bulletData.bulletDelay, 2));
        }
        
    }

    IEnumerator Delay(float delayValue, int objectPoolCount)
    {
        if (objectPoolCount == 2)
        {
            yield return new WaitForSeconds(1);
            _swordObject.SetActive(true);
            yield return new WaitForSeconds(delayValue);
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Sword);
            _bulletSpawnTransform.position = new Vector3(PlayerManager.GetInstance._currentCamera.transform.position.x, _bulletSpawnTransform.transform.position.y, _bulletSpawnTransform.transform.position.z);
            CreateBullet(_bulletSpawnTransform, bulletData.bulletSpeed, objectPoolCount, PlayerManager.GetInstance._objectPool, 1f);
            bulletData.bulletDelayCounter = 0;
            yield return new WaitForSeconds(delayValue * 50f);
            //_swordObject.SetActive(false);
        }
        else
        {
            _pistolObject.SetActive(true);
            _swordObject.SetActive(false);
            yield return new WaitForSeconds(delayValue);
            if (_playerData.fireCounter <= 0)
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.NonShoot);
            }
            else
            {
                PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Shoot);
            }
            _bulletSpawnTransform.position = new Vector3(PlayerManager.GetInstance._currentCamera.transform.position.x, 
                                                         _bulletSpawnTransform.transform.position.y, 
                                                         _bulletSpawnTransform.transform.position.z);
            if (_playerData.fireCounter >= 0)
            {
                CreateBullet(_bulletSpawnTransform, bulletData.bulletSpeed, objectPoolCount, PlayerManager.GetInstance._objectPool, 2f);
            }
            bulletData.bulletDelayCounter = 0;
            yield return new WaitForSeconds(delayValue * 50f);
            _pistolObject.SetActive(false);
            yield return new WaitForSeconds(3f);
            _swordObject.SetActive(true);
        }
        
    }

}
