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

    [SerializeField] float menuSlideSpeed;


    [SerializeField] TextMeshProUGUI[] weaponUsageLimits;

    
    void Start()
    {
        
        ResetWeaponsLocks();

        _playerController = FindObjectOfType<PlayerController>();

        WeaponPriceError();
        SetWeaponInfos();

    }
    private void Update()
    {
        SlideMenu();
        WeaponPickStates();
        WeaponUsageLimit();
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
                case "NEGEVUsageLimit":
                    if (bulletData.negevLock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.negevUsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "AK47UsageLimit":
                    if (bulletData.ak47Lock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.ak47UsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;
                case "M4A4UsageLimit":
                    if (bulletData.m4a4Lock == "")
                    {
                        weaponUsageLimits[i].enabled = true;

                        weaponUsageLimits[i].text = "Usage Limit: " + bulletData.m4a4UsageLimit.ToString();
                    }
                    else
                    {
                        weaponUsageLimits[i].enabled = false;
                    }
                    break;

            }
        }

    }
    void ResetWeaponsLocks()
    {

        if (bulletData.ak47Lock == bulletData.unLocked &&
            bulletData.axeLock == bulletData.unLocked &&
            bulletData.bulldogLock == bulletData.unLocked &&
            bulletData.cowLock == bulletData.unLocked &&
            bulletData.crystalLock == bulletData.unLocked &&
            bulletData.demonLock == bulletData.unLocked &&
            bulletData.iceLock == bulletData.unLocked &&
            bulletData.negevLock == bulletData.unLocked &&
            bulletData.pistolLock == bulletData.unLocked &&
            bulletData.m4a4Lock == bulletData.unLocked &&
            bulletData.resetLocks == bulletData.unLocked)
        {
            ResetTheWeapons();


            bulletData.ak47Lock = BulletData.locked;
            bulletData.axeLock = BulletData.locked;
            bulletData.bulldogLock = BulletData.locked;
            bulletData.cowLock = BulletData.locked;
            bulletData.crystalLock = BulletData.locked;
            bulletData.iceLock = BulletData.locked;
            bulletData.negevLock = BulletData.locked;
            bulletData.demonLock = BulletData.locked;
            bulletData.pistolLock = BulletData.locked;
            bulletData.m4a4Lock = BulletData.locked;
            bulletData.resetLocks = BulletData.locked;
        }
        else if (bulletData.ak47Lock == BulletData.locked &&
            bulletData.axeLock == BulletData.locked &&
            bulletData.bulldogLock == BulletData.locked &&
            bulletData.cowLock == BulletData.locked &&
            bulletData.crystalLock == BulletData.locked &&
            bulletData.demonLock == BulletData.locked &&
            bulletData.iceLock == BulletData.locked &&
            bulletData.negevLock == BulletData.locked &&
            bulletData.pistolLock == BulletData.locked &&
            bulletData.m4a4Lock == BulletData.locked &&
            bulletData.resetLocks == BulletData.locked)
        {
            bulletData.currentWeaponName = BulletData.ak47;
        }
    }
    public void ResetTheWeapons()
    {
        for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
        {
            bulletData.avaliableWeapons[i] = "";
        }
    }
    void WeaponPickStates()
    {
        if (weaponPriceErrorTextObjects.Length != 0)
        {
            PickAK47(bulletData.ak47Price);
            PickAxe(bulletData.axePrice);
            PickBulldog(bulletData.bulldogPrice);
            PickCow(bulletData.cowPrice);
            PickCrystal(bulletData.crystalPrice);
            PickDemon(bulletData.demonPrice);
            PickIce(bulletData.icePrice);
            PickNegev(bulletData.negevPrice);
            PickPistol(bulletData.pistolPrice);
            PickM4a4(bulletData.m4a4Price);
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
                if (bulletData.weaponStaffs[i].name == "AK47Staff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.ak47Power.ToString();
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
                else if (bulletData.weaponStaffs[i].name == "NegevStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.negevPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "PistolStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.pistolPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "M4A4Staff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.m4a4Power.ToString();
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

    public void PickAK47(int avaliableCoinAmount)
    {
        if (bulletData.ak47UsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.ak47Lock = BulletData.locked;
        }
        if (_playerController.AK47 && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            bulletData.currentWeaponName != BulletData.ak47)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" || bulletData.ak47Lock == BulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = BulletData.ak47;

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.ak47Lock = bulletData.unLocked;

                    ObjectPool.creatablePlayerBullet = true;

                    bulletData.ak47UsageLimit = 3;

                    break;
                }
            }

            bulletData.currentWeaponName = BulletData.ak47;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.AK47 && bulletData.ak47Lock == bulletData.unLocked)
        {
            if (bulletData.ak47UsageLimit > 0 && bulletData.currentWeaponName != BulletData.ak47)
            {
                bulletData.currentWeaponName = BulletData.ak47;

                SceneController.GetInstance.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.ak47Lock == BulletData.locked)
        {
            //bulletData.currentWeaponName = BulletData.ak47;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "AK47PriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }

    public void PickAxe(int avaliableCoinAmount)
    {
        if (bulletData.axeUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.axeLock = BulletData.locked;
        }

        if (_playerController.Axe && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
           bulletData.currentWeaponName != BulletData.axe && bulletData.axeLock == BulletData.locked)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" || bulletData.axeLock == BulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = BulletData.axe;

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.axeLock = bulletData.unLocked;

                    ObjectPool.creatablePlayerBullet = true;

                    bulletData.axeUsageLimit = 3;

                    break;
                }
            }

            bulletData.currentWeaponName = BulletData.axe;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Axe && bulletData.axeLock == bulletData.unLocked)
        {

            if (bulletData.axeUsageLimit > 0 && bulletData.currentWeaponName != BulletData.axe)
            {
                bulletData.currentWeaponName = BulletData.axe;

                SceneController.GetInstance.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;
            }            
            
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.axeLock == BulletData.locked)
        {
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "AXEPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickBulldog(int avaliableCoinAmount)
    {
        if (bulletData.bulldogUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.bulldogLock = BulletData.locked;
        }
        if (_playerController.Bulldog && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.bulldog)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" || bulletData.bulldogLock == BulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = BulletData.bulldog;

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.bulldogLock = bulletData.unLocked;

                    ObjectPool.creatablePlayerBullet = true;

                    bulletData.bulldogUsageLimit = 3;

                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.bulldog;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Bulldog && bulletData.bulldogLock == bulletData.unLocked)
        {
            if (bulletData.bulldogUsageLimit > 0 && bulletData.currentWeaponName != BulletData.bulldog)
            {
                bulletData.currentWeaponName = BulletData.bulldog;

                SceneController.GetInstance.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.bulldogLock == BulletData.locked)
        {
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                //bulletData.currentWeaponName = BulletData.bulldog;

                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "BULLDOGPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickCow(int avaliableCoinAmount)
    {
        if (bulletData.cowUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.cowLock = BulletData.locked;
        }
        if (_playerController.Cow && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.cow)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" || bulletData.cowLock == BulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = BulletData.cow;

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.cowLock = bulletData.unLocked;

                    ObjectPool.creatablePlayerBullet = true;

                    bulletData.cowUsageLimit = 3;

                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.cow;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Cow && bulletData.cowLock == bulletData.unLocked)
        {
            if (bulletData.cowUsageLimit > 0 && bulletData.currentWeaponName != BulletData.cow)
            {
                bulletData.currentWeaponName = BulletData.cow;

                SceneController.GetInstance.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.cowLock == BulletData.locked)
        {

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "COWPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickCrystal(int avaliableCoinAmount)
    {
        if (bulletData.crystalUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.crystalLock = BulletData.locked;
        }
        if (_playerController.Crystal && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            bulletData.currentWeaponName != BulletData.crystal)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" || bulletData.crystalLock == BulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = BulletData.crystal;

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.crystalLock = bulletData.unLocked;

                    ObjectPool.creatablePlayerBullet = true;

                    bulletData.crystalUsageLimit = 3;

                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.crystal;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Crystal && bulletData.crystalLock == bulletData.unLocked)
        {
            if (bulletData.crystalUsageLimit > 0 && bulletData.currentWeaponName != BulletData.crystal)
            {
                bulletData.currentWeaponName = BulletData.crystal;

                SceneController.GetInstance.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.crystalLock == BulletData.locked)
        {
            //bulletData.currentWeaponName = BulletData.crystalgun;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "CRYSTALPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickDemon(int avaliableCoinAmount)
    {
        if (bulletData.demonUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.demonLock = BulletData.locked;
        }
        if (_playerController.Demon && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.demon)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" || bulletData.demonLock == BulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = BulletData.demon;

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.demonLock = bulletData.unLocked;

                    ObjectPool.creatablePlayerBullet = true;

                    bulletData.demonUsageLimit = 3;

                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.demon;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Demon && bulletData.demonLock == bulletData.unLocked)
        {
            if (bulletData.demonUsageLimit > 0 && bulletData.currentWeaponName != BulletData.demon)
            {
                bulletData.currentWeaponName = BulletData.demon;

                SceneController.GetInstance.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.demonLock == BulletData.locked)
        {
            //bulletData.currentWeaponName = BulletData.demongun;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "DEMONPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickIce(int avaliableCoinAmount)
    {
        if (bulletData.iceUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.iceLock = BulletData.locked;
        }
        if (_playerController.Ice && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.ice)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" || bulletData.iceLock == BulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = BulletData.ice;

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.iceLock = bulletData.unLocked;

                    ObjectPool.creatablePlayerBullet = true;

                    bulletData.iceUsageLimit = 3;

                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.ice;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Ice && bulletData.iceLock == bulletData.unLocked)
        {
            if (bulletData.iceUsageLimit > 0 && bulletData.currentWeaponName != BulletData.ice)
            {
                bulletData.currentWeaponName = BulletData.ice;

                SceneController.GetInstance.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.iceLock == BulletData.locked)
        {
            //bulletData.currentWeaponName = BulletData.icegun;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "ICEPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void PickNegev(int avaliableCoinAmount)
    {
        if (bulletData.negevUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.negevLock = BulletData.locked;
        }
        if (_playerController.Negev && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.negev)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" || bulletData.negevLock == BulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = BulletData.negev;

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.negevLock = bulletData.unLocked;

                    ObjectPool.creatablePlayerBullet = true;

                    bulletData.negevUsageLimit = 3;

                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.negev;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Negev && bulletData.negevLock == bulletData.unLocked)
        {
            if (bulletData.negevUsageLimit > 0 && bulletData.currentWeaponName != BulletData.negev)
            {
                bulletData.currentWeaponName = BulletData.negev;

                SceneController.GetInstance.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.negevLock == BulletData.locked)
        {
            //bulletData.currentWeaponName = BulletData.negev;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "NEGEVPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }

    public void PickPistol(int avaliableCoinAmount)
    {
        if (bulletData.pistolUsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.pistolLock = BulletData.locked;
        }
        if (_playerController.Pistol && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.pistol)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" || bulletData.pistolLock == BulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = BulletData.pistol;

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.pistolLock = bulletData.unLocked;

                    ObjectPool.creatablePlayerBullet = true;

                    bulletData.pistolUsageLimit = 3;

                    break;
                }
            }

            bulletData.currentWeaponName = BulletData.pistol;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Pistol && bulletData.pistolLock == bulletData.unLocked)
        {
            if (bulletData.pistolUsageLimit > 0 && bulletData.currentWeaponName != BulletData.pistol)
            {
                bulletData.currentWeaponName = BulletData.pistol;

                SceneController.GetInstance.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.pistolLock == BulletData.locked)
        {
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "PISTOLPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }

    public void PickM4a4(int avaliableCoinAmount)
    {
        if (bulletData.m4a4UsageLimit <= 0)
        {
            ObjectPool.creatablePlayerBullet = true;
            bulletData.m4a4Lock = BulletData.locked;
        }
        if (_playerController.M4A4 && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.m4a4)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" || bulletData.m4a4Lock == BulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = BulletData.m4a4;

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.m4a4Lock = bulletData.unLocked;

                    ObjectPool.creatablePlayerBullet = true;

                    bulletData.m4a4UsageLimit = 3;

                    break;
                }
            }


            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.M4A4 && bulletData.m4a4Lock == bulletData.unLocked)
        {
            if (bulletData.m4a4UsageLimit > 0 && bulletData.currentWeaponName != BulletData.m4a4)
            {
                bulletData.currentWeaponName = BulletData.m4a4;

                SceneController.GetInstance.LoadMenuScene();

                ObjectPool.creatablePlayerBullet = true;
            }
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.m4a4Lock == BulletData.locked)
        {

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "M4A4PriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }


}
