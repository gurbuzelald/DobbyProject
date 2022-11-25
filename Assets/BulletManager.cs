using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class BulletManager : MonoBehaviour
{
    public ObjectPool _objectPool;
    public GameObject _bulletObject;
    [SerializeField] float _bulletSpeed = 5f;
    [SerializeField] Transform _gunTransform;
    [SerializeField] CinemachineVirtualCamera _virtualCamera;
    private Transform _initTransform;

    private void Start()
    {
        _initTransform = gameObject.transform;
        _initTransform.eulerAngles = gameObject.transform.eulerAngles;
    }
    private void Update()
    {
        _gunTransform.transform.eulerAngles = new Vector3(_virtualCamera.transform.eulerAngles.x - 20f, _gunTransform.transform.eulerAngles.y, _gunTransform.transform.eulerAngles.z);
    }
    public void CreateBullet()
    {
        GameObject bulletObject = Instantiate(_bulletObject, gameObject.transform);
        bulletObject.GetComponent<Rigidbody>().AddForce(_gunTransform.transform.TransformDirection(Vector3.forward * _bulletSpeed), ForceMode.Force);

        StartCoroutine(DelayDestroy(bulletObject));

        //StartCoroutine(DelaySpawn());
    }
    public IEnumerator DelayDestroy(GameObject value)
    {
        yield return new WaitForSeconds(2f);
        Destroy(value);
    }
    public IEnumerator DelaySpawn()
    {
        GameObject bulletObject = _objectPool.GetPooledObject(0);
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = gameObject.transform.rotation;

        bulletObject.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.TransformDirection(Vector3.up * _bulletSpeed), ForceMode.Force);

        yield return new WaitForSeconds(4f);
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = gameObject.transform.rotation;

        bulletObject.SetActive(false);

    }
}
