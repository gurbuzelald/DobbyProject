using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Finishes")]
    public GameObject[] _healtCoinTransform;
    public GameObject _healtCoinObject;

    [Header("Mirror")]
    public string currentMirrorName;

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

    [Header("Speed")]
    public float playerSpeed;
    public float rotateSpeed;     

    [Header("Animation Bools")]
    public bool isGround;
    public bool isWalking;
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

    [Header("CameraRotation Info")]
    public bool isLookingUp;

    [Header("Death Check")]
    public bool isDestroyed;

    [Header("Playable Check")]
    public bool isPlayable;

    [Header("Input")]
    public float jumpForce;
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
}