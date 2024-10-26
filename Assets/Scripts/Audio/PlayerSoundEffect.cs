using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffect : AbstractPlayerSFX<PlayerSoundEffect>
{
    public AudioData characterAudioData;

    public PlayerData playerData;
    public BulletData bulletData;

    public LevelData levelData;

    public void SoundEffectStatement(SoundEffectTypes soundEffectType)
    {
        SFXStatement(soundEffectType, characterAudioData);
    }

    public void ShootSoundEffectStatement(string shootSoundEffectName)
    {
        WeaponSFX(shootSoundEffectName, characterAudioData);
    }

    public void SwordSoundEffectStatement(SwordSoundEffectTypes swordSoundEffectType)
    {
        SwordSFX(swordSoundEffectType, characterAudioData);
    }

    
    public enum SwordSoundEffectTypes
    {
        LowSword
    }
    public enum SoundEffectTypes
    {
        NonShoot,
        GetEnemyHit,
        Poison,
        Jump,
        JumpToSea,
        Death,
        PickUpCoin,
        PickUpBulletCoin,
        ErrorPickUpBulletCoin,
        DestroyGiftBox,
        TouchGiftBox,
        LevelUp, 
        ShootOff,
        Teleport,
        IncreasingHealth
    }
}
