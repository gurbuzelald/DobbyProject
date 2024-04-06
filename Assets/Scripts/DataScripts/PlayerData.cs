using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Message Text")]
    public TextMeshProUGUI currentMessageText;
    public GameObject currentMessageObject;
    public const string pickBulletObjectMessage = "It's a Bullet Pack!!";
    public const string pickHealthObjectMessage = "Healthy!!";
    public const string pickWeaponObjectMessage = "Picked a Weapon!!";
    public const string alreadyHaveThisWeaponMessage = "You Already Have This!!";
    public const string emptyMessage = "";

    [Header("Background Maps")]
    public GameObject backgroundMap;

    [Header("Enemy Attack Damages")]
    public int currentEnemyAttackDamage;
    public int clownEnemyAttackDamage;
    public int monsterEnemyAttackDamage;
    public int prisonerEnemyAttackDamage;
    public int pedrosoEnemyAttackDamage;
    public int copEnemyAttackDamage;
    public int morakEnemyAttackDamage;
    public int ortizEnemyAttackDamage;
    public int skeletonEnemyAttackDamage;
    public int urielEnemyAttackDamage;
    public int goblinEnemyAttackDamage;

    [Header("Enemy Bullet Damages")]
    public int currentEnemyBulletDamage;
    public int clownEnemyBulletDamage;
    public int monsterEnemyBulletDamage;
    public int prisonerEnemyBulletDamage;
    public int pedrosoEnemyBulletDamage;
    public int copEnemyBulletDamage;
    public int morakEnemyBulletDamage;
    public int ortizEnemyBulletDamage;
    public int skeletonEnemyBulletDamage;
    public int urielEnemyBulletDamage;
    public int goblinEnemyBulletDamage;

    [Header("Enemy Collision Damages")]
    public int currentEnemyCollisionDamage;
    public int clownEnemyCollisionDamage;
    public int monsterEnemyCollisionDamage;
    public int prisonerEnemyCollisionDamage;    
    public int pedrosoEnemyCollisionDamage;
    public int copEnemyCollisionDamage;
    public int morakEnemyCollisionDamage;
    public int ortizEnemyCollisionDamage;
    public int skeletonEnemyCollisionDamage;
    public int urielEnemyCollisionDamage;
    public int goblinEnemyCollisionDamage;

    [Header("Player Durability")]
    public int dobbyDurability;
    public int glassyDurability;
    public int joleenDurability;
    public int guardDurability;
    public int lusthDurability;
    public int eveDurability;
    public int michelleDurability;
    public int bossDurability;
    public int ajDurability;
    public int mremirehDurability;
    public int tyDurability;


    [Header("Enemy Tag")]
    public string currentEnemyName;

    [Header("Enemy Names")]
    public const string clown = "Clown(Clone)";
    public const string monster = "Monster(Clone)";
    public const string prisoner = "PrisonerZombie(Clone)";
    public const string pedroso = "Pedroso(Clone)";
    public const string morak = "Morak(Clone)";
    public const string ortiz = "Ortiz(Clone)";
    public const string skeleton = "Skeleton(Clone)";
    public const string uriel = "Uriel(Clone)";
    public const string goblin = "Goblin(Clone)";
    public const string cop = "Cop(Clone)";


    [Header("Player Level Spawns")]
    public Transform playerSpawns;     

    [Header("Health State")]
    public bool isDecreaseHealth;
    public TextMeshProUGUI damageHealthText;
    public int decreaseCounter;

    [Header("ChooseCharacter")]
    public CharacterNames currentCharacterName;
    public GameObject characterObject;
    public GameObject dobby;
    public GameObject glassy;
    public GameObject joleen;
    public GameObject guard;
    public GameObject lusth;
    public GameObject eve;
    public GameObject michelle;
    public GameObject boss;
    public GameObject aj;
    public GameObject mremireh;
    public GameObject ty;

    [Header("Character Locking Modes")]
    public string dobbyLock = "locked";
    public string glassyLock = "locked";
    public string joleenLock = "locked";
    public string guardLock = "locked";
    public string lusthLock = "locked";
    public string eveLock = "locked";
    public string michelleLock = "locked";
    public string ajLock = "locked";
    public string bossLock = "locked";
    public string mremirehLock = "locked";
    public string tyLock = "locked";
    public string resetLocks = "locked";
    public string locked = "locked";
    public string unLocked = "";

    [Header("Prefab Game Objects For Player")]
    public GameObject[] objects;
    public GameObject[] slaveObjects;
    //public static int slaveCounter;
    public Transform spawns;

    [Header("Sensivity")]
    public float sensivityX = 250f;
    public float sensivityY = 80f;

    [Header("Finish Check")]
    public bool isTouchFinish;
    public bool isLose;

    [Header("Character Prices")]
    public int joleenPrice;
    public int dobbyPrice;
    public int glassyPrice;
    public int lusthPrice;
    public int guardPrice;
    public int michellePrice;
    public int evePrice;
    public int ajPrice;
    public int bossPrice;
    public int tyPrice;
    public int mremirehPrice;

    [Header("Speed")]

    public float playerSpeed;
    public float skateBoardSpeed;
    public float slideWalkSpeed;
    public float backWalkingSpeed;
    public float fireWalkSpeed;
    public float climbSpeed;
    public float lockedSpeed;
    public float rotateSpeed;

    [Header("Character Speeds")]
    public float dobbySpeed;
    public float michelleSpeed;
    public float glassySpeed;
    public float ajSpeed;
    public float eveSpeed;
    public float mremirehSpeed;
    public float lusthSpeed;
    public float joleenSpeed;
    public float bossSpeed;
    public float tySpeed;
    public float guardSpeed;
        

    [Header("Character Jump Forces")]
    public Dictionary<int, GameObject> characterStaffs;
    public float currentJumpForce;
    public float dobbyJumpForce;
    public float michelleJumpForce;
    public float glassyJumpForce;
    public float ajJumpForce;
    public float eveJumpForce;
    public float mremirehJumpForce;
    public float lusthJumpForce;
    public float joleenJumpForce;
    public float bossJumpForce;
    public float tyJumpForce;
    public float guardJumpForce;


    [Header("Avaliable Characters")]
    public string[] avaliableCharacters = new string[11];

    [Header("Animation Bools")]
    public bool isGround;
    public bool isWalking;
    public bool isSideWalking;
    public bool isLockedWalking;
    public bool isBackWalking;
    public bool isClimbing;
    public bool isBackClimbing;    
    public bool isIdling;
    public bool isDying;
    public bool isWinning;
    public bool isSkateBoarding;
    public bool isRunning;
    public bool isPicking;
    public bool isPickRotateCoin;
    public bool isSwordAnimate;

    [Header("CameraRotation Info")]
    public bool isLookingUp;

    [Header("Death Check")]
    public bool isDestroyed;

    [Header("Playable Check")]
    public bool isPlayable;

    [Header("Input")]
    public bool isFireNonWalk;
    public bool isFireWalk;
    public bool isFireTime;
    public bool isSwording;
    public bool isSwordTime;
    public bool isJumping;
    public bool isClickable;
    public int jumpCount;
    public int clickDoubleSpeedCount;
    public bool extraSpeed;
    public bool normalSpeed;
    public int clickTabCount;
    public int clickShiftCount;
    public int bulletAmount = 90;
    public int bulletPack = 90;
    public int bulletPackAmount = 2;
    public bool isTouchableSkate;

    [Header("Dance")]
    public float danceTime = 5f;
    public GameObject jolleenObject;

    [Header("Particle")]
    public ParticleSystem skateboardParticle;
    public ParticleSystem touchParticle;
    public ParticleSystem birthParticle;
    public ParticleSystem deathParticle;
    public ParticleSystem burningParticle;
    public ParticleSystem burningTouchParticle;
    public ParticleSystem destroyRotateCoinParticle;
    public ParticleSystem destroyHealthCoinParticle;
    public ParticleSystem destroyBulletCoinParticle;
    public ParticleSystem destroyMushroomCoinParticle;
    public ParticleSystem playerWalkingParticle;
    [Header("Particle Count Control")]
    public int particleCount;
    

    [Header("BulletManager Data")]
    //public GameObject[] _bulletObject;//If ObjectPool is not using in project, this'll use
    public float bulletSpeed = 5f;


    [Header("Clone Data")]
    public bool isCloneWalking;
    public bool isCloneDying;
    public bool isCloneDancing;
    public int idlingCount;

    [Header("Destination Touch Control")]
    public bool isTouchFirst;
    public bool isTouchSecond;
    public bool isTouchThird;

    public float cloneSpeed;

    [Header("Clone Transform")]
    public Transform[] cloneTransforms;
    public GameObject[] cloneObjects;
    
    public enum CharacterNames
    {
        Glassy,
        Dobby,
        Joleen,
        Lusth,
        Guard,
        Eve,
        Michelle,
        Boss,
        Aj, 
        Mremireh,
        Ty
    }
    
    public enum CharacterLocking
    {
        //Locked,
        //Unlocked
    }
}