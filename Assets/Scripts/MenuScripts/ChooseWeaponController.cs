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
            for (int i = 0; i < 10; i++)
            {
                PickWeapon(bulletData.weaponStruct[i].price, i);
            }
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

    public void PickWeapon(int availableCoinAmount, int weaponIndex)
    {
        // If the weapon has no remaining uses, lock it and enable bullet creation
        if (bulletData.weaponStruct[weaponIndex].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[weaponIndex].lockState = BulletData.locked;
            bulletData.weaponStruct[weaponIndex].usageLimit = 0;
            PlayerPrefs.SetInt("MachineUsageCount", bulletData.weaponStruct[weaponIndex].usageLimit);
        }

        // Check if the player can unlock the weapon
        bool hasEnoughCoins = playerCoinData.avaliableCoin >= availableCoinAmount;
        bool weaponNotInUse = bulletData.currentWeaponName != bulletData.weaponStruct[weaponIndex].weaponName;
        bool weaponLocked = bulletData.weaponStruct[weaponIndex].lockState == BulletData.locked;

        if (ButtonController.weaponButtonBools[weaponIndex])
        {
            if (hasEnoughCoins && weaponNotInUse)
            {
                if (weaponLocked)
                {
                    // Unlock the weapon
                    playerCoinData.avaliableCoin -= availableCoinAmount;
                    PlayerPrefs.SetInt("AvailableCoin", playerCoinData.avaliableCoin);

                    bulletData.weaponStruct[weaponIndex].lockState = bulletData.unLocked;
                    bulletData.weaponStruct[weaponIndex].usageLimit = 3;
                    PlayerPrefs.SetInt("MachineUsageCount", bulletData.weaponStruct[weaponIndex].usageLimit);
                    PlayerPrefs.SetFloat("MachineLock", 1);
                }

                // Set weapon as the current weapon
                SetCurrentWeapon(weaponIndex);
            }
            else if (!hasEnoughCoins && weaponLocked)
            {
                // Display error for insufficient coins
                DisplayPriceError(availableCoinAmount - playerCoinData.avaliableCoin);
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            else if (bulletData.weaponStruct[weaponIndex].lockState == bulletData.unLocked && bulletData.weaponStruct[weaponIndex].usageLimit > 0 && weaponNotInUse)
            {
                // Set unlocked weapon with remaining usage limit as the current weapon
                SetCurrentWeapon(weaponIndex);
            }
        }
    }

    private void SetCurrentWeapon(int weaponIndex)
    {
        bulletData.currentWeaponName = bulletData.weaponStruct[weaponIndex].weaponName;
        BulletData.currentWeaponID = bulletData.weaponStruct[weaponIndex].id;
        bulletData.currentBulletPackAmount = bulletData.weaponStruct[weaponIndex].bulletPackAmount;
        ObjectPool.creatablePlayerBullet = true;

        SceneController.LoadMenuScene();
        MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuClick);

        weaponPriceErrorTextObjectChilds[0].text = "";
    }

    private void DisplayPriceError(int missingCoins)
    {
        foreach (var textObject in weaponPriceErrorTextObjectChilds)
        {
            if (textObject.gameObject.name == "MachinePriceErrorText")
            {
                textObject.text = playerData.currentLanguage == PlayerData.Languages.Turkish
                    ? $"Satin Almak İçin {missingCoins} Daha Coin'e İhtiyacin Var!"
                    : $"You need {missingCoins} More Coin!";
            }
        }
    }

}
