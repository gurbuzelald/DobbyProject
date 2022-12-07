using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletManager : AbstractBullet<BulletManager>
{
    [Header("Object Pool")]
    public ObjectPool _objectPool;

    [Header("Bullet Transform")]
    [SerializeField] Transform _bulletSpawnTransform;

    [Header("Rotation of Bullet from Camera")]
    [SerializeField] CinemachineVirtualCamera _currentCamera;

    [Header("Data")]
    public BulletData bulletData;
    public PlayerData _playerData;

    [Header("Initial Transform of This")]
    private Transform _initTransform;
    [SerializeField] GameObject _pistolObject;

    

    void Start()
    {
        _pistolObject.SetActive(false);
        bulletData.bulletDelayCounter = 0;
        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;
    }
    void FixedUpdate()
    {
        BulletRotation(_playerData.isLookingUp, _currentCamera, _bulletSpawnTransform);

        if (_playerData.isFiring && bulletData.bulletDelayCounter == 0)
        {
            bulletData.bulletDelayCounter++;            
            StartCoroutine(Delay(bulletData.bulletDelay));
        }
    }

    IEnumerator Delay(float delayValue)
    {
        _pistolObject.SetActive(true);
        yield return new WaitForSeconds(delayValue);
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Shoot);
        _bulletSpawnTransform.position = new Vector3(_currentCamera.transform.position.x, _bulletSpawnTransform.transform.position.y, _bulletSpawnTransform.transform.position.z);
        CreateBullet(_bulletSpawnTransform, bulletData.bulletSpeed, 0, _objectPool);
        bulletData.bulletDelayCounter = 0;
        yield return new WaitForSeconds(delayValue*50f);
        _pistolObject.SetActive(false);
    }

}
