using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
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
    public bool isPicking;

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

    [Header("Dance")]
    public float danceTime = 5f;
    public GameObject jolleenObject;

    [Header("PlayerParticle")]
    public ParticleSystem skateboardParticle;
    public ParticleSystem touchParticle;
    public ParticleSystem birthParticle;
    public ParticleSystem deathParticle;
    public ParticleSystem firingParticle;

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
    public bool isDancing;
    public int idlingCount;
}