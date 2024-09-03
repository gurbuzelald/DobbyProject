using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [Header("Rotaters")]
    public GameObject _rotaterCoinObject;
    public Transform[] _rotaterCoinTransformList;

    public GameObject _rotaterBulletCoinObject;
    public Transform[] _rotaterBulletCoinTransformList;


    [Header("Statics")]
    public GameObject _coinGroupObject;
    public Transform[] _coinGroupTransformList;

    public GameObject _cheeseObject;
    public Transform[] _cheeseTransformList;

    public GameObject _mushroomObject;
    public Transform[] _mushroomTransformList;

    public GameObject _yellowFlowerObject;
    public Transform[] _yellowFlowerTransformList;

    public GameObject _levelUpKeyObject;
    public Transform[] _levelUpKeyTransformList;


    private void Start()
    {
        CreateCoinObject(_rotaterCoinObject, _rotaterCoinTransformList);
        CreateCoinObject(_rotaterBulletCoinObject, _rotaterBulletCoinTransformList);

        CreateCoinObject(_coinGroupObject, _coinGroupTransformList);
        CreateCoinObject(_cheeseObject, _cheeseTransformList);
        CreateCoinObject(_mushroomObject, _mushroomTransformList);
        CreateCoinObject(_yellowFlowerObject, _yellowFlowerTransformList);
        CreateCoinObject(_levelUpKeyObject, _levelUpKeyTransformList);
    }

    void CreateCoinObject(GameObject coinObject, Transform[] coinTransforms)
    {
        for (int i = 0; i < coinTransforms.Length; i++)
        {
            GameObject _coinObject = Instantiate(coinObject, coinTransforms[i].position, Quaternion.identity, coinTransforms[i].transform);
            _coinObject.transform.rotation = coinObject.transform.rotation;
        }
    }
    void Update()
    {
        RotaterCoin(_rotaterCoinTransformList, 90f, 90f, 90f);
        RotaterCoin(_rotaterBulletCoinTransformList, 90f, 0f, 0f);
        RotaterCoin(_levelUpKeyTransformList, 0f, 0f, 90f);
    }
    void RotaterCoin(Transform[] rotaterTransformList, float speedX, float speedY, float speedZ)
    {
        for (int i = 0; i < rotaterTransformList.Length; i++)
        {
            rotaterTransformList[i].gameObject.transform.Rotate(speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime);
        }
    }
}
