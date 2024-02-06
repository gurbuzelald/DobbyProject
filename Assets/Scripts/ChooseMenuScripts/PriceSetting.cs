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


    private GameObject characterStaffs;
    private GameObject weaponStaffs;

    private void Awake()
    {
        characterStaffs = GameObject.Find("CharacterStaffs");
        weaponStaffs = GameObject.Find("WeaponStaffs");

        SetWeaponNames();
        SetWeaponPrices();

        SetCharacterNames();
        SetCharacterPrices();        
    }
    
    void SetCharacterNames()
    {
        if (characterStaffs)
        {
            for (int i = 0; i < characterStaffs.transform.childCount; i++)
            {
                characterNames[i] = Enum.Parse<PlayerData.CharacterNames>(characterStaffs.transform.GetChild(i).GetChild(0).name);
            }
        }        
    }
    void SetWeaponNames()
    {

        if (weaponStaffs)
        {
            for (int i = 0; i < weaponStaffs.transform.childCount; i++)
            {
                weaponNames[i] = Enum.Parse<BulletData.WeaponNames>(weaponStaffs.transform.GetChild(i).GetChild(0).name);
            }
            

        }
    }
    void SetWeaponPrices()
    {
        if (weaponStaffs)
        {
            for (int i = 0; i < weaponStaffs.transform.childCount; i++)
            {
                switch (weaponNames[i])
                {
                    case BulletData.WeaponNames.ak47:
                        if (BulletData.locked == bulletData.ak47Lock)
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.ak47Price.ToString() + " Coin";
                        }
                        else
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.axegun:
                        if (BulletData.locked == bulletData.axeLock)
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.axegunPrice.ToString() + " Coin";
                        }
                        else
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.bulldog:
                        if (BulletData.locked == bulletData.bulldogLock)
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.bulldogPrice.ToString() + " Coin";
                        }
                        else
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.cowgun:
                        if (BulletData.locked == bulletData.cowLock)
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.cowgunPrice.ToString() + " Coin";
                        }
                        else
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.crystalgun:
                        if (BulletData.locked == bulletData.crystalLock)
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.crystalgunPrice.ToString() + " Coin";
                        }
                        else
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.demongun:
                        if (BulletData.locked == bulletData.demonLock)
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.demongunPrice.ToString() + " Coin";
                        }
                        else
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.icegun:
                        if (BulletData.locked == bulletData.iceLock)
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.icegunPrice.ToString() + " Coin";
                        }
                        else
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.negev:
                        if (BulletData.locked == bulletData.negevLock)
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.negevPrice.ToString() + " Coin";
                        }
                        else
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.pistol:
                        if (BulletData.locked == bulletData.pistolLock)
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.pistolPrice.ToString() + " Coin";
                        }
                        else
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "";
                        }
                        break;
                    case BulletData.WeaponNames.rifle:
                        if (BulletData.locked == bulletData.rifleLock)
                        {
                            gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.riflePrice.ToString() + " Coin";
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
    void SetCharacterPrices()
    {
        if (characterStaffs)
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
}
