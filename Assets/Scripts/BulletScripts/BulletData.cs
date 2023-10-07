using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletData", menuName = "BulletData")]
public class BulletData : ScriptableObject
{
    [Header("Player")]
    [Header("WeaponGiftBoxes")]
    public GameObject[] giftBoxes;

    [Header("Bullet Transform")]
    public float swordBulletDelay = 0.05f;
    public float weaponBulletDelay = 0.05f;
    public float bulletSpeed = 5f;
    public int bulletDelayCounter;
    public GameObject _bulletObject;
    public GameObject _swordingObject;

    [Header("Weapon Types")]
    public GameObject ak47Object;
    public GameObject ak47GiftBox;
    public GameObject rifleObject;
    public GameObject rifleGiftBox;
    public GameObject bullDogObject;
    public GameObject bullDogGiftBox;
    public GameObject cowgunObject;
    public GameObject cowgunGiftBox;
    public GameObject crsytalgunObject;
    public GameObject crsytalgunGiftBox;
    public GameObject demongunObject;
    public GameObject demongunGiftBox;
    public GameObject icegunObject;
    public GameObject icegunGiftBox;
    public GameObject negevObject;
    public GameObject negevGiftBox;
    public GameObject axegunObject;
    public GameObject axegunGiftBox;
    public GameObject pistolObject;
    public GameObject pistolGiftBox;


    public int ak47Power;
    public int axegunPower;
    public int bulldogPower;
    public int cowgunPower;
    public int crystalgunPower;
    public int demongunPower;
    public int icegunPower;
    public int negevPower;
    public int pistolPower;
    public int riflePower;

    public int ak47Price;
    public int axegunPrice;
    public int bulldogPrice;
    public int cowgunPrice;
    public int crystalgunPrice;
    public int demongunPrice;
    public int icegunPrice;
    public int negevPrice;
    public int pistolPrice;
    public int riflePrice;

    [Header("Weapon Staff")]
    public Dictionary<int, GameObject> weaponStaffs;

    [Header("Avaliable Weapons")]
    public string[] avaliableWeapons= new string[10];

    [Header("Weapon Locking Modes")]
    public string ak47Lock = "locked";
    public string axeLock = "locked";
    public string bulldogLock = "locked";
    public string cowLock = "locked";
    public string crystalLock = "locked";
    public string demonLock = "locked";
    public string iceLock = "locked";
    public string negevLock = "locked";
    public string pistolLock = "locked";
    public string rifleLock = "locked";
    public string resetLocks = "locked";
    public string locked = "locked";
    public string unLocked = "";


    public bool isRifle;
    public bool isPistol;
    public bool isAk47;
    public bool isBulldog;
    public bool isCowgun;
    public bool isCrystalgun;
    public bool isDemongun;
    public bool isIcegun;
    public bool isNegev;
    public bool isAxegun;

    public const string ak47 = "ak47";
    public const string rifle = "rifle";
    public const string bulldog = "bulldog";
    public const string cowgun = "cowgun";
    public const string crystalgun = "crystalgun";
    public const string demongun = "demongun";
    public const string icegun = "icegun";
    public const string negev = "negev";
    public const string axegun = "axegun";
    public const string pistol = "pistol";



    [Header("Sword Types")]
    public GameObject lowSwordObject;
    public GameObject warriorSwordObject;
    public GameObject hummerObject;
    public GameObject orcSwordObject;
    public GameObject axeObject;
    public GameObject axeKnightObject;
    public GameObject barbarianSwordObject;
    public GameObject demonSwordObject;
    public GameObject magicWeaponObject;
    public GameObject longHummerObject;
    public GameObject clubObject;

    public const string lowSword = "LowSword";
    public const string warriorSword = "WarriorSword";
    public const string hummer = "Hummer";
    public const string orcSword = "OrcSword";
    public const string axeSword = "Axe";
    public const string axeKnight = "AxeKnight";
    public const string barbarianSword = "BarbarianSword";
    public const string demonSword = "DemonSword";
    public const string magicSword = "MagicWeapon";
    public const string longHummer = "LongHummer";
    public const string club = "Club";

    public bool isLowSword;
    public bool isWarriorSword;
    public bool isHummer;
    public bool isOrcSword;
    public bool isAxeSword;
    public bool isAxeKnight;
    public bool isBarbarianSword;
    public bool isDemonSword;
    public bool isMagicSword;
    public bool isLongHummer;
    public bool isClub;



    [Header("ChooseSword")]
    public string currentSwordName = warriorSword;
    public string currentWeaponName = ak47;

    [Header("Enemy")]
    [Header("Bullet Transform")]
    public float enemyFireFrequency = 5f;
    public float enemyBulletDelayCounter = 0;
    public float enemyBulletDelay = 0.05f;
    public float enemyBulletSpeed = 3f;

    public bool isFirable;

    public enum WeaponNames
    {
        AK47,
        Bulldog,
        Cowgun,
        Crystalgun,
        Demongun,
        Icegun,
        Negev,
        Eve,
        Axegun,
        Pistol,
        Rifle
    }
}
