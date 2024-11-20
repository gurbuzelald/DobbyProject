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
        public GameObject characterObject;
        public int durability;
        public int price;
        public int jumpForce;
        public float speed;
        public int id;
        public string name;
        public string lockState;
        public float swordDamageValue;
    }

    public CharacterStruct[] characterStruct = new CharacterStruct[11];

    public static int currentCharacterID;

    public static int currentCharacterDurability;

    public static bool currentBulletExplosionIsChanged;

    public static float currentJumpForce;

    public static float currentCharacterSpeed;


    [Header("Player Object")]
    public GameObject playerObject;
    public GameObject characterObject;

    [Header("Player Object Pool IDs")]
    public int playerWeaponBulletObjectPoolCount;//0
    public int playerSwordBulletObjectPoolCount;//1
    public int destroyCoinParticleObjectPoolCount;//2
    public int destroyBulletCoinParticleObjectPoolCount;//3
    public int destroyHealthCoinObjectPoolCount;//4
    public int destroyMushroomCoinObjectPoolCount;//5
    public int playerBulletsExplosionObjectPoolCount;//6
    public int playerSwordExplosionObjectPoolCount;//7
    public int playerBurningTouchParticleObjectPoolCount;//8
    public int playerTouchParticleObjectPoolCount;//9
    public int deathParticleObjectPoolCount;//10
    public int enemyDeathParticleOjectPoolID;//11


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
    public Languages currentLanguage;


    [Header("Get Current Killing Enemy For Increase Health")]
    public bool getCurrentEnemyDead;

    

    [Header("Message Text")]
    public TextMeshProUGUI currentMessageText;
    public GameObject currentMessageObject;
    public const string pickBulletObjectMessage = "Bullet Pack!!";
    public const string pickBulletObjectMessageTr = "Mermi Paketi!!";
    public const string pickHealthObjectMessage = "Healthy!!";
    public const string pickHealthObjectMessageTr = "Sağlık!!";
    public const string pickWeaponObjectMessage = "Picked a Weapon!!";
    public const string pickWeaponObjectMessageTr = "Silah Aldın!!";
    public const string alreadyHaveThisMessage = "You Already Have Enough This!!";
    public const string alreadyHaveThisWeaponMessage = "You Already Have This Weapon!!";
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
    public bool isDecreaseHealth;
    public TextMeshProUGUI damageHealthText;
    public int decreaseCounter;

    [Header("Character Locking Modes")]
    public string resetLocks = "locked";
    public string locked = "locked";
    public string unLocked = "";

    [Header("Prefab Game Objects For Player")]
    public GameObject[] objects;

    [Header("Sensivity")]
    public float sensivityX = 250f;
    public float sensivityY = 80f;

    [Header("Finish Check")]
    public bool isTouchFinish;
    public bool isLose;

    [Header("Speed")]
    public float rotateSpeed;


    public Dictionary<int, GameObject> characterInfos;
    


    [Header("Animation Bools")]
    public bool isGround;
    public bool isWalking;
    public bool isSideWalking;
    public bool isBackWalking;  
    public bool isIdling;
    public bool isDying;
    public bool isWinning;
    public bool isRunning;
    public bool isPicking;
    public bool isPickRotateCoin;
    public bool isSwordAnimate;
    public bool isSword;

    [Header("CameraRotation Info")]
    public bool isLookingUp;

    [Header("Death Check")]
    public bool isDestroyed;

    [Header("Playable Check")]
    public bool isPlayable;

    [Header("Input")]
    public bool isFire;
    public bool isFireWalkAnimation;
    public bool isFireAnimation;
    public bool isFireTime;
    public bool isJumping;
    public int jumpCount;
    public int clickShiftCount;
    public int bulletAmount;
    public int bulletPackAmount;

    [Header("Dance")]
    public float danceTime = 5f;
    public GameObject jolleenObject;

    [Header("Particle")]
    public ParticleSystem touchParticle;
    public ParticleSystem birthParticle;
    public ParticleSystem deathParticle;
    public ParticleSystem burningParticle;
    public ParticleSystem burningTouchParticle;
    public ParticleSystem destroyRotateCoinParticle;
    public ParticleSystem destroyHealthCoinParticle;
    public ParticleSystem destroyBulletCoinParticle;
    public ParticleSystem destroyMushroomCoinParticle;
    [Header("Particle Count Control")]
    public int particleCount;
    


    [Header("Destination Touch Control")]
    public bool isTouchFirst;
    public bool isTouchSecond;
    public bool isTouchThird;

    [Header("Bullet Explosions")]
    public GameObject[] weaponBulletExplosionParticles;


    public int GetCharacterID()
    {
        return currentCharacterID;
    }

    
    public enum Languages
    {
        Turkish,
        English
    }
}