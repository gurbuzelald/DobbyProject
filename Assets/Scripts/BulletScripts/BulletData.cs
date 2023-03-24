using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletData", menuName = "BulletData")]
public class BulletData : ScriptableObject
{
    [Header("Player")]
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

    public bool isRifle;
    public bool isAk47;
    public bool isBulldog;
    public bool isCowgun;
    public bool isCrystalgun;
    public bool isDemongun;
    public bool isIcegun;
    public bool isNegev;
    public bool isAxegun;

    public const string ak47 = "Ak47";
    public const string rifle = "Rifle";
    public const string bulldog = "Bulldog";
    public const string cowgun = "Cowgun";
    public const string crystalgun = "Crystalgun";
    public const string demongun = "Demongun";
    public const string icegun = "Icegun";
    public const string negev = "Negev";
    public const string axegun = "Axegun";



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
    public int enemyBulletDelayCounter = 0;
    public float enemyBulletDelay = 0.05f;
    public float enemyBulletSpeed = 3f;

    public bool isFirable;

}
