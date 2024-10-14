using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class LockingStatement : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] BulletData bulletData;
    private ChooseCharacterController pickCharacterController;

    private PlayerData.CharacterNames[] characterNames = new PlayerData.CharacterNames[12];
    private BulletData.WeaponNames[] weaponNames = new BulletData.WeaponNames[10];

    private GameObject characterStaffs;
    private PriceSetting priceSetting;

    void Awake()
    {
        priceSetting = GameObject.FindObjectOfType<PriceSetting>();
        characterStaffs = GameObject.Find("CharacterStaffs");

        SetCharacterNames();
        SetWeaponNames();

        SetCharacterLockingMode();
        SetWeaponLockingMode(bulletData);
    }
    private void OnDisable()
    {
        gameObject.GetComponent<LockingStatement>().enabled = true;
    }
    private void Update()
    {

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
        if (priceSetting)
        {
            if (priceSetting.weaponStaffs.Length != 0)
            {
                for (int i = 0; i < priceSetting.weaponStaffs.Length; i++)
                {
                    weaponNames[i] = Enum.Parse<BulletData.WeaponNames>(priceSetting.weaponStaffs[i].transform.GetChild(0).name);
                }
            }
        }
        
    }

    void SetCharacterLockingMode()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            switch (characterNames[i])
            {
                case PlayerData.CharacterNames.Joleen:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.joleenLock.ToString();
                    break;
                case PlayerData.CharacterNames.Dobby:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.dobbyLock.ToString();
                    break;
                case PlayerData.CharacterNames.Glassy:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.glassyLock.ToString();
                    break;
                case PlayerData.CharacterNames.Lusth:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.lusthLock.ToString();
                    break;
                case PlayerData.CharacterNames.Guard:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.guardLock.ToString();
                    break;
                case PlayerData.CharacterNames.Michelle:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.michelleLock.ToString();
                    break;
                case PlayerData.CharacterNames.Eve:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.eveLock.ToString();
                    break;
                case PlayerData.CharacterNames.Aj:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.ajLock.ToString();
                    break;
                case PlayerData.CharacterNames.Boss:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.bossLock.ToString();
                    break;
                case PlayerData.CharacterNames.Ty:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.tyLock.ToString();
                    break;
                case PlayerData.CharacterNames.Mremireh:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = playerData.mremirehLock.ToString();
                    break;
                default:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "No Valid";
                    break;

            }
        }
    }
    void SetWeaponLockingMode(BulletData bulletData)
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            switch (weaponNames[i])
            {
                case BulletData.WeaponNames.shotGun:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.shotGunLock.ToString();
                    break;
                case BulletData.WeaponNames.axe:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.axeLock.ToString();
                    break;
                case BulletData.WeaponNames.bulldog:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.bulldogLock.ToString();
                    break;
                case BulletData.WeaponNames.cow:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.cowLock.ToString();
                    break;
                case BulletData.WeaponNames.crystal:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.crystalLock.ToString();
                    break;
                case BulletData.WeaponNames.demon:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.demonLock.ToString();
                    break;
                case BulletData.WeaponNames.ice:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.iceLock.ToString();
                    break;
                case BulletData.WeaponNames.electro:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.electroLock.ToString();
                    break;
                case BulletData.WeaponNames.pistol:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.pistolLock.ToString();
                    break;
                case BulletData.WeaponNames.machine:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.machineLock.ToString();
                    break;
                default:
                    gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "No Valid";
                    break;

            }
        }
    }
}
