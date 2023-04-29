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
    public void SFXStatement(PlayerSoundEffect.SoundEffectTypes soundEffect, AudioData audioData)
    {
        if (soundEffect == PlayerSoundEffect.SoundEffectTypes.NonShoot)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.nonShootClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Poison)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.poisonClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetEnemyHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.getEnemyHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.GetBulletHit)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.getBulletHitClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Jump)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.jumpingClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Death)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.dyingClip);
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
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.Teleport)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.teleportClip);
        }
        else if (soundEffect == PlayerSoundEffect.SoundEffectTypes.IncreasingHealth)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.healthClip);
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

    public void SwordSFX(PlayerSoundEffect.SwordSoundEffectTypes swordSoundEffectType, AudioData audioData)
    {
        if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.LowSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.LowSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.WarriorSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.WarriorSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.Hummer)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.HummerClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.OrcSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.OrcSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.AxeSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.AxeSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.AxeKnight)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.AxeKnightClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.BarbarianSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.BarbarianSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.DemonSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.DemonSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.MagicSword)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.MagicSwordClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.LongHummer)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.LongHummerClip);
        }
        else if (swordSoundEffectType == PlayerSoundEffect.SwordSoundEffectTypes.Club)
        {
            PlayerManager.GetInstance.audioSource.PlayOneShot(audioData.ClubClip);
        }
    }
}
