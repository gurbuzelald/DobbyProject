using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public ObjectPool _objectPool;
    public GameObject _bulletObject;
    [SerializeField] float _bulletSpeed = 5f;
    [SerializeField] Transform _dobbyTransform;

    private void Start()
    {
    }
    public void CreateBullet()
    {
        StartCoroutine(DelaySpawn());
    }
    public IEnumerator DelaySpawn()
    {
        GameObject bulletObject = _objectPool.GetPooledObject(0);
        bulletObject.transform.position = gameObject.transform.position;
        bulletObject.transform.rotation = gameObject.transform.rotation;
        bulletObject.GetComponent<Rigidbody>().AddForce(transform.TransformDirection(Vector3.up * _bulletSpeed));

        yield return new WaitForSeconds(5f);
        bulletObject.SetActive(false);

    }
}
