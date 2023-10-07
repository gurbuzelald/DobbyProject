using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseWeaponController : MonoBehaviour
{
    private GameObject weaponPriceErrorTextObjects;
    private TextMeshProUGUI[] weaponPriceErrorTextObjectChilds;

    private PlayerController _playerController;

    [SerializeField] GameObject _panelObject;


    [SerializeField] BulletData bulletData;
    [SerializeField] PlayerCoinData playerCoinData;
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
        WeaponChooseStates();
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
            bulletData.rifleLock == bulletData.unLocked &&
            bulletData.resetLocks == bulletData.unLocked)
        {
            ResetTheWeapons();


            bulletData.ak47Lock = bulletData.locked;
            bulletData.axeLock = bulletData.locked;
            bulletData.bulldogLock = bulletData.locked;
            bulletData.cowLock = bulletData.locked;
            bulletData.crystalLock = bulletData.locked;
            bulletData.iceLock = bulletData.locked;
            bulletData.negevLock = bulletData.locked;
            bulletData.demonLock = bulletData.locked;
            bulletData.pistolLock = bulletData.locked;
            bulletData.rifleLock = bulletData.locked;
            bulletData.resetLocks = bulletData.locked;
        }
        else if (bulletData.ak47Lock == bulletData.locked &&
            bulletData.axeLock == bulletData.locked &&
            bulletData.bulldogLock == bulletData.locked &&
            bulletData.cowLock == bulletData.locked &&
            bulletData.crystalLock == bulletData.locked &&
            bulletData.demonLock == bulletData.locked &&
            bulletData.iceLock == bulletData.locked &&
            bulletData.negevLock == bulletData.locked &&
            bulletData.pistolLock == bulletData.locked &&
            bulletData.rifleLock == bulletData.locked &&
            bulletData.resetLocks == bulletData.locked)
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
    void WeaponChooseStates()
    {
        if (weaponPriceErrorTextObjects)
        {
            ChoosedAK47(bulletData.ak47Price);
            ChoosedAxegun(bulletData.axegunPrice);
            ChoosedBulldog(bulletData.bulldogPrice);
            ChoosedCow(bulletData.cowgunPrice);
            ChoosedCrystal(bulletData.crystalgunPrice);
            ChoosedDemon(bulletData.demongunPrice);
            ChoosedIce(bulletData.icegunPrice);
            ChoosedNegev(bulletData.negevPrice);
            ChoosedPistol(bulletData.pistolPrice);
            ChoosedRifle(bulletData.riflePrice);
        }
    }
    void WeaponPriceError()
    {
        weaponPriceErrorTextObjects = GameObject.Find("WeaponPriceErrorTexts");

        if (weaponPriceErrorTextObjects)
        {
            weaponPriceErrorTextObjectChilds = new TextMeshProUGUI[weaponPriceErrorTextObjects.transform.childCount];

            for (int i = 0; i < weaponPriceErrorTextObjects.transform.childCount; i++)
            {
                weaponPriceErrorTextObjectChilds[i] = weaponPriceErrorTextObjects.transform.GetChild(i).GetComponent<TextMeshProUGUI>();
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
                else if (bulletData.weaponStaffs[i].name == "AxegunStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.axegunPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "BulldogStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.bulldogPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "CowStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.cowgunPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "CrystalStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.crystalgunPower.ToString();

                }
                else if (bulletData.weaponStaffs[i].name == "DemonStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.demongunPower.ToString();
                }
                else if (bulletData.weaponStaffs[i].name == "IceStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.icegunPower.ToString();
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
                else if (bulletData.weaponStaffs[i].name == "RifleStaff")
                {
                    bulletData.weaponStaffs[i].transform.GetChild(0).transform.Rotate(new Vector3(0F, Time.deltaTime * 50f, 0f));

                    bulletData.weaponStaffs[i].transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>().text = bulletData.riflePower.ToString();
                }
            }
        }
    }

    void SlideMenu()
    {
        if (_playerController.weaponStick.x < 0f)
        {
            for (int i = 0; i < bulletData.weaponStaffs.Count; i++)
            {
                _panelObject.transform.position = new Vector3(_panelObject.transform.position.x - 1.5f * Time.deltaTime,
                                                             _panelObject.transform.position.y,
                                                             _panelObject.transform.position.z);
            }
        }
        if (_playerController.weaponStick.x > 0f)
        {
            for (int i = 0; i < bulletData.weaponStaffs.Count; i++)
            {
                _panelObject.transform.position = new Vector3(_panelObject.transform.position.x + 1.5f * Time.deltaTime,
                                                             _panelObject.transform.position.y,
                                                             _panelObject.transform.position.z);
            }
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

    public void ChoosedAK47(int avaliableCoinAmount)
    {
        if (_playerController.AK47 && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            bulletData.currentWeaponName != BulletData.ak47)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" && bulletData.ak47Lock == bulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = "AK47";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.ak47Lock = bulletData.unLocked;
                    break;
                }
            }

            bulletData.currentWeaponName = BulletData.ak47;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.AK47 && bulletData.ak47Lock == bulletData.unLocked)
        {
            bulletData.currentWeaponName = BulletData.ak47;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.ak47Lock == bulletData.locked)
        {
            bulletData.currentWeaponName = BulletData.ak47;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "AK47PriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }

    public void ChoosedAxegun(int avaliableCoinAmount)
    {
        if (_playerController.Axe && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
           bulletData.currentWeaponName != BulletData.axegun)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" && bulletData.axeLock == bulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = "AXE";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.axeLock = bulletData.unLocked;
                    break;
                }
            }

            bulletData.currentWeaponName = BulletData.axegun;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Axe && bulletData.axeLock == bulletData.unLocked)
        {
            bulletData.currentWeaponName = BulletData.axegun;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.axeLock == bulletData.locked)
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
    public void ChoosedBulldog(int avaliableCoinAmount)
    {
        if (_playerController.Bulldog && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.bulldog)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" && bulletData.bulldogLock == bulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = "BULLDOG";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.bulldogLock = bulletData.unLocked;
                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.bulldog;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Bulldog && bulletData.bulldogLock == bulletData.unLocked)
        {
            bulletData.currentWeaponName = BulletData.bulldog;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.bulldogLock == bulletData.locked)
        {
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                bulletData.currentWeaponName = BulletData.bulldog;

                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "BULLDOGPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void ChoosedCow(int avaliableCoinAmount)
    {
        if (_playerController.Cow && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.cowgun)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" && bulletData.cowLock == bulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = "COW";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.cowLock = bulletData.unLocked;
                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.cowgun;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Cow && bulletData.cowLock == bulletData.unLocked)
        {
            bulletData.currentWeaponName = BulletData.cowgun;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.cowLock == bulletData.locked)
        {
            bulletData.currentWeaponName = BulletData.cowgun;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "COWPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void ChoosedCrystal(int avaliableCoinAmount)
    {
        if (_playerController.Crystal && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
            bulletData.currentWeaponName != BulletData.crystalgun)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" && bulletData.crystalLock == bulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = "CRYSTAL";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.crystalLock = bulletData.unLocked;
                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.crystalgun;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Crystal && bulletData.crystalLock == bulletData.unLocked)
        {
            bulletData.currentWeaponName = BulletData.crystalgun;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.crystalLock == bulletData.locked)
        {
            bulletData.currentWeaponName = BulletData.crystalgun;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "CRYSTALPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void ChoosedDemon(int avaliableCoinAmount)
    {
        if (_playerController.Demon && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.demongun)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" && bulletData.demonLock == bulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = "DEMON";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.demonLock = bulletData.unLocked;
                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.demongun;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Demon && bulletData.demonLock == bulletData.unLocked)
        {
            bulletData.currentWeaponName = BulletData.demongun;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.demonLock == bulletData.locked)
        {
            bulletData.currentWeaponName = BulletData.demongun;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "DEMONPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void ChoosedIce(int avaliableCoinAmount)
    {
        if (_playerController.Ice && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.icegun)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" && bulletData.iceLock == bulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = "ICE";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.iceLock = bulletData.unLocked;
                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.icegun;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Ice && bulletData.iceLock == bulletData.unLocked)
        {
            bulletData.currentWeaponName = BulletData.icegun;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.iceLock == bulletData.locked)
        {
            bulletData.currentWeaponName = BulletData.icegun;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "ICEPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }
    public void ChoosedNegev(int avaliableCoinAmount)
    {
        if (_playerController.Negev && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.negev)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" && bulletData.negevLock == bulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = "NEGEV";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.negevLock = bulletData.unLocked;
                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.negev;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Negev && bulletData.negevLock == bulletData.unLocked)
        {
            bulletData.currentWeaponName = BulletData.negev;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.negevLock == bulletData.locked)
        {
            bulletData.currentWeaponName = BulletData.negev;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "NEGEVPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }

    public void ChoosedPistol(int avaliableCoinAmount)
    {
        if (_playerController.Pistol && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.pistol)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" && bulletData.pistolLock == bulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = "PISTOL";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.pistolLock = bulletData.unLocked;
                    break;
                }
            }

            bulletData.currentWeaponName = BulletData.pistol;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();
        }
        else if (_playerController.Pistol && bulletData.pistolLock == bulletData.unLocked)
        {
            bulletData.currentWeaponName = BulletData.pistol;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.pistolLock == bulletData.locked)
        {
            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                bulletData.currentWeaponName = BulletData.pistol;

                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "PISTOLPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }

    public void ChoosedRifle(int avaliableCoinAmount)
    {
        if (_playerController.Rifle && playerCoinData.avaliableCoin >= avaliableCoinAmount &&
          bulletData.currentWeaponName != BulletData.rifle)
        {
            for (int i = 0; i < bulletData.avaliableWeapons.Length; i++)
            {
                if (bulletData.avaliableWeapons[i] == "" && bulletData.rifleLock == bulletData.locked)
                {
                    bulletData.avaliableWeapons[i] = "RIFLE";

                    playerCoinData.avaliableCoin -= avaliableCoinAmount;

                    bulletData.rifleLock = bulletData.unLocked;
                    break;
                }
            }
            bulletData.currentWeaponName = BulletData.rifle;

            weaponPriceErrorTextObjectChilds[0].text = "";

            SceneController.GetInstance.LoadMenuScene();

        }
        else if (_playerController.Rifle && bulletData.rifleLock == bulletData.unLocked)
        {
            bulletData.currentWeaponName = BulletData.rifle;

            SceneController.GetInstance.LoadMenuScene();
        }
        else if ((avaliableCoinAmount - playerCoinData.avaliableCoin) > 0 && bulletData.rifleLock == bulletData.locked)
        {
            bulletData.currentWeaponName = BulletData.rifle;

            for (int i = 0; i < weaponPriceErrorTextObjectChilds.Length; i++)
            {
                if (weaponPriceErrorTextObjectChilds[i].gameObject.name == "RIFLEPriceErrorText")
                {
                    weaponPriceErrorTextObjectChilds[i].text = "You need " + (avaliableCoinAmount - playerCoinData.avaliableCoin).ToString() + " More Coin!";
                }
            }
        }
    }


}
