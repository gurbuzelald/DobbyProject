using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public GameObject[] _coinList;
    void Update()
    {
        for (int i = 0; i < _coinList.Length; i++)
        {
            _coinList[i].transform.Rotate(90f * Time.deltaTime, 0f, 0f);
        }
    }
}
