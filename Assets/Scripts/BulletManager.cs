using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletManager : MonoBehaviour
{
    public ObjectPool _objectPool;
    public GameObject _bulletObject;
    [SerializeField] float _bulletSpeed = 5f;
    [SerializeField] Transform _bulletTransform;
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    private Transform _initTransform;

    private void Start()
    {
        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;
    }
    private void Update()
    {
        BulletRotation();
    }
    public void CreateBullet()
    {
        GameObject bulletObject = Instantiate(_bulletObject, gameObject.transform);
        bulletObject.GetComponent<Rigidbody>().AddForce(_bulletTransform.transform.TransformDirection(Vector3.forward * _bulletSpeed), ForceMode.Force);

        StartCoroutine(DelayDestroy(bulletObject));

        //StartCoroutine(DelaySpawn());
    }
    public IEnumerator DelayDestroy(GameObject gameobject)
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameobject);
    }
    public IEnumerator DelaySpawn()
    {
        GameObject bulletObject = _objectPool.GetPooledObject(0);
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = gameObject.transform.rotation;

        bulletObject.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.TransformDirection(Vector3.up * _bulletSpeed), ForceMode.Force);

        yield return new WaitForSeconds(2f);
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = gameObject.transform.rotation;

        bulletObject.SetActive(false);
    }
    private void BulletRotation()
    {
        if (_virtualCamera != null)
        {
            _bulletTransform.transform.eulerAngles = new Vector3(_virtualCamera.transform.eulerAngles.x - 20f, _bulletTransform.transform.eulerAngles.y, _bulletTransform.transform.eulerAngles.z);
        }
    }
}
