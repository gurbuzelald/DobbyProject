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
    public string currentSwordName = lowSword;
    public string currentWeaponName = "pistol";
    public int currentBulletPackAmount;
    public static int currentWeaponID;

    [Header("Bullet Transform")]
    public float weaponBulletDelay;
    public float swordBulletDelay;
    
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


    public bool isFirable;

    [Header("Sword Types")]
    public GameObject lowSwordObject;

    [Header("Sword Names")]
    public static int currentSwordID = 0;
    public const string lowSword = "LowSword";

    public bool isLowSword;
}
