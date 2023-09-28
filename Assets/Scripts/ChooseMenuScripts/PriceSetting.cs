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

    private void Awake()
    {
        characterStaffs = GameObject.Find("CharacterStaffs");
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
                    if (playerData.locked == playerData.spartacusLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.spartacusPrice.ToString() + " Coin";

                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case PlayerData.CharacterNames.Dobby:
                    if (playerData.locked == playerData.dobbyLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.dobbyPrice.ToString() + " Coin";
                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case PlayerData.CharacterNames.Glassy:
                    if (playerData.locked == playerData.glassyLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.glassyPrice.ToString() + " Coin";
                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case PlayerData.CharacterNames.Lusth:
                    if (playerData.locked == playerData.lusthLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.lusthPrice.ToString() + " Coin";
                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case PlayerData.CharacterNames.Guard:
                    if (playerData.locked == playerData.guardLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.guardPrice.ToString() + " Coin";
                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case PlayerData.CharacterNames.Michelle:
                    if (playerData.locked == playerData.michelleLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.michellePrice.ToString() + " Coin";
                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case PlayerData.CharacterNames.Eve:
                    if (playerData.locked == playerData.eveLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.evePrice.ToString() + " Coin";
                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case PlayerData.CharacterNames.Aj:
                    if (playerData.locked == playerData.ajLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.ajPrice.ToString() + " Coin";
                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case PlayerData.CharacterNames.Boss:
                    if (playerData.locked == playerData.bossLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.bossPrice.ToString() + " Coin";
                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case PlayerData.CharacterNames.Ty:
                    if (playerData.locked == playerData.tyLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.tyPrice.ToString() + " Coin";
                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                case PlayerData.CharacterNames.Mremireh:
                    if (playerData.locked == playerData.mremirehLock)
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.mremirehPrice.ToString() + " Coin";
                    }
                    else
                    {
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                    }
                    break;
                default:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "No Valid";
                    break;

            }
        }
    }
}
