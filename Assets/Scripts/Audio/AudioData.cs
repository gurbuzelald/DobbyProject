using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewAudioMusicData", menuName = "AudioMusicData")]
public class AudioData : ScriptableObject
{
    [Header("Musics")]
    public AudioClip menuMusic;
    public AudioClip endMusic;    
    public AudioClip winMusic;

    [Header("Game Musics")]
    public AudioClip currentGameMusic;
    public AudioClip[] levelsGameMusic;

    [Serializable]
    public struct PlayerCharacterClip
    {
        public AudioClip poison;
        public AudioClip getEnemyHit;
        public AudioClip jumping;
        public AudioClip dying;
    }
    public PlayerCharacterClip[] playerClip = new PlayerCharacterClip[11];


    public AudioClip nonShoot;
    public AudioClip pickUpCoin;
    public AudioClip pickUpBulletCoin;
    public AudioClip errorPickUpCoin;
    public AudioClip errorPickUpBulletCoin;
    public AudioClip destroyGiftBox;
    public AudioClip touchGiftBox;
    public AudioClip teleport;
    public AudioClip health;
    public AudioClip levelUp;


    public AudioClip currentBulletHitClip;
    public AudioClip currentSwordHitClip;

    [Serializable]
    public struct WeaponClip
    {
        public string name;
        public AudioClip weaponClip;
        public AudioClip weaponHitClip;
    }

    public WeaponClip[] weaponClip = new WeaponClip[10];

    [Header("Swords")]
    public AudioClip LowSwordClip;

    [Header("Menu Sounds")]
    public AudioClip menuClickClip;
    public AudioClip menuNotClickClip;

}
