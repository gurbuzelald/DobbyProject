using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{

    [Header("Sensivity")]
    public float sensivityX = 250f;
    public float sensivityY = 80f;

    [Header("FinishCheck")]
    public bool isTouchFinish;
    public bool isLose;

    [Header("Speed")]
    public float playerSpeed;
    public float rotateSpeed;

    [Header("Force")]
    public float jumpForce;   

    [Header("Animation Bools")]
    public bool isGround;
    public bool isWalking;
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
    public bool isFiring;
    public bool isJumping;
    public int jumpCount;
    public int clickTabCount;
    public int clickShiftCount;

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

    [Header("Sounds")]
    public AudioClip shootClip;
    public AudioClip getHitClip;
    public AudioClip jumpingClip;
    public AudioClip dyingClip;
    public AudioClip pickupCoinClip;
    public AudioClip trapClip;
    public AudioClip levelUpClip;
    public AudioClip jumpingSeaClip;

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
    public bool isTouchMain;

    public float cloneSpeed;
}