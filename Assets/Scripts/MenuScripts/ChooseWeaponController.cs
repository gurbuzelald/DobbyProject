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

    [SerializeField] GameObject[] holoWeaponObjects;
    [SerializeField] GameObject[] normalWeaponObjects;

    private PriceSetting priceSetting;


    void Start()
    {
        priceSetting = FindObjectOfType<PriceSetting>();        

        _playerController = FindObjectOfType<PlayerController>();

        WeaponPriceError();
        SetWeaponInfos();


        GetWeaponUnLockData();

        SetStrengthOfWeaponInfos();

        SetCharacterHoloOrNormalAtStart();

    }
    private void Update()
    {
        SlideMenu();
        WeaponPickStates();
        WeaponUsageLimit();
    }

    void SetCharacterHoloOrNormalAtStart()
    {
        // Array of player locks corresponding to each character
        bool[] playerLocks = {
            bulletData.weaponStruct[0].lockState == BulletData.locked,
            bulletData.weaponStruct[1].lockState == BulletData.locked,
            bulletData.weaponStruct[2].lockState == BulletData.locked,
            bulletData.weaponStruct[3].lockState == BulletData.locked,
            bulletData.weaponStruct[4].lockState == BulletData.locked,
            bulletData.weaponStruct[5].lockState == BulletData.locked,
            bulletData.weaponStruct[6].lockState == BulletData.locked,
            bulletData.weaponStruct[7].lockState == BulletData.locked,
            bulletData.weaponStruct[8].lockState == BulletData.locked,
            bulletData.weaponStruct[9].lockState == BulletData.locked
        };

        // Iterate over the characters and toggle holo/normal objects based on the lock state
        for (int i = 0; i < playerLocks.Length; i++)
        {
            holoWeaponObjects[i].SetActive(playerLocks[i]);
            normalWeaponObjects[i].SetActive(!playerLocks[i]);
        }
    }

    void SetStrengthOfWeaponInfos()
    {
        for (int i = 0; i < weaponStrengths.Length; i++)
        {
            if ("PistolStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.weaponStruct[0].power.ToString();
            }
            else if ("AxeStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.weaponStruct[1].power.ToString();
            }
            else if ("BulldogStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.weaponStruct[2].power.ToString();
            }
            else if ("CowStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.weaponStruct[3].power.ToString();
            }
            else if ("CrystalStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.weaponStruct[4].power.ToString();
            }
            else if ("DemonStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.weaponStruct[5].power.ToString();
            }
            else if ("IceStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.weaponStruct[6].power.ToString();
            }
            else if ("ElectroStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.weaponStruct[7].power.ToString();
            }
            else if ("ShotGunStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.weaponStruct[8].power.ToString();
            }
            else if ("MachineStrengthInfoText" == weaponStrengths[i].gameObject.transform.name)
            {
                weaponStrengths[i].text = bulletData.weaponStruct[9].power.ToString();
            }
        }
    }

    void GetWeaponUnLockData()
    {
        if (PlayerPrefs.GetFloat("AxeLock") == 1)
        {
            bulletData.weaponStruct[1].lockState = "";
            bulletData.weaponStruct[1].usageLimit = PlayerPrefs.GetInt("AxeUsageCount");
        }
        if (PlayerPrefs.GetFloat("BulldogLock") == 1)
        {
            bulletData.weaponStruct[2].lockState = "";
            bulletData.weaponStruct[2].usageLimit = PlayerPrefs.GetInt("BulldogUsageCount");
        }
        if (PlayerPrefs.GetFloat("CowLock") == 1)
        {
            bulletData.weaponStruct[3].lockState = "";
            bulletData.weaponStruct[3].usageLimit = PlayerPrefs.GetInt("CowUsageCount");
        }
        if (PlayerPrefs.GetFloat("CrystalLock") == 1)
        {
            bulletData.weaponStruct[4].lockState = "";
            bulletData.weaponStruct[4].usageLimit = PlayerPrefs.GetInt("CrystalUsageCount");
        }
        if (PlayerPrefs.GetFloat("DemonLock") == 1)
        {
            bulletData.weaponStruct[5].lockState = "";
            bulletData.weaponStruct[5].usageLimit = PlayerPrefs.GetInt("DemonUsageCount");
        }
        if (PlayerPrefs.GetFloat("IceLock") == 1)
        {
            bulletData.weaponStruct[6].lockState = "";
            bulletData.weaponStruct[6].usageLimit = PlayerPrefs.GetInt("IceUsageCount");
        }
        if (PlayerPrefs.GetFloat("ElectroLock") == 1)
        {
            bulletData.weaponStruct[7].lockState = "";
            bulletData.weaponStruct[7].usageLimit = PlayerPrefs.GetInt("ElectroUsageCount");
        }
        if (PlayerPrefs.GetFloat("ShotGunLock") == 1)
        {
            bulletData.weaponStruct[8].lockState = "";
            bulletData.weaponStruct[8].usageLimit = PlayerPrefs.GetInt("ShotGunUsageCount");
        }
        if (PlayerPrefs.GetFloat("MachineLock") == 1)
        {
            bulletData.weaponStruct[9].lockState = "";
            bulletData.weaponStruct[9].usageLimit = PlayerPrefs.GetInt("MachineUsageCount");
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
                    if (bulletData.weaponStruct[0].lockState == "")
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
                    if (bulletData.weaponStruct[1].lockState == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.weaponStruct[1].usageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "BULLDOGUsageLimit":
                    if (bulletData.weaponStruct[2].lockState == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.weaponStruct[2].usageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "COWUsageLimit":
                    if (bulletData.weaponStruct[3].lockState == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.weaponStruct[3].usageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "CRYSTALUsageLimit":
                    if (bulletData.weaponStruct[4].lockState == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.weaponStruct[4].usageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "DEMONUsageLimit":
                    if (bulletData.weaponStruct[5].lockState == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.weaponStruct[5].usageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "ICEUsageLimit":
                    if (bulletData.weaponStruct[6].lockState == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.weaponStruct[6].usageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "ELECTROUsageLimit":
                    if (bulletData.weaponStruct[7].lockState == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.weaponStruct[7].usageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "ShotGunUsageLimit":
                    if (bulletData.weaponStruct[8].lockState == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.weaponStruct[8].usageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "MachineUsageLimit":
                    if (bulletData.weaponStruct[9].lockState == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.weaponStruct[9].usageLimit.ToString();
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
            PickShotGun(bulletData.weaponStruct[8].price);
            PickAxe(bulletData.weaponStruct[1].price);
            PickBulldog(bulletData.weaponStruct[2].price);
            PickCow(bulletData.weaponStruct[3].price);
            PickCrystal(bulletData.weaponStruct[4].price);
            PickDemon(bulletData.weaponStruct[5].price);
            PickIce(bulletData.weaponStruct[6].price);
            PickElectro(bulletData.weaponStruct[7].price);
            PickPistol(bulletData.weaponStruct[0].price);
            PickMachine(bulletData.weaponStruct[9].price);
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

            // Populate weapon staffs
            var staffPanel = gameObject.transform.GetChild(1).GetChild(0);
            var weaponDetailsPanel = gameObject.transform.GetChild(1).GetChild(1);

            for (int i = 0; i < staffPanel.childCount; i++)
            {
                bulletData.weaponStaffs[i] = weaponDetailsPanel.GetChild(i).gameObject;
            }

            // Create a dictionary for power values
            var powerValues = new Dictionary<string, float>
        {
            { "ShotGunStaff", bulletData.weaponStruct[8].power },
            { "AxeStaff", bulletData.weaponStruct[1].power },
            { "BulldogStaff", bulletData.weaponStruct[2].power },
            { "CowStaff", bulletData.weaponStruct[3].power },
            { "CrystalStaff", bulletData.weaponStruct[4].power },
            { "DemonStaff", bulletData.weaponStruct[5].power },
            { "IceStaff", bulletData.weaponStruct[6].power },
            { "ElectroStaff", bulletData.weaponStruct[7].power },
            { "PistolStaff", bulletData.weaponStruct[0].power },
            { "MachineStaff", bulletData.weaponStruct[9].power }
        };

            // Update weapon staffs using a for loop
            for (int i = 0; i < bulletData.weaponStaffs.Count; i++)
            {
                var weaponStaff = bulletData.weaponStaffs[i];
                var weaponName = weaponStaff.transform.GetChild(0).name;

                if (powerValues.TryGetValue(weaponName, out float power))
                {
                    UpdateWeaponStaff(weaponStaff, power);
                }
            }
        }
    }

    void UpdateWeaponStaff(GameObject weaponStaff, float power)
    {
        // Rotate the weapon staff
        weaponStaff.transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

        // Update the TextMeshProUGUI with the power value
        var powerText = weaponStaff.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        powerText.text = power.ToString();
    }

    void SlideMenu()
    {
        float deltaX = _playerController.weaponStick.x * menuSlideSpeed * Time.deltaTime;

        // Update the x position based on the player's stick input
        Vector3 newPosition = _panelObject.transform.position + new Vector3(deltaX, 0f, 0f);

        // Clamp the x position to prevent going beyond the limits
        newPosition.x = Mathf.Clamp(newPosition.x, -9000f, 0f);

        // Apply the new position
        _panelObject.transform.position = newPosition;
    }



    public void PickShotGun(int avaliableCoinAmount)
    {
        if (bulletData.weaponStruct[8].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[8].lockState = BulletData.locked;
        }
        if (ButtonController.ShotGun && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            bulletData.currentWeaponName != bulletData.weaponStruct[8].weaponName)
        {
            if (bulletData.weaponStruct[8].lockState == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.weaponStruct[8].lockState = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.weaponStruct[8].usageLimit = 3;
                PlayerPrefs.SetInt("ShotGunUsageCount", bulletData.weaponStruct[8].usageLimit);

                PlayerPrefs.SetFloat("ShotGunLock", 1);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[8].bulletPackAmount;                
            }

            BulletData.currentWeaponID = bulletData.weaponStruct[8].id;

            bulletData.currentWeaponName = bulletData.weaponStruct[8].weaponName;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.ShotGun && bulletData.weaponStruct[8].lockState == bulletData.unLocked)
        {
            if (bulletData.weaponStruct[8].usageLimit > 0 && bulletData.currentWeaponName != bulletData.weaponStruct[8].weaponName)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[8].weaponName;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[8].bulletPackAmount;

                BulletData.currentWeaponID = bulletData.weaponStruct[8].id;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.weaponStruct[8].lockState == BulletData.locked)
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
            bulletData.weaponStruct[8].usageLimit = 0;
            PlayerPrefs.SetInt("ShotGunUsageCount", bulletData.weaponStruct[8].usageLimit);
        }
    }

    public void PickAxe(int avaliableCoinAmount)
    {
        if (bulletData.weaponStruct[1].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[1].lockState = BulletData.locked;
        }

        if (ButtonController.Axe && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
           bulletData.currentWeaponName != bulletData.weaponStruct[1].weaponName && bulletData.weaponStruct[1].lockState == BulletData.locked)
        {
            if (bulletData.weaponStruct[1].lockState == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.weaponStruct[1].lockState = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.weaponStruct[1].usageLimit = 3;
                PlayerPrefs.SetInt("AxeUsageCount", bulletData.weaponStruct[1].usageLimit);

                PlayerPrefs.SetFloat("AxeLock", 1);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[2].bulletPackAmount;
            }
            BulletData.currentWeaponID = bulletData.weaponStruct[1].id;

            bulletData.currentWeaponName = bulletData.weaponStruct[1].weaponName;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Axe && bulletData.weaponStruct[1].lockState == bulletData.unLocked)
        {
            if (bulletData.weaponStruct[1].usageLimit > 0 && bulletData.currentWeaponName != bulletData.weaponStruct[1].weaponName)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[1].weaponName;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[2].bulletPackAmount;

                BulletData.currentWeaponID = bulletData.weaponStruct[1].id;
            }  
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.weaponStruct[1].lockState == BulletData.locked)
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
            bulletData.weaponStruct[1].usageLimit = 0;
            PlayerPrefs.SetInt("AxeUsageCount", bulletData.weaponStruct[1].usageLimit);
        }
        
    }
    public void PickBulldog(int avaliableCoinAmount)
    {
        if (bulletData.weaponStruct[2].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[2].lockState = BulletData.locked;
        }
        if (ButtonController.Bulldog && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != bulletData.weaponStruct[2].weaponName)
        {
            if (bulletData.weaponStruct[2].lockState == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.weaponStruct[2].lockState = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.weaponStruct[2].usageLimit = 3;
                PlayerPrefs.SetInt("BulldogUsageCount", bulletData.weaponStruct[2].usageLimit);

                PlayerPrefs.SetFloat("BulldogLock", 1);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[2].bulletPackAmount;
            }
            BulletData.currentWeaponID = bulletData.weaponStruct[2].id;

            bulletData.currentWeaponName = bulletData.weaponStruct[2].weaponName;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Bulldog && bulletData.weaponStruct[2].lockState == bulletData.unLocked)
        {
            if (bulletData.weaponStruct[2].usageLimit > 0 && bulletData.currentWeaponName != bulletData.weaponStruct[2].weaponName)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[2].weaponName;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[2].bulletPackAmount;

                BulletData.currentWeaponID = bulletData.weaponStruct[2].id;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.weaponStruct[2].lockState == BulletData.locked)
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
            bulletData.weaponStruct[2].usageLimit = 0;
            PlayerPrefs.SetInt("BulldogUsageCount", bulletData.weaponStruct[2].usageLimit);
        }
    }
    public void PickCow(int avaliableCoinAmount)
    {
        if (bulletData.weaponStruct[3].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[3].lockState = BulletData.locked;
        }
        if (ButtonController.Cow && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != bulletData.weaponStruct[3].weaponName)
        {
            if (bulletData.weaponStruct[3].lockState == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.weaponStruct[3].lockState = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.weaponStruct[3].usageLimit = 3;
                PlayerPrefs.SetInt("CowUsageCount", bulletData.weaponStruct[3].usageLimit);

                PlayerPrefs.SetFloat("CowLock", 1);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[3].bulletPackAmount;
            }

            BulletData.currentWeaponID = bulletData.weaponStruct[3].id;

            bulletData.currentWeaponName = bulletData.weaponStruct[3].weaponName;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Cow && bulletData.weaponStruct[3].lockState == bulletData.unLocked)
        {
            if (bulletData.weaponStruct[3].usageLimit > 0 && bulletData.currentWeaponName != bulletData.weaponStruct[3].weaponName)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[3].weaponName;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[3].bulletPackAmount;

                BulletData.currentWeaponID = bulletData.weaponStruct[3].id;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.weaponStruct[3].lockState == BulletData.locked)
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
            bulletData.weaponStruct[3].usageLimit = 0;
            PlayerPrefs.SetInt("CowUsageCount", bulletData.weaponStruct[3].usageLimit);
        }
    }
    public void PickCrystal(int avaliableCoinAmount)
    {
        if (bulletData.weaponStruct[4].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[4].lockState = BulletData.locked;
        }
        if (ButtonController.Crystal && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            bulletData.currentWeaponName != bulletData.weaponStruct[4].weaponName)
        {
            if (bulletData.weaponStruct[4].lockState == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.weaponStruct[4].lockState = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.weaponStruct[4].usageLimit = 3;
                PlayerPrefs.SetInt("CrystalUsageCount", bulletData.weaponStruct[4].usageLimit);

                PlayerPrefs.SetFloat("CrystalLock", 1);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[4].bulletPackAmount;
            }
            BulletData.currentWeaponID = bulletData.weaponStruct[4].id;

            bulletData.currentWeaponName = bulletData.weaponStruct[4].weaponName;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Crystal && bulletData.weaponStruct[4].lockState == bulletData.unLocked)
        {
            if (bulletData.weaponStruct[4].usageLimit > 0 && bulletData.currentWeaponName != bulletData.weaponStruct[4].weaponName)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[4].weaponName;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[4].bulletPackAmount;

                BulletData.currentWeaponID = bulletData.weaponStruct[4].id;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.weaponStruct[4].lockState == BulletData.locked)
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
            bulletData.weaponStruct[4].usageLimit = 0;
            PlayerPrefs.SetInt("CrystalUsageCount", bulletData.weaponStruct[4].usageLimit);
        }
    }
    public void PickDemon(int avaliableCoinAmount)
    {
        if (bulletData.weaponStruct[5].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[5].lockState = BulletData.locked;
        }
        if (ButtonController.Demon && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != bulletData.weaponStruct[5].weaponName)
        {
            if (bulletData.weaponStruct[5].lockState == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.weaponStruct[5].lockState = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.weaponStruct[5].usageLimit = 3;
                PlayerPrefs.SetInt("DemonUsageCount", bulletData.weaponStruct[5].usageLimit);

                PlayerPrefs.SetFloat("DemonLock", 1);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[5].bulletPackAmount;
            }

            BulletData.currentWeaponID = bulletData.weaponStruct[5].id;

            bulletData.currentWeaponName = bulletData.weaponStruct[5].weaponName;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Demon && bulletData.weaponStruct[5].lockState == bulletData.unLocked)
        {
            if (bulletData.weaponStruct[5].usageLimit > 0 && bulletData.currentWeaponName != bulletData.weaponStruct[5].weaponName)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[5].weaponName;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[5].bulletPackAmount;

                BulletData.currentWeaponID = bulletData.weaponStruct[5].id;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.weaponStruct[5].lockState == BulletData.locked)
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
            bulletData.weaponStruct[5].usageLimit = 0;
            PlayerPrefs.SetInt("DemonUsageCount", bulletData.weaponStruct[5].usageLimit);
        }
    }
    public void PickIce(int avaliableCoinAmount)
    {
        if (bulletData.weaponStruct[6].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[6].lockState = BulletData.locked;
        }
        if (ButtonController.Ice && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != bulletData.weaponStruct[6].weaponName)
        {
            if (bulletData.weaponStruct[6].lockState == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.weaponStruct[6].lockState = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.weaponStruct[6].usageLimit = 3;
                PlayerPrefs.SetInt("IceUsageCount", bulletData.weaponStruct[6].usageLimit);

                PlayerPrefs.SetFloat("IceLock", 1);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[6].bulletPackAmount;
            }
            BulletData.currentWeaponID = bulletData.weaponStruct[6].id;

            bulletData.currentWeaponName = bulletData.weaponStruct[6].weaponName;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Ice && bulletData.weaponStruct[6].lockState == bulletData.unLocked)
        {
            if (bulletData.weaponStruct[6].usageLimit > 0 && bulletData.currentWeaponName != bulletData.weaponStruct[6].weaponName)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[6].weaponName;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[6].bulletPackAmount;

                BulletData.currentWeaponID = bulletData.weaponStruct[6].id;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.weaponStruct[6].lockState == BulletData.locked)
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
            bulletData.weaponStruct[6].usageLimit = 0;
            PlayerPrefs.SetInt("IceUsageCount", bulletData.weaponStruct[6].usageLimit);
        }
    }
    public void PickElectro(int avaliableCoinAmount)
    {
        if (bulletData.weaponStruct[7].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[7].lockState = BulletData.locked;
        }
        if (ButtonController.Electro && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != bulletData.weaponStruct[7].weaponName)
        {
            if (bulletData.weaponStruct[7].lockState == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.weaponStruct[7].lockState = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.weaponStruct[7].usageLimit = 3;
                PlayerPrefs.SetInt("ElectroUsageCount", bulletData.weaponStruct[7].usageLimit);

                PlayerPrefs.SetFloat("ElectroLock", 1);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[7].bulletPackAmount;
            }
            BulletData.currentWeaponID = bulletData.weaponStruct[7].id;

            bulletData.currentWeaponName = bulletData.weaponStruct[7].weaponName;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);
        }
        else if (ButtonController.Electro && bulletData.weaponStruct[7].lockState == bulletData.unLocked)
        {
            if (bulletData.weaponStruct[7].usageLimit > 0 && bulletData.currentWeaponName != bulletData.weaponStruct[7].weaponName)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[7].weaponName;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[7].bulletPackAmount;

                BulletData.currentWeaponID = bulletData.weaponStruct[7].id;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.weaponStruct[7].lockState == BulletData.locked)
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
            bulletData.weaponStruct[7].usageLimit = 0;
            PlayerPrefs.SetInt("ElectroUsageCount", bulletData.weaponStruct[7].usageLimit);
        }
    }

    public void PickPistol(int avaliableCoinAmount)
    {
        if (bulletData.weaponStruct[0].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
        }
        if (ButtonController.Pistol &&
          bulletData.currentWeaponName != bulletData.weaponStruct[0].weaponName)
        {
            BulletData.currentWeaponID = bulletData.weaponStruct[0].id;

            bulletData.currentWeaponName = bulletData.weaponStruct[0].weaponName;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

            BulletData.currentWeaponID = bulletData.weaponStruct[0].id;
        }
        else if (ButtonController.Pistol && bulletData.weaponStruct[0].lockState == bulletData.unLocked)
        {
            if (bulletData.weaponStruct[0].usageLimit > 0 && bulletData.currentWeaponName != bulletData.weaponStruct[0].weaponName)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[0].weaponName;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[0].bulletPackAmount;

                BulletData.currentWeaponID = bulletData.weaponStruct[0].id;
            }
        }
    }

    public void PickMachine(int avaliableCoinAmount)
    {
        if (bulletData.weaponStruct[9].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[9].lockState = BulletData.locked;
        }
        if (ButtonController.Machine && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != bulletData.weaponStruct[9].weaponName)
        {
            if (bulletData.weaponStruct[9].lockState == BulletData.locked)
            {
                playerCoinData.avaliableCoin -= avaliableCoinAmount;
                PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                bulletData.weaponStruct[9].lockState = bulletData.unLocked;

                ObjectPool.creatablePlayerBullet = true;

                bulletData.weaponStruct[9].usageLimit = 3;
                PlayerPrefs.SetInt("MachineUsageCount", bulletData.weaponStruct[9].usageLimit);

                PlayerPrefs.SetFloat("MachineLock", 1);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[9].bulletPackAmount;
            }
            BulletData.currentWeaponID = bulletData.weaponStruct[9].id;

            bulletData.currentWeaponName = bulletData.weaponStruct[9].weaponName;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.LoadMenuScene();

            MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        }
        else if (ButtonController.Machine && bulletData.weaponStruct[9].lockState == bulletData.unLocked)
        {
            if (bulletData.weaponStruct[9].usageLimit > 0 && bulletData.currentWeaponName != bulletData.weaponStruct[9].weaponName)
            {
                bulletData.currentWeaponName = bulletData.weaponStruct[9].weaponName;

                SceneController.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;

                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

                bulletData.currentBulletPackAmount = bulletData.weaponStruct[9].bulletPackAmount;

                BulletData.currentWeaponID = bulletData.weaponStruct[9].id;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.weaponStruct[9].lockState == BulletData.locked)
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
        bulletData.weaponStruct[9].usageLimit = 0;
        PlayerPrefs.SetInt("MachineUsageCount", bulletData.weaponStruct[9].usageLimit);
    }
}
