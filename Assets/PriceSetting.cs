using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PriceSetting : MonoBehaviour
{
    [SerializeField] PlayerData playerData;


    private void Awake()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            switch (i)
            {
                case 0:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.spartacusPrice.ToString() + " Coin";
                    break;
                case 1:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.dobbyPrice.ToString() + " Coin";
                    break;
                case 2:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.glassyPrice.ToString() + " Coin";
                    break;
                case 3:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.lusthPrice.ToString() + " Coin";
                    break;
                case 4:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.guardPrice.ToString() + " Coin";
                    break;
                case 5:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.michellePrice.ToString() + " Coin";
                    break;
                case 6:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.evePrice.ToString() + " Coin";
                    break;
                case 7:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.ajPrice.ToString() + " Coin";
                    break;
                case 8:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.bossPrice.ToString() + " Coin";
                    break;
                case 9:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.tyPrice.ToString() + " Coin";
                    break;
                case 10:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.mremirehPrice.ToString() + " Coin";
                    break;
                default:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "No Valid";
                    break;

            }
        }
    }
}
