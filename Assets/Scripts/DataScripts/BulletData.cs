using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBulletData", menuName = "Scriptable Objects/BulletData")]
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
        public float bulletSpeed;
        public float swordSpeed;
    }

    public WeaponStruct[] weaponStruct = new WeaponStruct[11];    

    [Header("Player")]
    public string currentSwordName;
    public static string currentWeaponName;
    public static int currentBulletPackAmount;
    public static int currentWeaponID;

    [Header("Bullet Transform")]
    public float weaponBulletDelay;
    public float swordBulletDelay;    

    [Header("Weapon GiftBoxes")]
    public static GameObject currentGiftBox;

    [Header("Weapon Shoot Frequency")]
    public static float currentShootFrequency;


    [Header("Weapon Staff")]
    public Dictionary<int, GameObject> weaponStaffs;

    [Header("Avaliable Weapons")]
    //public string[] avaliableWeapons= new string[10];

    [Header("Weapon Locking Modes")]
    public static string resetLocks = "locked";
    public const string locked = "locked";
    public static string unLocked = "";


    public static bool isFirable;

    [Header("Sword Types")]
    public GameObject lowSwordObject;

    [Header("Sword Names")]
    public static int currentSwordID = 0;
    public const string lowSword = "LowSword";

    public static bool isLowSword;
}
