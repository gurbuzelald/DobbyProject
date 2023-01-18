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

    void Start()
    {
        bulletData._pistolObject.SetActive(false);
        bulletData.bulletDelayCounter = 0;
        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;
    }
    void FixedUpdate()
    {
        BulletRotation(_playerData.isLookingUp, PlayerManager.GetInstance._currentCamera.transform.GetComponent<CinemachineVirtualCamera>(), _bulletSpawnTransform);

        if (_playerData.isFiring && bulletData.bulletDelayCounter == 0)
        {
            bulletData.bulletDelayCounter++;            
            StartCoroutine(Delay(bulletData.bulletDelay));
        }
    }

    IEnumerator Delay(float delayValue)
    {
        bulletData._pistolObject.SetActive(true);
        yield return new WaitForSeconds(delayValue);
        PlayerSoundEffect.GetInstance.SoundEffectStatement(PlayerSoundEffect.SoundEffectTypes.Shoot);
        _bulletSpawnTransform.position = new Vector3(PlayerManager.GetInstance._currentCamera.transform.position.x, _bulletSpawnTransform.transform.position.y, _bulletSpawnTransform.transform.position.z);
        CreateBullet(_bulletSpawnTransform, bulletData.bulletSpeed, 0, PlayerManager.GetInstance._objectPool);
        bulletData.bulletDelayCounter = 0;
        yield return new WaitForSeconds(delayValue*50f);
        bulletData._pistolObject.SetActive(false);
    }

}
