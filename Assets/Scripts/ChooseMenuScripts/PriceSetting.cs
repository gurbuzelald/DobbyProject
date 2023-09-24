using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PriceSetting : MonoBehaviour
{
    [SerializeField] PlayerData playerData;    

    private PlayerData.CharacterNames[] characterNames = new PlayerData.CharacterNames[12];


    private GameObject characterStaffs;
    private GameObject characterPriceErrorTextObject;

    private void Awake()
    {
        characterStaffs = GameObject.Find("CharacterStaffs");
        characterPriceErrorTextObject = GameObject.Find("CharacterPriceErrorTexts");
        SetCharacterNames();

        SetCharacterPrices();

    }
    
    void SetCharacterNames()
    {
        for (int i = 0; i < characterStaffs.transform.childCount; i++)
        {
            characterNames[i] = Enum.Parse<PlayerData.CharacterNames>(characterStaffs.transform.GetChild(i).GetChild(0).name);
        }
    }
    void SetCharacterPrices()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            switch (characterNames[i])
            {
                case PlayerData.CharacterNames.Spartacus:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.spartacusPrice.ToString() + " Coin";
                    break;
                case PlayerData.CharacterNames.Dobby:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.dobbyPrice.ToString() + " Coin";
                    break;
                case PlayerData.CharacterNames.Glassy:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.glassyPrice.ToString() + " Coin";
                    break;
                case PlayerData.CharacterNames.Lusth:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.lusthPrice.ToString() + " Coin";
                    break;
                case PlayerData.CharacterNames.Guard:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.guardPrice.ToString() + " Coin";
                    break;
                case PlayerData.CharacterNames.Michelle:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.michellePrice.ToString() + " Coin";
                    break;
                case PlayerData.CharacterNames.Eve:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.evePrice.ToString() + " Coin";
                    break;
                case PlayerData.CharacterNames.Aj:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.ajPrice.ToString() + " Coin";
                    break;
                case PlayerData.CharacterNames.Boss:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.bossPrice.ToString() + " Coin";
                    break;
                case PlayerData.CharacterNames.Ty:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.tyPrice.ToString() + " Coin";
                    break;
                case PlayerData.CharacterNames.Mremireh:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.mremirehPrice.ToString() + " Coin";
                    break;
                default:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "No Valid";
                    break;

            }
        }
    }
}
