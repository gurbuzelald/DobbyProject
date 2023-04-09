using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEffect : AbstractPlayerSFX<PlayerSoundEffect>
{
    public AudioData dobbyAudioData;
    public AudioData glassyAudioData;
    public AudioData spartacusAudioData;
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
        else if (PlayerData.CharacterNames.Spartacus == playerData.currentCharacterName)
        {
            currentAudioData = spartacusAudioData;
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
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Rifle == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Bulldog == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Cowgun == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Crystalgun == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Demongun == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Icegun == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Negev == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
        else if (PlayerSoundEffect.ShootSoundEffectTypes.Axegun == shootSoundEffectType)
        {
            WeaponSFX(shootSoundEffectType, weaponAudioData);
        }
    }

    public void SwordSoundEffectStatement(SwordtSoundEffectTypes swordSoundEffectType)
    {
        if (PlayerSoundEffect.SwordtSoundEffectTypes.LowSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordtSoundEffectTypes.WarriorSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordtSoundEffectTypes.Hummer == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordtSoundEffectTypes.OrcSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordtSoundEffectTypes.AxeSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordtSoundEffectTypes.AxeKnight == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordtSoundEffectTypes.BarbarianSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordtSoundEffectTypes.DemonSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordtSoundEffectTypes.MagicSword == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordtSoundEffectTypes.LongHummer == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
        else if (PlayerSoundEffect.SwordtSoundEffectTypes.Club == swordSoundEffectType)
        {
            SwordSFX(swordSoundEffectType, swordAudioData);
        }
    }

    public enum ShootSoundEffectTypes
    {
        Ak47,
        Rifle,
        Bulldog,
        Cowgun,
        Crystalgun,
        Demongun,
        Icegun,
        Negev,
        Axegun
    }
    public enum SwordtSoundEffectTypes
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
        GetBulletHit,
        Poison,
        Jump,
        JumpToSea,
        Death,
        PickUpCoin,
        PickUpBulletCoin,
        ErrorPickUpBulletCoin,
        DamageGiftBox,
        LevelUp, 
        ShootOff,

            ////Dobby
            //DobbyShoot,
            //DobbyNonShoot,
            //DobbySword,
            //DobbyGetHit,
            //DobbyJump,
            //DobbyJumpToSea,
            //DobbyDeath,
            //DobbyPickUpCoin,
            //DobbyPickUpBulletCoin,
            //DobbyTrap,
            //DobbyLevelUp,
            //DobbyShootOff,

            ////Glassy
            //GlassyShoot,
            //GlassyNonShoot,
            //GlassySword,
            //GlassyGetHit,
            //GlassyJump,
            //GlassyJumpToSea,
            //GlassyDeath,
            //GlassyPickUpCoin,
            //GlassyPickUpBulletCoin,
            //GlassyTrap,
            //GlassyLevelUp,
            //GlassyShootOff,

            ////Spartacus
            //SpartacusShoot,
            //SpartacusNonShoot,
            //SpartacusSword,
            //SpartacusGetHit,
            //SpartacusJump,
            //SpartacusJumpToSea,
            //SpartacusDeath,
            //SpartacusPickUpCoin,
            //SpartacusPickUpBulletCoin,
            //SpartacusTrap,
            //SpartacusLevelUp,
            //SpartacusShootOff,

            ////Lusth
            //LusthShoot,
            //LusthNonShoot,
            //LusthSword,
            //LusthGetHit,
            //LusthJump,
            //LusthJumpToSea,
            //LusthDeath,
            //LusthPickUpCoin,
            //LusthPickUpBulletCoin,
            //LusthTrap,
            //LusthLevelUp,
            //LusthShootOff,

            ////Guard
            //GuardShoot,
            //GuardNonShoot,
            //GuardSword,
            //GuardGetHit,
            //GuardJump,
            //GuardJumpToSea,
            //GuardDeath,
            //GuardPickUpCoin,
            //GuardPickUpBulletCoin,
            //GuardTrap,
            //GuardLevelUp,
            //GuardShootOff,
    }
}
