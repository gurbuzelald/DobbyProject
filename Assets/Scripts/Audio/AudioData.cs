using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioMusicData", menuName = "AudioMusicData")]
public class AudioData : ScriptableObject
{
    public AudioClip gameMusic;
    public AudioClip menuMusic;
    public AudioClip endMusic;    
    public AudioClip winMusic;


    [Header("Sounds")]

    //Defaulth
    [Header("Player Clips")]
    //public AudioClip shootClip;
    public AudioClip nonShootClip;
    public AudioClip poisonClip;
    public AudioClip getEnemyHitClip;
    public AudioClip getBulletHitClip;
    public AudioClip jumpingClip;
    public AudioClip dyingClip;
    public AudioClip pickupCoinClip;
    public AudioClip pickupBulletCoinClip;
    public AudioClip errorPickupBulletCoinClip;
    public AudioClip destroyGiftBoxClip;
    public AudioClip touchGiftBoxClip;
    public AudioClip levelUpClip;
    public AudioClip jumpingSeaClip;
    public AudioClip teleportClip;
    public AudioClip healthClip;

    [Header("Weapons")]
    public AudioClip Ak47Clip;
    public AudioClip RifleClip;
    public AudioClip BulldogClip;
    public AudioClip CowgunClip;
    public AudioClip CrystalgunClip;
    public AudioClip DemongunClip;
    public AudioClip IcegunClip;
    public AudioClip NegevClip;
    public AudioClip AxegunClip;

    [Header("Swords")]
    public AudioClip LowSwordClip;
    public AudioClip WarriorSwordClip;
    public AudioClip HummerClip;
    public AudioClip OrcSwordClip;
    public AudioClip AxeSwordClip;
    public AudioClip AxeKnightClip;
    public AudioClip BarbarianSwordClip;
    public AudioClip DemonSwordClip;
    public AudioClip MagicSwordClip;
    public AudioClip LongHummerClip;
    public AudioClip ClubClip;

    [Header("Menu Sounds")]
    public AudioClip menuClickClip;

}
