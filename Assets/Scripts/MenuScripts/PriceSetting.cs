using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PriceSetting : MonoBehaviour
{
    [SerializeField] PlayerData playerData;    
    [SerializeField] BulletData bulletData;    

    private PlayerData.CharacterNames[] characterNames = new PlayerData.CharacterNames[12];
    private BulletData.WeaponNames[] weaponNames = new BulletData.WeaponNames[10];


    public GameObject[] characterStaffs;
    public GameObject[] weaponStaffs;
    public GameObject[] weaponPriceTexts;
    public TextMeshProUGUI[] characterPriceTexts;

    private void Awake()
    {

        SetWeaponNames();
        SetWeaponPrices();

        SetCharacterNames();
        SetCharacterPrices();        
    }
    
    void SetCharacterNames()
    {
        if (characterStaffs.Length != 0)
        {
            for (int i = 0; i < characterStaffs.Length; i++)
            {
                characterNames[i] = Enum.Parse<PlayerData.CharacterNames>(characterStaffs[i].transform.GetChild(0).name);
            }
        }        
    }
    void SetWeaponNames()
    {

        if (weaponStaffs.Length != 0)
        {
            for (int i = 0; i < weaponStaffs.Length; i++)
            {
                weaponNames[i] = Enum.Parse<BulletData.WeaponNames>(weaponStaffs[i].transform.GetChild(0).name);
            }            

        }
    }
    void SetWeaponPrices()
    {
        if (weaponStaffs.Length != 0)
        {
            for (int i = 0; i < weaponStaffs.Length; i++)
            {
                switch (weaponNames[i])
                {
                    case BulletData.WeaponNames.pistol:
                        if (BulletData.locked == bulletData.pistolLock)
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = bulletData.pistolPrice.ToString() + " Coin";
                        }
                        else
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.axe:
                        if (BulletData.locked == bulletData.axeLock)
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = bulletData.axePrice.ToString() + " Coin";
                        }
                        else
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.bulldog:
                        if (BulletData.locked == bulletData.bulldogLock)
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = bulletData.bulldogPrice.ToString() + " Coin";
                        }
                        else
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.cow:
                        if (BulletData.locked == bulletData.cowLock)
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = bulletData.cowPrice.ToString() + " Coin";
                        }
                        else
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.crystal:
                        if (BulletData.locked == bulletData.crystalLock)
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = bulletData.crystalPrice.ToString() + " Coin";
                        }
                        else
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.demon:
                        if (BulletData.locked == bulletData.demonLock)
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = bulletData.demonPrice.ToString() + " Coin";
                        }
                        else
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.ice:
                        if (BulletData.locked == bulletData.iceLock)
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = bulletData.icePrice.ToString() + " Coin";
                        }
                        else
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.negev:
                        if (BulletData.locked == bulletData.negevLock)
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = bulletData.negevPrice.ToString() + " Coin";
                        }
                        else
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    
                    case BulletData.WeaponNames.ak47:
                        if (BulletData.locked == bulletData.ak47Lock)
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = bulletData.ak47Price.ToString() + " Coin";
                        }
                        else
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.m4a4:
                        if (BulletData.locked == bulletData.m4a4Lock)
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = bulletData.m4a4Price.ToString() + " Coin";
                        }
                        else
                        {
                            weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    default:
                        weaponPriceTexts[i].transform.GetComponent<TextMeshProUGUI>().text= "No Valid";
                        break;

                }
            }
        }
    }
    void SetCharacterPrices()
    {
        if (characterStaffs.Length != 0)
        {
            for (int i = 0; i < characterPriceTexts.Length; i++)
            {
                switch (characterNames[i])
                {
                    case PlayerData.CharacterNames.Joleen:
                        if (playerData.locked == playerData.joleenLock)
                        {
                            characterPriceTexts[i].text = playerData.joleenPrice.ToString() + " Coin";

                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    case PlayerData.CharacterNames.Dobby:
                        if (playerData.locked == playerData.dobbyLock)
                        {
                            characterPriceTexts[i].text = playerData.dobbyPrice.ToString() + " Coin";
                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    case PlayerData.CharacterNames.Glassy:
                        if (playerData.locked == playerData.glassyLock)
                        {
                            characterPriceTexts[i].text = playerData.glassyPrice.ToString() + " Coin";
                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    case PlayerData.CharacterNames.Lusth:
                        if (playerData.locked == playerData.lusthLock)
                        {
                            characterPriceTexts[i].text = playerData.lusthPrice.ToString() + " Coin";
                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    case PlayerData.CharacterNames.Guard:
                        if (playerData.locked == playerData.guardLock)
                        {
                            characterPriceTexts[i].text = playerData.guardPrice.ToString() + " Coin";
                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    case PlayerData.CharacterNames.Michelle:
                        if (playerData.locked == playerData.michelleLock)
                        {
                            characterPriceTexts[i].text = playerData.michellePrice.ToString() + " Coin";
                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    case PlayerData.CharacterNames.Eve:
                        if (playerData.locked == playerData.eveLock)
                        {
                            characterPriceTexts[i].text = playerData.evePrice.ToString() + " Coin";
                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    case PlayerData.CharacterNames.Aj:
                        if (playerData.locked == playerData.ajLock)
                        {
                            characterPriceTexts[i].text = playerData.ajPrice.ToString() + " Coin";
                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    case PlayerData.CharacterNames.Boss:
                        if (playerData.locked == playerData.bossLock)
                        {
                            characterPriceTexts[i].text = playerData.bossPrice.ToString() + " Coin";
                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    case PlayerData.CharacterNames.Ty:
                        if (playerData.locked == playerData.tyLock)
                        {
                            characterPriceTexts[i].text = playerData.tyPrice.ToString() + " Coin";
                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    case PlayerData.CharacterNames.Mremireh:
                        if (playerData.locked == playerData.mremirehLock)
                        {
                            characterPriceTexts[i].text = playerData.mremirehPrice.ToString() + " Coin";
                        }
                        else
                        {
                            characterPriceTexts[i].text = "";
                        }
                        break;
                    default:
                        characterPriceTexts[i].text = "No Valid";
                        break;

                }
            }
        }
    }
}
