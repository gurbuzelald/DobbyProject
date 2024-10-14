using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletData", menuName = "BulletData")]
public class BulletData : ScriptableObject
{
    [Header("Pick Sword Weapon")]
    public string currentSwordName = warriorSword;
    public string currentWeaponName = pistol;

    [Header("Player")]
    [Header("WeaponGiftBoxes")]
    public GameObject[] giftBoxes;
    

    [Header("Bullet Transform")]
    public float weaponBulletDelay;
    public float swordBulletDelay;
    public float bulletSpeed = 5f;
    public float swordSpeed = 1f;
    public int bulletDelayCounter;
    public GameObject _swordingObject;

    [Header("Weapon GiftBoxes")]
    public GameObject currentGiftBox;
    public GameObject pistolGiftBox;
    public GameObject machineGiftBox;
    public GameObject bullDogGiftBox; //+
    public GameObject cowGiftBox; //+
    public GameObject crystalGiftBox; //+
    public GameObject demonGiftBox; //+
    public GameObject iceGiftBox; //+
    public GameObject electroGiftBox; //+
    public GameObject shotGunGiftBox;
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
    public float electroShootFrequency;
    public float shotGunShootFrequency;
    public float machineShootFrequency;


    [Header("Weapon Types")]
    public GameObject shotGunObject;
    public GameObject machineObject;
    public GameObject bullDogObject;
    public GameObject cowObject;
    public GameObject crsytalObject;
    public GameObject demonObject;
    public GameObject iceObject;
    public GameObject electroObject;
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
    public int electroPower;
    public int shotGunPower;
    public int machinePower;

    [Header("Weapons Prices")]
    public int pistolPrice;    
    public int axePrice;
    public int bulldogPrice;
    public int cowPrice;
    public int crystalPrice;
    public int demonPrice;
    public int icePrice;
    public int electroPrice;
    public int shotGunPrice;
    public int machinePrice;

    [Header("Weapon Staff")]
    public Dictionary<int, GameObject> weaponStaffs;

    [Header("Avaliable Weapons")]
    //public string[] avaliableWeapons= new string[10];

    [Header("Weapon Locking Modes")]
    public string pistolLock;
    public string axeLock;
    public string bulldogLock;
    public string cowLock;
    public string crystalLock;
    public string demonLock;
    public string iceLock;
    public string electroLock;
    public string shotGunLock;
    public string machineLock;
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
    public int electroUsageLimit = 0;
    public int axeUsageLimit = 0;
    public int machineUsageLimit = 0;
    public int shotGunUsageLimit = 0;

    [Header("Check Pistol")]
    public bool isPistol;
    public bool isBulldog;
    public bool isCow;
    public bool isCrystal;
    public bool isDemon;
    public bool isIce;
    public bool isElectro;
    public bool isAxe;
    public bool isMachine;
    public bool isShotGun;

    [Header("Bullet Packs")]
    public int currentBulletPack;
    public int pistolBulletAmount;
    public int axeBulletAmount;
    public int bulldogBulletAmount;
    public int cowBulletAmount;
    public int crystalBulletAmount;
    public int demonBulletAmount;
    public int iceBulletAmount;
    public int electroBulletAmount;
    public int shotGunBulletAmount;
    public int machineBulletAmount;

    [Header("Weapon Names")]
    public static int currentWeaponID;
    public const string pistol = "pistol";
    public const string axe = "axe";
    public const string bulldog = "bulldog";
    public const string cow = "cow";
    public const string crystal = "crystal";
    public const string demon = "demon";
    public const string ice = "ice";
    public const string electro = "electro";
    public const string shotGun = "shotGun";
    public const string machine = "machine";

    [Header("Enemy Weapon Names")]
    public static int currentEnemyBulletID = 0;
    public const string chibiBullet = "ChibiBullet(Clone)";
    public const string minoBullet = "MinoBullet(Clone)";
    public const string bigMonsterBullet = "BigMonsterBullet(Clone)";
    public const string orcBullet = "OrcBBullet(Clone)";
    public const string beholderBullet = "BeholderBullet(Clone)";
    public const string femaleZombieBullet = "FemaleZombieBullet(Clone)";
    public const string doctorBullet = "DoctorBullet(Clone)";
    public const string giantBullet = "GiantBullet(Clone)";
    public const string boneBullet = "BoneBullet(Clone)";
    public const string clothyBoneBullet = "ClothyBoneBullet(Clone)";


    [Header("Enemy Bullet Damages")]
    public int currentEnemyBulletDamage;
    public int chibiEnemyBulletDamage;
    public int minoEnemyBulletDamage;
    public int bigMonsterEnemyBulletDamage;
    public int orcEnemyBulletDamage;
    public int boneEnemyBulletDamage;
    public int morakEnemyBulletDamage;
    public int beholderEnemyBulletDamage;
    public int femaleZombieEnemyBulletDamage;
    public int doctorEnemyBulletDamage;
    public int giantEnemyBulletDamage;
    public int clothyBoneEnemyBulletDamage;
    public int chestMonsterEnemyBulletDamage;
    public int chestMonster2EnemyBulletDamage;

    [Header("Enemy Attack Damages")]
    public int currentEnemyAttackDamage;
    public int chibiEnemyAttackDamage;
    public int minoEnemyAttackDamage;
    public int bigMonsterEnemyAttackDamage;
    public int orcEnemyAttackDamage;
    public int boneEnemyAttackDamage;
    public int morakEnemyAttackDamage;
    public int beholderEnemyAttackDamage;
    public int femaleZombieEnemyAttackDamage;
    public int doctorEnemyAttackDamage;
    public int giantEnemyAttackDamage;
    public int clothyBoneEnemyAttackDamage;
    public int chestMonsterEnemyAttackDamage;
    public int chestMonster2EnemyAttackDamage;


    [Header("Enemy Collision Damages")]
    public int currentEnemyCollisionDamage;
    public int chibiEnemyCollisionDamage;
    public int minoEnemyCollisionDamage;
    public int bigMonsterEnemyCollisionDamage;
    public int orcEnemyCollisionDamage;
    public int beholderEnemyCollisionDamage;
    public int femaleZombieEnemyCollisionDamage;
    public int doctorEnemyCollisionDamage;
    public int giantEnemyCollisionDamage;
    public int boneEnemyCollisionDamage;
    public int clothyBoneEnemyCollisionDamage;
    public int chestMonsterEnemyCollisionDamage;
    public int chestMonster2EnemyCollisionDamage;


    public enum WeaponNames
    {
        pistol,
        axe,
        bulldog,
        cow,
        crystal,
        demon,
        ice,
        electro,
        shotGun,
        machine
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



    [Header("Sword Power")]
    public float swordDamageValue;


    [Header("Enemy")]
    [Header("Bullet Transform")]
    public float enemyFireFrequency;
    public float enemyBulletDelayCounter = 0;
    public float enemyBulletDelay = 0.05f;
    public float enemyBulletSpeed;


    public bool isFirable;

   
}
