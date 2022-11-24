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
        GameObject bulletObject = Instantiate(_bulletObject, gameObject.transform);
        bulletObject.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.TransformDirection(Vector3.up * _bulletSpeed), ForceMode.Force);
        StartCoroutine(DelayDestroy(bulletObject));

        //StartCoroutine(DelaySpawn());
    }
    public IEnumerator DelayDestroy(GameObject value)
    {
        yield return new WaitForSeconds(3f);
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
