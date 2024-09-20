using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioMusicData", menuName = "AudioMusicData")]
public class AudioData : ScriptableObject
{
    [Header("Musics")]
    public AudioClip currentGameMusic;
    public AudioClip menuMusic;
    public AudioClip endMusic;    
    public AudioClip winMusic;

    [Header("Game Musics")]
    public AudioClip level1GameMusic;
    public AudioClip level2GameMusic;
    public AudioClip level3GameMusic;
    public AudioClip level4GameMusic;
    public AudioClip level5GameMusic;
    public AudioClip level6GameMusic;
    public AudioClip level7GameMusic;
    public AudioClip level8GameMusic;
    public AudioClip level9GameMusic;
    public AudioClip level10GameMusic;


    [Header("Sounds")]

    //Defaulth
    [Header("Player Clips")]
    //public AudioClip shootClip;
    public AudioClip nonShootClip;
    public AudioClip poisonClip;
    public AudioClip getEnemyHitClip;    
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

    public AudioClip currentBulletHitClip;
    public AudioClip currentSwordHitClip;

    [Header("BulletHits")]
    public AudioClip pistolHitClip;
    public AudioClip axeHitClip;
    public AudioClip bulldogHitClip;
    public AudioClip cowHitClip;
    public AudioClip crystalHitClip;
    public AudioClip demonHitClip;
    public AudioClip iceHitClip;
    public AudioClip electroHitClip;
    public AudioClip ak47HitClip;
    public AudioClip m4a4HitClip;

    [Header("Weapons")]
    public AudioClip Ak47Clip;
    public AudioClip M4a4Clip;
    public AudioClip BulldogClip;
    public AudioClip CowClip;
    public AudioClip CrystalClip;
    public AudioClip DemonClip;
    public AudioClip IceClip;
    public AudioClip ElectroClip;
    public AudioClip AxeClip;
    public AudioClip PistolClip;

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
    public AudioClip menuNotClickClip;

}
