using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletData", menuName = "BulletData")]
public class BulletData : ScriptableObject
{
    [Serializable]
    public struct WeaponStruct
    {
        public GameObject weaponObject;
        public GameObject giftBox;
        public float shootFrequency;
        public float power;
        public string lockState;
        public string weaponName;
        public int usageLimit;
        public int bulletPackAmount;
        public int price;
        public int id;
        public bool isWeapon;
    }

    public WeaponStruct[] weaponStruct = new WeaponStruct[11];

    [Header("Pick Sword Weapon")]
    public string currentSwordName = lowSword;
    public string currentWeaponName = "pistol";
    [Header("Bullet Packs")]
    public int currentBulletPackAmount;
    [Header("Weapon Names")]
    public static int currentWeaponID;

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

    [Header("Weapon Shoot Frequency")]
    public float currentShootFrequency;


    [Header("Weapon Staff")]
    public Dictionary<int, GameObject> weaponStaffs;

    [Header("Avaliable Weapons")]
    //public string[] avaliableWeapons= new string[10];

    [Header("Weapon Locking Modes")]
    public string resetLocks = "locked";
    public const string locked = "locked";
    public string unLocked = "";


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


   /* public enum WeaponNames
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
    }*/

    [Header("Sword Types")]
    public GameObject lowSwordObject;

    [Header("Sword Names")]
    public static int currentSwordID = 0;
    public const string lowSword = "LowSword";

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
