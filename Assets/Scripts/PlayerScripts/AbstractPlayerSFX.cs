using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class AbstractPlayerSFX<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T _instance;

    public static T GetInstance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<T>();
                GameObject objectOfGame = new GameObject();
                objectOfGame.name = typeof(T).Name;
                _instance = objectOfGame.AddComponent<T>();
            }
            return _instance;
        }

    }

    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = this as T;

            DontDestroyOnLoad(gameObject);
        }
    }

    void SoundEffectTypeControl(PlayerSoundEffect.SoundEffectTypes type)
    {
        if (PlayerSoundEffect.SoundEffectTypes.NonShoot == type)
        {

        }
        else if (PlayerSoundEffect.SoundEffectTypes.Jump == type)
        {

        }
        else if (PlayerSoundEffect.SoundEffectTypes.JumpToSea == type)
        {

        }
        else if (PlayerSoundEffect.SoundEffectTypes.Death == type)
        {

        }
        else if (PlayerSoundEffect.SoundEffectTypes.PickUpCoin == type)
        {

        }
        else if (PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin == type)
        {

        }
        else if (PlayerSoundEffect.SoundEffectTypes.Trap == type)
        {

        }
        else if (PlayerSoundEffect.SoundEffectTypes.LevelUp == type)
        {

        }
        else if (PlayerSoundEffect.SoundEffectTypes.ShootOff == type)
        {

        }
    }

    public void DobbySFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyShootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyPoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyGetHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyGetHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyPickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Trap)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyTrapClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyJumpingSeaClip);
        }
    }
    public void GlassySFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyShootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyPoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyGetHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyGetHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyPickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Trap)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyTrapClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyJumpingSeaClip);
        }
    }
    public void SpartacusSFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusShootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusPoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusGetHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusPickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Trap)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusTrapClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusJumpingSeaClip);
        }
    }
    public void GuardSFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardShootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardPoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardGetHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardPickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Trap)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardTrapClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardJumpingSeaClip);
        }
    }
    public void LusthSFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthShootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthPoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthGetHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthGetHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthPickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Trap)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthTrapClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthJumpingSeaClip);
        }
    }


    public virtual void SFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.shootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.nonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.getHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.jumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.getHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.pickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.pickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.errorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Trap)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.trapClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.levelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.jumpingSeaClip);
        }
    }

    public void WeaponSFX(PlayerSoundEffect.ShootSoundEffectTypes shootSoundEffectType, AudioData audioData)
    {
        if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Ak47)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.Ak47Clip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Rifle)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.RifleClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Bulldog)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.BulldogClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Cowgun)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.CowgunClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Crystalgun)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.CrystalgunClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Demongun)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.DemongunClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Icegun)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.IcegunClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Negev)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.NegevClip);
        }
        else if (shootSoundEffectType == PlayerSoundEffect.ShootSoundEffectTypes.Axegun)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.AxegunClip);
        }
    }

    public void SwordSFX(PlayerSoundEffect.SwordtSoundEffectTypes swordSoundEffectType, AudioData audioData)
    {
        if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.LowSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.LowSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.WarriorSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.WarriorSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.Hummer)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.HummerClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.OrcSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.OrcSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.AxeSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.AxeSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.AxeKnight)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.AxeKnightClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.BarbarianSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.BarbarianSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.DemonSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.DemonSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.MagicSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.MagicSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.LongHummer)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.LongHummerClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordtSoundEffectTypes.Club)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ClubClip);
        }
    }
}
