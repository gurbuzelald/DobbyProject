using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffect : AbstractPlayerSFX<PlayerSoundEffect>
{
    public AudioData dobbyAudioData;
    public AudioData glassyAudioData;
    public AudioData joleenAudioData;
    public AudioData guardAudioData;
    public AudioData lusthAudioData;
    public AudioData eveAudioData;
    public AudioData michelleAudioData;
    public AudioData bossAudioData;
    public AudioData ajAudioData;
    public AudioData mremirehAudioData;
    public AudioData tyAudioData;

    public AudioData currentAudioData;


    public AudioData weaponAudioData;
    public AudioData swordAudioData;

    public PlayerData playerData;
    public BulletData bulletData;
    public void SoundEffectStatement(SoundEffectTypes soundEffectType)
    {//Add Tag, Add Data Name, Add Data, Add If.
        if (playerData.characterStruct[0].id == PlayerData.currentCharacterID)
        {
            currentAudioData = dobbyAudioData;
        }
        else if (playerData.characterStruct[1].id == PlayerData.currentCharacterID)
        {
            currentAudioData = glassyAudioData;
        }
        else if (playerData.characterStruct[2].id == PlayerData.currentCharacterID)
        {
            currentAudioData = guardAudioData;
        }
        else if (playerData.characterStruct[3].id == PlayerData.currentCharacterID)
        {
            currentAudioData = joleenAudioData;
        }
        else if (playerData.characterStruct[4].id == PlayerData.currentCharacterID)
        {
            currentAudioData = lusthAudioData;
        }
        else if (playerData.characterStruct[5].id == PlayerData.currentCharacterID)
        {
            currentAudioData = eveAudioData;
        }
        else if (playerData.characterStruct[6].id == PlayerData.currentCharacterID)
        {
            currentAudioData = michelleAudioData;
        }
        else if (playerData.characterStruct[7].id == PlayerData.currentCharacterID)
        {
            currentAudioData = bossAudioData;
        }
        else if (playerData.characterStruct[8].id == PlayerData.currentCharacterID)
        {
            currentAudioData = ajAudioData;
        }
        else if (playerData.characterStruct[9].id == PlayerData.currentCharacterID)
        {
            currentAudioData = mremirehAudioData;
        }
        else if (playerData.characterStruct[10].id == PlayerData.currentCharacterID)
        {
            currentAudioData = tyAudioData;
        }
        SFXStatement(soundEffectType, currentAudioData);
    }

    public void ShootSoundEffectStatement(ShootSoundEffectTypes shootSoundEffectType)
    {
        if (PlayerSoundEffect.ShootSoundEffectTypes.ShotGun == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Machine == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Bulldog == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Cow == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Crystal == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Demon == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Ice == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Electro == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Axe == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Pistol == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
    }

    public void SwordSoundEffectStatement(SwordSoundEffectTypes swordSoundEffectType)
    {
        if (PlayerSoundEffect.SwordSoundEffectTypes.LowSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordSoundEffectTypes.WarriorSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordSoundEffectTypes.Hummer == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordSoundEffectTypes.OrcSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordSoundEffectTypes.AxeSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordSoundEffectTypes.AxeKnight == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordSoundEffectTypes.BarbarianSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordSoundEffectTypes.DemonSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordSoundEffectTypes.MagicSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordSoundEffectTypes.LongHummer == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordSoundEffectTypes.Club == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
    }

    public enum ShootSoundEffectTypes
    {
        ShotGun,
        Machine,
        Bulldog,
        Cow,
        Crystal,
        Demon,
        Ice,
        Electro,
        Axe,
        Pistol
    }
    public enum SwordSoundEffectTypes
    {
        LowSword,
        WarriorSword,
        Hummer,
        OrcSword,
        AxeSword,
        AxeKnight,
        BarbarianSword,
        DemonSword,
        MagicSword,
        LongHummer,
        Club
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
