using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Enemy Damages")]
    public int currentEnemyAttackDamage;
    public int monsterEnemyAttackDamage;
    public int prisonerEnemyAttackDamage;
    public int clownEnemyAttackDamage;

    public int currentEnemyTriggerDamage;
    public int monsterEnemyTriggerDamage;
    public int prisonerEnemyTriggerDamage;
    public int clownEnemyTriggerDamage;

    public int currentEnemyCollisionDamage;
    public int monsterEnemyCollisionDamage;
    public int prisonerEnemyCollisionDamage;
    public int clownEnemyCollisionDamage;

    [Header("Player Resistance")]
    public int dobbyResistance;
    public int glassyResistance;
    public int spartacusResistance;
    public int guardResistance;
    public int lusthResistance;
    public int eveResistance;
    public int michelleResistance;
    public int bossResistance;
    public int ajResistance;
    public int mremirehResistance;
    public int tyResistance;


    [Header("Enemy Tag")]
    public char enemyTag;

    [Header("Player Level Spawns")]
    public Transform playerSpawns;

    [Header("Level SkyBoxes")]
    public MapNames currentMapName;

    [Header("Current Level")]
    public Levels currentLevel;

    [Header("Level SkyBoxes")]
    public Material firstSkybox;
    public Material secondMapSkyBox;
    public Material thirdSkybox;
    public Material fourthSkybox;

    [Header("Health State")]
    public bool isDecreaseHealth;
    public TextMeshProUGUI damageHealthText;
    public int decreaseCounter;

    [Header("Enemy Spawn")]
    public int enemySpawnDelay;
    public int firstMapEnemySpawnDelay;
    public int secondMapEnemySpawnDelay;
    public int thirdMapEnemySpawnDelay;
    public int fourthMapEnemySpawnDelay;

    [Header("Coin Transforms")]
    public GameObject[] mapCoins;
    public GameObject[] _healtCoinTransform;
    public GameObject _healtCoinObject;

    [Header("Mirror")]
    public string currentMirrorName;
    public GameObject[] _firstMapMirrorCouples;
    public GameObject[] _secondMapMirrorCouples;
    public GameObject[] _thirdMapMirrorCouples;
    public GameObject[] _fourthMapMirrorCouples;

    [Header("Finishes")]
    public GameObject _finishAreas;

    [Header("MapCompleteBools")]
    public bool isCompleteFirstMap;
    public bool isCompleteSecondMap;
    public bool isCompleteThirdMap;
    public bool isCompleteFourthMap;

    [Header("MapFinishTargetBools")]
    public bool isFirstMapTarget;
    public bool isSecondMapTarget;
    public bool isThirdMapTarget;
    public bool isFourthMapTarget;
    public bool isLevelUp;


    [Header("ChooseCharacter")]
    public CharacterNames currentCharacterName;

    public GameObject characterObject;

    public GameObject dobby;
    public GameObject glassy;
    public GameObject spartacus;
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
    public string spartacusLock = "locked";
    public string guardLock = "locked";
    public string lusthLock = "locked";
    public string eveLock = "locked";
    public string michelleLock = "locked";
    public string ajLock = "locked";
    public string bossLock = "locked";
    public string mremirehLock = "locked";
    public string tyLock = "locked";
    public string resetLocks = "locked";



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

    public int spartacusPrice;
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

    [Header("Character Speed")]

    public float playerSpeed;
    public float skateBoardSpeed;
    public float slideWalkSpeed;
    public float backWalkingSpeed;
    public float fireWalkSpeed;
    public float climbSpeed;
    public float lockedSpeed;
    public float rotateSpeed;
    //Character Speeds
    public float dobbySpeed;
    public float michelleSpeed;
    public float glassySpeed;
    public float ajSpeed;
    public float eveSpeed;
    public float mremirehSpeed;
    public float lusthSpeed;
    public float spartacusSpeed;
    public float bossSpeed;
    public float tySpeed;
    public float guardSpeed;


    [Header("Character Jump Forces")]
    public Dictionary<int, GameObject> characterStaffs;
    public float dobbyJumpForce;
    public float michelleJumpForce;
    public float glassyJumpForce;
    public float ajJumpForce;
    public float eveJumpForce;
    public float mremirehJumpForce;
    public float lusthJumpForce;
    public float spartacusJumpForce;
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
    public float currentJumpForce;
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
    public GameObject _bulletObject;//If ObjectPool is not using in project, this'll use
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

    public Transform firstTarget;
    public Transform secondTarget;
    public Transform thirdTarget;
    public Transform finishTarget;
    public Transform currentTarget;


    public enum CharacterNames
    {
        Glassy,
        Dobby,
        Spartacus,
        Lusth,
        Guard,
        Eve,
        Michelle,
        Boss,
        Aj, 
        Mremireh,
        Ty
    }

    public enum MapNames
    {
        FirstMap,
        SecondMap,
        ThirdMap,
        FourthMap
    }
    public enum Levels
    {
        Level1,
        Level2,
        Level3,
        Level4
    }
    public string locked = "Locked";
    public string unLocked = "";
    public enum CharacterLocking
    {
        //Locked,
        //Unlocked
    }
}