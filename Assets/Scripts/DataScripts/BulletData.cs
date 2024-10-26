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
        public GameObject giftBoxTransform;
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

    [Header("Player")]
    public string currentSwordName = lowSword;
    public string currentWeaponName = "pistol";
    public int currentBulletPackAmount;
    public static int currentWeaponID;

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



    [Serializable]
    public struct EnemyAttackInfos
    {
        public string bulletName;
        public int id;
        public int bulletDamage;
        public int attackDamage;
        public int hitDamage;
    }

    public EnemyAttackInfos[] enemyAttackInfos = new EnemyAttackInfos[12];


    public int currentEnemyBulletDamage;
    public int currentEnemyAttackDamage;
    public int currentEnemyHitDamage;

    [Header("Bullet Transform")]
    public float enemyFireFrequency;
    public float enemyBulletDelayCounter = 0;
    public float enemyBulletDelay = 0.05f;
    public float enemyBulletSpeed;


    public bool isFirable;

    [Header("Sword Types")]
    public GameObject lowSwordObject;

    [Header("Sword Names")]
    public static int currentSwordID = 0;
    public const string lowSword = "LowSword";

    public bool isLowSword;

    [Header("Sword Power")]
    public float swordDamageValue;
}
