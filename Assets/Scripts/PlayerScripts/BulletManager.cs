using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletManager : MonoBehaviour
{
    [Header("Object Pool")]
    public ObjectPool _objectPool;

    [Header("Bullet Transform")]
    [SerializeField] Transform _bulletSpawnTransform;

    [Header("Rotation of Bullet from Camera")]
    [SerializeField] CinemachineVirtualCamera _currentCamera;
    [SerializeField] CinemachineVirtualCamera _upCamera;
    [SerializeField] CinemachineVirtualCamera _downCamera;

    [Header("Data")]
    public PlayerData _playerData;

    [Header("Initial Transform of This")]
    private Transform _initTransform;

    private void Start()
    {
        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;
    }
    private void Update()
    {
        if (gameObject.transform.name == "Bullets")
        {
            BulletRotation();
        }
    }
    public void CreateBullet()
    {
        //GameObject bulletObject = Instantiate(_bulletObject, _bulletTransform.transform.position, _bulletTransform.transform.rotation);
        //bulletObject.GetComponent<Rigidbody>().velocity = (_bulletTransform.transform.TransformDirection(Vector3.forward * _bulletSpeed));

        //StartCoroutine(DelayDestroy(bulletObject));

        StartCoroutine(DelaySpawn(_bulletSpawnTransform, _playerData.bulletSpeed, 0));
    }
    public IEnumerator DelayDestroy(GameObject gameobject)
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameobject);
    }
    public IEnumerator DelaySpawn(Transform bulletSpawn, float bulletSpeed, int objectpoolCount)
    {
        GameObject bulletObject = _objectPool.GetPooledObject(objectpoolCount);
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = bulletSpawn.rotation;

        bulletObject.GetComponent<Rigidbody>().velocity = (bulletSpawn.TransformDirection(Vector3.forward * bulletSpeed));

        yield return new WaitForSeconds(2f);
        bulletObject.transform.rotation = bulletSpawn.rotation;

        bulletObject.SetActive(false);
    }
    private void BulletRotation()
    {
        if (_playerData.isLookingUp)
        {
            _upCamera.gameObject.SetActive(true);
            _downCamera.gameObject.SetActive(false);
            _currentCamera = _upCamera;
        }
        else
        {
            _downCamera.gameObject.SetActive(true);
            _upCamera.gameObject.SetActive(false);
            _currentCamera = _downCamera;
        }
        if (_currentCamera != null)
        {
            _bulletSpawnTransform.transform.eulerAngles = new Vector3(_currentCamera.transform.eulerAngles.x - 20f, _bulletSpawnTransform.transform.eulerAngles.y, _bulletSpawnTransform.transform.eulerAngles.z);
        }
    }
}
