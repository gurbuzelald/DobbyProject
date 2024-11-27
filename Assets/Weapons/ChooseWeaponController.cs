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
        foreach (var weaponStrength in weaponStrengths)
        {
            for (int j = 0; j < bulletData.weaponStruct.Length; j++)
            {
                string expectedName = $"{bulletData.weaponStruct[j].weaponName}StrengthInfoText";
                if (weaponStrength.gameObject.transform.name == expectedName)
                {
                    weaponStrength.text = bulletData.weaponStruct[j].power.ToString();
                    break; // Exit inner loop once the correct weapon is found
                }
            }
        }
    }


    void GetWeaponUnLockData()
    {
        for (int i = 1; i <= 9; i++)
        {
            if (PlayerPrefs.GetFloat($"{bulletData.weaponStruct[i].weaponName}Lock") == 1)
            {
                bulletData.weaponStruct[i].lockState = "";
                bulletData.weaponStruct[i].usageLimit = PlayerPrefs.GetInt($"{bulletData.weaponStruct[i].weaponName}UsageCount");
            }
        }

        priceSetting?.SetWeaponPrices();
    }


    public void WeaponUsageLimit()
    {
        for (int i = 1; i < weaponUsageLimits.Length; i++)
        {
            for (int j = 1; j < bulletData.weaponStruct.Length; j++)
            {
                string expectedName = $"{bulletData.weaponStruct[j].weaponName}UsageLimit";
                if (weaponUsageLimits[i].name == expectedName)
                {
                    if (bulletData.weaponStruct[j].lockState == "")
                    {
                        weaponUsageLimits[i].enabled = true;
                        if (PlayerData.currentLanguage == PlayerData.Languages.Turkish)
                        {
                            weaponUsageLimits[i].text = bulletData.weaponStruct[j].usageLimit > 0
                            ? $"Kullanım Limiti: {bulletData.weaponStruct[j].usageLimit}"
                            : "";
                        }
                        else
                        {
                            weaponUsageLimits[i].text = bulletData.weaponStruct[j].usageLimit > 0
                            ? $"Usage Limit: {bulletData.weaponStruct[j].usageLimit}"
                            : "";
                        }
                        
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break; // Exit inner loop once the correct weapon is found
                }
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
            { $"{bulletData.weaponStruct[0].weaponName}Staff", bulletData.weaponStruct[0].power },
            { $"{bulletData.weaponStruct[1].weaponName}Staff", bulletData.weaponStruct[1].power },
            { $"{bulletData.weaponStruct[2].weaponName}Staff", bulletData.weaponStruct[2].power },
            { $"{bulletData.weaponStruct[3].weaponName}Staff", bulletData.weaponStruct[3].power },
            { $"{bulletData.weaponStruct[4].weaponName}Staff", bulletData.weaponStruct[4].power },
            { $"{bulletData.weaponStruct[5].weaponName}Staff", bulletData.weaponStruct[5].power },
            { $"{bulletData.weaponStruct[6].weaponName}Staff", bulletData.weaponStruct[6].power },
            { $"{bulletData.weaponStruct[7].weaponName}Staff", bulletData.weaponStruct[7].power },
            { $"{bulletData.weaponStruct[8].weaponName}Staff", bulletData.weaponStruct[8].power },
            { $"{bulletData.weaponStruct[9].weaponName}Staff", bulletData.weaponStruct[9].power }
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
        float deltaX = PlayerController.GetWeaponStick().x * menuSlideSpeed * Time.deltaTime;

        // Update the x position based on the player's stick input
        Vector3 newPosition = _panelObject.transform.position + new Vector3(deltaX, 0f, 0f);

        // Clamp the x position to prevent going beyond the limits
        newPosition.x = Mathf.Clamp(newPosition.x, -9000f, 0f);

        // Apply the new position
        _panelObject.transform.position = newPosition;
    }

    public void PickWeapon(int weaponPrice, int weaponID)
    {
        // If the weapon has no remaining uses, lock it and enable bullet creation
        if (bulletData.weaponStruct[weaponID].usageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.weaponStruct[weaponID].lockState = BulletData.locked;
            bulletData.weaponStruct[weaponID].usageLimit = 0;
            PlayerPrefs.SetInt($"{bulletData.weaponStruct[weaponID].weaponName}UsageCount", bulletData.weaponStruct[weaponID].usageLimit);
        }

        // Check if the player can unlock the weapon
        bool hasEnoughCoins = playerCoinData.avaliableCoin >= weaponPrice;
        bool weaponNotInUse = bulletData.currentWeaponName != bulletData.weaponStruct[weaponID].weaponName;
        bool weaponLocked = bulletData.weaponStruct[weaponID].lockState == BulletData.locked;

        if (ButtonController.weaponButtonBools[weaponID] && ButtonController.buttonTimeFlow > .2f)
        {
            if (hasEnoughCoins && weaponNotInUse)
            {
                if (weaponLocked)
                {
                    // Unlock the weapon
                    playerCoinData.avaliableCoin -= weaponPrice;

                    PlayerPrefs.SetInt("AvaliableCoin", playerCoinData.avaliableCoin);

                    bulletData.weaponStruct[weaponID].lockState = bulletData.unLocked;
                    bulletData.weaponStruct[weaponID].usageLimit = 3;
                    PlayerPrefs.SetInt($"{bulletData.weaponStruct[weaponID].weaponName}UsageCount", bulletData.weaponStruct[weaponID].usageLimit);
                    PlayerPrefs.SetFloat($"{bulletData.weaponStruct[weaponID].weaponName}Lock", 1);
                }

                // Set weapon as the current weapon
                SetCurrentWeapon(weaponID);
            }
            else if (!hasEnoughCoins && weaponLocked)
            {
                // Display error for insufficient coins
                DisplayPriceError(weaponPrice - playerCoinData.avaliableCoin, weaponID);
                MenuSoundEffect.GetInstance.MenuSoundEffectStatement(MenuSoundEffect.MenuSoundEffectTypes.MenuNotClick);
            }
            else if (bulletData.weaponStruct[weaponID].lockState == bulletData.unLocked && bulletData.weaponStruct[weaponID].usageLimit > 0 && weaponNotInUse)
            {
                // Set unlocked weapon with remaining usage limit as the current weapon
                SetCurrentWeapon(weaponID);
            }
        }
    }

    private void SetCurrentWeapon(int weaponID)
    {
        bulletData.currentWeaponName = bulletData.weaponStruct[weaponID].weaponName;
        BulletData.currentWeaponID = bulletData.weaponStruct[weaponID].id;

        PlayerPrefs.SetInt("CurrentWeaponID", BulletData.currentWeaponID);

        bulletData.currentBulletPackAmount = bulletData.weaponStruct[weaponID].bulletPackAmount;
        ObjectPool.creatablePlayerBullet = true;

        SceneController.LoadMenuScene();

        weaponPriceErrorTextObjectChilds[0].text = "";
    }

    private void DisplayPriceError(int missingCoins, int weaponID)
    {
        foreach (var textObject in weaponPriceErrorTextObjectChilds)
        {
            if (textObject.gameObject.name == $"{bulletData.weaponStruct[weaponID].weaponName}PriceErrorText")
            {
                textObject.text = PlayerData.currentLanguage == PlayerData.Languages.Turkish
                    ? $"Satin Almak İçin {missingCoins} Daha Coin'e İhtiyacin Var!"
                    : $"You need {missingCoins} More Coin!";
            }
        }
    }

}
