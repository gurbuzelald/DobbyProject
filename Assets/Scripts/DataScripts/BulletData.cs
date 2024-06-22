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
    public GameObject _swordingObject;

    [Header("Weapon GiftBoxes")]
    public GameObject currentGiftBox;
    public GameObject pistolGiftBox;
    public GameObject m4a4GiftBox;
    public GameObject bullDogGiftBox; //+
    public GameObject cowGiftBox; //+
    public GameObject crystalGiftBox; //+
    public GameObject demonGiftBox; //+
    public GameObject iceGiftBox; //+
    public GameObject negevGiftBox; //+
    public GameObject ak47GiftBox;
    public GameObject axeGiftBox; //+



    [Header("Weapon Shoot Frequency")]
    public float currentShootFrequency;
    public float pistolShootFrequency;
    public float axeShootFrequency;
    public float bulldogShootFrequency;
    public float cowShootFrequency;
    public float crystalShootFrequency;
    public float demonShootFrequency;
    public float iceShootFrequency;
    public float negevShootFrequency;
    public float ak47ShootFrequency;
    public float m4a4ShootFrequency;


    [Header("Weapon Types")]
    public GameObject ak47Object;
    public GameObject m4a4Object;
    public GameObject bullDogObject;
    public GameObject cowObject;
    public GameObject crsytalObject;
    public GameObject demonObject;
    public GameObject iceObject;
    public GameObject negevObject;
    public GameObject axeObject;
    public GameObject pistolObject;

    [Header("Weapons Powers")]
    public int pistolPower;
    public int axePower;
    public int bulldogPower;
    public int cowPower;
    public int crystalPower;
    public int demonPower;
    public int icePower;
    public int negevPower;
    public int ak47Power;
    public int m4a4Power;

    [Header("Weapons Prices")]
    public int pistolPrice;    
    public int axePrice;
    public int bulldogPrice;
    public int cowPrice;
    public int crystalPrice;
    public int demonPrice;
    public int icePrice;
    public int negevPrice;
    public int ak47Price;
    public int m4a4Price;

    [Header("Weapon Staff")]
    public Dictionary<int, GameObject> weaponStaffs;

    [Header("Avaliable Weapons")]
    public string[] avaliableWeapons= new string[10];

    [Header("Weapon Locking Modes")]
    public string pistolLock = "locked";
    public string axeLock = "locked";
    public string bulldogLock = "locked";
    public string cowLock = "locked";
    public string crystalLock = "locked";
    public string demonLock = "locked";
    public string iceLock = "locked";
    public string negevLock = "locked";
    public string ak47Lock = "locked";
    public string m4a4Lock = "locked";
    public string resetLocks = "locked";
    public const string locked = "locked";
    public string unLocked = "";

    [Header("Weapon Usage Limites")]
    public int pistolUsageLimit = 0;
    public int bulldogUsageLimit = 0;
    public int cowUsageLimit = 0;
    public int crystalUsageLimit = 0;
    public int demonUsageLimit = 0;
    public int iceUsageLimit = 0;
    public int negevUsageLimit = 0;
    public int axeUsageLimit = 0;
    public int m4a4UsageLimit = 0;
    public int ak47UsageLimit = 0;

    [Header("Check Pistol")]
    public bool isPistol;
    public bool isBulldog;
    public bool isCow;
    public bool isCrystal;
    public bool isDemon;
    public bool isIce;
    public bool isNegev;
    public bool isAxe;
    public bool isM4a4;
    public bool isAk47;

    [Header("Weapon Names")]
    public static int currentWeaponID = 0;
    public const string pistol = "pistol";
    public const string axe = "axe";
    public const string bulldog = "bulldog";
    public const string cow = "cow";
    public const string crystal = "crystal";
    public const string demon = "demon";
    public const string ice = "ice";
    public const string negev = "negev";
    public const string ak47 = "ak47";
    public const string m4a4 = "m4a4";

    [Header("Enemy Weapon Names")]
    public static int currentEnemyBulletID = 0;
    public const string clownBullet = "ClownBullet(Clone)";
    public const string monsterBullet = "MonsterBullet(Clone)";
    public const string prisonerBullet = "PrisonerBullet(Clone)";
    public const string pedrosoBullet = "PedrosoBullet(Clone)";
    public const string copBullet = "CopBullet(Clone)";
    public const string morakBullet = "MorakBullet(Clone)";
    public const string ortizBullet = "OrtizBullet(Clone)";
    public const string skeletonBullet = "SkeletonBullet(Clone)";
    public const string urielBullet = "UrielBullet(Clone)";
    public const string goblinBullet = "GoblinBullet(Clone)";


    public enum WeaponNames
    {
        pistol,
        axe,
        bulldog,
        cow,
        crystal,
        demon,
        ice,
        negev,
        ak47,
        m4a4
    }



    [Header("Sword Types")]
    public GameObject lowSwordObject;
    public GameObject warriorSwordObject;
    public GameObject hummerObject;
    public GameObject orcObject;
    public GameObject axeSwordObject;
    public GameObject axeKnightObject;
    public GameObject barbarianSwordObject;
    public GameObject demonSwordObject;
    public GameObject magicWeaponObject;
    public GameObject longHummerObject;
    public GameObject clubObject;

    [Header("Sword Names")]
    public static int currentSwordID = 0;
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



    [Header("Pick Sword")]
    public string currentSwordName = warriorSword;
    public string currentWeaponName = pistol;

    [Header("Sword Power")]
    public float swordDamageValue;


    [Header("Enemy")]
    [Header("Bullet Transform")]
    public float enemyFireFrequency = 5f;
    public float enemyBulletDelayCounter = 0;
    public float enemyBulletDelay = 0.05f;
    public float enemyBulletSpeed;


    public bool isFirable;

   
}
