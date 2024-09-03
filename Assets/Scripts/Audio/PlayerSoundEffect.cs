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
        if (PlayerData.CharacterNames.Dobby == playerData.currentCharacterName)
        {
            currentAudioData = dobbyAudioData;
        }
        else if (PlayerData.CharacterNames.Glassy == playerData.currentCharacterName)
        {
            currentAudioData = glassyAudioData;
        }
        else if (PlayerData.CharacterNames.Joleen == playerData.currentCharacterName)
        {
            currentAudioData = joleenAudioData;
        }
        else if (PlayerData.CharacterNames.Guard == playerData.currentCharacterName)
        {
            currentAudioData = guardAudioData;
        }
        else if (PlayerData.CharacterNames.Lusth == playerData.currentCharacterName)
        {
            currentAudioData = lusthAudioData;
        }
        else if (PlayerData.CharacterNames.Eve == playerData.currentCharacterName)
        {
            currentAudioData = eveAudioData;
        }
        else if (PlayerData.CharacterNames.Michelle == playerData.currentCharacterName)
        {
            currentAudioData = michelleAudioData;
        }
        else if (PlayerData.CharacterNames.Boss == playerData.currentCharacterName)
        {
            currentAudioData = bossAudioData;
        }
        else if (PlayerData.CharacterNames.Aj == playerData.currentCharacterName)
        {
            currentAudioData = ajAudioData;
        }
        else if (PlayerData.CharacterNames.Mremireh == playerData.currentCharacterName)
        {
            currentAudioData = mremirehAudioData;
        }
        else if (PlayerData.CharacterNames.Ty == playerData.currentCharacterName)
        {
            currentAudioData = tyAudioData;
        }
        SFXStatement(soundEffectType, currentAudioData);
    }

    public void ShootSoundEffectStatement(ShootSoundEffectTypes shootSoundEffectType)
    {
        if (PlayerSoundEffect.ShootSoundEffectTypes.Ak47 == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.M4a4 == shootSoundEffectType)
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
        Ak47,
        M4a4,
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
