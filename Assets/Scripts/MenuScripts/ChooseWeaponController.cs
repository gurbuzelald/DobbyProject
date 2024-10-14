using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseWeaponController : MonoBehaviour
{
    public GameObject[] weaponPriceErrorTextObjects;
    private TextMeshProUGUI[] weaponPriceErrorTextObjectChilds;

    private PlayerController _playerController;

    [SerializeField] GameObject _panelObject;


    [SerializeField] BulletData bulletData;
    [SerializeField] PlayerCoinData playerCoinData;
    [SerializeField] PlayerData playerData;

    [SerializeField] float menuSlideSpeed;


    [SerializeField] TextMeshProUGUI[] weaponUsageLimits;
    [SerializeField] TextMeshProUGUI[] weaponStrengths;

    private PriceSetting priceSetting;


    void Start()
    {
        priceSetting = FindObjectOfType<PriceSetting>();        

        _playerController = FindObjectOfType<PlayerController>();

        WeaponPriceError();
        SetWeaponInfos();


        GetWeaponUnLockData();

        SetStrengthOfWeaponInfos();
    }
    private void Update()
    {
        SlideMenu();
        WeaponPickStates();
        WeaponUsageLimit();
        if (BulletController.ShotGun)
        {
            Debug.Log("3");

        }
    }


    void SetStrengthOfWeaponInfos()
    {
        for (int i = 0; i < weaponStrengths.Length; i++)
        {
            if ("PistolStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.pistolPower.ToString();
            }
            else if ("AxeStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.axePower.ToString();
            }
            else if ("BulldogStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.bulldogPower.ToString();
            }
            else if ("CowStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.cowPower.ToString();
            }
            else if ("CrystalStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.crystalPower.ToString();
            }
            else if ("DemonStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.demonPower.ToString();
            }
            else if ("IceStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.icePower.ToString();
            }
            else if ("ElectroStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.electroPower.ToString();
            }
            else if ("ShotGunStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.shotGunPower.ToString();
            }
            else if ("MachineStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.machinePower.ToString();
            }
        }
    }

    void GetWeaponUnLockData()
    {
        if (PlayerPrefs.GetFloat("AxeLock") == 1)
        {
            bulletData.axeLock = "";
            bulletData.axeUsageLimit = PlayerPrefs.GetInt("AxeUsageCount");
        }
        if (PlayerPrefs.GetFloat("BulldogLock") == 1)
        {
            bulletData.bulldogLock = "";
            bulletData.bulldogUsageLimit = PlayerPrefs.GetInt("BulldogUsageCount");
        }
        if (PlayerPrefs.GetFloat("CowLock") == 1)
        {
            bulletData.cowLock = "";
            bulletData.cowUsageLimit = PlayerPrefs.GetInt("CowUsageCount");
        }
        if (PlayerPrefs.GetFloat("CrystalLock") == 1)
        {
            bulletData.crystalLock = "";
            bulletData.crystalUsageLimit = PlayerPrefs.GetInt("CrystalUsageCount");
        }
        if (PlayerPrefs.GetFloat("DemonLock") == 1)
        {
            bulletData.demonLock = "";
            bulletData.demonUsageLimit = PlayerPrefs.GetInt("DemonUsageCount");
        }
        if (PlayerPrefs.GetFloat("IceLock") == 1)
        {
            bulletData.iceLock = "";
            bulletData.iceUsageLimit = PlayerPrefs.GetInt("IceUsageCount");
        }
        if (PlayerPrefs.GetFloat("ElectroLock") == 1)
        {
            bulletData.electroLock = "";
            bulletData.electroUsageLimit = PlayerPrefs.GetInt("ElectroUsageCount");
        }
        if (PlayerPrefs.GetFloat("ShotGunLock") == 1)
        {
            bulletData.shotGunLock = "";
            bulletData.shotGunUsageLimit = PlayerPrefs.GetInt("ShotGunUsageCount");
        }
        if (PlayerPrefs.GetFloat("MachineLock") == 1)
        {
            bulletData.machineLock = "";
            bulletData.machineUsageLimit = PlayerPrefs.GetInt("MachineUsageCount");
        }

        if (priceSetting)
        {
            priceSetting.SetWeaponPrices();
        }        
    }

    public void WeaponUsageLimit()
    {
        for (int i = 0; i < weaponUsageLimits.Length; i++)
        {
            switch (weaponUsageLimits[i].name)
            {      
                case "PISTOLUsageLimit":
                    if (bulletData.pistolLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "";
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "AXEUsageLimit":
                    if (bulletData.axeLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.axeUsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "BULLDOGUsageLimit":
                    if (bulletData.bulldogLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.bulldogUsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "COWUsageLimit":
                    if (bulletData.cowLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.cowUsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "CRYSTALUsageLimit":
                    if (bulletData.crystalLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.crystalUsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "DEMONUsageLimit":
                    if (bulletData.demonLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.demonUsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "ICEUsageLimit":
                    if (bulletData.iceLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.iceUsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "ELECTROUsageLimit":
                    if (bulletData.electroLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.electroUsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "ShotGunUsageLimit":
                    if (bulletData.shotGunLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.shotGunUsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "MachineUsageLimit":
                    if (bulletData.machineLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.machineUsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
            }
        }

    }    
    
    void WeaponPickStates()
    {
        if (weaponPriceErrorTextObjects.Length != 0)
        {
            PickShotGun(bulletData.shotGunPrice);
            PickAxe(bulletData.axePrice);
            PickBulldog(bulletData.bulldogPrice);
            PickCow(bulletData.cowPrice);
            PickCrystal(bulletData.crystalPrice);
            PickDemon(bulletData.demonPrice);
            PickIce(bulletData.icePrice);
            PickElectro(bulletData.electroPrice);
            PickPistol(bulletData.pistolPrice);
            PickMachine(bulletData.machinePrice);
        }
    }
    void WeaponPriceError()
    {

        if (weaponPriceErrorTextObjects.Length != 0)
        {
            weaponPriceErrorTextObjectChilds = new TextMeshProUGUI[weaponPriceErrorTextObjects.Length];

            for (int i = 0; i < weaponPriceErrorTextObjects.Length; i++)
            {
                weaponPriceErrorTextObjectChilds[i] = weaponPriceErrorTextObjects[i].GetComponent<TextMeshProUGUI>();
            }
        }


    }

    void SetWeaponInfos()
    {
        if (gameObject.transform.GetChild(1).gameObject.name == "Panel")
        {
            bulletData.weaponStaffs = new Dictionary<int, GameObject>();

            for (int i = 0; i < gameObject.transform.GetChild(1).GetChild(0).childCount; i++)
            {
                bulletData.weaponStaffs[i] = gameObject.transform.GetChild(1).GetChild(1).GetChild(i).gameObject;
            }

            for (int i = 0; i < bulletData.weaponStaffs.Count; i++)
            {
                if (bulletData.weaponStaffs[i].name == "ShotGunStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.shotGunPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "AxeStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.axePower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "BulldogStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.bulldogPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "CowStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.cowPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "CrystalStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.crystalPower.ToString();

                }
                else if (bulletData.weaponStaffs[i].name == "DemonStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.demonPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "IceStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.icePower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "ElectroStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.electroPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "PistolStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.pistolPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "MachineStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.machinePower.ToString();
                }
            }
        }
    }

    void SlideMenu()
    {
        if (_playerController.weaponStick.x < 0f)
        {
            _panelObject.transform.position = new Vector3(_panelObject.transform.position.x - menuSlideSpeed * Time.deltaTime,
                                                             _panelObject.transform.position.y,
                                                             _panelObject.transform.position.z);
        }
        if (_playerController.weaponStick.x > 0f)
        {
            _panelObject.transform.position = new Vector3(_panelObject.transform.position.x + menuSlideSpeed * Time.deltaTime,
                                                             _panelObject.transform.position.y,
                                                             _panelObject.transform.position.z);           
        }
        if (_panelObject.transform.localPosition.x > 0)
        {
            _panelObject.transform.localPosition = new Vector3(0f, _panelObject.transform.localPosition.y, _panelObject.transform.localPosition.z);
        }
        if (_panelObject.transform.localPosition.x < -9000)
        {
            _panelObject.transform.localPosition = new Vector3(-9000f, _panelObject.transform.localPosition.y, _panelObject.transform.localPosition.z);
        }
    }

    public void PickShotGun(int avaliableCoinAmount)
    {
        if (bulletData.shotGunUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.shotGunLock = BulletData.locked;
        }
        if (ButtonController.ShotGun && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            bulletData.currentWeaponName != BulletData.shotGun)
        {
            if (bulletData.shotGunLock == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.shotGunLock = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.shotGunUsageLimit = 3;
                PlayerPrefs.SetInt("ShotGunUsageCount", bulletData.shotGunUsageLimit);

                PlayerPrefs.SetFloat("ShotGunLock", 1);

                bulletData.currentBulletPack = bulletData.shotGunBulletAmount;                
            }

            BulletData.currentWeaponID = 8;

            bulletData.currentWeaponName = BulletData.shotGun;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.ShotGun && bulletData.shotGunLock == bulletData.unLocked)
        {
            if (bulletData.shotGunUsageLimit > 0 && bulletData.currentWeaponName != BulletData.shotGun)
            {
                bulletData.currentWeaponName = BulletData.shotGun;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPack = bulletData.shotGunBulletAmount;

                BulletData.currentWeaponID = 8;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.shotGunLock == BulletData.locked)
        {
            if (ButtonController.ShotGun)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "ShotGunPriceErrorText")
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "Satin Almak İçİn " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " Daha Coin' e İhtİyacin Var!";
                    }
                    else
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                    }
                }
            }
            bulletData.shotGunUsageLimit = 0;
            PlayerPrefs.SetInt("ShotGunUsageCount", bulletData.shotGunUsageLimit);
        }
    }

    public void PickAxe(int avaliableCoinAmount)
    {
        if (bulletData.axeUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.axeLock = BulletData.locked;
        }

        if (ButtonController.Axe && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
           bulletData.currentWeaponName != BulletData.axe && bulletData.axeLock == BulletData.locked)
        {
            if (bulletData.axeLock == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.axeLock = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.axeUsageLimit = 3;
                PlayerPrefs.SetInt("AxeUsageCount", bulletData.axeUsageLimit);

                PlayerPrefs.SetFloat("AxeLock", 1);

                bulletData.currentBulletPack = bulletData.axeBulletAmount;
            }
            BulletData.currentWeaponID = 1;

            bulletData.currentWeaponName = BulletData.axe;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Axe && bulletData.axeLock == bulletData.unLocked)
        {
            if (bulletData.axeUsageLimit > 0 && bulletData.currentWeaponName != BulletData.axe)
            {
                bulletData.currentWeaponName = BulletData.axe;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPack = bulletData.axeBulletAmount;

                BulletData.currentWeaponID = 1;
            }  
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.axeLock == BulletData.locked)
        {
            if (ButtonController.Axe)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "AXEPriceErrorText")
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "Satin Almak İçİn " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " Daha Coin' e İhtİyacin Var!";
                    }
                    else
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                    }
                }
            }
            bulletData.axeUsageLimit = 0;
            PlayerPrefs.SetInt("AxeUsageCount", bulletData.axeUsageLimit);
        }
        
    }
    public void PickBulldog(int avaliableCoinAmount)
    {
        if (bulletData.bulldogUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.bulldogLock = BulletData.locked;
        }
        if (ButtonController.Bulldog && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.bulldog)
        {
            if (bulletData.bulldogLock == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.bulldogLock = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.bulldogUsageLimit = 3;
                PlayerPrefs.SetInt("BulldogUsageCount", bulletData.bulldogUsageLimit);

                PlayerPrefs.SetFloat("BulldogLock", 1);

                bulletData.currentBulletPack = bulletData.bulldogBulletAmount;
            }
            BulletData.currentWeaponID = 2;

            bulletData.currentWeaponName = BulletData.bulldog;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Bulldog && bulletData.bulldogLock == bulletData.unLocked)
        {
            if (bulletData.bulldogUsageLimit > 0 && bulletData.currentWeaponName != BulletData.bulldog)
            {
                bulletData.currentWeaponName = BulletData.bulldog;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPack = bulletData.bulldogBulletAmount;

                BulletData.currentWeaponID = 2;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.bulldogLock == BulletData.locked)
        {
            if (ButtonController.Bulldog)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "BULLDOGPriceErrorText")
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "Satin Almak İçİn " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " Daha Coin' e İhtİyacin Var!";
                    }
                    else
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                    }
                }
            }
            bulletData.bulldogUsageLimit = 0;
            PlayerPrefs.SetInt("BulldogUsageCount", bulletData.bulldogUsageLimit);
        }
    }
    public void PickCow(int avaliableCoinAmount)
    {
        if (bulletData.cowUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.cowLock = BulletData.locked;
        }
        if (ButtonController.Cow && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.cow)
        {
            if (bulletData.cowLock == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.cowLock = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.cowUsageLimit = 3;
                PlayerPrefs.SetInt("CowUsageCount", bulletData.cowUsageLimit);

                PlayerPrefs.SetFloat("CowLock", 1);

                bulletData.currentBulletPack = bulletData.cowBulletAmount;
            }

            BulletData.currentWeaponID = 3;

            bulletData.currentWeaponName = BulletData.cow;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Cow && bulletData.cowLock == bulletData.unLocked)
        {
            if (bulletData.cowUsageLimit > 0 && bulletData.currentWeaponName != BulletData.cow)
            {
                bulletData.currentWeaponName = BulletData.cow;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPack = bulletData.cowBulletAmount;

                BulletData.currentWeaponID = 3;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.cowLock == BulletData.locked)
        {
            if (ButtonController.Cow)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "COWPriceErrorText")
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "Satin Almak İçİn " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " Daha Coin' e İhtİyacin Var!";
                    }
                    else
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                    }
                }
            }
            bulletData.cowUsageLimit = 0;
            PlayerPrefs.SetInt("CowUsageCount", bulletData.cowUsageLimit);
        }
    }
    public void PickCrystal(int avaliableCoinAmount)
    {
        if (bulletData.crystalUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.crystalLock = BulletData.locked;
        }
        if (ButtonController.Crystal && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            bulletData.currentWeaponName != BulletData.crystal)
        {
            if (bulletData.crystalLock == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.crystalLock = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.crystalUsageLimit = 3;
                PlayerPrefs.SetInt("CrystalUsageCount", bulletData.crystalUsageLimit);

                PlayerPrefs.SetFloat("CrystalLock", 1);

                bulletData.currentBulletPack = bulletData.crystalBulletAmount;
            }
            BulletData.currentWeaponID = 4;

            bulletData.currentWeaponName = BulletData.crystal;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Crystal && bulletData.crystalLock == bulletData.unLocked)
        {
            if (bulletData.crystalUsageLimit > 0 && bulletData.currentWeaponName != BulletData.crystal)
            {
                bulletData.currentWeaponName = BulletData.crystal;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPack = bulletData.crystalBulletAmount;

                BulletData.currentWeaponID = 4;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.crystalLock == BulletData.locked)
        {
            if (ButtonController.Crystal)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "CRYSTALPriceErrorText")
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "Satin Almak İçİn " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " Daha Coin' e İhtİyacin Var!";
                    }
                    else
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                    }
                }
            }
            bulletData.crystalUsageLimit = 0;
            PlayerPrefs.SetInt("CrystalUsageCount", bulletData.crystalUsageLimit);
        }
    }
    public void PickDemon(int avaliableCoinAmount)
    {
        if (bulletData.demonUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.demonLock = BulletData.locked;
        }
        if (ButtonController.Demon && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.demon)
        {
            if (bulletData.demonLock == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.demonLock = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.demonUsageLimit = 3;
                PlayerPrefs.SetInt("DemonUsageCount", bulletData.demonUsageLimit);

                PlayerPrefs.SetFloat("DemonLock", 1);

                bulletData.currentBulletPack = bulletData.demonBulletAmount;
            }

            BulletData.currentWeaponID = 5;

            bulletData.currentWeaponName = BulletData.demon;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Demon && bulletData.demonLock == bulletData.unLocked)
        {
            if (bulletData.demonUsageLimit > 0 && bulletData.currentWeaponName != BulletData.demon)
            {
                bulletData.currentWeaponName = BulletData.demon;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPack = bulletData.demonBulletAmount;

                BulletData.currentWeaponID = 5;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.demonLock == BulletData.locked)
        {
            if (ButtonController.Demon)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "DEMONPriceErrorText")
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "Satin Almak İçİn " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " Daha Coin' e İhtİyacin Var!";
                    }
                    else
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                    }
                }
            }
            bulletData.demonUsageLimit = 0;
            PlayerPrefs.SetInt("DemonUsageCount", bulletData.demonUsageLimit);
        }
    }
    public void PickIce(int avaliableCoinAmount)
    {
        if (bulletData.iceUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.iceLock = BulletData.locked;
        }
        if (ButtonController.Ice && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.ice)
        {
            if (bulletData.iceLock == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.iceLock = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.iceUsageLimit = 3;
                PlayerPrefs.SetInt("IceUsageCount", bulletData.iceUsageLimit);

                PlayerPrefs.SetFloat("IceLock", 1);

                bulletData.currentBulletPack = bulletData.iceBulletAmount;
            }
            BulletData.currentWeaponID = 6;

            bulletData.currentWeaponName = BulletData.ice;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Ice && bulletData.iceLock == bulletData.unLocked)
        {
            if (bulletData.iceUsageLimit > 0 && bulletData.currentWeaponName != BulletData.ice)
            {
                bulletData.currentWeaponName = BulletData.ice;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPack = bulletData.iceBulletAmount;

                BulletData.currentWeaponID = 6;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.iceLock == BulletData.locked)
        {
            if (ButtonController.Ice)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "ICEPriceErrorText")
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "Satin Almak İçİn " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " Daha Coin' e İhtİyacin Var!";
                    }
                    else
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                    }
                }
            }
            bulletData.iceUsageLimit = 0;
            PlayerPrefs.SetInt("IceUsageCount", bulletData.iceUsageLimit);
        }
    }
    public void PickElectro(int avaliableCoinAmount)
    {
        if (bulletData.electroUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.electroLock = BulletData.locked;
        }
        if (ButtonController.Electro && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.electro)
        {
            if (bulletData.electroLock == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.electroLock = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.electroUsageLimit = 3;
                PlayerPrefs.SetInt("ElectroUsageCount", bulletData.electroUsageLimit);

                PlayerPrefs.SetFloat("ElectroLock", 1);

                bulletData.currentBulletPack = bulletData.electroBulletAmount;
            }
            BulletData.currentWeaponID = 7;

            bulletData.currentWeaponName = BulletData.electro;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Electro && bulletData.electroLock == bulletData.unLocked)
        {
            if (bulletData.electroUsageLimit > 0 && bulletData.currentWeaponName != BulletData.electro)
            {
                bulletData.currentWeaponName = BulletData.electro;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPack = bulletData.electroBulletAmount;

                BulletData.currentWeaponID = 7;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.electroLock == BulletData.locked)
        {
            if (ButtonController.Electro)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "ELECTROPriceErrorText")
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "Satin Almak İçİn " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " Daha Coin' e İhtİyacin Var!";
                    }
                    else
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                    }
                }
            }
            bulletData.electroUsageLimit = 0;
            PlayerPrefs.SetInt("ElectroUsageCount", bulletData.electroUsageLimit);
        }
    }

    public void PickPistol(int avaliableCoinAmount)
    {
        if (bulletData.pistolUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
        }
        if (ButtonController.Pistol &&
          bulletData.currentWeaponName != BulletData.pistol)
        {
            BulletData.currentWeaponID = 0;

            bulletData.currentWeaponName = BulletData.pistol;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            BulletData.currentWeaponID = 0;
        }
        else if (ButtonController.Pistol && bulletData.pistolLock == bulletData.unLocked)
        {
            if (bulletData.pistolUsageLimit > 0 && bulletData.currentWeaponName != BulletData.pistol)
            {
                bulletData.currentWeaponName = BulletData.pistol;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPack = bulletData.pistolBulletAmount;

                BulletData.currentWeaponID = 0;
            }
        }
    }

    public void PickMachine(int avaliableCoinAmount)
    {
        if (bulletData.machineUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.machineLock = BulletData.locked;
        }
        if (ButtonController.Machine && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.machine)
        {
            if (bulletData.machineLock == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.machineLock = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.machineUsageLimit = 3;
                PlayerPrefs.SetInt("MachineUsageCount", bulletData.machineUsageLimit);

                PlayerPrefs.SetFloat("MachineLock", 1);

                bulletData.currentBulletPack = bulletData.machineBulletAmount;
            }
            BulletData.currentWeaponID = 9;

            bulletData.currentWeaponName = BulletData.machine;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        }
        else if (ButtonController.Machine && bulletData.machineLock == bulletData.unLocked)
        {
            if (bulletData.machineUsageLimit > 0 && bulletData.currentWeaponName != BulletData.machine)
            {
                bulletData.currentWeaponName = BulletData.machine;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPack = bulletData.machineBulletAmount;

                BulletData.currentWeaponID = 9;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.machineLock == BulletData.locked)
        {
            if (ButtonController.Machine)
            {
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "MachinePriceErrorText")
                {
                    if (playerData.currentLanguage == PlayerData.Languages.Turkish)
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "Satin Almak İçİn " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " Daha Coin' e İhtİyacin Var!";
                    }
                    else
                    {
                        weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                    }
                }
            }
        }
    }
}
