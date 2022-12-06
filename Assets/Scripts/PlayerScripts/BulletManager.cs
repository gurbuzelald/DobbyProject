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
    public PlayerData _playerData;

    [Header("Initial Transform of This")]
    private Transform _initTransform;



    //[SerializeField] GameObject _bulletObject;

    private void Start()
    {
        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;
    }
    private void Update()
    {
        BulletRotation(_playerData.isLookingUp, _currentCamera, _bulletSpawnTransform);

        if (_playerData.isFiring)
        {
            CreateBullet(_bulletSpawnTransform, _playerData.bulletSpeed, 0, _objectPool);
        }        
    }

    public IEnumerator DelayDestroy(GameObject gameobject)
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameobject);
    } 
    
}
