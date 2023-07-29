using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject bulletCoinObject;
    [SerializeField] Transform bulletCoinTransform;
    [SerializeField] Transform[] bulletCoinTransformPos;

    [SerializeField] GameObject healthCoinObject;
    [SerializeField] Transform healthCoinTransform;
    [SerializeField] Transform[] healthCoinTransformPos;

    private GameObject currentBulletCoinObject;
    private GameObject currentHealthCoinObject;

    [SerializeField] PlayerData playerData;

    [SerializeField] GameObject[] _mapCoins;
    private GameObject currentMapCoins;

    void Start()
    {
        if (playerData.currentMapName == PlayerData.MapNames.FirstMap)
        {
            currentMapCoins = Instantiate(_mapCoins[0], gameObject.transform);
        }
        else if (playerData.currentMapName == PlayerData.MapNames.SecondMap)
        {
            currentMapCoins = Instantiate(_mapCoins[1], gameObject.transform);
        }
        else if (playerData.currentMapName == PlayerData.MapNames.ThirdMap)
        {
            currentMapCoins = Instantiate(_mapCoins[2], gameObject.transform);
        }
        else if (playerData.currentMapName == PlayerData.MapNames.FourthMap)
        {
            currentMapCoins = Instantiate(_mapCoins[3], gameObject.transform);
        }


        for (int i = 0; i < bulletCoinTransformPos.Length; i++)
        {
            currentBulletCoinObject = Instantiate(bulletCoinObject, bulletCoinTransformPos[i].position, Quaternion.identity, bulletCoinTransform.transform);
        }
        for (int i = 0; i < healthCoinTransformPos.Length; i++)
        {
            currentHealthCoinObject = Instantiate(healthCoinObject, healthCoinTransformPos[i].position, Quaternion.identity, healthCoinTransform.transform);
        }
    }
    void Update()
    {
        
        

        
    }
    public void CreateSecondCoin()
    {
        Destroy(currentMapCoins);
        currentMapCoins = Instantiate(_mapCoins[1], gameObject.transform);

        for (int i = 0; i < bulletCoinTransformPos.Length; i++)
        {
            Destroy(currentBulletCoinObject);
            currentBulletCoinObject = Instantiate(bulletCoinObject, bulletCoinTransformPos[i].position, Quaternion.identity, bulletCoinTransform.transform);
        }

        for (int i = 0; i < healthCoinTransformPos.Length; i++)
        {
            Destroy(currentHealthCoinObject);
            currentHealthCoinObject = Instantiate(healthCoinObject, healthCoinTransformPos[i].position, Quaternion.identity, healthCoinTransform.transform);
        }
    }
    public void CreateThirdCoin()
    {
        Destroy(currentMapCoins);
        currentMapCoins = Instantiate(_mapCoins[2], gameObject.transform);

        for (int i = 0; i < bulletCoinTransformPos.Length; i++)
        {
            Destroy(currentBulletCoinObject);
            currentBulletCoinObject = Instantiate(bulletCoinObject, bulletCoinTransformPos[i].position, Quaternion.identity, bulletCoinTransform.transform);
        }

        for (int i = 0; i < healthCoinTransformPos.Length; i++)
        {
            Destroy(currentHealthCoinObject);
            currentHealthCoinObject = Instantiate(healthCoinObject, healthCoinTransformPos[i].position, Quaternion.identity, healthCoinTransform.transform);
        }
    }
    public void CreateFourthCoin()
    {
        Destroy(currentMapCoins);
        currentMapCoins = Instantiate(_mapCoins[3], gameObject.transform);

        for (int i = 0; i < bulletCoinTransformPos.Length; i++)
        {
            Destroy(currentBulletCoinObject);
            currentBulletCoinObject = Instantiate(bulletCoinObject, bulletCoinTransformPos[i].position, Quaternion.identity, bulletCoinTransform.transform);
        }

        for (int i = 0; i < healthCoinTransformPos.Length; i++)
        {
            Destroy(currentHealthCoinObject);
            currentHealthCoinObject = Instantiate(healthCoinObject, healthCoinTransformPos[i].position, Quaternion.identity, healthCoinTransform.transform);
        }
    }
}
