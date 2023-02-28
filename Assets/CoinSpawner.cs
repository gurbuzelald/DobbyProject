using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] coinObject;
    private GameObject currentCoinObject;
    [SerializeField] PlayerData playerData;
    // Start is called before the first frame update
    void Awake()
    {
        currentCoinObject = Instantiate(coinObject[0], gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerData.isCompleteFirstMap)
        {
            Destroy(currentCoinObject);
            currentCoinObject = Instantiate(coinObject[1], gameObject.transform);
        }
        else if (playerData.isCompleteSecondMap)
        {
            Destroy(currentCoinObject);
            currentCoinObject = Instantiate(coinObject[2], gameObject.transform);
        }
    }
}
