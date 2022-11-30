using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] GameObject[] _coinList;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < _coinList.Length; i++)
        {
            _coinList[i].transform.Rotate(90f * Time.deltaTime, 0f, 0f);
        }
    }
}
