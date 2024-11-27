using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "Scriptable Objects/PlayerData")]
public class PlayerData : ScriptableObject
{
    [Serializable]
    public struct CharacterStruct
    {
        public string name;
        public GameObject characterObject;
        public int durability;
        public int price;
        public int jumpForce;
        public float speed;
        public int id;        
        public string lockState;
        public float swordDamageValue;
    }

    public CharacterStruct[] characterStruct = new CharacterStruct[11];

    public static int currentCharacterID;

    public static int currentCharacterDurability;

    public static bool currentBulletExplosionIsChanged;

    public static float currentJumpForce;

    public static float currentCharacterSpeed;


    public static int GetCharacterID()
    {
        return currentCharacterID;
    }

    [Serializable]
    public struct Pool
    {
        public Queue<GameObject> pooledObjects;
        public GameObject[] objectPrefab;
        public int poolSize;
    }

    public Pool[] pools = null;


    [Header("Player Object")]
    public GameObject playerObject;
    public GameObject characterObject;

    [Header("Player Object Pool IDs")]
    public int playerWeaponBulletObjectPoolCount;//0
    public int playerSwordBulletObjectPoolCount;//1    
    public int playerBulletsExplosionObjectPoolCount;//2
    public int playerSwordExplosionObjectPoolCount;//3
    public int playerBurningTouchParticleObjectPoolCount;//4
    public int playerTouchParticleObjectPoolCount;//5
    public int deathParticleObjectPoolCount;//6
    public int enemyDeathParticleOjectPoolID;//7
    public int playerRunParticleOjectPoolID;//8

    [Header("Environment Object Pool IDs")]
    public int destroyCoinParticleObjectPoolCount;//0
    public int destroyBulletCoinParticleObjectPoolCount;//1
    public int destroyHealthCoinObjectPoolCount;//2
    public int destroyMushroomCoinObjectPoolCount;//3
    public int destroyGroupCoinParticleObjectPoolCount;//4
    public int destroyKeyParticleObjectPoolCount;//5
    public int destroyWeaponCollectParticleObjectPoolCount;//6


    //EnemyBullet = 0
    [Header("Enemy Object Pool IDs")]
    public int enemyBulletParticleObjectPoolID;//0
    public int enemyMidParticleObjectPoolID;//1
    public int enemyPrefabObjectPoolID;//2
    public int bossEnemyPrefabObjectPoolID;//3
    public int chestMonsterEnemyPrefabObjectPoolID;//4
    public int tazoEnemyPrefabObjectPoolID;//5
    public int chestMonster2EnemyPrefabObjectPoolID;//6
    


    [Header("Current Language")]
    public static Languages currentLanguage;


    [Header("Get Current Killing Enemy For Increase Health")]
    public static bool getCurrentEnemyDead;
    

    [Header("Message Text")]
    public static TextMeshProUGUI currentMessageText;
    public static GameObject currentMessageObject;


    public const string pickBulletObjectMessage = "Bullet Pack!!";
    public const string pickBulletObjectMessageTr = "Mermi Paketi!!";
    public const string pickHealthObjectMessage = "Healthy!!";
    public const string pickHealthObjectMessageTr = "Sağlık!!";
    public const string pickWeaponObjectMessage = "Picked a Weapon!!";
    public const string pickWeaponObjectMessageTr = "Silah Aldın!!";
    public const string alreadyHaveThisMessage = "You Already Have Enough This!!";
    public const string alreadyHaveThisWeaponMessage = "You Already Have That Weapon!!";
    public const string alreadyHaveThisWeaponMessageTr = "Zaten Bu Silaha Sahipsin!!";
    public const string alreadyHaveThisMessageTr = "Yeterince Mermin Var!!";
    public const string poisonMessage = "Poison!!!";
    public const string poisonMessageTr = "Zehir!!!";
    public const string pickedKeyMessage = "Picked A Key!!!";
    public const string pickedKeyMessageTr = "Anahtar Topladın!!!";
    public const string emptyMessage = "";

    [Header("Enemy Names")]
    public const string chibi = "Chibi(Clone)";
    public const string mino = "Mino(Clone)";
    public const string bigMonster = "BigMonster(Clone)";
    public const string orc = "Orc(Clone)";
    public const string beholder = "Beholder(Clone)";
    public const string femaleZombie = "FemaleZombi(Clone)";
    public const string doctor = "Doctor(Clone)";
    public const string giant = "Giant(Clone)";
    public const string bone = "Bone(Clone)";
    public const string clothyBone = "ClothyBone(Clone)";
    public const string chestMonster = "ChestMonster(Clone)";
    public const string chestMonster2 = "ChestMonster2(Clone)";
    public const string tazo = "Tazo(Clone)";

    [Header("Health State")]
    public static bool isDecreaseHealth;
    public static TextMeshProUGUI damageHealthText;
    public static int decreaseCounter;

    [Header("Character Locking Modes")]
    public static string resetLocks = "locked";
    public static string locked = "locked";
    public static string unLocked = "";

    [Header("Prefab Game Objects For Player")]
    public GameObject[] objects;

    [Header("Sensivity")]
    public static float sensivityX;
    public static float sensivityY;

    [Header("Finish Check")]
    public static bool isTouchFinish;
    public static bool isLose;

    [Header("Speed")]
    public static float rotateSpeed;


    public static Dictionary<int, GameObject> characterInfos;   


    [Header("Animation Bools")]
    public static bool isGround;
    public static bool isWalking;
    public static bool isSideWalking;
    public static bool isBackWalking;
    public static bool isIdling;
    public static bool isDying;
    public static bool isWinning;
    public static bool isRunning;
    public static bool isPicking;
    public static bool isPickRotateCoin;
    public static bool isSwordAnimate;
    public static bool isSword;

    [Header("CameraRotation Info")]
    public static bool isLookingUp;

    [Header("Death Check")]
    public static bool isDestroyed;

    [Header("Playable Check")]
    public static bool isPlayable;

    [Header("Input")]
    public static bool isFire;
    public static bool isFireWalkAnimation;
    public static bool isFireAnimation;
    public static bool isFireTime;
    public static bool isJumping;
    public static int jumpCount;
    public static int clickShiftCount;
    public static int bulletAmount;
    public static int bulletPackAmount;


    
    public enum Languages
    {
        Turkish,
        English
    }
}