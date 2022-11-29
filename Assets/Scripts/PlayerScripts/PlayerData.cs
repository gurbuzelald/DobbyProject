using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerData", menuName = "PlayerData")]
public class PlayerData : ScriptableObject
{
    [Header("Bools")]
    public float playerSpeed;
    public float rotateSpeed;
    public float jumpForce;
    public bool isGround;
    public bool isWalking;
    public bool isBackWalking;
    public bool isClimbing;
    public bool isBackClimbing;
    public bool isFiring;
    public bool isJumping;
    public bool isIdling;
    public bool isDying;
    public bool isPlayable;
    public bool isWinning;
    public bool isSkateBoarding;

    [Header("Sounds")]
    public AudioClip shootClip;
    public AudioClip getHitClip;
    public AudioClip jumpingClip;
    public AudioClip dyingClip;
    public AudioClip pickupCoinClip;
    public AudioClip trapClip;
    public AudioClip levelUpClip;
    public AudioClip jumpingSeaClip;
}