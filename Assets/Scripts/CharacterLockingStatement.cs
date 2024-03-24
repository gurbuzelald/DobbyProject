using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CharacterLockingStatement : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [SerializeField] BulletData bulletData;
    private ChooseCharacterController chooseCharacterController;

    private PlayerData.CharacterNames[] characterNames = new PlayerData.CharacterNames[12];
    private BulletData.WeaponNames[] weaponNames = new BulletData.WeaponNames[10];

    public GameObject[] characterStaffs;
    public GameObject[] weaponStaffs;

    void Awake()
    {
        ResetCharactersLocks();

        SetCharacterNames();
        SetWeaponNames();

        SetCharacterLockingMode();
        SetWeaponLockingMode(bulletData);
    }

    void ResetCharactersLocks()
    {
        chooseCharacterController = FindObjectOfType<ChooseCharacterController>();

        if (playerData.dobbyLock == playerData.unLocked &&
            playerData.glassyLock == playerData.unLocked &&
            playerData.joleenLock == playerData.unLocked &&
            playerData.guardLock == playerData.unLocked &&
            playerData.lusthLock == playerData.unLocked &&
            playerData.eveLock == playerData.unLocked &&
            playerData.michelleLock == playerData.unLocked &&
            playerData.ajLock == playerData.unLocked &&
            playerData.bossLock == playerData.unLocked &&
            playerData.mremirehLock == playerData.unLocked &&
            playerData.tyLock == playerData.unLocked &&
            playerData.resetLocks == playerData.unLocked)
        {
            chooseCharacterController.ResetTheCharacters();


            playerData.dobbyLock = playerData.locked;
            playerData.glassyLock = playerData.locked;
            playerData.joleenLock = playerData.locked;
            playerData.lusthLock = playerData.locked;
            playerData.eveLock = playerData.locked;
            playerData.guardLock = playerData.locked;
            playerData.bossLock = playerData.locked;
            playerData.michelleLock = playerData.locked;
            playerData.ajLock = playerData.locked;
            playerData.mremirehLock = playerData.locked;
            playerData.tyLock = playerData.locked;
            playerData.resetLocks = playerData.locked;
        }
        else if (playerData.dobbyLock == playerData.locked &&
            playerData.glassyLock == playerData.locked &&
            playerData.joleenLock == playerData.locked &&
            playerData.guardLock == playerData.locked &&
            playerData.lusthLock == playerData.locked &&
            playerData.eveLock == playerData.locked &&
            playerData.michelleLock == playerData.locked &&
            playerData.ajLock == playerData.locked &&
            playerData.bossLock == playerData.locked &&
            playerData.mremirehLock == playerData.locked &&
            playerData.tyLock == playerData.locked &&
            playerData.resetLocks == playerData.locked)
        {
            playerData.currentCharacterName = PlayerData.CharacterNames.Joleen;
        }
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

    void SetCharacterLockingMode()
    {
        if (characterStaffs.Length != 0)
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
        
    }
    void SetWeaponLockingMode(BulletData bulletData)
    {
        if (weaponStaffs.Length != 0)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                switch (weaponNames[i])
                {
                    case BulletData.WeaponNames.ak47:
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.ak47Lock.ToString();
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
                    case BulletData.WeaponNames.negev:
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.negevLock.ToString();
                        break;
                    case BulletData.WeaponNames.pistol:
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.pistolLock.ToString();
                        break;
                    case BulletData.WeaponNames.m4a4:
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = bulletData.m4a4Lock.ToString();
                        break;
                    default:
                        gameObject.transform.GetChild(i).transform.GetComponent<TextMeshProUGUI>().text = "No Valid";
                        break;

                }
            }
        }
        
    }
}
