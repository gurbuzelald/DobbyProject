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
        else if (PlayerSoundEffect.SoundEffectTypes.DamageGiftBox == type)
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyGetBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyGetEnemyHitClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dobbyDamageGiftBoxClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyGetBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyDyingClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.glassyDamageGiftBoxClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusGetBulletHitClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.spartacusDamageGiftBoxClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardGetBulletHitClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.guardDamageGiftBoxClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthGetBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthGetEnemyHitClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthDamageGiftBoxClip);
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

    public void EveSFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthShootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.eveNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.evePoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.eveGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.eveGetBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.eveJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.eveDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.evePickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.evePickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.eveErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.eveDamageGiftBoxClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.eveLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.eveJumpingSeaClip);
        }
    }

    public void MichelleSFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthShootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michelleNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michellePoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michelleGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michelleGetBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michelleJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michelleDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michellePickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michellePickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michelleErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michelleDamageGiftBoxClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michelleLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.michelleJumpingSeaClip);
        }
    }
    public void BossSFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthShootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossPoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossGetBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossPickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossDamageGiftBoxClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.bossJumpingSeaClip);
        }
    }

    public void AjSFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthShootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajPoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajGetBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajPickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajDamageGiftBoxClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ajJumpingSeaClip);
        }
    }

    public void MremirehSFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        //if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Shoot)
        //{
        //    PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.lusthShootClip);
        //}
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehPoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehGetBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehPickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehDamageGiftBoxClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.mremirehJumpingSeaClip);
        }
    }


    public void TySFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyNonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyPoisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyGetEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyGetBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyJumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyDyingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyPickupCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.PickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.ErrorPickUpBulletCoin)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyErrorPickupBulletCoinClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyDamageGiftBoxClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.LevelUp)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyLevelUpClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.JumpToSea)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.tyJumpingSeaClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.DamageGiftBox)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.damageGiftBoxClip);
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
