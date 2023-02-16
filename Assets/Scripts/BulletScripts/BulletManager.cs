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
        _pistolObject = Instantiate(bulletData._pistolObject, 
                                    _bulletSpawnTransform.position, 
                                    Quaternion.identity, 
                                    PlayerManager.GetInstance._gunTransform);//Bullet

        _swordObject = Instantiate(bulletData._swordObject, 
                                   _bulletSpawnTransform.position, 
                                   Quaternion.identity, 
                                   PlayerManager.GetInstance._swordTransform);//Bullet

        _swordObject.SetActive(false);
        _pistolObject.SetActive(false);
        _swordObject.transform.position = PlayerManager.GetInstance._swordTransform.position;
        _pistolObject.transform.position = PlayerManager.GetInstance._gunTransform.position;

        _swordObject.transform.rotation = PlayerManager.GetInstance._swordTransform.rotation;
        _pistolObject.transform.rotation = PlayerManager.GetInstance._gunTransform.rotation;

        bulletData.bulletDelayCounter = 0;
        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;
    }
    void FixedUpdate()
    {//Bullet Sound Opening With Fix Because Of This Method

        BulletRotation(_playerData.isLookingUp, 
                       PlayerManager.GetInstance._currentCamera.transform.GetComponent<CinemachineVirtualCamera>(), 
                       _bulletSpawnTransform);

        if (_playerData.isFiring && !_playerData.isSword && bulletData.bulletDelayCounter == 0)
        {
            bulletData.bulletDelayCounter++;            
            StartCoroutine(Delay(bulletData.bulletDelay, 0));
        }
        if (_playerData.isSword && !_playerData.isFiring && bulletData.bulletDelayCounter == 0 && _playerData.isTime)
        {
            bulletData.bulletDelayCounter++;
            StartCoroutine(Delay(bulletData.bulletDelay, 2));
        }
    }

    IEnumerator Delay(float delayValue, int objectPoolCount)
    {
        if (objectPoolCount == 2 && !_pistolObject.active)
        {
            yield return new WaitForSeconds(1);
            _swordObject.SetActive(true);
            yield return new WaitForSeconds(delayValue);
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Sword);
            _bulletSpawnTransform.position = new Vector3(PlayerManager.GetInstance._currentCamera.transform.position.x, _bulletSpawnTransform.transform.position.y, _bulletSpawnTransform.transform.position.z);
            CreateBullet(_bulletSpawnTransform, bulletData.bulletSpeed, objectPoolCount, PlayerManager.GetInstance._objectPool, 1f);
            bulletData.bulletDelayCounter = 0;
            yield return new WaitForSeconds(delayValue * 50f);
            _swordObject.SetActive(false);
        }
        else if(!_swordObject.active)
        {
            _pistolObject.SetActive(true);
            yield return new WaitForSeconds(delayValue);
            PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Shoot);
            _bulletSpawnTransform.position = new Vector3(PlayerManager.GetInstance._currentCamera.transform.position.x, _bulletSpawnTransform.transform.position.y, _bulletSpawnTransform.transform.position.z);
            CreateBullet(_bulletSpawnTransform, bulletData.bulletSpeed, objectPoolCount, PlayerManager.GetInstance._objectPool, 2f);
            bulletData.bulletDelayCounter = 0;
            yield return new WaitForSeconds(delayValue * 50f);
            _pistolObject.SetActive(false);
        }
        
    }

}
